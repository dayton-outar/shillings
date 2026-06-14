# Understanding Critical CSS

This chapter covers:

- Understanding critical CSS and the problem it solves
- Understanding how critical CSS works
- Using critical CSS in projects
- Knowing the benefits of critical CSS before and after implementation

Critical CSS is an advanced CSS optimization technique that improves perceived page speed by prioritizing the styles needed for above-the-fold content. The goal is simple: let the browser paint the visible part of the page sooner.

## What Does Critical CSS Solve?

Critical CSS changes how CSS is loaded. Instead of treating every style as equally urgent, it prioritizes the styles needed for content visible at initial load and delays the rest until after rendering can begin.

### Understanding The Fold

The fold comes from print media. Newspapers place the lead story at the top of the front page so that it remains visible when papers are folded and bundled.

On the web, the fold is not fixed. It changes with screen resolution, device orientation, and browser window size.

> [!figure]
> Figure 4.1 placeholder: above-the-fold and below-the-fold device diagram from the source PDF.
>
> Above-the-fold content starts at the top of the page and ends at the bottom of the visible screen. Everything outside the browser's initial view is below the fold.

Critical CSS divides styles into two categories:

- Critical CSS, or above-the-fold CSS: styles needed for content the user sees immediately
- Noncritical CSS, or below-the-fold CSS: styles for content users do not see until scrolling

The critical styles should load first. Noncritical styles should still load quickly, but not before they have to.

### Understanding Render Blocking

Render blocking is any activity that prevents the browser from painting content during initial page load. CSS render blocking exists partly to prevent a Flash of Unstyled Content, where users briefly see an unstyled page before CSS applies.

Some render blocking is useful, but too much delays content. External CSS loaded through `@import` or `<link>` blocks rendering. Chapter 3 explains why `<link>` is better than `@import`, but `<link>` still blocks initial rendering.

To see this, open the Coyle Appliance Repair site from chapter 1, load it while recording in Chrome's Timeline profiler, switch to the `Event Log`, and filter to painting events. The Time to First Paint appears there.

> [!figure]
> Figure 4.2 placeholder: Chrome Timeline first paint screenshot from the source PDF.
>
> Chrome's Timeline profiler shows the document's first painting event, with a first paint time around `860 ms`.

Inlining the site's CSS inside `<style>` tags in `index.html` improves first paint time.

> [!figure]
> Figure 4.3 placeholder: improved first paint screenshot from the source PDF.
>
> Chrome's Timeline profiler shows improved first paint after the site's CSS is inlined into the HTML.

Inlining all CSS can be reasonable for a single-page website, but it is incomplete for larger sites. It sacrifices caching and duplicates CSS across page loads.

> [!note]
> Inlining is suitable for `HTTP/1` clients and servers, but should generally be avoided on `HTTP/2` servers when server push can provide similar benefits while preserving cacheability. Chapter 11 covers `HTTP/2` server push.

## How Does Critical CSS Work?

Critical CSS separates above-the-fold styles from the rest of the page styles. Above-the-fold styles are inlined into the HTML. Below-the-fold styles are loaded asynchronously.

### Loading Above-The-Fold Styles

Inlining CSS into a `<style>` tag removes the wait for an external stylesheet request.

> [!figure]
> Figure 4.4 placeholder: inline above-the-fold style example from the source PDF.
>
> CSS for above-the-fold content is inlined into the HTML so it can be parsed and applied as soon as the HTML arrives.

Example:

```html
<style>
  header{
    max-width: 64rem;
    width: 100%;
    ...
  }
</style>
```

The drawback is duplication. If all CSS is inlined, repeat page views lose the caching benefits of external stylesheets. Critical CSS limits the duplication to a smaller, meaningful set: the styles needed to paint the initially visible content.

### Loading Below-The-Fold Styles

Below-the-fold CSS is still loaded with a `<link>` element, but not as a normal blocking stylesheet. Instead, use the `preload` resource hint and a small JavaScript assist.

> [!figure]
> Figure 4.5 placeholder: preload CSS loading example from the source PDF.
>
> A `preload` resource hint loads external CSS without blocking rendering, then an `onload` handler changes `rel` to `stylesheet` once the file is ready.

```html
<link rel="preload" href="css/styles.min.css" as="style"
      onload="this.rel='stylesheet'">
```

This loads CSS without blocking rendering. When the file finishes downloading, the `onload` handler changes `rel` from `preload` to `stylesheet`, applying the CSS to the rest of the page.

Because some browsers do not support `preload`, the chapter uses Filament Group's `loadCSS` polyfill. Chapter 10 covers resource hints more broadly.

## Implementing Critical CSS

The implementation example uses a single page from a mobile-first responsive recipe website. The workflow is:

1. Set up the website locally.
2. Identify above-the-fold CSS for each breakpoint.
3. Move above-the-fold CSS out of the main CSS and inline it into the HTML.
4. Use `preload` to load the rest of the CSS without blocking rendering.

