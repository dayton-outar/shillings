# Going Further With Images

This chapter covers:

- Creating image sprites from multiple image files with automated tools
- Reducing image file size without significantly degrading visual quality
- Using Google's WebP format and understanding how it compares to older formats
- Deferring the loading, or lazy loading, of images outside the viewport

Chapter 5 covered responsive image delivery in CSS and HTML. This chapter goes deeper into image performance: reducing requests with sprites, reducing file sizes, using WebP, and loading images only when users are likely to see them.

## Using Image Sprites

Image sprites combine multiple images into one image file. They are usually used for global visual elements such as icons, rating stars, and share buttons. CSS then uses `background-image` and `background-position` to reveal the needed part of the sprite inside an element.

> [!note]
> Image sprites reduce HTTP requests and are useful on `HTTP/1`, but they are usually an `HTTP/2` antipattern. Chapter 11 covers the protocol tradeoffs.

> [!figure]
> Figure 6.1 placeholder: social media image sprite from the source PDF.
>
> An image sprite made from several social media icons.

The example recipe site has six SVG icons: four social icons and two rating stars. The goal is to reduce page requests from 25 to 20 and reduce icon load time from about 500 ms to about 90 ms on Chrome's `Good 3G` throttling profile.

### Getting Up And Running

Install the sprite generator:

```sh
npm install -g svg-sprite
```

Download and run the recipe site:

```sh
git clone https://github.com/webopt/ch6-sprites.git
cd ch6-sprites
npm install
node http.js
```

The site runs at:

```text
http://localhost:8080
```

To skip to the completed sprite implementation:

```sh
git checkout svg-sprite -f
```

### Generating The Image Sprite

The `img/icon-images` folder contains six SVG icons.

| Image name | Image function | Image size |
| --- | --- | ---: |
| `icon_facebook.svg` | Facebook icon | 600 bytes |
| `icon_google-plus.svg` | Google Plus icon | 938 bytes |
| `icon_pinterest.svg` | Pinterest icon | 563 bytes |
| `icon_star-off.svg` | Rating star, inactive | 299 bytes |
| `icon_star-on.svg` | Rating star, active | 302 bytes |
| `icon_twitter.svg` | Twitter icon | 759 bytes |

Generate the sprite from the project root:

```sh
svg-sprite --css --css-render-less --css-dest=less \
           --css-sprite=../img/icons.svg \
           --css-layout=diagonal img/icon-images/*.svg
```

> [!figure]
> Figure 6.2 placeholder: `svg-sprite` command anatomy diagram from the source PDF.
>
> The command runs in CSS mode, generates LESS mixins, sets the LESS output directory, sets the sprite path, chooses diagonal layout, and reads SVGs from `img/icon-images`.

The generated sprite is written to `img/icons.svg`, and the generated LESS file is written to `less/sprite.less`.

> [!figure]
> Figure 6.3 placeholder: generated SVG sprite from the source PDF.
>
> The generated image sprite annotated with the source icon filenames.

### Using The Generated Sprite

Import the generated LESS file at the top of `less/main.less`:

```less
@import "sprite.less";
```

Then replace individual icon `background-image` references with generated LESS mixins.

| Image name | LESS mixin |
| --- | --- |
| `icon_facebook.svg` | `.svg-icon_facebook;` |
| `icon_google-plus.svg` | `.svg-icon_google-plus;` |
| `icon_pinterest.svg` | `.svg-icon_pinterest;` |
| `icon_star-off.svg` | `.svg-icon_star-off;` |
| `icon_star-on.svg` | `.svg-icon_star-on;` |
| `icon_twitter.svg` | `.svg-icon_twitter;` |

For example, replace:

```css
background-image: url("../img/icon-images/icon_facebook.svg");
```

with:

```less
.svg-icon_facebook;
```

Then recompile LESS:

- UNIX-like systems: run `less.sh`
- Windows: run `less.bat`

Repeat for each icon. When complete, the page uses one sprite request instead of six separate icon requests.

### Considerations For Image Sprites

Sprites are best for global visual elements. Do not sprite content-specific images that appear only on a single page or in a narrow context, because that forces users to download imagery they may never need.

> [!figure]
> Figure 6.4 placeholder: sprite candidate annotation from the source PDF.
>
> Iconography is a good sprite candidate; recipe images and ads are not.

Some icons may not appear on every page but are still good sprite candidates because they add little weight and can help subsequent pages load faster from cache.

