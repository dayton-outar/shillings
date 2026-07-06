# Keeping JavaScript Lean And Fast

JavaScript libraries and frameworks can save time, but the fastest path for users is often a smaller one. This chapter focuses on practical ways to reduce JavaScript cost: load scripts without blocking rendering, replace large dependencies when possible, use browser-native APIs, and animate efficiently.

## Affecting Script-Loading Behavior

The `<script>` tag can delay rendering depending on where it appears and how it loads. Download and run the Coyle Appliance Repair example site:

```sh
git clone https://github.com/webopt/ch8-javascript.git
cd ch8-javascript
npm install
node http.js
```

### Placing The `<script>` Element Properly

Browsers parse HTML from top to bottom. When the parser finds a blocking script, it pauses to download and execute that script before continuing.

![Figure](/.attachments/8-1-performance-browsers.read.html.png)

_**Figure 8.1.** browser discovering script tags in document order._
>
> A script in the `<head>` is discovered early and blocks rendering sooner. A script near the end of `<body>` is discovered later.

On the example site, placing `jquery.min.js` and `behaviors.js` in the `<head>` produces an average Time to First Paint of roughly 830 ms on Chrome's `Regular 3G` throttling profile.

Moving the same scripts to the end of `index.html`, just before `</body>`, lowers the measured Time to First Paint to about 500 ms in the source test.

This is a broadly compatible optimization. Script size, script count, and HTML length all affect the exact results, but late script placement is usually an easy win.

### Working With Asynchronous Script Loading

Modern browsers support the `async` attribute on external scripts. An async script downloads without blocking rendering and executes as soon as it finishes downloading.

![Figure](/.attachments/8-4-performance-loading.scripts.png)

_**Figure 8.4.** Script loading with and without `async`._
>
> Without `async`, scripts wait for ordered execution. With `async`, a script executes as soon as it finishes downloading.

### Using `async`

Add `async` to external scripts:

```html
<script src="js/jquery.min.js" async></script>
<script src="js/behaviors.js" async></script>
```

This can improve Time to First Paint, but it can also break dependent scripts.

When scripts depend on one another, `async` can create a race condition. In this example, `behaviors.js` is smaller than `jquery.min.js`, so it finishes first and runs before jQuery exists.

![Figure](/.attachments/8-6-performance-race.condition.png)

_**Figure 8.6.** race condition between `jquery.min.js` and `behaviors.js`._
>
> The dependent script downloads and executes first, then fails because its dependency has not run.

One solution is to combine dependent scripts in dependency order:

```sh
cat jquery.min.js behaviors.js > scripts.js
```

On Windows:

```sh
type jquery.min.js behaviors.js > scripts.js
```

Then replace both script tags with one async bundle:

```html
<script src="js/scripts.js" async></script>
```

With scripts bundled and loaded asynchronously, the example beats bottom-of-document script placement by about 200 ms. The DOM also becomes available much earlier in the source test.

### Using `async` Reliably With Multiple Scripts

Bundling helps on `HTTP/1`, but `HTTP/2` often benefits from smaller, more granular assets because multiplexing reduces head-of-line blocking and improves caching. To load separate scripts asynchronously while respecting dependencies, the chapter uses Alameda, an AMD module loader.

Project:

```text
https://github.com/requirejs/alameda
```

Replace existing script tags with:

```html
<script src="js/alameda.min.js" data-main="js/behaviors" async></script>
```

The attributes do three jobs:

- `src` loads Alameda.
- `data-main` points to `behaviors.js`, without the `.js` extension.
- `async` prevents Alameda from blocking rendering while it downloads.

Listing 8.1 configures Alameda and defines `behaviors.js` as an AMD module:

```js
requirejs.config({
    paths:{
        jquery: "jquery.min"
    }
});

require(["jquery"], function($){
    /* behaviors.js contents truncated for brevity */
});
```

The configuration tells Alameda where jQuery lives. The module definition then declares jQuery as a dependency, and the dependent code runs only after jQuery is available.

