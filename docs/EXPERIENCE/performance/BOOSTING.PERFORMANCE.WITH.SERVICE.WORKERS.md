# Boosting Performance With Service Workers

This chapter covers:

- Understanding what service workers are and what they allow you to do
- Installing a service worker on a simple site
- Caching network requests inside a service worker
- Updating a service worker

Mobile connections are not always stable. Users move through weak cellular networks, tunnels, airplanes, and other places where connectivity is poor or absent. Service workers help by sitting between the page and the network, letting you cache assets, serve repeat visits faster, and provide useful offline behavior.

## What Are Service Workers?

Service workers are a kind of worker: scripts that run in a separate scope and on a separate thread from ordinary page JavaScript. They do not have direct access to the page's `window` object, though they can communicate indirectly with the page through APIs such as `postMessage`.

![Figure](/.attachments/)

_**Figure 9.1.** service worker operating on its own thread in Chrome Timeline._
>
> The service worker runs on a separate `ServiceWorker` thread rather than the page's main JavaScript thread.

Different workers solve different problems. Web workers can move CPU-heavy work off the UI thread. Service workers can intercept network requests and use the CacheStorage API to store and retrieve responses. CacheStorage is separate from the browser's normal HTTP cache.

The most important event in this chapter is `fetch`. A service worker can listen for `fetch` events, inspect requests, and decide whether to respond from CacheStorage, fetch from the network, or store a response for later.

![Figure](/.attachments/)

_**Figure 9.2.** service worker acting as a proxy between user and web server._
>
> The user requests assets, the service worker intercepts the request, and the service worker can retrieve from CacheStorage, pass through to the server, or store assets in the cache.

Service workers do not fix unavailable connectivity. They make the experience less broken by serving content the user has already cached, and they can make repeat visits faster by serving assets from a controlled cache.

## Writing Your First Service Worker

The example project is a static version of the author's blog. Download and run it:

```sh
git clone https://github.com/webopt/ch9-service-workers.git
cd ch9-service-workers
npm install
node http.js
```

The local site runs at:

```text
http://localhost:8080
```

> [!note]
> Service workers require HTTPS in production because they can intercept requests and run in the background. For development convenience, browsers allow service workers on `localhost` without HTTPS.

### Installing The Service Worker

Service worker installation starts with feature detection. If the browser supports service workers, register one. If it does not, do nothing and let the site continue normally.

![Figure](/.attachments/)

_**Figure 9.3.** service worker installation flow._
>
> The page checks whether the browser supports service workers. If yes, it registers the service worker. If no, the browser continues as usual.

The example references `sw-install.js` from the footer of each page.

### Registering The Service Worker

Listing 9.1 detects service worker support and registers `/sw.js`:

```js
if("serviceWorker" in navigator){
    navigator.serviceWorker.register("/sw.js");
}
```

The `in` operator checks whether `navigator.serviceWorker` exists. If it does, `register` installs the service worker.

> [!note]
> Service worker scope is based on where the service worker file lives. A worker at `/sw.js` can cover the whole site. A worker inside `/js/` would normally cover only that directory and its subdirectories. You can expand scope with the `Service-Worker-Allowed` HTTP response header.

### Writing The Service Worker's Install Event

When a service worker is first installed, the `install` event fires. The example uses this moment to cache global site assets such as CSS, JavaScript, and shared images.

![Figure](/.attachments/)

_**Figure 9.4.** service worker install event caching global assets._
>
> The service worker installs, the `install` event fires, and global assets are added to CacheStorage.

Listing 9.2 caches assets during the service worker's `install` event:

```js
var cacheVersion = "v1",
    cachedAssets = [
        "/css/global.css",
        "/js/debounce.js",
        "/js/nav.js",
        "/js/attach-nav.js",
        "/img/global/jeremy.svg",
        "/img/global/icon-github.svg",
        "/img/global/icon-email.svg",
        "/img/global/icon-twitter.svg",
        "/img/global/icon-linked-in.svg"
    ];

self.addEventListener("install", function(event){
    event.waitUntil(caches.open(cacheVersion).then(function(cache){
        return cache.addAll(cachedAssets);
    }).then(function(){
        return self.skipWaiting();
    }));
});

self.addEventListener("activate", function(event){
    return self.clients.claim();
});
```

The `cacheVersion` string names the cache. The `cachedAssets` array lists the assets to cache up front. During `install`, `caches.open(cacheVersion)` opens a CacheStorage cache and `cache.addAll(cachedAssets)` populates it. `skipWaiting()` moves the service worker to activation immediately, and `clients.claim()` lets it control pages right away.

