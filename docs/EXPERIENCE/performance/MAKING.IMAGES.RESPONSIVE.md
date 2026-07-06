# Making Images Responsive

This chapter covers:

- Using CSS media queries to deliver appropriate background images for a user's device
- Delivering responsive images in HTML with `srcset` and the `<picture>` element
- Using Picturefill to polyfill `srcset` and `<picture>` in older browsers
- Using SVG images in CSS and HTML

Images are often the largest part of a page's payload. As devices with high-DPI screens become common, sites need higher-resolution imagery for capable displays while still avoiding oversized downloads for less capable devices. Responsive image delivery balances visual quality and performance.

## Why Think About Image Delivery?

Responsive image delivery means serving image sizes and formats appropriate to the device. The goal is not just visual quality; it is avoiding unnecessary download and rendering work.

A single oversized image can look acceptable everywhere, but it forces smaller devices to download extra bytes and scale the image down. A better approach is to maintain multiple image sizes and serve the closest match for the current device.

![Figure](/.attachments/5-1-performance-scaling.image.png)

_**Figure 5.1.** Image scaling comparison from the source PDF._
>
> A 170 KB image with a width of 1440 pixels must be scaled down for a high-DPI phone, while a 41 KB image with a width of 750 pixels fits the phone without scaling.

Chrome Timeline measurements show that avoiding scaling improves rendering and painting time, even for a single image.

![Figure](/.attachments/5-2-performance-rendering.painting.times.png)

_**Figure 5.2.** Rendering and painting benchmark chart from the source PDF._
>
> Rendering and painting times are lower when the image is already sized for its container.

In the chapter's test, avoiding scaling improved rendering time by about 15% and painting time by about 36%. The per-image savings are small, but they add up across a full page.

Perfectly scaled images for every device are impractical. A better plan is to define a range of image widths that covers common device sizes and display densities while accepting some overlap.

## Understanding Image Types And Their Applications

Most web images fall into two broad types:

- Raster images, such as JPEG, PNG, and GIF
- SVG images, which are vector graphics

### Working With Raster Images

Raster images, also called bitmap images, are made of pixels on a two-dimensional grid. Common raster formats include `JPEG`, `PNG`, and `GIF`.

![Figure](/.attachments/5-3-performance-raster.image.png)

_**Figure 5.3.** Enlarged raster favicon from the source PDF._
>
> A 16 x 16 YouTube favicon enlarged to 512 x 512 shows the underlying pixel grid.

Raster images appear in HTML through `<img>` and in CSS through properties such as `background` and `list-style-image`. Raster formats are commonly categorized by compression type: lossy or lossless.

**Lossy images**

Lossy images discard some source data to reduce file size. JPEG is the most common lossy web format and is well suited to photographs.

Lossy compression can create visible artifacts if pushed too far. It can also create generational loss if an already-compressed file is repeatedly recompressed. Used carefully from an uncompressed source, JPEG quality loss is often acceptable because the file-size savings are large.

![Figure](/.attachments/5-5-performance-same.image.compressed.uncompressed.png)

_**Figure 5.5.** TIFF versus JPEG comparison from the source PDF._
>
> A compressed JPEG version is much smaller than an uncompressed TIFF source, with only subtle visual degradation at the tested quality setting.

**Lossless images**

Lossless images compress without discarding source data. PNG and GIF are common examples.

Lossless formats commonly fall into two groups:

- 8-bit images: `GIF` and 8-bit `PNG`, supporting 256 colors and 1-bit transparency
- Full-color images: full-color `PNG` and lossless `WebP`, supporting full alpha transparency and up to about 16.7 million colors

8-bit PNG often compresses better than GIF but does not support animation. Full-color PNG is more broadly supported than WebP and works well when transparency or lossless quality is required, though photos usually compress better as JPEG.

![Figure](/.attachments/5-7-performance-lossless.image.compression.png)

_**Figure 5.7.** Lossless compression comparison from the source PDF._
>
> Lossless image compression formats vary in file size and color range; 8-bit output is limited to 256 colors.

Simple images with few colors usually fit 8-bit lossless formats. Images that need full transparency or lossless full color usually fit full-color PNG.

### Working With SVG Images

Scalable Vector Graphics, or `SVG`, use vector artwork rather than pixels. They are composed of mathematical shapes and can scale without losing quality.

![Figure](/.attachments/5-8-performance-vector.image.png)

_**Figure 5.8.** Scalable vector illustration from the source PDF._
>
> A vector image remains sharp when scaled to different sizes.

SVG files are XML text files with the media type `image/svg+xml`. They can be edited in a text editor, placed inline in HTML, and styled with CSS, including media queries.

SVG works best for logos, icons, line art, diagrams, and geometric artwork. It is not a good fit for photographs.