> Alameda targets modern browsers and depends on features such as JavaScript promises. If you need wider support, RequireJS shares the same API and can be used instead. RequireJS is available at `http://requirejs.org`.

## Using Leaner jQuery-Compatible Alternatives

jQuery became popular because it made browser differences easier to handle. Many tasks that once required compatibility wrappers are now supported directly by browsers, and some jQuery-compatible libraries offer smaller downloads for projects that do not need all of jQuery.

### Comparing The Alternatives

`jQuery-compatible` does not mean every jQuery method is available. It means an alternative provides many familiar methods with similar syntax, usually trading functionality for smaller size and sometimes better performance.

### Exploring The Contenders

The chapter compares three jQuery-compatible libraries:

- Zepto: the most feature-rich alternative in this group, with a familiar API and plugin support. Project: `http://zeptojs.com`.
- Shoestring: a smaller Filament Group library with core DOM traversal and manipulation methods plus limited `$.ajax` support. Project: `https://github.com/filamentgroup/shoestring`.
- Sprint: the smallest and most minimal option, with strong performance but fewer features. Project: `https://github.com/bendc/sprint`.

### Comparing File Size

The main advantage is payload reduction. All source file-size comparisons assume minification and server compression.

### Comparing Performance

The chapter uses Benchmark.js to compare common tasks.

Project:

```text
https://benchmarkjs.com/
```

Benchmark repository:

```text
https://github.com/webopt/ch8-benchmark
```

The benchmark samples element selection, class toggling, and attribute toggling.

These tests cover only a few methods, so results vary by task. Sprint is attractive for raw speed and size, but its API is less compatible with jQuery. Zepto is larger, but easier to retrofit.

### Implementing An Alternative

For a site that uses jQuery lightly, replacing it can be as simple as dropping in a compatible alternative.

The source exercise says to reset local example-site changes before continuing:

```sh
git reset --hard
```

### Using Zepto

The Coyle site uses Zepto because it supports the required features and is less than a third of jQuery's size. It reduces the example payload from about 122 KB to about 102 KB.

Replace the jQuery script source:

```text
js/jquery.min.js
```

with:

```text
js/zepto.min.js
```

After reloading, the page should work without console errors, including the AJAX-driven appointment scheduling modal.

### Understanding Caveats On Using Shoestring Or Sprint

Shoestring and Sprint need more refactoring for this site. The site uses jQuery's `$.ajax` method, and Shoestring's `$.ajax` is not fully jQuery-compatible. Sprint has no `$.ajax` implementation.

Other incompatibilities matter too. Shoestring does not support `toggleClass`, while Sprint does. Sprint does not support `bind`, while Shoestring does. These gaps can often be handled with workarounds or native JavaScript APIs.

For a new site, start with the smallest library that can do the job. Move to a larger option only when real requirements demand it.

## Getting By Without jQuery

Many browser APIs now cover the use cases that once made jQuery essential: DOM readiness, element selection, event binding, class manipulation, attribute manipulation, content updates, and AJAX.

To skip to the finished native JavaScript version in the example repo:

```sh
git checkout -f native-js
```

The source exercise says to reset local example-site changes before this section:

```sh
git reset --hard
```

The strategy is to replace jQuery piece by piece, then remove `jquery.min.js` and load `behaviors.js` with `async`.

### Checking For The DOM To Be Ready

jQuery commonly wraps behavior in a DOM-ready callback.

Listing 8.2 checks DOM readiness with jQuery:

```js
$(function(){
    /* Content of behaviors.js truncated for brevity. */
});
```

Native JavaScript can listen for `readystatechange`.

Listing 8.3 checks DOM readiness with `addEventListener`:

```js
document.addEventListener("readystatechange", function(){
    /* Content of behaviors.js truncated for brevity. */
});
```

`addEventListener` is available in IE9 and above. For older IE, the chapter notes `document.onreadystatechange` as an alternative.

### Selecting Elements And Binding Events

