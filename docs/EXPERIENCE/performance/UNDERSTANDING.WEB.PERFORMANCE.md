# Understanding Web Performance

Web performance is mostly about how quickly a website loads and becomes useful. Faster sites improve the user experience across connection types, make users more likely to stay, and help a site meet its goals, whether those goals are reading, conversion, revenue, or engagement. Slow sites test patience, and many users leave before the page has a chance to make its case.

For sites tied directly to revenue, performance has a visible business cost. E-commerce sites, ad-supported sites, and content portals all depend on people reaching and using the page. This chapter introduces the core ideas behind web performance, then applies basic optimization techniques to a small client website.

## Understanding Web Performance

Web performance work starts with the problem: modern websites ask browsers to download, parse, and render many files, often across networks with unpredictable latency. The aim is to understand where that time goes and reduce the amount of work required before users can see and use the page.

### Web Performance And The User Experience

High-performing websites improve the experience by delivering content faster. When the page responds quickly, users are more likely to stay long enough to care about the content.

Slow websites also measurably affect engagement. In e-commerce contexts, nearly half of users expect a site to load within 2 seconds, and 40% will leave if it takes more than 3 seconds. A 1-second delay in page response can reduce user action by about 7% (`https://blog.kissmetrics.com/loading-time`). That can mean lost traffic and lost revenue.

Performance can also affect search visibility. Google stated as early as 2010 that page speed is a ranking factor, even though relevance remains the primary factor. The chapter uses Legendary Tones, a guitar-focused blog with about 20,000 unique monthly visitors, as an example. Its Google Analytics data showed that rankings stayed stable until crawl times moved past about a second, at which point rankings slipped.

![Figure](/.attachments/1-1-performance-average.rankings.png)

_**Figure 1.1.** chart from the source PDF._
>
> The average rankings of all pages on the Legendary Tones website according to page download time by Google. Lower ranking values are better.

For content-driven sites, organic search is often the main source of traffic. Reducing load time is one practical part of improving that channel.

### How Web Browsers Talk To Web Servers

Web optimization begins with the browser-server conversation. A user asks for a page, waits for the server to respond, and then downloads the page into the browser.

![Figure](/.attachments/1-2-performance-user.request.png)

_**Figure 1.2.** request/response diagram from the source PDF._
>
> A user requests `example.com`, waits while the server prepares a response, and then downloads the web page into the browser.

A browser fetches pages using Hypertext Transfer Protocol, or `HTTP`. The browser sends an HTTP request, and the server sends an HTTP response containing a status code and the requested content.

A simple request for `example.com/index.html` includes:

```http
GET /index.html HTTP/1.1
Host: example.com
```

The request contains a method, or verb, such as `GET`; a resource, such as `/index.html`; and a protocol version, such as `HTTP/1.1`. If the resource exists, the server may respond with `200 OK` and send the contents of `index.html`.

Every request creates latency: time for the request to reach the server, time for the server to gather and send a response, and time for the browser to download that response. One request is usually trivial. Real pages, however, often require many requests, and latency compounds as request volume grows.

With `HTTP/1`, browsers can run into head-of-line blocking. Browsers limit the number of simultaneous requests to a host, often around six. If some requests finish while one slow request is still running, later requests wait until the first batch clears. That waiting increases page load time.

`HTTP/2` largely addresses head-of-line blocking and has broad browser support, but servers must implement it. In July 2016, about 8.5% of web servers used `HTTP/2` (`http://w3techs.com/technologies/details/ce-http2/all/all`). Because the web still needs to support both `HTTP/1` and `HTTP/2`, this book covers `HTTP/1` optimizations while calling out places where `HTTP/2` changes the best approach. Chapter 11 goes deeper into `HTTP/2`.

### How Web Pages Load

A minimal page like `example.com` might be just one HTML file. Most real websites are not that simple. They include images, CSS, JavaScript, fonts, and other assets.

After the browser downloads `index.html`, it discovers references such as:

- `<link>` tags for stylesheets
- `<script>` tags for JavaScript
- `<img>` tags for images

Each discovered asset can trigger another HTTP request. A page that starts as one request can quickly become five, fifty, or more. As requests and bytes increase, load time increases too.

