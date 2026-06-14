# Faster Fonts

This chapter covers:

- Limiting the number of fonts through careful selection
- Rolling your own `@font-face` cascade
- Understanding the benefits of server compression for older font formats
- Limiting font size by subsetting
- Using `unicode-range` to serve font subsets
- Managing font loading through JavaScript APIs

Fonts can make an interface feel polished, but they also add network requests and bytes. This chapter focuses on making fonts cheaper to deliver: choose only the variants you need, provide efficient formats, compress older formats, subset glyphs, and control how text appears while fonts are loading.

## Using Fonts Wisely

The example site for this chapter is a content page for Legendary Tones. Download and run it with:

```sh
git clone https://github.com/webopt/ch7-fonts.git
cd ch7-fonts
npm install
node http.js
```

Open the site at:

```text
http://localhost:8080
```

### Selecting Fonts And Font Variants

The site uses Open Sans. The `css/open-sans` folder contains several font weights, but the page only uses three of them.

> [!figure]
> Figure 7.1 placeholder: Legendary Tones content page annotated with font weights.
>
> The page uses light, regular, and bold variants in different areas of the layout.

| Font weight value | Font variant filename | Use on page? |
| ---: | --- | --- |
| 300 | `OpenSans-Light.ttf` | Yes |
| 400 | `OpenSans-Regular.ttf` | Yes |
| 600 | `OpenSans-SemiBold.ttf` | No |
| 700 | `OpenSans-Bold.ttf` | Yes |
| 800 | `OpenSans-ExtraBold.ttf` | No |

Choosing only the necessary variants is the first and easiest optimization. A full type family can include many weights and styles, but every unused variant is extra page weight.

To skip to the branch used in this section:

```sh
git checkout -f fontface
```

### Rolling Your Own `@font-face` Cascade

Different font formats exist because browser support evolved over time. A useful cascade starts with locally installed fonts, then falls back from newer web formats to older ones.

| Font format | Extension | Browser support |
| --- | --- | --- |
| TrueType | `ttf` | All except IE8 and below |
| Embedded OpenType | `eot` | IE6+ |
| WOFF | `woff` | All except Android Browser 4.3 and below, and IE8 and below |
| WOFF2 | `woff2` | Firefox 39+, Chrome 36+, Opera 23+, Android Browser 4.7+, Chrome and Firefox for Android, Opera Mobile 36+ |

Install the conversion tools:

```sh
npm install -g ttf2eot ttf2woff ttf2woff2
```

Convert the selected TTF files to EOT:

```sh
ttf2eot OpenSans-Light.ttf OpenSans-Light.eot
ttf2eot OpenSans-Regular.ttf OpenSans-Regular.eot
ttf2eot OpenSans-Bold.ttf OpenSans-Bold.eot
```

Convert them to WOFF:

```sh
ttf2woff OpenSans-Light.ttf OpenSans-Light.woff
ttf2woff OpenSans-Regular.ttf OpenSans-Regular.woff
ttf2woff OpenSans-Bold.ttf OpenSans-Bold.woff
```

Convert them to WOFF2:

```sh
cat OpenSans-Light.ttf | ttf2woff2 >> OpenSans-Light.woff2
cat OpenSans-Regular.ttf | ttf2woff2 >> OpenSans-Regular.woff2
cat OpenSans-Bold.ttf | ttf2woff2 >> OpenSans-Bold.woff2
```

On Windows, use `type` instead of `cat`.

Listing 7.1 defines Open Sans Regular with local fonts first, then WOFF2, WOFF, EOT, and TTF:

```css
@font-face{
    font-family: "Open Sans Regular";
    font-weight: 400;
    font-style: normal;
    src: local("Open Sans Regular"),
         local("OpenSans-Regular"),
         url("open-sans/OpenSans-Regular.woff2") format("woff2"),
         url("open-sans/OpenSans-Regular.woff") format("woff"),
         url("open-sans/OpenSans-Regular.eot") format("embedded-opentype"),
         url("open-sans/OpenSans-Regular.ttf") format("truetype");
}
```

Then use it as the first font in the page stack:

```css
font-family: "Open Sans Regular", Helvetica, Arial, sans-serif;
```

> [!figure]
> Figure 7.2 placeholder: browser processing an `@font-face` cascade.
>
> The browser tries local matches first, then walks through the remote sources until it finds a supported format.

Listing 7.2 adds the light and bold variants:

```css
@font-face{
    font-family: "Open Sans Light";
    font-weight: 300;
    font-style: normal;
    src: local("Open Sans Light"),
         local("OpenSans-Light"),
         url("open-sans/OpenSans-Light.woff2") format("woff2"),
         url("open-sans/OpenSans-Light.woff") format("woff"),
         url("open-sans/OpenSans-Light.eot") format("embedded-opentype"),
         url("open-sans/OpenSans-Light.ttf") format("truetype");
}

@font-face{
    font-family: "Open Sans Bold";
    font-weight: 700;
    font-style: normal;
    src: local("Open Sans Bold"),
         local("OpenSans-Bold"),
         url("open-sans/OpenSans-Bold.woff2") format("woff2"),
         url("open-sans/OpenSans-Bold.woff") format("woff"),
         url("open-sans/OpenSans-Bold.eot") format("embedded-opentype"),
         url("open-sans/OpenSans-Bold.ttf") format("truetype");
}
```

Where CSS uses `font-weight: 300`, set `font-family: "Open Sans Light"`. Where it uses `font-weight: 700`, set `font-family: "Open Sans Bold"`.

## Compressing EOT And TTF Font Formats

WOFF and WOFF2 are already compressed internally. EOT and TTF are not, so older browsers that need those formats benefit from server compression.

Listing 7.3 enables compression for TTF and EOT in Apache:

```apache
<IfModule mime_module>
    AddType font/ttf .ttf
    AddType font/eot .eot
</IfModule>
<IfModule mod_deflate.c>
    AddOutputFilterByType DEFLATE font/ttf font/eot
</IfModule>
```

> [!figure]
> Figure 7.3 placeholder: Open Sans Regular before and after compression.
>
> Server compression reduces the uncompressed font formats by roughly 45%, with the measured Open Sans Regular file dropping from about 212.26 KB to 113.76 KB.

Compression has a tradeoff: the server must spend time compressing the response. For large files this can increase time to first byte, so test the real effect before assuming compression is always a net win.

## Subsetting Fonts

Even after choosing only three variants, the fonts still add meaningful weight. In modern browsers that support WOFF2, the three fonts add about 185 KB. In browsers that use WOFF or other older formats, they add about 260 KB.

Subsetting reduces a font to only the characters a page needs. Google Fonts exposes this idea by allowing language-specific subsets.

> [!figure]
> Figure 7.4 placeholder: Google Fonts subsetting by language.
>
> Font services can offer predefined language subsets so users download fewer glyphs.

### Manually Subsetting Fonts

Unicode gives every character a code point. For example, Basic Latin runs from `U+0000` to `U+007F`, and lowercase `p` is `U+0070`.

> [!figure]
> Figure 7.5 placeholder: Unicode table.
>
> The Basic Latin table maps common English characters, punctuation, and digits to Unicode code points.

The chapter uses `fonttools` and its `pyftsubset` command. Check Python and `pip`:

```sh
python --version
pip -V
```

If `pip` is unavailable but Python is installed, install it with:

```sh
easy_install pip
```

Then install `fonttools`:

```sh
pip install fonttools
```

Check the subsetter:

```sh
pyftsubset --help
```

From `css/open-sans`, generate the Basic Latin subset for Open Sans Regular:

```sh
pyftsubset OpenSans-Regular.ttf --unicodes=U+0000-007F \
    --output-file=OpenSans-Regular-BasicLatin.ttf --name-IDs='*'
```

> [!figure]
> Figure 7.6 placeholder: `pyftsubset` command anatomy.
>
> The command names the input font, the Unicode range, the output filename, and `--name-IDs='*'` to preserve name table entries for converter compatibility.

The resulting `OpenSans-Regular-BasicLatin.ttf` is about 17.68 KB, down from about 212.26 KB. That is roughly a 90% reduction before converting to the more efficient web formats.

Convert the subsetted font:

```sh
ttf2eot OpenSans-Regular-BasicLatin.ttf OpenSans-Regular-BasicLatin.eot
ttf2woff OpenSans-Regular-BasicLatin.ttf OpenSans-Regular-BasicLatin.woff
cat OpenSans-Regular-BasicLatin.ttf | ttf2woff2 >> OpenSans-Regular-BasicLatin.woff2
```

Repeat the same process for `OpenSans-Bold.ttf` and `OpenSans-Light.ttf`, then update `@font-face` sources in `styles.css` to reference the subsetted files.

> [!note]
> Subset according to real content. A site that uses words like `cafe` with an accented `e` needs characters outside Basic Latin.