Use `querySelector` to select the first matching element and `querySelectorAll` to select all matching elements. Both accept CSS selector strings.

Listing 8.4 compares `querySelector` and `querySelectorAll` with jQuery's `$` method:

```js
/* Selecting one element. */
var element = document.querySelector("div.item");
var jqElement = $("div.item").eq(0);

/* Selecting a set of elements */
var elements = document.querySelectorAll("div.item");
var jqElements = $("div.item");
```

After selecting an element, use `addEventListener` to attach events.

Listing 8.5 binds a click event with `addEventListener`:

```js
document.querySelector("#schedule").addEventListener("click", function(){
    /* Code to execute on click. */
});
```

Listing 8.6 shows the jQuery-centric appointment modal launch code:

```js
// Scheduling modal open
$("#schedule").bind("click", function(){
    $("body").addClass("locked");
    openModal();
});
```

Listing 8.7 replaces the event binding with native JavaScript:

```js
// Scheduling modal open
document.querySelector("#schedule").addEventListener("click", function(){
    $("body").addClass("locked");
    openModal();
});
```

At this stage, the event binding is native, but the handler still contains jQuery. The remaining `bind` calls can be converted the same way.

### Using `classList` To Manipulate Classes On Elements

The native `classList` API replaces common jQuery class methods.

Listing 8.8 compares `classList` with jQuery's class helpers:

```js
/* Adding Classes */
$(".modal").addClass("show");
document.querySelector(".modal").classList.add("show");

/* Removing Classes */
$(".modal").removeClass("show");
document.querySelector(".modal").classList.remove("show");

/* Toggling Classes */
$(".modal").toggleClass("show");
document.querySelector(".modal").classList.toggle("show");
```

The `classList` API has good support overall, including IE10 and above, though `toggle` has weaker IE support.

Listing 8.9 shows the jQuery-dependent `openModal` function:

```js
function openModal(){
    window.scroll(0, 0);
    $(".pageFade").removeClass("hide");
    $(".modal").addClass("open");
}
```

Listing 8.10 rewrites `openModal` without jQuery:

```js
function openModal(){
    window.scroll(0, 0);
    document.querySelector(".pageFade").classList.remove("hide");
    document.querySelector(".modal").classList.add("open");
}
```

If `classList` is not available, `className` can be used as a fallback string property, though it is less convenient.

### Reading And Modifying Element Attributes And Content

Native JavaScript can also replace jQuery's attribute and HTML helpers.

Listing 8.11 compares attribute manipulation:

```js
/* Reading attributes */
var jqAttr = $("link").attr("media");
var attr = document.querySelector("link").getAttribute("media");

/* Setting attributes */
$("link").attr("media", "print");
document.querySelector("link").setAttribute("media", "print");

/* Removing attributes */
$("link").removeAttr("media");
document.querySelector("link").removeAttribute("media");
```

Listing 8.12 compares jQuery's `html` method with `innerHTML`:

```js
/* Reading the content of an element */
var jqContents = $(".item").html();
var contents = document.querySelector(".item").innerHTML;

/* Changing the contents of an element */
$(".item").html("Hello world!");
document.querySelector(".item").innerHTML = "Hello world!";
```

Listing 8.13 shows the appointment status callback with jQuery still present:

```js
success: function(data){
    $("#status").html(data.message);
    document.querySelector(".statusModal").classList.add("show");
    document.querySelector(".modal").classList.remove("open");

    if(data.status === true){
        $("#okayButton").attr("data-status", "success");
        $("#headerStatus").html("Thank You!");
    }
    else{
        $("#okayButton").attr("data-status", "failure");
        $("#headerStatus").html("Error");
    }
}
```

Listing 8.14 rewrites it with native JavaScript:

```js
success: function(data){
    document.querySelector("#status").innerHTML = data.message;
    document.querySelector(".statusModal").classList.add("show");
    document.querySelector(".modal").classList.remove("open");

    if(data.status === true){
        document.querySelector("#okayButton")
            .setAttribute("data-status", "success");
        document.querySelector("#headerStatus").innerHTML = "Thank You!";
    }
    else{
        document.querySelector("#okayButton")
            .setAttribute("data-status", "failure");
        document.querySelector("#headerStatus").innerHTML = "Error";
    }
}
```