### Knowing What Image Formats To Use

Table 5.1 summarizes common image formats and their best uses.

| Image format | Colors | Image type | Compression | Best fit |
| --- | --- | --- | --- | --- |
| PNG | Full | Raster | Lossless | Content where quality loss is unacceptable, full transparency may be required, or the format needs to support a broad range of image content. Often less efficient than JPEG for photographs. |
| PNG (8-bit) | 256 | Raster | Lossless | Icons, pixel art, and other content that does not need full color but may need 1-bit transparency. |
| GIF | 256 | Raster | Lossless | Similar use cases to 8-bit PNG, with lower compression efficiency but animation support. |
| JPEG | Full | Raster | Lossy | Photographs and other full-color content where some quality loss and no transparency are acceptable. |
| SVG | Full | Vector | Uncompressed | Line art, diagrams, logos, and nonphotographic content that must scale cleanly across devices. |
| WebP (Lossy) | Full | Raster | Lossy | Similar to JPEG, with full transparency support and potential compression gains. |
| WebP (Lossless) | Full | Raster | Lossless | Similar to full-color PNG, with potential compression gains. |

## Image Delivery In CSS

Responsive image delivery in CSS usually uses media queries.

### Targeting Displays In CSS By Using Media Queries

The masthead is controlled by the `#masthead` selector.

```css
#masthead{
     padding: .5rem 0 0;
     height: 10rem;
     background-size: cover;
     background-image: url("../img/masthead-xxxsmall.jpg");
     background-position: 50% 50%;
     position: relative;
}
```

Listing 5.1 shows the default `#masthead` styling. It uses `background-size: cover` and a mobile-first default image.

The available masthead images map to breakpoints like this:

| Image name | Image resolution | Media query |
| --- | ---: | --- |
| `masthead-xxxsmall.jpg` | 320 x 135 | None, default image |
| `masthead-xxsmall.jpg` | 640 x 269 | `(min-width: 30em)` |
| `masthead-xsmall.jpg` | 768 x 323 | `(min-width: 44em)` |
| `masthead-small.jpg` | 1024 x 430 | `(min-width: 56em)` |
| `masthead-medium.jpg` | 1440 x 604 | `(min-width: 77em)` |
| `masthead-large.jpg` | 1920 x 805 | `(min-width: 105em)` |
| `masthead-xlarge.jpg` | 2560 x 1073 | `(min-width: 140em)` |
| `masthead-xxlarge.jpg` | 3840 x 1609 | Not used initially |

The first breakpoint appears at `30em`, or `480px / 16px`:

```css
@media screen and (min-width: 30em){ /* 480px/16px */
     #masthead{
          height: 12rem;
     }

     #logo{
          width: 70%;
     }

     #tagline{
          font-size: 1.25rem;
     }
}
```

Listing 5.2 shows a media query breakpoint. Add the larger background image at that breakpoint:

```css
#masthead{
     height: 12rem;
     background-image: url("../img/masthead-xxsmall.jpg");
}
```

Repeat that process for the remaining breakpoints in Table 5.2. To skip to the completed state:

```sh
git checkout responsive-images -f
```

### Targeting High DPI Displays With Media Queries

High-DPI screens, such as Retina and 4K/5K displays, need higher-resolution images to appear sharp.

A basic high-DPI media query:

```css
@media screen (-webkit-min-device-pixel-ratio: 2),
                  (min-resolution: 192dpi){
     /* Put High DPI Styles Here */
}
```

`-webkit-min-device-pixel-ratio` supports older WebKit-style high-DPI checks. `min-resolution: 192dpi` is the modern form. Since `1x` equals 96 DPI, `192dpi` targets screens at `2x`.

Table 5.3 maps high-DPI masthead image usage.

| Image name | Image resolution | Standard DPI media query | High DPI media query |
| --- | ---: | --- | --- |
| `masthead-xxxsmall.jpg` | 320 x 135 | None, default | Not used |
| `masthead-xxsmall.jpg` | 640 x 269 | `(min-width: 30em)` | `(-webkit-min-device-pixel-ratio: 2)`, `(min-resolution: 192dpi)` |
| `masthead-xsmall.jpg` | 768 x 323 | `(min-width: 44em)` | `(-webkit-min-device-pixel-ratio: 2)`, `(min-resolution: 192dpi)`, and `(min-width: 30em)` |
| `masthead-small.jpg` | 1024 x 430 | `(min-width: 56em)` | `(-webkit-min-device-pixel-ratio: 2)`, `(min-resolution: 192dpi)`, and `(min-width: 44em)` |
| `masthead-medium.jpg` | 1440 x 604 | `(min-width: 77em)` | `(-webkit-min-device-pixel-ratio: 2)`, `(min-resolution: 192dpi)`, and `(min-width: 56em)` |
| `masthead-large.jpg` | 1920 x 805 | `(min-width: 105em)` | `(-webkit-min-device-pixel-ratio: 2)`, `(min-resolution: 192dpi)`, and `(min-width: 77em)` |
| `masthead-xlarge.jpg` | 2560 x 1073 | `(min-width: 140em)` | `(-webkit-min-device-pixel-ratio: 2)`, `(min-resolution: 192dpi)`, and `(min-width: 105em)` |
| `masthead-xxlarge.jpg` | 3840 x 1609 | Not used | `(-webkit-min-device-pixel-ratio: 2)`, `(min-resolution: 192dpi)`, and `(min-width: 140em)` |