### Getting The Recipe Website Up And Running

The example uses Git, npm, Node, and LESS. SASS users should find the workflow familiar; the specific preprocessor matters less than the critical CSS process.

Clone and run the recipe site:

```sh
git clone https://github.com/webopt/ch4-critical-css.git
cd ch4-critical-css
npm install
node http.js
```

The site runs at:

```text
http://localhost:8080
```

> [!figure]
> Figure 4.6 placeholder: recipe website screenshot from the source PDF.
>
> The recipe website in Chrome at the tablet breakpoint, roughly 750 pixels wide.

Use Chrome's Timeline tool with the `Regular 3G` throttling profile to capture Time to First Paint before and after the work. The expected improvement is roughly 30%-40%.

**Project structure**

The site uses this structure:

- `index.html`: the page HTML at the project root
- `js/scripts.min.js`: site behavior
- `js/loadcss.min.js`: async CSS loading helper
- `js/cssrelpreload.min.js`: `preload` resource hint polyfill
- `less/main.less`: generates `css/styles.min.css`
- `less/critical.less`: generates `css/critical.min.css`
- `less/components/`: componentized breakpoint files

Global component files initially contain all styles:

- `global_small.less`
- `global_medium.less`
- `global_large.less`

Critical component files start empty and receive above-the-fold CSS:

- `critical_small.less`
- `critical_medium.less`
- `critical_large.less`

### Identifying And Separating Above-The-Fold CSS

The first task is identifying the fold and then moving critical component styles from global LESS files into critical LESS files.

**Identifying the fold**

Above-the-fold content is whatever is visible when the page first loads. The hard part is that different users have different viewport heights.

The chapter recommends checking common device resolutions at `http://mydevice.io/devices` and sorting by CSS height.

> [!figure]
> Figure 4.7 placeholder: mydevice.io resolution chart from the source PDF.
>
> Common device resolutions sorted by CSS height.

To visualize fold positions, the chapter uses the VisualFold bookmarklet at `http://jlwagner.net/visualfold`. Add guides at common vertical positions:

```text
480, 667, 768, 800, 900, 1024, 1280
```

> [!figure]
> Figure 4.8 placeholder: VisualFold bookmarklet screenshot from the source PDF.
>
> VisualFold draws horizontal guidelines at entered pixel positions so you can see how content falls across viewport sizes.

For the recipe site, `1280px` is a reasonable fold threshold. It covers the recipe steps section and the right-column content in larger breakpoints.

**Identifying the critical components**

At the mobile breakpoint, identify all components above the `1280px` guideline.

> [!figure]
> Figure 4.9 placeholder: mobile breakpoint critical component labels from the source PDF.
>
> The mobile breakpoint labeled with critical components such as header, content hubs, recipe title, recipe image, recipe attributes, social buttons, recipe description, ingredient list, banner ad, and recipe steps.

At the large breakpoint, new above-the-fold components appear in the two-column layout.

> [!figure]
> Figure 4.10 placeholder: large breakpoint critical component labels from the source PDF.
>
> The large breakpoint labels additional critical components such as main column, right column, content list, collection list, and right-column ad.

The chapter notes that this manual process can be automated with Filament Group's CriticalCSS Node program at `https://github.com/filamentgroup/criticalCSS`, but the example performs the identification manually.

**Separating the critical CSS**

Move critical styles out of the breakpoint-specific global includes referenced by `main.less`, and into the includes referenced by `critical.less`.

First, move `reset.less` from line 2 of `main.less` to line 2 of `critical.less`. The reset is derived from Eric Meyer's CSS reset (`http://meyerweb.com/eric/tools/css/reset`), and because all elements inherit from it, it is critical.

Compile LESS after changes:

- UNIX-like systems: run `less.sh` at the project root
- Windows: run `less.bat`

Before moving styles, comment out line 7 of `index.html`, the `<link>` tag that loads the normal stylesheet. This leaves the page unstyled and makes critical CSS easier to inspect when `critical.min.css` is inlined.

Table 4.1 maps critical components to parent selectors.

| Critical component | Related parent container selector |
| --- | --- |
| Site header | `header` |
| Content hubs | `.destinations` |
| Recipe title | `.recipeName` |
| Content container | `#content` |
| Recipe image | `#masthead` |
| Recipe attributes | `.attributes` |
| Social buttons | `.actions` |
| Recipe description | `.description` |
| Section header | `.sectionHeader` |
| Ingredient List | `.ingredientList` |
| Banner ad | `.ad` |
| Recipe steps | `.stepList` |
| Main column | `#mainColumn` |
| Right column | `aside` |
| Content list/collection list | `.contentList` |
| Right column ad | `.ad` |

Start with the header:

1. Open `global_small.less`.
2. Find the `header` selector.
3. Cut it from `global_small.less`.
4. Paste it into `critical_small.less`.
5. Save and rebuild `main.less`.
6. Copy `css/critical.min.css` into `<style>` tags in the `<head>` of `index.html`.