The central performance challenge is balancing the needs of modern websites with the need to deliver content quickly. The rest of this chapter uses a client website to demonstrate that balance.

## Getting Up And Running

The chapter exercise uses a fictional client, Coyle Appliance Repair. The site is a small responsive website that needs a performance pass.

### Installing Node.js And Git

Two tools are needed:

- `Node.js`, to run the local development web server
- `Git`, to download the exercise source code

Install Node from `http://nodejs.org`. Use the standard installer so `npm`, the Node Package Manager, is installed too. `npm` gives access to packages from `http://npmjs.com`, including the packages used by the exercise server.

Install Git from `https://git-scm.com/downloads`. Prior Git experience is helpful but not required for the chapter exercises.

### Downloading And Running The Client's Website

Clone the exercise repository:

```sh
git clone https://github.com/malchata/ch1-coyle.git
cd ch1-coyle
```

The text also notes that the exercise can be downloaded as a ZIP from `https://github.com/webopt/ch1-coyle` if Git is unavailable.

Install the server dependency:

```sh
npm install express
```

This installs Express, which is used here only to serve static files locally.

> On macOS or other UNIX-like systems, permission errors from `npm` may require rerunning the command with `sudo`. On Windows, opening the command line as an administrator can help with similar permission issues.

Start the local server:

```sh
node http.js
```

The site should now be available at:

```text
http://localhost:8080
```

If another service is already using port `8080`, edit `http.js` and change the port number. Stop the server with `Ctrl-C`.

### Simulating A Network Connection

Because the site runs locally, requests to `localhost` have almost no real network latency. That makes performance gains hard to measure. Instead of deploying the site to a remote server, use Chrome Developer Tools to simulate a slower connection.

Open Chrome Developer Tools:

- Windows: press `F12`
- macOS: press `Command-Alt-I`
- Menu path: `View > Developer > Developer Tools`

Open the `Network` tab and use the throttling menu near the top of the panel. Select the `Regular 3G` profile to simulate a slower mobile network.

## Auditing The Client's Website

Optimization starts with measurement. For a first pass, look at:

- How many requests the page makes
- How much data the page transfers
- How long the page takes to load

In Chrome's `Network` tab, enable recording and select `Disable cache`. Disabling the cache simulates a first visit, where the user has none of the site's assets cached locally.

![Figure](/.attachments/1-7-performance-record.button.png)

_**Figure 1.7.** Chrome Network panel screenshot from the source PDF._
>
> The Record button must be enabled, and `Disable cache` should be selected before generating a waterfall chart.

With the local server running, visit or reload:

```text
http://localhost:8080
```

Chrome generates a waterfall chart showing each asset request, when it begins, and when it finishes.

![Figure](/.attachments/1-8-performance-waterfall.chart.png)

_**Figure 1.8.** waterfall chart screenshot from the source PDF._
>
> The chart shows requests for `index.html`, CSS, JavaScript, and images. Bar position shows request timing, and bar length shows how long each asset takes to request and download.

The client site makes 8 requests and transfers about 536 KB in the tested desktop high-DPI scenario. On the `Regular 3G` profile, that produces a load time of about 6.15 seconds.

The site is responsive, so different devices receive different layouts and sometimes different images. Device class and display density both affect page weight. High-DPI screens need higher-resolution images to preserve visual quality.

Table 1.1 shows the baseline measurements.

| Device type | Display density | Page weight | Load time |
| --- | --- | ---: | ---: |
| Mobile (phone and tablet) | Standard | 378 KB | 4.46 seconds |
| Mobile (phone and tablet) | High | 526 KB | 6.01 seconds |
| Desktop | Standard | 383 KB | 4.51 seconds |
| Desktop | High | 536 KB | 6.15 seconds |

## Optimizing The Client's Website

The main goal is to reduce transferred data. Fewer bytes almost always mean faster pages, and this helps users whether the server uses `HTTP/1` or `HTTP/2`.

Reducing request count can help too, especially on `HTTP/1`, but this site already has few requests. The chapter focuses first on minifying text assets, then optimizing images, then using server compression.