At the high-DPI default query, set:

```css
#masthead{
    background-image: url("../img/masthead-xxsmall.jpg");
}
```

Then continue through the Table 5.3 mappings. To skip ahead:

```sh
git checkout hi-dpi-images -f
```

### Using SVG Background Images In CSS

SVG can remove the need for multiple raster breakpoints when the image content suits vector graphics.

In the `img` folder, find `masthead.svg`. In `styles.css`, change the `#masthead` background image:

```css
background-image: url("../img/masthead.svg");
```

Then remove the raster background-image overrides in later media queries so they do not override the SVG. The masthead now scales cleanly across widths and display densities without additional media queries.

SVG is still not appropriate for photographs. It is best for logos, line art, patterns, and similar artwork. Check file size and visual quality before choosing SVG over raster.

## Image Delivery In HTML

CSS media queries solve responsive background images, but HTML images need their own tools. The main tools are:

- `srcset` on `<img>`
- The `<picture>` element
- Picturefill for browsers without support

### The Universal `max-width` Rule For Images

Every responsive site should include:

```css
img{
     max-width: 100%;
}
```

Listing 5.3 shows the universal `max-width` rule. It allows images to render at natural size until they exceed the width of their container, then constrains them.

![Figure](/.attachments/5-13-performance-max.width.png)

_**Figure 5.13.** image max-width comparison from the source PDF._
>
> Without `max-width`, an oversized image spills outside its container. With `max-width: 100%`, it fits inside.

### Using `srcset`

The `srcset` attribute lets an `<img>` offer multiple candidate images. It does not replace `src`; it supplements it.

```html
<img src="image-small.jpg"
     srcset="image-medium.jpg 640w,
             image-large.jpg 1280w">
```

The `src` value is the default and fallback. The `srcset` value lists image URLs and their intrinsic widths, such as `640w` or `1280w`.

`srcset` works best when all candidates have the same visual treatment and aspect ratio. The browser chooses the best option for the viewport and device characteristics.

Switch to the `srcset` branch:

```sh
git checkout srcset -f
```

The available article image widths are:

| Image name | Image width |
| --- | ---: |
| `amp-xsmall.jpg` | 320w, already referenced in `src` |
| `amp-small.jpg` | 512w |
| `amp-medium.jpg` | 768w |
| `amp-large.jpg` | 1280w |

Update the image:

```html
<img src="img/amp-xsmall.jpg" class="articleImageFull"
     srcset="img/amp-small.jpg 512w,
             img/amp-medium.jpg 768w,
             img/amp-large.jpg 1280w">
```

The browser downloads only what it needs. If it already loaded a large image and the viewport shrinks, it adapts the existing image instead of downloading smaller ones. If the viewport grows, it downloads a larger candidate when needed.

**Getting more granular with `sizes`**

Use `sizes` when the rendered image width changes across breakpoints:

```html
<img src="image-small.jpg"
     srcset="image-medium.jpg 640w, image-large.jpg 1280w"
     sizes="(min-width: 704px) 50vw, 100vw">
```

This tells the browser that at `704px` and wider, the image occupies `50vw`; otherwise it occupies `100vw`.

For the Legendary Tones image:

```html
<img src="img/amp-xsmall.jpg" class="articleImageFull"
     srcset="img/amp-small.jpg 512w,
             img/amp-medium.jpg 768w,
             img/amp-large.jpg 1280w"
     sizes="(min-width: 704px) 50vw, (min-width: 480px) 75vw, 100vw">
```

Keep `sizes` media queries aligned with your CSS breakpoints unless a tested design reason says otherwise.

### Using The `<picture>` Element

Use `<picture>` when you need art direction: different crops, focal points, or image treatments at different screen widths.

![Figure](/.attachments/5-16-performance-art.direction.png)

_**Figure 5.16.** Art direction image set from the source PDF._
>
> The same subject receives different cropping at different screen widths so the focal point remains visible.

Switch to the `<picture>` branch:

```sh
git checkout picture -f
```

![Figure](/.attachments/5-17-performance-image.behaviours.png)

