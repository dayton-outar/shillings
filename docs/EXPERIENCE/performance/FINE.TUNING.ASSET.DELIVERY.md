# Fine-Tuning Asset Delivery

This chapter covers:

- Understanding compression basics, poor compression configuration, and Brotli
- Using caching to improve repeat-visit performance
- Exploring the benefits of CDN-hosted assets
- Verifying CDN resources with Subresource Integrity
- Using resource hints to preload, prefetch, preconnect, and prerender

Earlier chapters focused on optimizing page ingredients such as CSS, images, fonts, and JavaScript. This chapter focuses on delivery: compression, caching, CDNs, integrity checks, and browser hints that help assets arrive sooner or more safely.

## Compressing Assets

Server compression runs content through a compression algorithm before transferring it to the browser. The browser advertises supported algorithms in the `Accept-Encoding` request header. If the server sends compressed content, it identifies the algorithm with the `Content-Encoding` response header.

> [!figure]
> Figure 10.1 placeholder: browser requests compressed content and server replies with compressed `index.html`.
>
> The browser sends `Accept-Encoding: gzip, deflate`; the server responds with `Content-Encoding: gzip`.

### Following Compression Guidelines

Compression is not simply "compress everything." You need to consider file type and compression level.

Download the Weekly Timber example site:

```sh
git clone https://github.com/webopt/ch10-asset-delivery.git
cd ch10-asset-delivery
npm install
```

Do not start the server yet; the examples modify server code first.

#### Configuring Compression Levels

In `http.js`, the Node `compression` middleware starts as:

```js
app.use(compression());
```

You can set gzip compression from `0` to `9`, where `0` means no compression, `9` means maximum compression, and the default is `6`:

```js
app.use(compression({
    level: 7
}));
```

Start or restart the server after changes:

```sh
node http.js
```

In the source test, setting `level` to `0` makes `http://localhost:8080/index.html` about 393 KB. Setting it to `9` reduces it to about 299 KB. Moving from `0` to `1` already drops the page to about 307 KB.

> [!figure]
> Figure 10.2 placeholder: compression level effects on jQuery load time and TTFB.
>
> The biggest gain happens when compression is enabled. Higher levels gradually increase TTFB and hit diminishing returns around levels 5 or 6.

Higher compression levels require more CPU time. On a busy production server, this extra work can compound. The practical advice is to balance payload size against compression time; the default gzip level of `6` is often good enough.

Apache's `mod_deflate`, for example, uses `DeflateCompressionLevel` for the same kind of configuration.

#### Compressing The Right File Types

Text assets compress well. Already-compressed formats often do not. Avoid compressing most images, except SVGs, and avoid WOFF/WOFF2 fonts. TTF and EOT fonts can compress well, as discussed in chapter 7.

Listing 10.1 forces the Node `compression` module to compress every file type:

```js
app.use(compression({
    filter: function(request, response){
        return true;
    }
}));
```

> [!figure]
> Figure 10.3 placeholder: compression ratios for PNG, JPEG, and SVG across gzip levels.
>
> PNG and JPEG show little to no benefit because they are already compressed. SVG compresses well because it is text-based XML.

Compressing uncompressible files hurts performance. The server spends CPU time trying to compress them, delaying TTFB, and the browser still has to decode the response. If you are unsure whether a file type compresses well, test it.

### Using Brotli Compression

Brotli is a newer compression algorithm. gzip remains widely used, but Brotli can produce smaller files in supported browsers and servers.

More on Brotli:

```text
http://mng.bz/85Y1
```

#### Checking For Brotli Support

Brotli-capable browsers include `br` in the `Accept-Encoding` request header, but Brotli is used only over HTTPS.

> [!figure]
> Figure 10.4 placeholder: Chrome request header showing Brotli support with the `br` token.
>
> A server can choose Brotli when the browser advertises `br` in `Accept-Encoding`.

To skip to the Brotli branch:

```sh
git checkout -f brotli
```

