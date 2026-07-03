# Using Assessment Tools

## Evaluating With Google PageSpeed Insights

Google cares about web performance. Since 2010, it has treated performance as one factor in organic search ranking. If a content-driven site depends heavily on search traffic, performance deserves attention. Google PageSpeed Insights provides a starting point for that work.

### Appraising Website Performance

Google PageSpeed Insights (`https://developers.google.com/speed/pagespeed/insights/`) analyzes a website and recommends ways to improve performance and user experience. It runs its analysis twice:

- Once with a mobile user agent
- Once with a desktop user agent

It evaluates two broad timing concerns:

- How quickly above-the-fold content loads
- How quickly the entire page loads

![Figure](/.attachments/)

_**Figure 2.1.** above-the-fold versus below-the-fold diagram from the source PDF._
>
> Google PageSpeed Insights checks both the content visible immediately when the page loads and the full page load.

PageSpeed Insights scores each user-agent profile from `0` to `100`. It also color-codes recommendations:

- Green: passing performance characteristics
- Yellow: issues worth fixing when time allows
- Red: issues that should be fixed

![Figure](/.attachments/)

_**Figure 2.2.** Google PageSpeed Insights report screenshot from the source PDF._
>
> A user enters a URL and receives performance recommendations grouped by severity for mobile and desktop states.

To experiment, run PageSpeed Insights against the chapter 1 client website before and after optimization:

```text
http://jlwagner.net/webopt/ch01-exercise-pre-optimization
http://jlwagner.net/webopt/ch01-exercise-post-optimization
```

After clicking `Analyze`, the report takes about a minute to generate. It shows separate `Mobile` and `Desktop` tabs and a score for each.

![Figure](/.attachments/)

_**Figure 2.3.** before-and-after PageSpeed Insights screenshot from the source PDF._
>
> PageSpeed Insights results for the chapter 1 client website before and after optimization.

Many suggestions correspond to chapter 1 optimizations, such as minifying HTML, CSS, and JavaScript; enabling compression; and optimizing images.

One persistent issue can remain even after those optimizations: the `<link>` tag that loads CSS blocks rendering until the stylesheet is downloaded. One possible fix is inlining CSS inside `<style>` tags so CSS arrives with the HTML. Inlining can hurt caching and is often treated as an antipattern, but it reduces HTTP requests and can improve rendering speed on `HTTP/1`.

Chapter 4 covers critical CSS, which improves initial rendering while avoiding the bluntness of fully inlining all CSS. `HTTP/2` server push also changes this tradeoff, and later chapters cover that in more detail.

### Using Google Analytics For Bulk Reporting

Google Analytics can expose PageSpeed Insights data across many pages, which gives a broader view of site performance than testing a single URL at a time.

If Google Analytics is already installed, log in and follow the reports. If not, sign in at `www.google.com/analytics`, create the property, and paste the provided JavaScript tracking code into the site HTML. Analytics needs a day or two to gather data.

> [!note]
> Adding Google Analytics has legal implications because it involves accepting terms and collecting visitor data. If you do not own the site, get the site owner's consent.

In Google Analytics, open the `Behavior` section in the left menu and choose `Speed Suggestions`.

The dashboard includes a line graph of average page load times for the selected reporting period and a table with these columns:

- `Page`: the page URL
- `Pageviews`: the number of views in the reporting period
- `Avg. Page Load Time`: the average page load time in seconds
- `PageSpeed Suggestions`: the number of PageSpeed Insights recommendations for that URL
- `PageSpeed Score`: the score from PageSpeed Insights, from `1` to `100`

![Figure](/.attachments/)

_**Figure 2.5.** Google Analytics performance table screenshot from the source PDF._
>
> The reporting table includes PageSpeed Insights suggestion counts and scores for associated page URLs.

The `PageSpeed Suggestions` and `PageSpeed Score` columns cannot be sorted, but the other columns can. A practical workflow is to sort by pageviews descending and start fixing the highest-traffic pages.

## Using Browser-Based Assessment Tools

Every major desktop browser ships with developer tools. They share many concepts, though each browser differs in presentation and coverage. This chapter focuses on Chrome Developer Tools, while noting differences in Firefox, Safari, and Microsoft Edge.

On Windows, developer tools open with `F12`. On macOS, they open with `Cmd-Alt-I`.

Most equivalent tools work similarly across browsers. For example, in Firefox and Edge, request timing details can be found by opening Developer Tools, choosing the `Network` tab, and selecting an entry in the waterfall chart.

## Inspecting Network Requests

The chapter 1 audit used Chrome's network tools to generate a waterfall chart and measure page load time. Network tools can also inspect individual asset timing and HTTP headers.

### Viewing Timing Information