_**Figure 5.17.** Article image layout comparison from the source PDF._
>
> On small screens, the image is centered between paragraphs; on large screens, it floats right and text wraps around it.

Initial markup:

```html
<picture>
    <img src="img/amp-small.jpg">
</picture>
```

Listing 5.4 shows the `<picture>` element on the Legendary Tones website.

Add image treatments:

```html
<picture>
    <source media="(min-width: 704px)"
            srcset="img/amp-medium.jpg 384w" sizes="33.3vw">
    <source srcset="img/amp-cropped-small.jpg 320w" sizes="75vw">
    <img src="img/amp-small.jpg">
</picture>
```

Listing 5.5 adds new image treatments for different devices with `<picture>`.

The first `<source>` applies at `704px` and wider. The second applies below that. The `<img>` remains required and acts as a fallback.

![Figure](/.attachments/5-18-performance-picture.behaviour.png)

_**Figure 5.18.** Post-`<picture>` behavior comparison from the source PDF._
>
> Small screens receive a different image treatment after the `<picture>` changes.

**Targeting high-DPI displays**

Use `x` density descriptors when selecting images for standard and high-DPI displays:

```html
<picture>
    <source media="(min-width: 704px)"
            srcset="img/amp-medium.jpg 384w,
                    img/amp-large.jpg 512w"
            sizes="33.3vw">
    <source srcset="img/amp-cropped-small.jpg 1x,
                    img/amp-cropped-medium.jpg 2x"
            sizes="75vw">
    <img src="img/amp-small.jpg">
</picture>
```

Listing 5.6 adds high-DPI image candidates. `1x` marks standard-DPI images; `2x` and higher mark high-DPI images.

**Using the `type` attribute for fallback images**

The `<picture>` element can also choose formats by MIME type. This lets you prefer newer formats such as WebP while falling back to JPEG.

```html
<picture>
    <source srcset="img/amp-small.webp" type="image/webp">
    <img src="img/amp-small.jpg">
</picture>
```

Browsers that support WebP use it; others fall back to JPEG. Browsers without `<picture>` support still use the `<img>` fallback.

### Polyfilling Support With Picturefill

`srcset` and `<picture>` are not supported everywhere. Picturefill is an 11 KB polyfill that lets unsupported browsers use the same markup patterns.

Download Picturefill from `https://scottjehl.github.io/picturefill`, or switch to the branch that includes it:

```sh
git checkout picturefill -f
```

In `index.html`, Picturefill appears in the `<head>`:

```html
<script>document.createElement("picture");</script>
<script src="js/picturefill.min.js" async></script>
```

The first script helps older browsers recognize the `<picture>` element before Picturefill loads. The second loads Picturefill asynchronously.

**Conditionally loading Picturefill with Modernizr**

Modern browsers should not download Picturefill unnecessarily. Modernizr (`http://modernizr.com`) can feature-detect `srcset` and `<picture>` support.

Remove the direct Picturefill script and add this before `</body>`:

```html
<script src="js/modernizr.custom.min.js"></script>
<script>
    if(Modernizr.srcset === false || Modernizr.picture === false){
         var picturefill = document.createElement("script");
         picturefill.src = "js/picturefill.min.js";
         document.body.appendChild(picturefill);
    }
</script>
```

If either feature check fails, the code creates a `<script>` element for Picturefill and injects it into the DOM. If both pass, Picturefill is skipped.

### Using SVG In HTML

SVG in HTML provides the same scaling benefits as SVG in CSS when the image content fits the format.

> [!note]
> Inlining SVG can be a useful `HTTP/1` optimization, but it is usually an `HTTP/2` antipattern. Match the technique to the protocol your site uses.

There are two common SVG approaches in HTML.

**Use `<img>`**

Replace the PNG logo:

```html
<img src="img/logo.png" alt="Legendary Tones" id="logo">
```

with:

```html
<img src="img/logo.svg" alt="Legendary Tones" id="logo">
```

When SVG is used through `<img>`, it usually does not need `srcset` or `<picture>` unless it is part of a fallback chain.

**Inline the SVG**

SVG is XML-compatible with HTML, so it can be copied directly into the document. Switch to the inline SVG branch:

```sh
git checkout -f inline-svg
```

Copy only the `<svg>` tag and its contents, not the `<?xml>` header. The result resembles:

```html
<section id="masthead">
    <svg id="logo" xmlns="http://www.w3.org/2000/svg"
         viewBox="0 0 216.7 34">...</svg>
    <h2 id="tagline">Your Source for Great Guitar Tone</h2>
</section>
```

Listing 5.7 shows an inlined SVG in HTML. Inlining can reduce one request on `HTTP/1`, but it also reduces cross-page cacheability. It is often best for SVG content that appears on only one page, such as a vector infographic.