### Falling Back To Raster Image Sprites With Grumpicon

Most modern browsers support SVG, but older browsers may need a PNG fallback. Grumpicon can generate PNG fallbacks from SVG files.

Switch branches:

```sh
git checkout -f png-fallback
```

Go to `http://grumpicon.com` and upload `img/icons.svg`. Grumpicon downloads a ZIP containing a `png/icons.png` file. Copy `icons.png` into the recipe site's `img` folder.

> [!figure]
> Figure 6.5 placeholder: Grumpicon upload screenshot from the source PDF.
>
> SVG files can be converted to PNG by uploading or dragging them onto Grumpicon.

Change the `.svg-common()` mixin in `sprite.less`:

```less
.svg-common(){
    background: url("../img/icons.png") no-repeat;
    background: none, url("../img/icons.svg");
}
```

Listing 6.1 falls back to PNG for browsers without SVG support.

Older browsers use the first `background` declaration and fail to parse the multiple-background declaration. Modern browsers use the SVG sprite and avoid downloading the PNG fallback because it is overridden.

## Reducing Images

Image reduction lowers image file size without significantly degrading visual quality. Many image tools do not produce the smallest web-friendly output, so specialized optimizers can help.

The example uses a recipe collections page with responsive images. Download and run it:

```sh
git clone https://github.com/webopt/ch6-image-reduction.git
cd ch6-image-reduction
npm install
node http.js
```

Open:

```text
http://localhost:8080
```

> [!figure]
> Figure 6.6 placeholder: recipe website screenshot from the source PDF.
>
> The client recipe website in the tablet breakpoint.

### Reducing Raster Images With imagemin

`imagemin` is a Node image-optimization module that can optimize common web image formats through plugins.

**Optimizing JPEG images**

The `img` folder contains 17 pairs of JPEGs, ending in `-1x.jpg` and `-2x.jpg` for standard- and high-DPI screens. The page uses `srcset` to deliver the appropriate image.

Baseline measurements on Chrome's `Good 3G` throttling profile:

| Screen DPI | Image payload | Load time |
| --- | ---: | ---: |
| High | 2089 KB | 11.5 seconds |
| Standard | 732 KB | 4.38 seconds |

Install the optimizer and create an output folder:

```sh
npm install imagemin imagemin-jpeg-recompress
mkdir optimg
```

Create `reduce.js`:

```js
var imagemin = require("imagemin"),
    jpegRecompress = require("imagemin-jpeg-recompress");

imagemin(["img/*.jpg"], "optimg", {
    plugins: [
        jpegRecompress({
            accurate: true,
            max: 70
        })
    ]
});
```

Listing 6.2 uses `imagemin` to optimize all JPEGs in a folder.

Run it:

```sh
node reduce.js
```

> [!figure]
> Figure 6.7 placeholder: JPEG optimization comparison from the source PDF.
>
> `chicken-tacos-2x.jpg` drops from 181.9 KB to 79.41 KB with virtually imperceptible visual differences.

Copy optimized files from `optimg` into `img`, or update image references to point at `optimg`. The chapter reports a 59% image-size reduction and about a 50% reduction in page-load time.

> [!figure]
> Figure 6.8 placeholder: recipe website JPEG optimization load-time chart from the source PDF.
>
> Load times improve for both high-DPI and standard-DPI screens after image optimization.

`imagemin-jpeg-recompress` options are documented at `www.npmjs.com/package/imagemin-jpeg-recompress`. Other plugins are listed at `www.npmjs.com/browse/keyword/imageminplugin`.

**Optimizing PNG images**

Switch to the PNG optimization branch:

```sh
git checkout -f pngopt
```

Install the PNG plugin:

```sh
npm install imagemin-optipng
```

Update `reduce.js`:

```js
var imagemin = require("imagemin"),
    optipng = require("imagemin-optipng");

imagemin(["img/*.png"], "optimg", {
    plugins: [optipng()]
});
```

Listing 6.3 uses `imagemin` to optimize PNGs.

Run:

```sh
node reduce.js
```

The optimized PNGs appear in `optimg`.

> [!figure]
> Figure 6.9 placeholder: PNG optimization file-size chart from the source PDF.
>
> `logo.png` and `logo-2x.png` shrink by roughly 33% to 37% after optimization.

The `imagemin-optipng` plugin supports an `optimizationLevel` option from `0` to `7`, with `2` as the default. Higher values may or may not improve output depending on the image.