Listing 8.15 reads an attribute with jQuery's `attr` method:

```js
$("#okayButton").bind("click", function(e){
    if($(this).attr("data-status") === "failure"){
```

When converting the event binding, replace jQuery's `$(this)` with the event target.

Listing 8.16 reads the attribute with `getAttribute`:

```js
document.querySelector("#okayButton").addEventListener("click", function(e){
    if(e.target.getAttribute("data-status") === "failure"){
```

### Making AJAX Requests With The Fetch API

The old native AJAX interface was `XMLHttpRequest`. jQuery made it easier with `$.ajax`, but modern browsers increasingly support the Fetch API.

### Using The Fetch API

Listing 8.17 makes a basic Fetch API request and reads JSON:

```js
fetch("https://api.moviemaniac.com/movies/the-burbs")
    .then(function(response){
        return response.json();
    }).then(function(data){
        console.log(data);
    });
```

The `fetch` method takes the resource URL and returns a promise. The raw response object's `json` method returns another promise containing parsed JSON data.

Listing 8.18 replaces jQuery AJAX with `fetch` for the appointment form:

```js
fetch("js/response.json", {
    method: "post",
    body: new FormData(document.querySelector("#appointmentForm"))
}).then(function(response){
    return response.json();
}).then(function(data){
    document.querySelector("#status").innerHTML = data.message;
    document.querySelector(".statusModal").classList.add("show");
    document.querySelector(".modal").classList.remove("open");

    if(data.status === true){
        document.querySelector("#okayButton")
            .setAttribute("data-status", "success");
        document.querySelector("#headerStatus").innerHTML = "Thank You!";
    }
    else{
        document.querySelector("#okayButton")
            .setAttribute("data-status", "failure");
        document.querySelector("#headerStatus").innerHTML = "Error";
    }
});
```

This sends a `POST` request with form data wrapped in a `FormData` object, then updates the status modal from the JSON response.

### Polyfilling The Fetch API

Not every browser supports `fetch`. The chapter gives three options:

- Avoid `fetch` and use a standalone `$.ajax`-style library such as `https://github.com/ForbesLindesay/ajax`.
- Detect `window.fetch` and fall back to `XMLHttpRequest` when unavailable.
- Detect `window.fetch` and asynchronously load a polyfill only when needed.

The third option is the most efficient for browsers that support `fetch` natively.

Polyfill project:

```text
https://github.com/github/fetch
```

Listing 8.19 conditionally loads the Fetch API polyfill:

```html
<script>
    (function(document, window){
        if(!window.fetch){
            var fetchScript = document.createElement("script");
            fetchScript.src = "js/fetch.min.js";
            fetchScript.async = "async";

            document.body.appendChild(fetchScript);
        }
    })(document, window);
</script>
```

Because the call to `fetch` happens only when the user opens and submits the scheduling modal, the polyfill has time to load before it is needed.

![Figure](/.attachments/8-12-performance-loading.fetch.api.png)

_**Figure 8.12.** Fetch API polyfill load timing._
>
> The page begins loading, `behaviors.js` loads, the Fetch polyfill loads if needed, and only later does the user trigger the scheduling modal.

After replacing jQuery methods, remove `jquery.min.js` and load `behaviors.js` with `async`.

## Animating With `requestAnimationFrame`

JavaScript animation once relied on `setTimeout` and `setInterval`. `requestAnimationFrame` is a newer, more animation-aware API that lets the browser schedule frames efficiently.

### `requestAnimationFrame` At A Glance

CSS transitions let the browser handle animation after a property changes. JavaScript animations must update style values directly over time. `requestAnimationFrame` gives JavaScript a browser-coordinated way to perform those updates.

### Timer Function-Driven Animations And `requestAnimationFrame`

