# Looking To The Future With HTTP/2

This chapter covers:

- Learning the history of HTTP/1 and its problems
- Exploring the evolution of HTTP/2
- Understanding request multiplexing and header compression in HTTP/2
- Exploring how optimization practices differ between HTTP/1 and HTTP/2
- Speeding crucial asset delivery with Server Push
- Optimizing for HTTP/1 and HTTP/2 clients on the same server

HTTP/1 served the web for decades, but modern websites place stress on its design. HTTP/2 addresses long-standing protocol limits with request multiplexing, header compression, secure transport expectations, and Server Push.

## Understanding Why We Need HTTP/2

HTTP/2 exists because HTTP/1 is a legacy protocol being asked to deliver complex, media-heavy applications. To understand HTTP/2's value, start with HTTP/1's limits.

### Understanding The Problem With HTTP/1

HTTP began in 1991 as HTTP/0.9, a simple protocol built around `GET` requests for linked documents. HTTP/1.0 and HTTP/1.1 added capabilities such as `POST`, and HTTP/1 became the web's long-running workhorse.

> [!figure]
> Figure 11.1 placeholder: 1996 and 2016 versions of the Los Angeles Times website.
>
> The web evolved from simple documents to complex pages with many assets.

HTTP/1 has three major problems for modern performance: head-of-line blocking, uncompressed headers, and no required secure transport.

#### Head-Of-Line Blocking

HTTP/1 usually handles only a small number of concurrent requests per domain, commonly six. New requests wait until earlier requests in the batch complete.

> [!figure]
> Figure 11.2 placeholder: head-of-line blocking across nine requests.
>
> The first six requests download together, while the remaining requests wait for the slowest request in the first batch.

Front-end workarounds include bundling files and domain sharding. Bundling reduces requests but hurts caching when only one part of a bundle changes. Domain sharding spreads requests across hostnames, but it adds setup and operating complexity.

Persistent connections help by reusing one connection across batches. HTTP pipelining tried to address the problem more directly, but implementation challenges prevented broad success.

#### Uncompressed Headers

HTTP headers travel with every request and response. A cookie-heavy site can send lots of repeated header data.

> [!figure]
> Figure 11.3 placeholder: 128-byte session cookie repeated across 60 requests.
>
> A 128-byte session ID sent on 60 requests adds about 7.5 KB of extra request data.

Server compression does not solve this because gzip or Brotli compresses the response body, not HTTP/1 headers.

#### Nonsecure Websites

HTTP/1 does not require SSL. Security is optional, and optional security is often skipped. HTTP/2 support in major browsers effectively requires secure transport, which helps move the web toward encrypted connections.

### Solving Common HTTP/1 Problems Via HTTP/2

HTTP/2 grew from Google's SPDY protocol. SPDY addressed HTTP/1's limits, and HTTP/2 used it as a starting point.

#### No More Head-Of-Line Blocking

HTTP/2 uses one connection with many bidirectional streams. Its communication model is:

- Streams: bidirectional channels between browser and server.
- Messages: request or response units inside streams.
- Frames: typed pieces inside messages, such as `HEADERS`, `DATA`, and `PUSH_PROMISE`.

> [!figure]
> Figure 11.4 placeholder: anatomy of an HTTP/2 request.
>
> One connection contains multiple streams. Streams contain messages, and messages are delimited by frames.

Requests are much cheaper in HTTP/2, which changes the value of request-reduction techniques such as bundling and sprites.

#### Header Compression

HTTP/2 uses HPACK to compress and deduplicate headers. Repeated values such as `Cookie` and `User-Agent` can be indexed instead of resent in full.

> [!figure]
> Figure 11.5 placeholder: HPACK header compression.
>
> Repeated headers are stored in an indexed table, and later requests refer to table indexes instead of duplicating values.

The browser builds a compressed header table for requests, the server decodes it, and the server performs the same process for response headers. The page receives ordinary headers, but fewer bytes travel across the connection.

#### HTTPS Is Guaranteed

Browser HTTP/2 implementations expect secure connections. SSL setup has some overhead, but HTTP/2 uses one connection rather than many, and modern hardware makes SSL cost much less concerning.

More on SSL performance:

```text
https://istlsfastyet.com
```

Free certificates:

```text
https://letsencrypt.org
```

### Writing A Simple HTTP/2 Server In Node

The chapter uses the `spdy` npm package to write a local HTTP/2 server. Despite the package name, it supports HTTP/2.

Download the example:

```sh
git clone https://github.com/webopt/ch11-http2.git
cd ch11-http2
npm install
```

Create `http2.js` in the project root.

Listing 11.1 imports the modules needed for the HTTP/2 server:

```js
var fs = require("fs"),
    path = require("path"),
    http2 = require("spdy"),
    mime = require("mime"),
    pubDir = path.join(__dirname, "/htdocs");
```