### Optimizing SVG Images

SVG files are text, so optimization differs from raster optimization. They can be minified, simplified, and server-compressed.

Install `svgo`:

```sh
npm install -g svgo
```

Download the SVG at:

```text
http://jlwagner.net/webopt/ch06/weekly-timber.svg
```

Optimize it:

```sh
svgo -o weekly-timber-opt.svg weekly-timber.svg
```

Example output:

```text
39.998 KiB - 28.4% = 28.656 KiB
```

> [!figure]
> Figure 6.10 placeholder: default `svgo` optimization comparison from the source PDF.
>
> The Weekly Timber logo before and after default `svgo` optimization.

You can inspect `svgo` options with:

```sh
svgo -h
```

The `-p` option controls floating-point precision. Try:

```sh
svgo -p 1 -o weekly-timber-opt.svg weekly-timber.svg
```

Example output:

```text
39.998 KiB - 53.9% = 18.42 KiB
```

> [!figure]
> Figure 6.11 placeholder: reduced precision SVG comparison from the source PDF.
>
> The Weekly Timber logo before and after reducing decimal precision with `svgo` to `1`.

Overoptimization can damage visual fidelity, especially with Bézier curves.

> [!figure]
> Figure 6.12 placeholder: overoptimized SVG comparison from the source PDF.
>
> Stripping all precision creates a smaller file but visibly damages the logo curves.

Always compare optimized SVG output with the original, zooming in when necessary.

## Encoding Images With WebP

WebP is a newer Google image format that can be encoded as either lossy or lossless. `imagemin-webp` can convert images to WebP using the same pattern as the previous `imagemin` scripts.

### Encoding Lossy WebP Images With imagemin

Switch branches:

```sh
git checkout -f webp
```

Install packages:

```sh
npm install imagemin imagemin-webp
```

Create `reduce-webp.js`:

```js
var imagemin = require("imagemin"),
    webp = require("imagemin-webp");

imagemin(["img/*.jpg"], "optimg", {
    plugins: [webp({
        quality: 40
    })]
});
```

Listing 6.4 encodes JPEG images into lossy WebP with `imagemin`.

Run:

```sh
node reduce-webp.js
```

> [!figure]
> Figure 6.13 placeholder: JPEG versus WebP comparison from the source PDF.
>
> An optimized JPEG at 79.41 KB compared with a WebP image at 67.67 KB.

After converting all JPEG references in `index.html` to WebP, Chrome's `Good 3G` profile shows faster load times.

> [!figure]
> Figure 6.14 placeholder: JPEG versus WebP load-time chart from the source PDF.
>
> WebP improves load time compared with both unoptimized and optimized JPEGs on standard- and high-DPI screens.

The chapter reports a 35% load-time decrease for high-DPI screens and 20% for standard-DPI screens compared with optimized JPEGs.

### Encoding Lossless WebP Images With imagemin

WebP also supports lossless encoding with 24-bit color and full transparency. Convert PNG images by changing the input wildcard and options:

```js
var imagemin = require("imagemin"),
    webp = require("imagemin-webp");

imagemin(["img/*.png"], "optimg", {
    plugins: [webp({
        lossless: true
    })]
});
```

Listing 6.5 encodes PNG images into lossless WebP.

> [!figure]
> Figure 6.15 placeholder: PNG versus lossless WebP file-size chart from the source PDF.
>
> Lossless WebP reduces the logo images further compared with optimized PNGs.

The chapter reports additional reductions of about 40% for `logo.png` and 33% for `logo-2x.png` compared with optimized PNGs.

### Supporting Browsers That Don't Support WebP

WebP support is not universal. Browsers such as Safari or Firefox in the chapter's timeframe fail to display WebP images.

> [!figure]
> Figure 6.16 placeholder: Safari WebP failure screenshot from the source PDF.
>
> Safari failing to display a WebP image.

Use `<picture>` with `type` fallbacks.

Switch branches:

```sh
git checkout webp-fallback
```

The WebP-only logo starts as:

```html
<img src="optimg/logo.webp"
     srcset="optimg/logo.webp 1x, optimg/logo-2x.webp 2x"
     alt="AllTheFoods" id="logo">
```

Rewrite it:

```html
<picture>
    <source srcset="optimg/logo-2x.webp 2x, optimg/logo.webp 1x"
            type="image/webp">
    <source srcset="img/logo-2x.png 2x, img/logo.png 1x" type="image/png">
    <img src="img/logo.png" id="logo">
</picture>
```