> [!note]
> To skip to the finished optimized exercise code, run `git checkout -f optimized` in the root folder of the web project. This overwrites local work, so back up changes first.

### Minifying Assets

Minification removes whitespace and unnecessary characters from text assets without changing how they work. CSS, JavaScript, and HTML often include indentation, line breaks, and comments for developer readability. Browsers do not need that formatting.

![Figure](/.attachments/1-9-performance-minification.png)

_**Figure 1.9.** CSS minification example from the source PDF._
>
> A CSS rule is reduced from 98 bytes to 77 bytes, a 21% reduction.

Keep original source files. Minified files are harder to edit, and future changes should be made against readable source files. Chapter 12 covers automating this workflow.

Install the minification tools:

```sh
npm install -g minifier html-minify
```

After minifying CSS, JavaScript, and HTML, the site's total weight drops by about 173 KB.

**Minifying the website's CSS**

The original CSS is 18.2 KB. From inside the site's `css` folder, minify it:

```sh
minify -o styles.min.css styles.css
```

The `-o` option sets the output file, `styles.min.css`. The input file is `styles.css`. The minified file is about 15.6 KB, a 14% reduction.

Update the stylesheet reference in `index.html`:

```html
<link rel="stylesheet" type="text/css" href="css/styles.min.css">
```

Reload the site and verify that styles still render and that the waterfall chart shows `styles.min.css`.

**Minifying the website's JavaScript**

The site has two JavaScript files:

- `jquery.js`, at 252.6 KB
- `behaviors.js`, at 3.1 KB

Minify both:

```sh
minify -o jquery.min.js jquery.js
minify -o behaviors.min.js behaviors.js
```

After minification:

- `behaviors.js` drops by 46% to 1.66 KB
- `jquery.js` drops by 66% to 84.4 KB

Update the script references in `index.html`:

```html
<script src="js/jquery.min.js"></script>
<script src="js/behaviors.min.js"></script>
```

Reload the page and confirm that the Network panel references the minified files.

**Minifying the website's HTML**

HTML can also be minified, but whitespace can affect layouts that depend on inline or `inline-block` behavior. Also watch for `white-space` in CSS and `<pre>` in HTML, since they treat whitespace more literally.

Before minifying, preserve the original file:

```text
index.src.html
```

Then minify the source HTML into `index.html`:

```sh
htmlminify -o index.html index.src.html
```

The minified HTML drops from 4.57 KB to 3.71 KB, a 19% reduction.

![Figure](/.attachments/1-10-performance-load.times.png)

_**Figure 1.10.** load-time comparison chart from the source PDF._
>
> Load times on the `Regular 3G` profile before and after minification. Improvements range from 31% to 41%, depending on device.

### Using Server Compression

Server compression works like file compression for web responses. The browser sends an `Accept-Encoding` header listing the compression formats it supports. If the server supports one of those formats, it responds with compressed content and a `Content-Encoding` header.

![Figure](/.attachments/1-11-performance-server.compression.png)

_**Figure 1.11.** server compression process diagram from the source PDF._
>
> A browser requests compressed content with `Accept-Encoding: gzip, deflate`; the server returns compressed content with `Content-Encoding: gzip`.

Text compresses well, and `gzip` has near-universal browser support. In this exercise, server compression reduces page weight by another 70 KB and improves load time by 18% to 32%, depending on device.

Stop the local server with `Ctrl-C`, then install the compression module:

```sh
npm install compression
```

Update `http.js` to use compression.

```js
var express = require("express");
var compression = require("compression");

var app = express();

// Run static server
app.use(compression());
app.use(express.static(__dirname));

app.listen(8080);
```

Listing 1.1 configures the Node HTTP server to import the compression module and hook it into the Express static server.

Restart the server and reload the page. Table 1.2 compares text assets before and after compression.

| Asset filename | Size before | Size after | Reduction |
| --- | ---: | ---: | ---: |
| `index.html` | 4 KB | 1.8 KB | 55% |
| `styles.min.css` | 15.9 KB | 3.1 KB | 80.5% |
| `jquery.min.js` | 84.7 KB | 30 KB | 64.5% |
| `behaviors.min.js` | 1.9 KB | 1.1 KB | 42.1% |
| Total | 106.5 KB | 36 KB | 66.2% |