#### Writing A Brotli-Enabled Web Server In Node

The earlier `compression` package does not support Brotli. The chapter uses `shrink-ray`, plus HTTPS:

```sh
npm i https shrink-ray
```

Create `brotli.js` in the project root.

Listing 10.2 creates a Brotli-capable Node server:

```js
var express = require("express"),
    https = require("https"),
    shrinkRay = require("shrink-ray"),
    fs = require("fs"),
    path = require("path"),
    app = express(),
    pubDir = "./htdocs";

app.use(shrinkRay({
    cache: function(request, response){
        return false;
    }
}));

app.use(express.static(path.join(__dirname, pubDir)));

https.createServer({
    key: fs.readFileSync("crt/localhost.key"),
    cert: fs.readFileSync("crt/localhost.crt")
}, app).listen(8443);
```

This server uses HTTPS, serves files from `htdocs`, and disables `shrink-ray`'s cache so compression performance can be measured. Keeping public site files in `htdocs` also avoids exposing the `crt` folder.

Run it with:

```sh
node brotli.js
```

Open:

```text
https://localhost:8443
```

Your browser may show a warning because the local certificate is not signed by a recognized authority. That is acceptable for this local test, but production servers need valid certificates.

> [!figure]
> Figure 10.5 placeholder: Chrome Network panel showing Brotli-encoded files.
>
> Brotli-compressed responses show `br` in the `Content-Encoding` column.

#### Comparing Brotli Performance To gzip

Brotli uses a `quality` value from `0` to `11`, similar to gzip's `level` from `0` to `9`.

Listing 10.3 configures the Brotli compression level:

```js
app.use(shrinkRay({
    cache: function(request, response){
        return false;
    },
    brotli: {
        quality: 11
    }
}));
```

> [!figure]
> Figure 10.6 placeholder: jQuery file size with gzip versus Brotli across compression levels.
>
> Brotli gives roughly 3% to 10% smaller output in the source test. gzip's smallest jQuery result is about 29.4 KB, while Brotli reaches about 26.5 KB.

> [!figure]
> Figure 10.7 placeholder: TTFB for gzip versus Brotli when compressing jQuery.
>
> Brotli and gzip are roughly similar until Brotli quality settings 10 and 11, where Brotli becomes slower. The source test favors Brotli quality 9.

Server support for Brotli was still emerging in the source context. Nginx has a Brotli module:

```text
https://github.com/google/ngx_brotli
```

Apache module:

```text
https://github.com/kjdev/apache-mod-brotli
```

If your server can cache compressed output, use that feature. Some modules, such as Apache `mod_deflate`, do not cache compressed content by default.

## Caching Assets

First visits matter, but many users are repeat visitors or navigate to additional pages. Good caching makes those later requests much cheaper.

### Understanding Caching

When a browser downloads an asset, it follows the server's cache policy to decide whether it can reuse that asset later. If the server does not define a policy, browser defaults apply.

> [!figure]
> Figure 10.8 placeholder: basic caching process.
>
> The browser requests `index.html`; the server checks whether it changed. If not, the server can return `304 Not Modified`; if it changed, it returns `200 OK` with a new copy.

> [!figure]
> Figure 10.9 placeholder: first uncached visit versus subsequent cached visit.
>
> In the source example, the cached visit transfers nearly 98% less data and loads much faster.

An unprimed cache is a first visit, where everything must be downloaded. A primed cache is a repeat visit, where assets already exist locally.

#### Using The `Cache-Control` Header's `max-age` Directive

The `max-age` directive defines cache lifetime in seconds:

```http
Cache-Control: max-age=3600
```

That value means the cached resource is fresh for one hour.

In the Node server, set a short test value:

```js
app.use(express.static(__dirname, {
    maxAge: "10s"
}));
```

After restarting the server and visiting `http://localhost:8080`, navigate to the page again without pressing Reload. The browser can use cached assets directly.