> [!figure]
> Figure 7.7 placeholder: load times before and after font subsetting.
>
> Subsetting improves measured page-load time by well over 200% across TTF with gzip, WOFF, and WOFF2 trials.

### Delivering Font Subsets With `unicode-range`

A multilingual site should avoid sending every language subset to every user. The example adds Russian content, which uses Cyrillic characters. One option is to send the full unsubsetted font, but the better option is to serve only the subsets a page needs.

The `unicode-range` property is declared inside `@font-face`. If page content uses characters in that range, the browser downloads that font. If not, it skips the resource.

Switch to the branch for this section:

```sh
git checkout -f unicoderange
```

The site now contains `index-en.html` and `index-ru.html`.

#### Generating Cyrillic Font Subsets

Generate the Cyrillic subset for Open Sans Regular:

```sh
pyftsubset OpenSans-Regular.ttf --unicodes=U+0400-045F,U+0490-0491,U+04B0-04B1 \
    --output-file=OpenSans-Regular-Cyrillic.ttf --name-IDs='*'
```

Convert it:

```sh
ttf2eot OpenSans-Regular-Cyrillic.ttf OpenSans-Regular-Cyrillic.eot
ttf2woff OpenSans-Regular-Cyrillic.ttf OpenSans-Regular-Cyrillic.woff
cat OpenSans-Regular-Cyrillic.ttf | ttf2woff2 >> OpenSans-Regular-Cyrillic.woff2
```

Repeat the process for `OpenSans-Light.ttf` and `OpenSans-Bold.ttf`, outputting `OpenSans-Light-Cyrillic.ttf` and `OpenSans-Bold-Cyrillic.ttf`.

#### Using The `unicode-range` Property

The Basic Latin subset uses:

```css
unicode-range: U+0000-007F;
```

Listing 7.4 shows valid `unicode-range` forms:

```css
/* Single value */
unicode-range: U+0026;

/* Range */
unicode-range: U+0000-007F;

/* Wildcard range */
unicode-range: U+002?;

/* Multiple values */
unicode-range: U+0000-007F, U+0100, U+02??;
```

Basic Latin still loads on the Russian page because punctuation and numbers are shared by many languages.

> [!figure]
> Figure 7.8 placeholder: Basic Latin subsets loading on the Russian page.
>
> The Russian version still needs Basic Latin characters for shared symbols, so those subsets are correctly downloaded.

Listing 7.5 adds an Open Sans Regular Cyrillic subset:

```css
@font-face{
    font-family: "Open Sans Regular";
    font-weight: 400;
    font-style: normal;
    src: local("Open Sans Regular"),
         local("OpenSans-Regular"),
         url("open-sans/OpenSans-Regular-Cyrillic.woff2") format("woff2"),
         url("open-sans/OpenSans-Regular-Cyrillic.woff") format("woff"),
         url("open-sans/OpenSans-Regular-Cyrillic.eot") format("embedded-opentype"),
         url("open-sans/OpenSans-Regular-Cyrillic.ttf") format("truetype");
    unicode-range: U+0400-045F,U+0490-0491,U+04B0-04B1;
}
```

Add equivalent declarations for the Cyrillic subsets of Open Sans Light and Open Sans Bold.

> [!figure]
> Figure 7.9 placeholder: Russian and English font downloads.
>
> The Russian page downloads both Basic Latin and Cyrillic subsets. The English page skips the Cyrillic subsets because its content does not need them.

This technique is especially useful when languages use substantially different character sets. Greek, Russian, and many Asian languages benefit more than western languages that can often share a broader Latin subset.

#### Fallbacks For Older Browsers

Some browsers ignore `unicode-range` and download every font subset in the stylesheet.

> [!figure]
> Figure 7.10 placeholder: Safari loading Cyrillic subsets on the English page.
>
> Without `unicode-range` support, the browser downloads all font subsets declared in the CSS.

One fallback is to put language-specific `@font-face` declarations in separate stylesheets. The page stores the intended stylesheet URL in `data-href`, then JavaScript checks the `<html lang>` value and activates the correct link only when needed.

Listing 7.6 defers language-specific font subsets with JavaScript:

```html
<!doctype html>
<html lang="ru">
    <head>
        <title>Легендарные Тонизирует - Этого не случится.</title>
        <link rel="stylesheet" href="css/styles.css" type="text/css">
        <link rel="stylesheet" data-href="css/ru.css" data-lang="ru" type="text/css">
        <script>
            (function(document){
                var documentLang = document.querySelector("html").getAttribute("lang"),
                    linkCollection = document.querySelectorAll("link[data-href]");

                for(var i = 0; i < linkCollection.length; i++){
                    var linkLang = linkCollection[i].getAttribute("data-lang"),
                        linkHref = linkCollection[i].getAttribute("data-href");

                    if(documentLang === linkLang){
                        linkCollection[i].setAttribute("href", linkHref);
                    }
                }
            })(document);
        </script>
        <noscript>
            <link rel="stylesheet" href="css/ru.css" type="text/css">
        </noscript>
    </head>
```

Because this script runs early in the document, it adds the needed stylesheet with minimal delay. The `<noscript>` fallback ensures users without JavaScript still receive the needed font subset, though it cannot discriminate as precisely.

> [!figure]
> Figure 7.11 placeholder: Safari network output with the fallback script.
>
> With the fallback script enabled, the English page downloads only the base fonts, while the Russian page downloads `ru.css` and the Cyrillic subsets.

This is less elegant than native `unicode-range`, but it shows the general idea: when CSS support is not enough, you can selectively serve subsets with JavaScript or a server-side language.

## Optimizing The Loading Of Fonts

Fonts affect not only page weight, but also when text becomes readable. Browsers can hide text while a font downloads, show fallback text, or swap fonts after the custom font arrives.

### Understanding Font-Loading Problems

Flash of Invisible Text, or FOIT, happens when text is invisible until a web font has loaded. It becomes more visible on slow or high-latency connections.

> [!figure]
> Figure 7.12 placeholder: fonts still loading and fonts loaded.
>
> Text is initially invisible while fonts load, then appears with the embedded font once loading completes.

Browsers hide text to avoid Flash of Unstyled Text, or FOUT. With FOUT, fallback text appears first and is restyled when the custom font finishes loading.

> [!figure]
> Figure 7.13 placeholder: unstyled text and styled text.
>
> When font downloads take too long, fallback text appears first, then swaps to the custom font.

If the font request stalls, FOIT can leave users waiting seconds for readable content. In some browsers, text can remain hidden until the page is refreshed. The practical response is to embrace controlled FOUT so content is readable as soon as possible.

### Using The CSS `font-display` Property

The `font-display` property controls how font loading affects rendering. In the chapter's source context, support is limited to Chrome, but it is the cleanest first choice when you control the CSS.

Switch branches:

```sh
git checkout font-display
```

To skip ahead:

```sh
git checkout -f font-display-complete
```

Use Chrome Developer Tools with the `Regular 3G` throttling profile to make FOIT visible. The Network panel can capture page-load screenshots.

> [!figure]
> Figure 7.14 placeholder: Capture Screenshots toggle in Chrome Developer Tools.
>
> Captured screenshots help pinpoint when text becomes visible during page load.

`font-display` is placed inside `@font-face` and accepts:

- `auto`: the default, generally similar to `block`.
- `block`: hides text until the associated font is loaded.
- `swap`: shows fallback text first, then swaps in the custom font.
- `fallback`: briefly hides text, then shows fallback text if the font is not ready, and swaps later if possible.
- `optional`: similar to `fallback`, but allows the browser more freedom to skip downloading or applying the font on slow connections.

Listing 7.7 uses `font-display: swap`:

```css
@font-face{
    font-family: "Open Sans Light";
    font-weight: 300;
    font-style: normal;
    src: local("Open Sans Light"),
         local("OpenSans-Light"),
         url("open-sans/OpenSans-Light-BasicLatin.woff2") format("woff2"),
         url("open-sans/OpenSans-Light-BasicLatin.woff") format("woff"),
         url("open-sans/OpenSans-Light-BasicLatin.eot") format("embedded-opentype"),
         url("open-sans/OpenSans-Light-BasicLatin.ttf") format("truetype");
    font-display: swap;
}
```

For more detail, the chapter points to:

```text
https://css-tricks.com/font-display-masses
```

`font-display` is simple, but it only works when the browser supports it and when you control the CSS that declares the fonts. For third-party font providers or broader fallback behavior, use JavaScript.

### Using The Font-Loading API

The font-loading API lets JavaScript control when fonts load and when custom font families are applied. This works whether fonts are self-hosted or served by a provider.

Switch branches:

```sh
git checkout -f font-loader-api
```

To skip ahead:

```sh
git checkout -f font-loader-api-complete
```

The page uses three embedded font families.