![Figure](/.attachments/1-12-performance-load.times.after.compression.png)

_**Figure 1.12.** load-time comparison chart from the source PDF._
>
> Load times on the `Regular 3G` profile before and after applying compression. Improvements range from 18% to 32%, depending on device.

Different web servers configure compression differently. Apache can enable compression for common text asset types in `httpd.conf`:

```apache
<IfModule mod_deflate.c>
    AddOutputFilterByType DEFLATE text/html text/css text/javascript
</IfModule>
```

Listing 1.2 enables server compression on Apache web servers when `mod_deflate` is loaded.

For Microsoft Internet Information Services (`IIS`), compression can be configured through the `inetmgr` admin panel by opening the target website and editing compression settings in the GUI.

Avoid compressing formats that are already compressed during encoding, such as `JPEG`, `PNG`, `GIF`, `WOFF`, and `WOFF2`. Recompressing them can provide no savings and may even make the output larger.

### Optimizing Images

Modern image optimization can remove unnecessary image data while preserving visual quality. The goal is to compare the optimized image against the source and keep the result only if quality remains acceptable.

![Figure](/.attachments/1-13-performance-image.optimization.png)

_**Figure 1.13.** image optimization comparison from the source PDF._
>
> A PNG image is reduced from 30.87 KB to 11.69 KB with no noticeable visual difference.

The chapter uses TinyPNG (`http://tinypng.com`) for simplicity. Despite the name, TinyPNG can optimize both PNG and JPEG files.

![Figure](/.attachments/1-14-performance-tinypng.compressing.png)

_**Figure 1.14.** TinyPNG screenshot from the source PDF._
>
> TinyPNG compresses the client website images and reports a 61% total size reduction.

Upload the images from the site's `img` folder to TinyPNG, download the optimized versions, and copy them back into the `img` folder. Overwrite the originals when prompted. Then reload the site and inspect the Network panel.

Table 1.3 shows the image savings.

| Asset filename | Size before | Size after | Reduction |
| --- | ---: | ---: | ---: |
| `bg.png` | 56.6 KB | 32.0 KB | -43% |
| `bg@2x.jpg` | 147.4 KB | 29.4 KB | -80% |
| `brothers.jpg` | 11.9 KB | 9.7 KB | -18% |
| `brothers@2x.jpg` | 33.8 KB | 29.8 KB | -12% |
| `logo.png` | 31.6 KB | 12.0 KB | -62% |
| `logo@2x.png` | 70.5 KB | 25.2 KB | -64% |
| `states.png` | 4.9 KB | 1.8 KB | -63% |
| `states@2x.png` | 9.6 KB | 3.5 KB | -63% |

![Figure](/.attachments/1-15-performance-load.times.regular.3g.png)

_**Figure 1.15.** load-time comparison chart from the source PDF._
>
> Load times on the `Regular 3G` profile before and after image optimization. Improvements range from 23% to 53%, depending on device.

After image optimization, load times for all tested device scenarios are reduced to under 2 seconds on the simulated `Regular 3G` connection.

## Performing The Final Weigh-In

After minification, server compression, and image optimization, the transferred page weight drops dramatically across device types. Table 1.4 compares the final page weights.

| Device type | Page weight before | Page weight after | Reduction |
| --- | ---: | ---: | ---: |
| Mobile (high DPI) | 526 KB | 118 KB | 77.5% |
| Mobile | 378 KB | 87.4 KB | 76.8% |
| Desktop (high DPI) | 536 KB | 121 KB | 77.4% |
| Desktop | 383 KB | 89.5 KB | 76.6% |

![Figure](/.attachments/1-16-performance-load.times.throttling.png)

_**Figure 1.16.** load-time comparison chart from the source PDF._
>
> Load times on the `Regular 3G` profile before and after all optimizations. Load times improve by roughly 70% for all tested visitors and device types.

The final result is a client website that transfers roughly three-quarters less data and loads nearly 70% faster for users across the measured device scenarios. Even basic optimization techniques can produce large, measurable improvements in user experience.