> [!figure]
> Figure 10.10 placeholder: jQuery retrieved from the local browser cache.
>
> When `max-age` has not expired and the user navigates normally, the browser can avoid a server request.

If the user reloads or `max-age` expires, the browser revalidates with the server. If the asset has not changed, the server returns `304 Not Modified`. If it has changed, the server returns a fresh copy.

> [!figure]
> Figure 10.11 placeholder: `max-age` and revalidation flow.
>
> Fresh cached assets are used locally. Expired assets are revalidated, then either refreshed or reused after a `304`.

Servers can validate freshness with an ETag checksum or last-modified time.

#### Controlling Asset Revalidation

Useful `Cache-Control` directives include:

- `no-cache`: store locally, but always revalidate before reuse.
- `no-store`: do not store the asset; download it every time.
- `stale-while-revalidate`: allow a stale cached asset during a grace period while the browser refreshes it in the background.

These directives reduce or remove caching performance benefits, so use them only when freshness requirements justify it.

#### `Cache-Control` And CDNs

A CDN is a proxy service in front of your site that can cache and distribute content from servers closer to users.

> [!figure]
> Figure 10.12 placeholder: CDN distributing content to geographically dispersed users.
>
> User requests can be fulfilled by CDN servers closer to them rather than by the origin server alone.

Use `public` with `max-age` to allow intermediaries such as CDNs to cache:

```http
Cache-Control: public, max-age=86400
```

`public` is usually implied when `Cache-Control` is present. Use `private` to prevent intermediary caching while still allowing the user's browser to cache according to `max-age`.

### Crafting An Optimal Caching Strategy

Start by categorizing assets according to how often they change.

Table 10.1: Asset types for the Weekly Timber website, their modification frequencies, and the `Cache-Control` header value that should be used.

| Asset type | Frequency of modification | `Cache-Control` header value |
| --- | --- | --- |
| HTML | Potentially frequently, but needs to be as fresh as possible | `private, no-cache, max-age=3600` |
| CSS and JavaScript | Potentially monthly | `public, max-age=2592000, stale-while-revalidate=86400` |
| Images | Almost never | `public, max-age=31536000, stale-while-revalidate=86400` |

HTML should be conservative: revalidate often and prevent CDN caching with `private`. CSS and JavaScript can be cached for 30 days when you have an invalidation strategy. Images and media can often be cached for a year.

#### Implementing The Caching Strategy

To skip ahead:

```sh
git checkout -f cache-control
```

Listing 10.4 sets `Cache-Control` headers by file type:

```js
var express = require("express"),
    compression = require("compression"),
    path = require("path"),
    mime = require("mime"),
    app = express(),
    pubDir = "./htdocs";

app.use(compression());
app.use(express.static(path.join(__dirname, pubDir), {
    setHeaders: function(res, path){
        var fileType = mime.lookup(path);

        switch(fileType){
            case "text/html":
                res.setHeader("Cache-Control",
                              "private, no-cache, max-age=" + (60 * 60));
                break;

            case "text/javascript":
            case "application/javascript":
            case "text/css":
                res.setHeader("Cache-Control",
                              "public, max-age=" + (60 * 60 * 24 * 30));
                break;

            case "image/png":
            case "image/jpeg":
            case "image/svg+xml":
                res.setHeader("Cache-Control",
                              "public, max-age=" + (60 * 60 * 24 * 365));
                break;
        }
    }
}));

app.listen(8080);
```

To test in Chrome:

1. Open a new tab and the Network panel. Select Disable Cache for the first load.
2. Navigate to `http://localhost:8080`.
3. After loading finishes, clear Disable Cache.
4. Navigate to the page again by focusing the address bar and pressing Enter, rather than using Reload.

> [!figure]
> Figure 10.13 placeholder: Weekly Timber cache policy effects in Chrome Network panel.
>
> HTML is revalidated and returns `304` if unchanged. Other assets are served from the browser cache without a server round trip.

### Invalidating Cached Assets