Listing 8.20 animates with `setTimeout`:

```js
function draw(){
    var item = document.querySelector(".item");
    item.style.width = (parseInt(item.style.width, 10) + 2) + "px";
    setTimeout(draw, 1000 / 60);
}

draw();
```

This recursively runs `draw` at roughly 60 frames per second.

Listing 8.21 animates with `requestAnimationFrame`:

```js
function draw(){
    var item = document.querySelector(".item");
    item.style.width = (parseInt(item.style.width, 10) + 2) + "px";
    requestAnimationFrame(draw);
}

draw();
```

Unlike `setTimeout`, `requestAnimationFrame` does not take a millisecond interval. The browser schedules frames according to the display refresh rate, commonly aiming for 60 FPS.

### Comparing Performance

The chapter compares `setTimeout`, `requestAnimationFrame`, and CSS transitions by animating a box 256 pixels, doubling its dimensions, and shifting it to 50% opacity.

Demo:

```text
http://jlwagner.net/webopt/ch08-animation
```

![Figure](/.attachments/)

_**Figure 8.13.** normalized performance of animation techniques in Chrome Timeline._
>
> `requestAnimationFrame` uses less rendering and painting time than the timer-based animation and CSS transition in the source test.

JavaScript-driven animation naturally spends more time in scripting than CSS transitions. The advantage of `requestAnimationFrame` is that it reduces rendering and painting work compared with older timer-based approaches.

### Implementing `requestAnimationFrame`

Switch to the animation branch:

```sh
git checkout -f requestanimationframe
```

Listing 8.22 shows a flexible animation function using `setTimeout`:

```js
function animate(selector, duration, property, from, to, units){
    var element = document.querySelector(selector),
        endTime = Number(new Date()) + duration,
        interval = (1000 / 60),
        progress = function(){
            var progress = Math.abs(((endTime - +new Date()) / duration) - 1);
            return (progress * (to - from)) + from;
        },
        draw = function(){
            if(endTime > +new Date()){
                element.style[property] = progress() + units;
                setTimeout(draw, interval);
            }
            else{
                element.style[property] = to + units;
                return;
            }
        };

    draw();
}
```

The source example invokes it like this:

```js
animate(".modal", 500, "top", -150, 10, "%");
```

![Figure](/.attachments/)

_**Figure 8.14.** labeled `animate` function arguments._
>
> The arguments identify the DOM selector, duration, CSS property, starting value, ending value, and unit.

Listing 8.23 substitutes `requestAnimationFrame` for `setTimeout` inside `draw`:

```js
draw = function(){
    if(endTime > +new Date()){
        element.style[property] = progress() + units;
        requestAnimationFrame(draw);
    }
    else{
        element.style[property] = to + units;
        return;
    }
};
```

After this change, the `interval` variable can be removed because `requestAnimationFrame` handles frame timing.

Listing 8.24 creates a `requestAnimationFrame` fallback using `setTimeout`:

```js
window.raf = (function(){
    return window.requestAnimationFrame || function(callback){
        var interval = 1000 / 60;
        window.setTimeout(callback, interval);
    };
})();
```

Use `raf` in place of `requestAnimationFrame` to get native support where available and `setTimeout` fallback behavior elsewhere.

### Dropping In Velocity.js

Velocity.js is a JavaScript animation library with an API similar to jQuery's `animate` method.

Project:

```text
http://velocityjs.org
```

jQuery animation code:

```js
$(".item").animate({
    opacity: 1,
    left: "8px"
}, 500);
```

Velocity.js with jQuery-style syntax:

```js
$(".item").velocity({
    opacity: 1,
    left: "8px"
}, 500);
```

Velocity.js without jQuery:

```js
Velocity(document.querySelector(".item"), {
    opacity: 1,
    left: "8px"
}, {
    duration: 500
});
```

Velocity.js can animate colors, transforms, and scrolling, and it uses `requestAnimationFrame` under the hood. It is about 13 KB minified and compressed, so it makes the most sense when animation is an important part of the site.