| `font-family` | Associated CSS selectors |
| --- | --- |
| `Open Sans Light` | `.navItem a` |
| `Open Sans Regular` | `body` |
| `Open Sans Bold` | `.articleTitle`, `.sectionHeader` |

First, replace those custom font stacks with system fonts:

```css
font-family: "Helvetica", "Arial", sans-serif;
```

Then add CSS that applies custom fonts only after a `fonts-loaded` class exists on `<html>`.

Listing 7.8 controls font display with the `fonts-loaded` class:

```css
.fonts-loaded body{
    font-family: "Open Sans Regular";
}

.fonts-loaded .navItem a{
    font-family: "Open Sans Light";
}

.fonts-loaded .articleTitle,
.fonts-loaded .sectionHeader{
    font-family: "Open Sans Bold";
}
```

Listing 7.9 loads fonts with the font-loading API:

```js
(function(document){
    if(document.fonts){
        document.fonts.load("1em Open Sans Light");
        document.fonts.load("1em Open Sans Regular");
        document.fonts.load("1em Open Sans Bold");

        document.fonts.ready.then(function(fontFaceSet){
            document.documentElement.className += " fonts-loaded";
        });
    }
    else{
        document.documentElement.className += " fonts-loaded";
    }
})(document);
```

The page starts with system fonts, so text appears immediately. The custom fonts are loaded explicitly, and once all specified fonts are ready, the `fonts-loaded` class applies them.

#### Optimizing For Repeat Visitors

On repeat visits, the fonts may already be in the browser cache. To avoid running the font-loading flow again, use a cookie.

Modify the condition to check for the `fonts-loaded` cookie before loading fonts:

```js
if(document.fonts && document.cookie.indexOf("fonts-loaded") === -1){
```

Then set the cookie after adding the class:

```js
document.cookie = "fonts-loaded=";
```

When the cookie exists, the script can apply `fonts-loaded` immediately. This may reintroduce FOIT, but the risk is lower because the fonts are cached.

You can also add the class server-side. Listing 7.10 does this in PHP:

```php
<?php if(isset($_COOKIE["fonts-loaded"])){
    ?><html class="fonts-loaded">
<?php }
else {
    ?><html>
<?php } ?>
```

#### Accommodating Users With JavaScript Disabled

Without JavaScript, the `fonts-loaded` class is never added. If you want those users to receive the custom fonts through normal browser behavior, use `<noscript>`.

Listing 7.11 provides a `<noscript>` alternative:

```html
<noscript>
    <style>
        body{
            font-family: "Open Sans Regular", "Helvetica", "Arial", sans-serif;
        }

        .navItem a{
            font-family: "Open Sans Light", "Helvetica", "Arial", sans-serif;
        }

        .articleTitle,
        .sectionHeader{
            font-family: "Open Sans Bold", "Helvetica", "Arial", sans-serif;
        }
    </style>
</noscript>
```

### Using Font Face Observer As A Fallback

The font-loading API is not universal. Font Face Observer provides similar font-loading control in browsers that lack the native API.

Project:

```text
https://github.com/bramstein/fontfaceobserver
```

Switch branches:

```sh
git checkout -f fontface-observer
```

The branch includes `js/fontfaceobserver.min.js` and `js/fontloading.js`.

Listing 7.12 conditionally loads Font Face Observer and the fallback script:

```js
else if(!document.fonts && document.cookie.indexOf("fonts-loaded") === -1){
    var fontFaceObserverScript = document.createElement("script"),
        fontLoadingScript = document.createElement("script");

    fontFaceObserverScript.src = "js/fontfaceobserver.min.js";
    fontLoadingScript.src = "js/fontloading.js";

    fontFaceObserverScript.defer = "defer";
    fontLoadingScript.defer = "defer";

    document.head.appendChild(fontFaceObserverScript);
    document.head.appendChild(fontLoadingScript);
}
```

Listing 7.13 uses Font Face Observer to control font loading:

```js
document.onreadystatechange = function(){
    var openSansLight = new FontFaceObserver("Open Sans Light"),
        openSansRegular = new FontFaceObserver("Open Sans Regular"),
        openSansBold = new FontFaceObserver("Open Sans Bold");

    Promise.all([
        openSansLight.load(),
        openSansRegular.load(),
        openSansBold.load()
    ]).then(function(){
        document.documentElement.className += " fonts-loaded";
        document.cookie = "fonts-loaded=";
    });
};
```

The fallback mirrors the native API approach: wait for all font variants, add `fonts-loaded`, and set the cookie so subsequent pages can apply the fonts immediately.