Listing 6.6 establishes fallbacks with `<picture>`.

Keep styling on the `<img>` element, since `<picture>` assigns the chosen source to the `<img>`.

To skip to the completed fallback implementation:

```sh
git checkout -f webp-picture-fallback
```

> [!figure]
> Figure 6.17 placeholder: browser network comparison from the source PDF.
>
> Chrome loads WebP images, while Firefox falls back to JPEG and PNG images.

## Lazy Loading Images

Lazy loading defers image downloads until the images are in or near the viewport. This saves initial bandwidth and can reduce initial load time, especially on image-heavy pages where users may not scroll to every image.

Download and run the lazy loading project:

```sh
git clone https://github.com/webopt/ch6-lazyload.git
cd ch6-lazyload
npm install
node http.js
```

To skip to the complete lazy loading implementation:

```sh
git checkout -f lazyload
```

### Configuring The Markup

Lazy load images that are below, or likely below, the fold. The logo and hero image should load normally because they are above the fold. Recipe collection thumbnails are good lazy loading candidates.

> [!figure]
> Figure 6.18 placeholder: lazy loading image audit from the source PDF.
>
> The logo and hero image should not be lazy loaded; collection thumbnail images should be.

Original `<picture>` markup:

```html
<picture>
    <source srcset="img/fish-and-chips-2x.webp 2x,
                    img/fish-and-chips-1x.webp 1x"
            type="image/webp">
    <source srcset="img/fish-and-chips-2x.jpg 2x,
                    img/fish-and-chips-1x.jpg 1x"
            type="image/jpeg">
    <img src="img/fish-and-chips-1x.jpg" class="recipeImage">
</picture>
```

Lazy-load-ready markup:

```html
<picture>
    <source data-srcset="img/fish-and-chips-2x.webp 2x,
                         img/fish-and-chips-1x.webp 1x"
            type="image/webp">
    <source data-srcset="img/fish-and-chips-2x.jpg 2x,
                         img/fish-and-chips-1x.jpg 1x"
            type="image/jpeg">
    <img src="img/blank.png"
         data-src="img/fish-and-chips-1x.jpg"
         class="recipeImage lazy">
</picture>
```

Listing 6.7 prepares images for the lazy loading script.

Move `srcset` and `src` values to `data-srcset` and `data-src`, point `src` at a small placeholder (`img/blank.png`), and add the `lazy` class to the `<img>`.

### Writing The Lazy Loader

Create `js/lazyloader.js`.

**Laying the foundations**

```js
(function(window, document){
    var lazyLoader = {
        lazyClass: "lazy",
        images: null,
        processing: false,
        throttle: 200,
        buffer: 50
    }
})(window, document);
```

Listing 6.8 begins the lazy loader. The `lazyClass` identifies images to load, `images` stores the collection, `processing` prevents excessive work, `throttle` limits scan frequency, and `buffer` starts loading images just before they enter the viewport.

> [!figure]
> Figure 6.19 placeholder: lazy loading buffer diagram from the source PDF.
>
> The `buffer` property extends the scan area beyond the viewport so images can begin loading before they are visible.

**Building the initializer and destroyer**

```js
buffer: 50,
init: function(){
    lazyLoader.images = [].slice.call(document.getElementsByClassName(lazyLoader.lazyClass));
    lazyLoader.scanImages();
    document.addEventListener("scroll", lazyLoader.scanImages);
    document.addEventListener("touchmove", lazyLoader.scanImages);
},
destroy: function(){
    document.removeEventListener("scroll", lazyLoader.scanImages);
    document.removeEventListener("touchmove", lazyLoader.scanImages);
},
```

Listing 6.9 defines initializing and destroying functions. `init` collects lazy images, runs the first scan, and attaches scroll listeners. `destroy` removes listeners after all images are loaded.

**Scanning the document for images**

```js
scanImages: function(){
    if(document.getElementsByClassName(lazyLoader.lazyClass).length === 0){
        lazyLoader.destroy();
        return;
    }

    if(lazyLoader.processing === false){
        lazyLoader.processing = true;

        setTimeout(function(){
            for(var i in lazyLoader.images){
                if(lazyLoader.images[i].className.indexOf(lazyLoader.lazyClass) !== -1){
                    if(lazyLoader.inViewport(lazyLoader.images[i])){
                        lazyLoader.loadImage(lazyLoader.images[i]);
                    }
                }
            }

            lazyLoader.processing = false;
        }, lazyLoader.throttle);
    }
},
```