Every browser-server exchange contains latency. One important metric is Time to First Byte, or `TTFB`: the time from the user's request to the arrival of the first byte of the response. `TTFB` differs from total load time, which measures the time for the full asset to download.

![Figure](/.attachments/)

_**Figure 2.6.** browser request process diagram from the source PDF._
>
> A browser request incurs latency while the request travels to the server, the user waits for a response, and the page downloads. Time to First Byte measures the delay before the response begins arriving.

Long `TTFB` can come from network distance, poor server performance, or slow application back ends. The longer content takes to start downloading, the longer the user waits.

In Chrome:

1. Open the `Network` tab.
2. Reload the page to populate the waterfall chart.
3. Click an asset row.
4. Inspect the timing details.

![Figure](/.attachments/)

_**Figure 2.7.** Chrome request timing screenshot from the source PDF._
>
> Timing information for a site asset, including a `TTFB` value of `174.56 ms` in the example.

Before a request is made, Chrome may show steps such as queueing, DNS lookup, connection setup, and the SSL handshake.

> [!note]
> Browsers cache DNS lookups to avoid repeated lookup latency. In Chrome, the DNS cache can be inspected at `chrome://net-internals#dns`.

Safari requires a little setup if the `Develop` menu is not visible.

To enable Safari Developer Tools:

1. Open `Safari > Preferences`.
2. Go to the `Advanced` tab.
3. Select `Show Develop menu in menu bar`.
4. Open Developer Tools with `Cmd-Alt-I`.

In Safari, open the `Network` tab and visit:

```text
http://jlwagner.net/webopt/ch01-exercise-post-optimization
```

Safari's network view does not show the same waterfall graph as Chrome, but it does show timing columns such as `Latency`, `Start Time`, and `Duration`.

Safari's `Latency` value is not the same as `TTFB`. `TTFB` begins when the request is made and ends when the response starts arriving. Safari's latency includes earlier work such as DNS lookup and connection setup.

### Viewing HTTP Request And Response Headers

Browser developer tools can inspect HTTP headers sent with requests and responses. Headers include response codes, content types, host information, cookies, cache directives, compression information, and more.

A simplified request and response might look like this:

```http
GET /index.html HTTP/1.1
Host: jeremywagner.me
Accept: text/html
User-Agent: Mozilla/5.0

HTTP/1.1 200 OK
Content-Length: 47044
Content-Type: text/html
```

In Chrome's `Network` tab, click an asset row to open a details pane. The `Headers` tab shows request and response headers.

One performance-related header is `Content-Encoding`. It tells you whether the server compressed the resource and which algorithm it used.

Firefox exposes headers through a similar flow. Microsoft Edge also uses the Network tab, but requires clicking a small toggle button to reveal the details pane.

Safari also uses a small toggle in a similar relative position. The end result is the same: inspect headers when troubleshooting compression, caching, cookies, and other request/response behavior.

## Rendering Performance-Auditing Tools

Load time is only one part of performance. Pages also need to render smoothly after they load. Rendering performance covers initial page rendering and later interaction quality, such as animation smoothness and responsiveness to input.

### Understanding How Browsers Render Web Pages

When a user visits a page, the browser interprets HTML and CSS and renders pixels to the screen.

![Figure](/.attachments/)

_**Figure 2.15.** page-rendering process diagram from the source PDF._
>
> The page-rendering process: parse HTML into the DOM, parse CSS into the CSSOM, lay out elements, and paint the page.

The rendering process has four broad steps:

1. Parse HTML to create the Document Object Model (`DOM`): the browser downloads HTML and builds a hierarchical representation of the document.
2. Parse CSS to create the CSS Object Model (`CSSOM`): the browser builds a representation of the rules that apply to the document.
3. Lay out elements: the DOM and CSSOM are combined into a render tree, CSS rules are applied, and elements are positioned.
4. Paint the page: visual details are applied, output is rasterized into pixels, and the result is displayed.

Most rendering happens during the initial load, but user interaction can trigger later rendering work. Those later updates are often where smoothness problems become visible.

### Using Google Chrome's Timeline Tool

Chrome's Timeline tool records page activity across loading, scripting, rendering, and painting. It can look dense at first, but it is useful for identifying performance bottlenecks.

![Figure](/.attachments/)

_**Figure 2.16.** Chrome Timeline interface screenshot from the source PDF._
>
> Chrome's Timeline tool in a populated state, showing recording controls, FPS, activity overview, and flame chart detail view.

To profile the optimized chapter 1 site:

1. Open `http://jlwagner.net/webopt/ch01-exercise-post-optimization`.
2. Open Developer Tools.
3. Select the `Timeline` tab.
4. Reload with `Ctrl-R`, or `Cmd-R` on macOS, while Timeline is focused.
5. Stop recording with `Ctrl-E`, or `Cmd-E` on macOS.

Timeline events are grouped by color:

- Blue: loading, including network requests, HTML parsing, CSS parsing, and image decoding
- Yellow: scripting, including JavaScript, DOM activity, and garbage collection
- Purple: rendering, including CSS application and re-rendering caused by DOM or style changes
- Green: painting, including compositing and rasterization

Chrome may initially select a time range automatically. You can adjust the selected range with the mouse wheel or by dragging the edges in the activity overview. The flame chart and summary update to match the selected range.

Make sure the page being profiled is visible. Browsers reduce work for hidden tabs, so rendering and painting data can be misleading if the profiled tab is in the background.

The flame chart shows a hierarchical call stack of recorded page activity.

Clicking a layer in the flame chart updates the lower summary panel with details for that event.

### Identifying Problem Events: Thy Enemy Is Jank

The rendering goal is to minimize the time the browser spends loading and rendering, especially during interaction. The main enemy is jank: stuttering or uneven animation and interaction.

Jank happens when too much CPU work occurs in a single frame. A frame is the browser's unit of work for one display update. Loading, scripting, rendering, and painting can all contribute.

The target frame rate for typical displays is 60 frames per second (`FPS`). Since one second has 1000 milliseconds, a 60 FPS target gives about `16.66 ms` per frame. Because the browser has overhead too, Google recommends a tighter `10 ms` budget per frame.

> Jake Archibald's `Jank Invaders` game can help train your eye to notice jank: `http://jakearchibald.github.io/jank-invaders`.

To reproduce and inspect jank, clone the chapter 2 exercise:

```sh
git clone https://github.com/webopt/ch2-jank.git
cd ch2-jank
npm install
node http.js
```

Open:

```text
http://localhost:8080
```

Record a Timeline session and click the `Schedule Appointment` button to launch the scheduling modal. Stop recording after the modal slides into view.

Red frames indicate low frame rate. Selecting one shows a warning in the summary area.

![Figure](/.attachments/)

_**Figure 2.21.** janky frame summary screenshot from the source PDF._
>
> A janky frame summary shows a warning, low frames per second, and processing time.

The example frame averages only about `3 FPS`. To investigate, open the `Event Log` tab and filter the frame events.

Many `Timer Fired` events suggest activity caused by `setTimeout` or `setInterval`. In this exercise, the likely source is jQuery's `animate` function, which animates the appointment modal.

In `js/behaviors.js`, the modal animation looks like this:

```js
$(".modal").animate({
    "top": topPlacement
}, 500);
```

This timer-based animation can be replaced with CSS transitions, which are native to the browser and often better for simple linear animations.

> To skip to the finished CSS-transition version, run `git checkout -f css-transition`. Back up local work first because this overwrites changes.

In `styles.css`, find the desktop modal rule near line 557. Change:

```css
top: -150%;
```

to:

```css
transform: translateY(-150%);
```

Add a transition:

```css
transition: transform .5s;
```

Add a desktop open-state rule:

```css
div.modal.open{
    transform: translateY(10%);
}
```

Inside the mobile breakpoint near line 1040, add the mobile version:

```css
div.modal.open{
    transform: translateY(0);
}
```

This replaces `top` positioning with `transform: translateY(...)`. Transforms animate more efficiently and usually produce less jank.

Then replace the jQuery animation call in the `openModal` function:

```js
$(".modal").animate({
    "top": topPlacement
}, 500);
```

with:

```js
$(".modal").addClass("open");
```

In `closeModal`, replace:

```js
$(".modal").hide(0, function(){
    $(".modal").removeAttr("style");
});
```

with:

```js
$(".modal").removeClass("open");
```

Retest the modal, then record another Timeline session.

The CSS transition reduces jitter and saves CPU time. CSS transitions are not always enough for complex animation requirements, but they are a strong fit for simple linear transitions.

### Marking Points In The Timeline With JavaScript

Busy timelines can be hard to inspect. Chrome lets developers add timeline markers from JavaScript using `console.timeStamp()`. The method accepts a string label and can be called from the console or from application code.

In `js/behaviors.js`, find the click handler that opens the scheduling modal:

```js
$("#schedule").click(function(){
```

Inside that function, add:

```js
console.timeStamp("Modal open.");
```

While recording, this places a marker on the timeline when the modal opens.

Markers help narrow the search area when inspecting large recordings.

### Rendering Profilers In Other Browsers

Other browsers include similar rendering profilers. Usually, reload the page or press `Ctrl-E` on Windows or `Cmd-E` on macOS to start recording, then press the same shortcut to stop.

Firefox's profiler is under `Performance`, not `Timeline`. It shows frame rate, minimum/maximum/average frame rate, a flame chart, and a waterfall view.

Microsoft Edge's profiler is also under `Performance`. It includes a timeline overview, frame-rate graph, CPU utilization frames, event types, waterfall graph, and activity summary.