Listing 11.2 sets up SSL certificates:

```js
var server = http2.createServer({
    key: fs.readFileSync(path.join(__dirname, "/crt/localhost.key")),
    cert: fs.readFileSync(path.join(__dirname, "/crt/localhost.crt"))
```

Listing 11.3 writes the HTTP/2 server behavior:

```js
}, function(request, response){
    var filename = path.join(pubDir, request.url),
        contentType = mime.lookup(filename);

    if((filename.indexOf(pubDir) === 0) &&
       fs.existsSync(filename) &&
       fs.statSync(filename).isFile()){
        response.writeHead(200, {
            "content-type": contentType,
            "cache-control": "max-age=3600"
        });

        var fileStream = fs.createReadStream(filename);
        fileStream.pipe(response);
        fileStream.on("finish", response.end);
    }
    else{
        response.writeHead(404);
        response.end();
    }
});

server.listen(8443);
```

Run the server:

```sh
node http2.js
```

Open:

```text
https://localhost:8443/index.html
```

The bundled certificate is unsigned, so your browser may show an SSL warning. That is fine for local testing, but production servers need valid signed certificates.

> [!figure]
> Figure 11.6 placeholder: Chrome Network panel showing assets transferred over HTTP/2.
>
> In Chrome's Network panel, the Protocol column shows HTTP/2 assets as `h2`; HTTP/1 assets show `http/1.1`.

### Observing The Benefits

HTTP/2 requests begin more in parallel than HTTP/1 requests.

> [!figure]
> Figure 11.7 placeholder: HTTP/1 versus HTTP/2 asset downloads.
>
> HTTP/1 downloads appear more serialized; HTTP/2 downloads begin more closely together.

You can compare by running the included HTTP/1 server:

```sh
node http1.js
```

Then visit:

```text
https://localhost:8080/index.html
```

Local throttling is not a perfect comparison because both servers run on the same machine. The source author tested remote versions:

```text
https://h1.jeremywagner.me
```

```text
https://h2.jeremywagner.me
```

> [!figure]
> Figure 11.8 placeholder: Weekly Timber page load times over HTTP/1 versus HTTP/2.
>
> Pages with more assets show larger HTTP/2 gains. The source test reports about 24% improvement on asset-heavy pages, 15% on `index.html`, 7% on `contact-us.html`, and no improvement on a very light page.

To inspect header compression, Chrome's old `chrome://net-internals#timeline` view can compare bytes sent.

> [!figure]
> Figure 11.9 placeholder: bytes sent during HTTP/2 versus HTTP/1 sessions.
>
> HTTP/2 sends fewer request bytes because HPACK compresses and deduplicates headers.

## Exploring How Optimization Techniques Change For HTTP/2

Two rules guide HTTP/2 optimization:

- Keep techniques that reduce asset size, such as minification, compression, and image optimization.
- Stop techniques whose main purpose is combining files to reduce request count.

HTTP/2 requests are cheaper, and combining files can reduce cache effectiveness.

### Asset Granularity And Caching Effectiveness

Concatenation combines files to reduce HTTP requests. In HTTP/1, this often improves first-load performance. In HTTP/2, it can hurt cache efficiency when a small part changes.

> [!figure]
> Figure 11.10 placeholder: one icon changes inside an image sprite.
>
> If one icon changes, the whole sprite must be invalidated and downloaded again.

With HTTP/2, you can keep assets more granular and preserve better caching behavior without paying the same request overhead.

### Identifying Performance Antipatterns For HTTP/2

#### Bundling CSS And JavaScript

Bundling CSS and JavaScript is useful for HTTP/1 request reduction, but HTTP/2 favors more granular assets. CSS can often be split by page template. JavaScript can be split according to shared functionality and page-specific behavior.

#### Image Sprites

Image sprites reduce HTTP/1 request counts but create the same cache-invalidation problem as other concatenated assets. For HTTP/2, keep images separate unless you have a specific measured reason to sprite them.

#### Asset Inlining

Asset inlining embeds CSS, JavaScript, SVG, or binary data into HTML or CSS. Data URIs encode binary assets as base64 strings.

> [!figure]
> Figure 11.11 placeholder: anatomy of a data URI.
>
> A data URI includes the `data:` scheme, content type, encoding name, and encoded data.

Example shape:

```html
<img src="data:image/png;base64,iVBORw0KGgoAAAANS...">
```

Data URI strings are often larger than the original file, sometimes by 33% or more. Inlined assets are cached only as part of the document that contains them, so shared inlined data is repeatedly downloaded.

Critical CSS inlining can still help HTTP/1 render speed, but HTTP/2 can use Server Push to gain similar benefits while keeping assets separately cacheable.

## Sending Assets Preemptively With Server Push

Server Push lets an HTTP/2 server send assets the browser has not explicitly requested yet. This can mimic the render-speed benefits of inlining without sacrificing cache granularity.