Listing 6.10 defines `scanImages`. It stops when no lazy images remain, throttles execution, checks each remaining lazy image, and loads images that are in range.

**Writing the core lazy loading methods**

```js
inViewport: function(img){
    var top = ((document.body.scrollTop ||
                document.documentElement.scrollTop) + window.innerHeight) +
                lazyLoader.buffer;
    return img.offsetTop <= top;
},
```

Listing 6.11 defines `inViewport`. It calculates the viewport's lower boundary plus the buffer and checks whether the image top is above that line.

> [!figure]
> Figure 6.20 placeholder: viewport position calculation diagram from the source PDF.
>
> The viewport height plus buffer exceeds the image top boundary, so `inViewport` returns `true`.

```js
loadImage: function(img){
    if(img.parentNode.tagName === "PICTURE"){
        var sourceEl = img.parentNode.getElementsByTagName("source");

        for(var i = 0; i < sourceEl.length; i++){
            var sourceSrcset = sourceEl[i].getAttribute("data-srcset");

            if(sourceSrcset !== null){
                sourceEl[i].setAttribute("srcset", sourceSrcset);
                sourceEl[i].removeAttribute("data-srcset");
            }
        }
    }

    var imgSrc = img.getAttribute("data-src"),
        imgSrcset = img.getAttribute("data-srcset");

    if(imgSrc !== null){
        img.setAttribute("src", imgSrc);
        img.removeAttribute("data-src");
    }

    if(imgSrcset !== null){
        img.setAttribute("srcset", imgSrcset);
        img.removeAttribute("data-srcset");
    }

    lazyLoader.removeClass(img, lazyLoader.lazyClass);
},
```

Listing 6.12 defines `loadImage`. It supports `<picture>` by converting nearby `<source>` `data-srcset` attributes into real `srcset` attributes, then does the same for the `<img>` element's `data-src` and `data-srcset`.

```js
removeClass: function(img, className){
    var classArr = img.className.split(" ");

    for(var i = 0; i < classArr.length; i++){
        if(classArr[i] === className){
            classArr.splice(i, 1);
        }
    }

    img.className = classArr.toString().replace(",", " ");
}
```

Listing 6.13 defines `removeClass`. It removes the `lazy` class after image loading begins.

**Turning the key and running the script**

After the `lazyLoader` object, initialize on DOM readiness:

```js
document.onreadystatechange = lazyLoader.init;
```

Load the script after `scripts.min.js`:

```html
<script src="js/lazyloader.js"></script>
```

Open the Network tab, reload the page, and scroll. New image requests appear as images lazy load.

> [!figure]
> Figure 6.21 placeholder: lazy-loaded network waterfall from the source PDF.
>
> The network waterfall shows initial image downloads and later lazy-loaded image downloads.

### Accommodating Users Without JavaScript

Without JavaScript, lazy-loaded images remain placeholders.

> [!figure]
> Figure 6.22 placeholder: lazy loading failure without JavaScript from the source PDF.
>
> Images never load because JavaScript never runs.

Add a `<noscript>` fallback immediately after each lazy-loaded `<picture>`:

```html
<noscript>
    <picture>
        <source srcset="img/fish-and-chips-2x.webp 2x,
                        img/fish-and-chips-1x.webp 1x"
                type="image/webp">
        <source srcset="img/fish-and-chips-2x.jpg 2x,
                        img/fish-and-chips-1x.jpg 1x"
                type="image/jpeg">
        <img src="img/fish-and-chips-1x.jpg" class="recipeImage">
    </picture>
</noscript>
```

This displays the real image when JavaScript is disabled, but both placeholder and fallback can appear.

> [!figure]
> Figure 6.23 placeholder: `<noscript>` double-image screenshot from the source PDF.
>
> Both the lazy placeholder and the `<noscript>` image are visible when JavaScript is disabled.

Add a `no-js` class to `<html>`:

```html
<html class="no-js">
```

Hide lazy placeholders when JavaScript is disabled:

```css
.no-js .lazy{
    display: none;
}
```

Recompile LESS with `less.sh` or `less.bat`.

Then remove the `no-js` class when JavaScript is available by adding this before `</head>`:

```html
<script>document.getElementsByTagName("html")[0].className="";</script>
```

This approach clears every class on `<html>`. If other classes need to remain, use a more selective approach such as `classList`, or a library helper.