Chrome, Firefox, Edge, and Safari all support `console.timeStamp()` for marking timeline activity.

## Benchmarking JavaScript In Chrome

Benchmarking JavaScript helps compare different solutions and choose the faster one. Faster code can make pages render sooner and respond more quickly to user input.

Most browser consoles provide `console.time()` and `console.timeEnd()` for simple benchmarks. Both methods take the same string label. The label passed to `timeEnd()` must match the label passed to `time()`.

Open the chapter 2 jank exercise and run these command batches in Chrome's Console:

```js
console.time("jQuery"); jQuery("#schedule"); console.timeEnd("jQuery");
```

```js
console.time("querySelector"); document.querySelector("#schedule"); console.timeEnd("querySelector");
```

In the example, `document.querySelector()` is faster than jQuery's selector engine, which is expected because native methods often outperform user-defined abstractions.

Run benchmarks multiple times and average the results. A single run is not reliable enough for decision-making.

Console benchmarking is useful for small tests. For larger code paths, place `console.time()` and `console.timeEnd()` in the application JavaScript and read the results from the console when that code runs. These methods are available across the browsers covered in this chapter.

## Simulating And Monitoring Devices

Desktop testing is only the first pass. Responsive and mobile performance testing should include simulated device checks and, when possible, real devices.

### Simulating Devices In The Desktop Web Browser

Device simulation tools in desktop browsers approximate characteristics such as resolution and pixel density. In Chrome, use Device Mode.

To try it:

1. Open `www.manning.com`.
2. Open Developer Tools.
3. Press `Ctrl-Shift-M`, or `Cmd-Shift-M` on macOS.
4. Alternatively, click the mobile device icon beside the `Elements` tab.

![Figure](/.attachments/)

_**Figure 2.28.** Chrome Device Mode screenshot from the source PDF._
>
> Chrome Device Mode viewing the Manning Publications website, with device presets, viewport dimensions, scale, device pixel ratio, and menu controls.

Chrome Device Mode lets you choose preset devices, enter custom resolutions, adjust device pixel ratio, and debug high-density display issues.

Other browsers offer similar tools:

- Safari: `Responsive Design Mode`, opened from `Develop > Enter Responsive Design Mode` or `Alt-Cmd-R`
- Firefox: `Responsive Design Mode`
- Edge: device simulation focused on Microsoft mobile devices and Internet Explorer contexts

Simulation helps, but it does not replace testing on physical devices.

### Debugging Websites Remotely On Android Devices

Desktop machines usually have more CPU and memory than mobile devices. Remote debugging lets you inspect a real Android device using desktop Chrome.

To debug Android with Chrome:

1. Connect the Android device with USB.
2. Open Chrome on both desktop and mobile.
3. Enable developer options on Android by opening `Settings > About Device` and tapping the build number seven times.
4. Enable USB debugging in `Settings > Developer Options`.
5. On desktop Chrome, open `chrome://inspect#devices`.
6. Ensure `Discover USB Devices` is selected.
7. Accept the authorization prompt on the Android device.
8. Click `Inspect` under the device entry.

The desktop Developer Tools window opens for the page running on the Android device. The device screen is mirrored beside the tools.

Once connected, the same tools used for desktop profiling can be used against the Android device. Useful tests include load-time measurement on a real mobile connection and Timeline profiling on real mobile hardware.

### Debugging Websites Remotely On iOS Devices

iOS remote debugging uses Safari on both macOS and the iOS device.

To debug iOS:

1. Connect the iOS device to the Mac with USB.
2. Open Safari on both devices.
3. Open `www.manning.com` on the iOS device.
4. In Safari on the Mac, open the `Develop` menu.
5. Choose the iOS device name.
6. Click `Use for Development`.
7. On the iOS device, tap `Trust` when prompted.
8. Return to the Mac's `Develop` menu, choose the device, and select the page open in Mobile Safari.

Safari Developer Tools opens for the page running on the iOS device. The same desktop debugging and performance tools can then be used against the mobile page.

## Creating Custom Network Throttling Profiles

Chrome's network throttling tool can simulate connection types such as 3G and 4G. This is especially helpful for sites running locally, where normal requests have no network bottleneck.

Chrome is the only browser among the four covered here that includes this specific throttling feature. Built-in presets are usually sufficient, but custom profiles are useful for specific test scenarios.

Open the throttling menu and choose `Add`.

Chrome opens the `Network Throttling Profiles` settings screen. Click `Add Custom Profile`.

The profile fields are:

- `Profile Name`: the label shown in the throttling menu
- `Throughput`: the connection speed, entered for download and upload
- `Latency`: the connection latency in milliseconds

After the profile is saved, it appears in the throttling menu.

Select the custom profile and watch the `Network` tab while pages load to see how it affects load time and request timing.