### Understanding Server Push And How It Works

When a user requests `index.html`, the server can respond with the HTML plus related assets such as `styles.min.css`.

> [!figure]
> Figure 11.12 placeholder: anatomy of a Server Push event.
>
> The server responds to an HTML request with a `PUSH_PROMISE` frame containing the pushed CSS response.

You are not limited to one pushed asset, but pushing too much can waste bandwidth.

### Using Server Push

#### How Server Push Is Typically Invoked

On servers such as Apache, Server Push can be invoked with a `Link` HTTP response header:

```http
Link: </css/styles.min.css>; rel=preload; as=style
```

This uses the same format as the `preload` resource hint header from chapter 10, but it is a server behavior. Adding an HTML `<link rel="preload">` tag does not itself trigger Server Push.

Content type hints for `as` are listed in the W3C spec:

```text
http://mng.bz/r84O
```

Listing 11.4 pushes content in Apache when a user requests an HTML file:

```apache
<Location /index.html>
    Header add Link "</ch11-http2/htdocs/css/styles.min.css>; rel=preload; as=style"
</Location>
```

#### Writing Server Push Behavior In Node

In the custom Node HTTP/2 server, you implement push behavior yourself.

Listing 11.5 writes a Server Push response in a Node HTTP/2 server:

```js
if((filename.indexOf(pubDir) === 0) &&
   fs.existsSync(filename) &&
   fs.statSync(filename).isFile()){
    if(filename.indexOf(".html") !== -1 && response.push){
        var pushAsset = "/css/styles.min.css",
            pushAssetFSPath = path.join(pubDir, pushAsset),
            pushAssetContentType = mime.lookup(pushAssetFSPath);

        response.push(pushAsset, {
            response:{
                "content-type": pushAssetContentType,
                "cache-control": "max-age=3600",
                "link": "<" + pushAsset + ">; rel=preload; as=style"
            }
        }, function(error, stream){
            if(error){
                return;
            }

            var pushStream = fs.createReadStream(pushAssetFSPath);
            pushStream.pipe(stream);
            pushStream.on("finish", stream.end);
        });
    }
}
```

> [!figure]
> Figure 11.13 placeholder: Chrome Network panel identifying a pushed asset.
>
> Chrome marks pushed assets with `Push` in the Initiator column.

Command-line inspection:

```text
https://nghttp2.org/documentation/nghttp.1.html
```

The `nghttp` client shows HTTP/2 frames, including `PUSH_PROMISE`, which is useful for confirming Server Push.

### Measuring Server Push Performance

The source compares an HTTP/2 site with Server Push enabled against one without it:

```text
https://serverpush.jeremywagner.me
```

```text
https://h2.jeremywagner.me
```

> [!figure]
> Figure 11.14 placeholder: Time to First Paint with and without Server Push.
>
> Pushing the CSS improves Time to First Paint by about 19% in the source test.

Guidelines:

- Push more than one asset only when it makes sense.
- Do not push assets a page does not need.
- Be careful pushing assets for likely future navigation because that can waste bandwidth.

Cache-aware Server Push reference:

```text
https://css-tricks.com/cache-aware-server-push/
```

## Optimizing For Both HTTP/1 And HTTP/2

Some users may still use browsers that cannot speak HTTP/2. This section demonstrates a proof of concept for serving assets differently to HTTP/1 and HTTP/2 clients.

### How HTTP/2 Servers Deal With HTTP/2-Incapable Browsers

HTTP/2 servers can downgrade to HTTP/1 when the browser does not support HTTP/2.

> [!figure]
> Figure 11.15 placeholder: HTTP/2 negotiation and downgrade flow.
>
> If the browser supports HTTP/2, the connection remains HTTP/2. If not, the server downgrades to HTTP/1.

This makes it possible to serve granular assets to HTTP/2 clients and concatenated assets to HTTP/1 clients.

### Segmenting Your Users

Use browser support data plus analytics before deciding whether two optimization paths are worth the effort.

> [!figure]
> Figure 11.16 placeholder: Can I Use showing HTTP/2 support by browser.
>
> Can I Use shows full, partial, and missing HTTP/2 support across browser versions.

Can I Use can import Google Analytics data.

> [!figure]
> Figure 11.17 placeholder: Can I Use Google Analytics import controls.
>
> Site analytics can be imported to see feature support for your actual audience.

> [!figure]
> Figure 11.18 placeholder: Can I Use support formula after analytics import.
>
> Support, partial support, and total support are calculated against imported site visitor data.

In the source example, roughly 18% of Weekly Timber visitors use browsers that do not support HTTP/2, making dual optimization reasonable.

### Serving Assets According To Browser Capability

Install `jsdom`, switch to the protocol-detection branch, or skip to the completed version:

```sh
npm i jsdom
git checkout -f protocol-detection
```

```sh
git checkout -f protocol-detection-complete
```

#### Detecting The Protocol Version

The `spdy` package exposes `request.isSpdy`, which indicates whether the current connection is using HTTP/2.

Listing 11.6 detects the HTTP version:

```js
var filename = path.join(pubDir, request.url),
    contentType = mime.lookup(filename),
    protocolVersion = request.isSpdy ? "http2" : "http1";
```

#### Adding The HTTP/1 Class

The server can add a class to `<html>` for HTTP/1 clients. The CSS is HTTP/2-first by default, and the `http1` class can trigger request-reducing fallbacks such as sprites.

Listing 11.7 adds a class to `<html>` when the HTTP version downgrades:

```js
if(protocolVersion === "http1" && filename.indexOf(".html") !== -1){
    fs.readFile(filename, function(error, data){
        jsdom.env(data.toString(), function(error, window){
            window.document.documentElement.classList.add(protocolVersion);
            var newDocument = "<!doctype html>" +
                              window.document.documentElement.outerHTML;
            response.end(newDocument);
        });
    });
}
```

Listing 11.8 isolates other requests that do not require modification:

```js
else{
    var fileStream = fs.createReadStream(filename);
    fileStream.pipe(response);
    fileStream.on("finish", response.end);
}
```

> [!figure]
> Figure 11.19 placeholder: `<html>` tag modified with `http1` class.
>
> When the connection downgrades to HTTP/1, the server adds `class="http1"` to the root element.

The example stylesheet uses the `http1` class to serve an image sprite to HTTP/1 browsers. HTTP/2 browsers keep separate SVG requests.

#### Replacing Multiple Scripts With Concatenated Ones For HTTP/1 Users

The site references seven scripts, with jQuery hosted on a CDN and six local scripts that can be concatenated for HTTP/1 clients.

Listing 11.9 shows the scripts on the Weekly Timber site:

```html
<script src="https://code.jquery.com/jquery-2.2.4.min.js"
        integrity="sha256-BbhdlvQf/xTY9gja0Dq3HiwQF8LaCRTXxZKRutelT44="
        crossorigin="anonymous">
</script>
<script src="js/jquery.colorbox.min.js"></script>
<script src="js/colorbox-init.min.js"></script>
<script src="js/scooch.min.js"></script>
<script src="js/carousel.min.js"></script>
<script src="js/lazyload.min.js"></script>
<script src="js/collapsible-content.min.js"></script>
```

Listing 11.10 shows optimal script handling for HTTP/1:

```html
<script src="https://code.jquery.com/jquery-2.2.4.min.js"
        integrity="sha256-BbhdlvQf/xTY9gja0Dq3HiwQF8LaCRTXxZKRutelT44="
        crossorigin="anonymous">
</script>
<script src="js/scripts.min.js"></script>
```

Listing 11.11 transforms script delivery based on HTTP version:

```js
jsdom.env(data.toString(), function(error, window){
    window.document.documentElement.classList.add(protocolVersion);

    var scripts = window.document.querySelectorAll("script:not([crossorigin])"),
        jQueryScript = window.document.querySelector("script[crossorigin]"),
        concatenatedScript = window.document.createElement("script");

    concatenatedScript.src = "js/scripts.min.js";

    for(var i in scripts){
        scripts[i].remove();
    }

    jQueryScript.parentNode.insertBefore(concatenatedScript, jQueryScript.nextSibling);

    var newDocument = "<!doctype html>" +
                      window.document.documentElement.outerHTML;
    response.end(newDocument);
});
```

> [!figure]
> Figure 11.20 placeholder: scripts delivered in concatenated fashion for HTTP/1 browsers.
>
> HTTP/1 clients receive the CDN jQuery file plus one concatenated local script.

#### Considerations

Whether this is worth doing depends on site complexity and audience capability. Server-side implementation varies by platform.

Listing 11.12 serves assets by protocol in PHP:

```php
<script src="https://code.jquery.com/jquery-2.2.4.min.js"
        integrity="sha256-BbhdlvQf/xTY9gja0Dq3HiwQF8LaCRTXxZKRutelT44="
        crossorigin="anonymous">
</script>
<?php if($_SERVER["SERVER_PROTOCOL"] == "HTTP/1.1"){ ?>
    <script src="js/scripts.min.js"></script>
<?php }else{ ?>
    <script src="js/jquery.colorbox.min.js"></script>
    <script src="js/colorbox-init.min.js"></script>
    <script src="js/scooch.min.js"></script>
    <script src="js/carousel.min.js"></script>
    <script src="js/lazyload.min.js"></script>
    <script src="js/collapsible-content.min.js"></script>
<?php } ?>
```

The implementation changes by language, but the principle is the same: detect the protocol and serve the asset shape best suited to that protocol.