After reloading, verify the service worker in Chrome Developer Tools under the Application tab.

![Figure](/.attachments/)

_**Figure 9.5.** Chrome Application tab showing active service workers._
>
> The Service Workers panel shows active workers, lets you stop or unregister them, and includes an Update on Reload option useful during development.

### Looking At The Service Worker Cache

In Chrome Developer Tools, expand Cache Storage in the Application tab and open the `v1` cache. The assets from `cachedAssets` should be present.

![Figure](/.attachments/)

_**Figure 9.6.** `v1` CacheStorage cache with global assets._
>
> The cache contains the global CSS, JavaScript, and image assets listed in the service worker.

To simulate offline behavior, use the Offline checkbox in the Network panel.

![Figure](/.attachments/)

_**Figure 9.7.** Offline checkbox in Chrome's Network panel._
>
> The Network panel can simulate being offline without disabling the machine's network connection.

At this point, reloading offline still fails because the HTML document itself has not been cached, and there is no `fetch` event behavior to intercept requests. The install event is best for global assets you know every page needs. The `fetch` event is where you handle assets on demand.

### Intercepting And Caching Network Requests

The service worker's `fetch` event can decide whether a request should be served from the service worker cache or fetched from the network and cached for later.

![Figure](/.attachments/)

_**Figure 9.8.** service worker `fetch` event behavior._
>
> The user requests an asset. If it is in CacheStorage, the service worker serves it. If not, it fetches the asset from the network and caches it.

You do not want to cache every possible asset during installation. Some assets are device-specific, such as high-density images, and should be cached only when the device actually requests them.

Listing 9.3 intercepts and caches additional assets in the `fetch` event:

```js
self.addEventListener("fetch", function(event){
    var allowedHosts =
        /(localhost|fonts\.googleapis\.com|fonts\.gstatic\.com)/i,
        deniedAssets = /(sw\.js|sw-install\.js)$/i;

    if(allowedHosts.test(event.request.url) === true &&
       deniedAssets.test(event.request.url) === false){
        event.respondWith(
            caches.match(event.request).then(function(cachedResponse){
                return cachedResponse ||
                    fetch(event.request).then(function(fetchedResponse){
                        caches.open(cacheVersion).then(function(cache){
                            cache.put(event.request, fetchedResponse.clone());
                        });

                        return fetchedResponse;
                    });
            })
        );
    }
});
```

The regular expressions allow requests from trusted hosts and deny service worker files that should not be cached by this logic. If a matching request already exists in CacheStorage, the cached response is returned. If it does not, the request is fetched from the network, cloned into the cache, and returned to the page.

Force a reload with `Ctrl-Shift-R` or `Cmd-Shift-R` after changing the service worker.

> [!note]
> If a service worker refuses to update during development, check the response caching policy for the worker file. The example uses `Cache-Control: no-cache`, which makes the browser revalidate the stored copy with the server.

Chrome's Network panel marks intercepted responses in the Size column.

![Figure](/.attachments/)

_**Figure 9.9.** network requests marked `(from ServiceWorker)`._
>
> Requests served by the service worker appear with `(from ServiceWorker)` in Chrome's Network panel.

After the `fetch` event is in place, turn on Offline mode and reload. The cached site can now render without a network connection.

### Measuring The Performance Benefits

Serving assets through the service worker cache can be faster than using the browser cache. In the source measurement, service worker caching improves Time to First Paint by about 50% compared with the browser cache on Chrome's `Regular 3G` throttling profile.

![Figure](/.attachments/)

_**Figure 9.10.** Time to First Paint across uncached, browser cache, and service worker cache scenarios._
>
> The service worker cache produces the lowest Time to First Paint in the source test.

The browser cache still matters. It remains the fallback for browsers that do not support service workers, and a service worker can allow selected requests to use the browser's default caching behavior.

### Tweaking Network Request Interception Behavior

The first `fetch` strategy has one problem: cached HTML can become stale. For content pages, HTML should usually be as fresh as possible so updated content and asset references appear immediately.

The chapter adopts a two-part strategy:

- For HTML, fetch from the network first and cache the response for offline use later.
- For non-HTML assets such as images, CSS, and JavaScript, serve from the service worker cache first and fetch from the network only when the asset is missing.

![Figure](/.attachments/)