Caching creates a release problem: users may keep old CSS, JavaScript, images, or HTML after you deploy fixes. Your strategy should let you force updated URLs into the page.

#### Invalidating CSS And JavaScript Assets

Because HTML revalidates with the server, updating asset references in HTML can force updated CSS or JavaScript downloads.

For example:

```html
<link rel="stylesheet" href="css/styles.min.css?v=2" type="text/css">
```

Adding a query string changes the asset URL, so the browser treats it as a new resource.

Listing 10.5 automates cache invalidation in PHP with a content hash:

```php
<?php $cssVersion = md5_file("css/styles.min.css"); ?>
<link rel="stylesheet" href="css/styles.min.css?v=<?php echo($cssVersion); ?>"
      type="text/css">
```

If the file contents change, the MD5 hash changes. You could also use a file modification time such as `filemtime`, a build-system hash, or another versioning system.

#### Invalidating Images And Other Media Files

For media, the easiest path is often to point to a new file URL. In a CMS, uploading a new image usually creates or references a new file, making cache invalidation automatic from the browser's perspective.

## Using CDN Assets

CDNs can improve delivery by serving common assets from geographically distributed edge servers and by handling cache policy for hosted libraries.

### Using CDN-Hosted Assets

> [!figure]
> Figure 10.14 placeholder: CDN origin and edge servers.
>
> Assets are hosted on an origin server and distributed to edge servers closer to users.

The Weekly Timber site uses local jQuery:

```html
<script src="js/jquery.min.js"></script>
```

Replace it with the CDN-hosted jQuery 2.2.3:

```html
<script src="https://code.jquery.com/jquery-2.2.3.min.js"></script>
```

> [!figure]
> Figure 10.15 placeholder: jQuery load times and TTFB across CDNs versus shared hosting.
>
> In the source test, several CDNs outperform the low-cost shared host in both TTFB and total load time.

CDN-hosted popular assets may already be in a user's browser cache from another site.

Common public CDNs include:

- cdnjs: `https://cdnjs.com`
- jsDelivr: `http://jsdelivr.com`
- Google CDN: `https://developers.google.com/speed/libraries`
- ASP.NET CDN: `http://www.asp.net/ajax/cdn`

Use as few distinct CDN hosts as possible to avoid extra DNS lookups. If a library such as Modernizr or Bootstrap can be custom-built, a smaller self-hosted build may beat a full CDN-hosted build.

### What To Do If A CDN Fails

CDNs can fail, and some networks block specific hosts. A fallback script can load a local copy when a CDN asset is unavailable.

Listing 10.6 defines a reusable fallback loader:

```html
<script>
    function fallback(missingObj, fallbackUrl){
        if(typeof(missingObj) === "undefined"){
            var fallbackScript = document.createElement("script");
            fallbackScript.src = fallbackUrl;
            document.body.appendChild(fallbackScript);
        }
    }
</script>
<script src="https://code.jquery.com/jquery-2.2.3.min.js"></script>
<script>
    fallback(window.jQuery, "js/jquery.min.js");
</script>
```

> [!figure]
> Figure 10.16 placeholder: CDN asset failure and local fallback in Chrome Network panel.
>
> When the CDN request fails, the local fallback script is loaded.

The fallback works because script tags execute in order. The fallback check runs only after the CDN script has either loaded or failed.

For another library, test its global object:

```js
fallback(window.Modernizr, "js/modernizr.min.js");
```

### Verifying CDN Assets With Subresource Integrity

Subresource Integrity, or SRI, lets the browser verify that an external asset matches an expected checksum before using it.

> [!figure]
> Figure 10.17 placeholder: Subresource Integrity verification process.
>
> The browser requests a CDN asset, verifies its checksum, and discards it if the checksum does not match.

The `integrity` attribute identifies the hash algorithm and the expected checksum.

> [!figure]
> Figure 10.18 placeholder: `integrity` attribute format.
>
> The value starts with the hashing algorithm, such as `sha256`, followed by the checksum value.

Example:

```html
<script src="https://code.jquery.com/jquery-2.2.3.min.js"
        integrity="sha256-a23g1Nt4dtEYOj7bR+vTu7+T8VP13humZFBJNIYoEJo="
        crossorigin="anonymous">
</script>
```

The `crossorigin="anonymous"` attribute indicates that the CDN resource does not require credentials. Browsers that do not support SRI ignore the attributes and load the resource normally.

Generate checksums with an online tool:

```text
https://srihash.org
```

Or use OpenSSL:

```sh
openssl dgst -sha256 -binary yourfile.js | openssl base64 -A
```

Use modern hash algorithms such as SHA-256 or SHA-384. Avoid MD5 and SHA-1 for this purpose.

## Using Resource Hints

Resource hints are `<link>` tags or `Link` HTTP headers that tell the browser about work it may want to do early: connect to another host, fetch a resource, preload a critical asset, or prerender a page.

### Using The `preconnect` Resource Hint

`preconnect` tells the browser to connect to another domain before the resource is discovered naturally. It is useful for assets on other domains, such as CDN-hosted scripts.

HTML:

```html
<link rel="preconnect" href="https://code.jquery.com">
```

HTTP header:

```http
Link: <https://code.jquery.com>; rel=preconnect
```

Using an HTTP header is discovered earlier, but is more work to configure.

> [!figure]
> Figure 10.19 placeholder: jQuery load-time effects of `preconnect`.
>
> The source test compares no `preconnect`, HTML `preconnect`, and HTTP-header `preconnect` for HTTP and HTTPS.

`dns-prefetch` is similar but only resolves the host's IP address instead of opening a full connection:

```html
<link rel="dns-prefetch" href="https://code.jquery.com">
```

### Using The `prefetch` And `preload` Resource Hints

`prefetch` tells capable browsers to download a resource and store it in the browser cache. It can target current-page resources or likely next-page resources, but careless use can waste bandwidth.

HTML:

```html
<link rel="prefetch" href="https://code.jquery.com/jquery-2.2.3.min.js">
```

HTTP header:

```http
Link: <https://code.jquery.com/jquery-2.2.3.min.js>; rel=prefetch
```

> [!figure]
> Figure 10.20 placeholder: page load times with and without prefetching jQuery.
>
> In the source test, prefetching jQuery cuts the Weekly Timber home page load time by nearly 20%.

When testing `prefetch` in Chrome, clear the cache, re-enable caching, and test with an unprimed cache. If Disable Cache is selected, the prefetched asset may appear to download twice.

`preload` is similar to `prefetch`, but it more strongly requires the browser to fetch the resource. It has narrower support in the source context.

HTML:

```html
<link rel="preload" href="https://code.jquery.com/jquery-2.2.3.min.js"
      as="script">
```

HTTP header:

```http
Link: <https://code.jquery.com/jquery-2.2.3.min.js>; rel=preload; as=script
```

The optional `as` attribute describes the resource type, such as `script`, `style`, `font`, or `image`.

> [!figure]
> Figure 10.21 placeholder: Chrome Network panel showing jQuery loaded with `preload`.
>
> The first jQuery request comes from the preload hint; the later script reference is satisfied from cache with a 0-byte transfer.

If broad support matters most, choose `prefetch`. If support is acceptable and the resource should be requested more assertively, choose `preload`.

### Using The `prerender` Resource Hint

`prerender` targets an entire page rather than a single asset. The browser may download and render the target document before the user navigates to it.

Use it sparingly. A bad `prerender` choice can waste significant bandwidth, especially for mobile users.

HTML:

```html
<link rel="prerender" href="http://localhost:8080/contact-us.html">
```

HTTP header:

```http
Link: <http://localhost:8080/contact-us.html>; rel=prerender
```

Good candidates are rare: high-confidence next navigations, multi-page articles, promotion funnels, or intranet apps where bandwidth cost is less consequential. Browsers may ignore `prerender` when they judge it too expensive.