> [!figure]
> Figure 4.11 placeholder: partially styled header screenshot from the source PDF.
>
> After inlining only the `header` selector CSS, the header is partially styled but missing child styles.

The header contains child elements with their own styles. Move those related selectors too:

- `#logo`
- `#innerHeader`
- `nav`
- `nav:hover .nav`
- `#navIcon`
- `#navIcon > div`
- `.nav`
- `.show`
- `.navItem`

After moving these selectors into `critical_small.less`, rebuild and re-inline `critical.min.css`.

> [!figure]
> Figure 4.12 placeholder: fully styled header screenshot from the source PDF.
>
> The header appears fully styled after all header-related critical CSS is inlined into `index.html`.

Repeat this process across `global_medium.less` and `global_large.less`, moving header-related styles into the appropriate critical files. Then repeat for every component in Table 4.1. Each time, rebuild and re-inline `critical.min.css`.

To skip to the completed critical CSS state:

```sh
git checkout -f criticalcss
```

### Loading Below-The-Fold CSS

After critical styles are separated and inlined, load the remaining `styles.min.css` asynchronously.

**Loading CSS asynchronously with the preload resource hint**

Remove any old stylesheet `<link>` in `index.html`, then add this after the inlined critical CSS:

```html
<link rel="preload"
      href="css/styles.min.css"
      as="style"
      onload="this.rel='stylesheet'">
<noscript><link rel="stylesheet" href="css/styles.min.css"></noscript>
```

Listing 4.1 uses the `preload` resource hint to asynchronously load a CSS file. The `<noscript>` fallback loads the stylesheet normally for users without JavaScript. Those users still get render-blocking CSS, but not an unstyled page.

**Polyfilling the preload resource hint**

Not all browsers support `preload`, especially outside Chromium-based browsers. Use Filament Group's `loadCSS` polyfill from `https://github.com/filamentgroup/loadcss`.

The recipe repo includes:

- `js/cssrelpreload.min.js`: polyfills `preload`
- `js/loadcss.min.js`: provides async CSS-loading behavior when `preload` is unavailable

Do not include these as external `<script>` tags, because that would block rendering. Inline them inside one `<script>` tag after the preload markup, with `loadcss.min.js` first and `cssrelpreload.min.js` second.

Test in a browser without native `preload` support, such as Safari, and confirm that below-the-fold CSS still renders.

## Weighing The Benefits

Chrome testing across throttling profiles shows a clear Time to First Paint improvement after implementing critical CSS.

> [!figure]
> Figure 4.13 placeholder: Time to First Paint benchmark chart from the source PDF.
>
> Time to First Paint in Chrome before and after critical CSS across GPRS, 2G, 3G, 4G, and DSL profiles. Lower is better.

The benefit is largest on slow, high-latency connections and smaller on faster connections. That pattern is typical for front-end optimizations.

On mobile devices accessing the recipe website from a shared host, the improvement was more modest, around 20%.

> [!figure]
> Figure 4.14 placeholder: Mobile Safari Time to First Paint benchmark chart from the source PDF.
>
> Time to First Paint in Mobile Safari on an iPhone 6S over cable and LTE before and after prioritizing critical CSS.

A useful benchmark is `0.1 seconds`, the threshold where an interface feels instantaneous. Critical CSS helps users feel that the page is responding sooner, which can increase the chance they stay.

## Making Maintainability Easier

The main maintainability problem with critical CSS is manual inlining. Copying `critical.min.css` and polyfill scripts into the HTML every time they change is tedious.

A server-side language can inline those files automatically. PHP's `file_get_contents()` is one option:

```php
<style>
    <?php echo(file_get_contents("./css/critical.min.css")); ?>
</style>
<link rel="preload" href="css/styles.min.css" as="style"
      onload="this.rel='stylesheet'">
<noscript><link rel="stylesheet" href="css/styles.min.css"></noscript>
<script>
    <?php
    echo(file_get_contents("./js/loadcss.min.js"));
    echo(file_get_contents("./js/cssrelpreload.js"));
    ?>
</script>
```

Listing 4.2 uses PHP to inline a stylesheet and the preload polyfills on the server side. Other server-side technologies usually provide equivalent file-read functionality.

## Considerations For Multipage Websites

On multipage sites, critical CSS should be modular. Different templates have different above-the-fold content, so each template should inline only its own critical styles.

Some critical styles are global, such as headers, navigation, and headline styles. Those can be bucketed separately and inlined across all templates.

> [!figure]
> Figure 4.15 placeholder: modular critical CSS diagram from the source PDF.
>
> Template A and Template B inline their own critical CSS, while both also inline globally common critical styles.

For larger sites, avoid combining every template's critical CSS into every page. Use analytics to prioritize high-value pages and templates first, because critical CSS takes effort and the biggest wins should come first.