_**Figure 9.11.** two-pronged service worker request strategy._
>
> HTML requests prefer the network and fall back to cache. Non-HTML requests prefer the cache and fall back to the network.

Listing 9.4 adds a regular expression to detect HTML requests:

```js
var allowedHosts = /(localhost|fonts\.googleapis\.com|fonts\.gstatic\.com)/i,
    deniedAssets = /(sw\.js|sw-install\.js)$/i,
    htmlDocument = /(\/|\.html)$/i;
```

Listing 9.5 handles HTML with a network-first/cache-for-offline pattern:

```js
if(allowedHosts.test(event.request.url) === true &&
   deniedAssets.test(event.request.url) === false){
    if(htmlDocument.test(event.request.url) === true){
        event.respondWith(
            fetch(event.request).then(function(response){
                caches.open(cacheVersion).then(function(cache){
                    cache.put(event.request, response.clone());
                });

                return response;
            }).catch(function(){
                return caches.match(event.request);
            })
        );
    }
    else{
        /* Handle non-HTML requests as before */
    }
}
```

This makes HTML updates visible immediately while still preserving offline fallback. It is slightly slower than serving HTML directly from CacheStorage. In the source test, the adjusted strategy averages about 120 ms Time to First Paint, compared with 90 ms for the original service worker behavior and about 175 ms for the browser cache.

You do not need to intercept every request. A request is intercepted only when the service worker passes a response to `event.respondWith`. If it does not, the browser handles the request normally.

> [!note]
> CDN-hosted assets can usually be cached with CacheStorage if the CDN sends `Access-Control-Allow-Origin: *`. If caching a CDN asset fails, check for that header.

## Updating Your Service Worker

The current worker caches CSS, JavaScript, and images aggressively, and always fetches HTML from the network first. If a cached CSS file changes, users need a way to receive the new version without forcing a reload.

### Versioning Your Files

Because HTML is fetched from the network, it can point to new versions of assets. A normal stylesheet reference looks like:

```html
<link rel="stylesheet" href="/css/global.css" type="text/css">
```

Add a query string to distinguish the updated asset:

```html
<link rel="stylesheet" href="/css/global.css?v=1" type="text/css">
```

The filename is the same, but the URL is different, so the browser and service worker cache treat it as a separate asset.

![Figure](/.attachments/)

_**Figure 9.12.** orphaned cache entry after updating a stylesheet URL._
>
> `global.css?v=1` appears in the cache, but the old `global.css` entry remains unless you remove it.

Leaving old entries behind can bloat the user's storage over time. Updating the cache name and cleaning old caches keeps CacheStorage lean.

### Cleaning Up Old Caches

First, bump `cacheVersion` from `v1` to `v2`, and update the cached stylesheet URL.

Listing 9.6 updates the cache name and assets to cache:

```js
var cacheVersion = "v2",
    cachedAssets = [
        "/css/global.css?v=1",
        "/js/debounce.js",
        "/js/nav.js",
        "/js/attach-nav.js",
        "/img/global/jeremy.svg",
        "/img/global/icon-github.svg",
        "/img/global/icon-email.svg",
        "/img/global/icon-twitter.svg",
        "/img/global/icon-linked-in.svg"
    ];
```

This creates the new cache, but it does not remove `v1`. Clean old caches in the `activate` event.

Listing 9.7 removes old caches:

```js
self.addEventListener("activate", function(event){
    var cacheWhitelist = ["v2"];

    event.waitUntil(
        caches.keys().then(function(keyList){
            return Promise.all(
                keyList.map(function(key){
                    if(cacheWhitelist.indexOf(key) === -1){
                        return caches.delete(key);
                    }
                })
            ).then(function(){
                return self.clients.claim();
            });
        })
    );
});
```

The worker gets all cache keys, deletes any cache name not present in `cacheWhitelist`, and then calls `clients.claim()` so the worker can control pages immediately.

![Figure](/.attachments/)

_**Figure 9.13.** new `v2` cache in Chrome Developer Tools._
>
> After activation cleanup, only the new `v2` cache remains, including the updated `global.css?v=1` entry.

Update every reference to the versioned asset across the site. If an old page still references `/css/global.css`, visiting it can add the old URL back to the cache.

### Going Further With Service Workers

The chapter points to additional resources for broader service worker patterns:

```text
https://jakearchibald.com/2014/offline-cookbook
```

```text
https://service-worke.rs
```

CacheStorage reference:

```text
http://mng.bz/NVXR
```

Service worker and page communication with `postMessage`:

```text
http://mng.bz/De31
```
