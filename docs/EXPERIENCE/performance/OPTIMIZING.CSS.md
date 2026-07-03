# Optimizing CSS

This chapter covers:

- Reducing CSS size with shorthand properties, shallow selectors, and the DRY principle
- Segmenting CSS by page template
- Understanding why mobile-first responsive design matters
- Knowing what makes a page mobile-friendly and why that matters to Google search rankings
- Improving CSS performance by avoiding bad practices, using faster selectors, using flexbox, and using CSS transitions

After learning how to assess performance with browser developer tools, CSS is a natural first target for optimization. CSS affects both download time and rendering time, so efficient CSS can make a site lighter, faster, and easier for the browser to draw.

## Don't Talk Much And Stay DRY

CSS optimization starts with discipline. Write less CSS where you can, avoid needless selector specificity, remove repeated declarations, and keep framework code lean. These practices reduce transfer size and can also make styles easier to maintain.

### Write Shorthand CSS

Shorthand CSS uses less verbose properties and values. The savings from one rule may be small, but repeated across a large stylesheet, they add up.

![Figure](/.attachments/)

_**Figure 3.1.** shorthand CSS comparison from the source PDF._
>
> A set of longhand font properties is replaced with a single shorthand `font` property, shrinking the rule by about 35%.

The chapter returns to the Coyle Appliance Repair site. Download and run it locally:

```sh
git clone https://github.com/webopt/ch3-css.git
cd ch3-css
npm install
node http.js
```

Open `css/styles.css`. A verbose margin rule might look like this:

```css
div.pageWrapper{
    width: 100%;
    max-width: 906px;
    margin-top: 0;
    margin-right: auto;
    margin-bottom: 0;
    margin-left: auto;
}
```

The `margin` shorthand can replace the four directional margin properties:

![Figure](/.attachments/)

_**Figure 3.2.** margin shorthand diagram from the source PDF._
>
> The `margin` shorthand accepts one to four values for top, right, bottom, and left.

Use shorthand values like this:

- One value: all four sides use the same value, such as `margin: 20px;`
- Two values: top/bottom and right/left share values, such as `margin: 10px 20px;`
- Three values: top is unique, right/left share a value, and bottom is unique, such as `margin: 10px 20px 30px;`
- Four values: every side is unique

The wrapper rule can become:

```css
div.pageWrapper{
    width: 100%;
    max-width: 906px;
    margin: 0 auto;
}
```

Another example:

```css
header div.phoneNumber h1.number{
    font-size: 55px;
    font-weight: normal;
    color: #fff;
    margin-top: 0;
    margin-right: 0;
    margin-bottom: -8px;
    margin-left: 0;
}
```

can become:

```css
header div.phoneNumber h1.number{
    font-size: 55px;
    font-weight: normal;
    color: #fff;
    margin: 0 0 -8px;
}
```

Borders can also be shortened:

```css
a img{
    border-top: 0;
    border-right: 0;
    border-bottom: 0;
    border-left: 0;
}
```

becomes:

```css
a img{
    border: 0;
}
```

Use shorthand thoughtfully. If a new context needs to override only one part of a shorthand value, prefer the specific property. For example, override `margin-bottom` instead of copying a whole `margin` declaration and changing one value.

The chapter focuses on `margin`, `padding`, `border`, `background`, and `border-radius`. A broader shorthand reference is available at `www.w3.org/community/webed/wiki/CSS_shorthand_reference`.

After applying shorthand properties, the client CSS can shrink from 18.5 KB to 13.33 KB. To see the completed exercise state:

```sh
git checkout -f shorthand
```

### Use Shallow CSS Selectors

Selector shallowness means using only as much specificity as needed. Deep selectors are longer, harder to maintain, and can cost more during rendering. Shallow selectors are shorter and usually clearer.

![Figure](/.attachments/)

_**Figure 3.3.** selector specificity comparison from the source PDF._
>
> An overqualified selector is compared with a shallow selector for the same element. The longer selector is 67 characters; the shorter one is 12.

### Culling Shallow Selectors

To find overqualified selectors, scan for selectors with multiple element levels. Use only the specificity needed to match the target element.

For example, this selector:

```css
header div.phoneNumber h3.numberHeader
```

can often be reduced to:

```css
.numberHeader
```

After each substantial selector cleanup, reload the page and verify that nothing broke. To see the completed selector cleanup:

```sh
git checkout -f selectors
```

You can also use `uncss` to remove unused CSS. From the root folder of the client site:

```sh
npm install -g uncss
uncss http://localhost:8080 -i .modal.open > css/styles.clean.css
```

The `-i` option tells `uncss` to keep selectors that might not appear during static page inspection. Here, `.modal.open` is needed for the modal animation.

After switching `index.html` to `styles.clean.css`, or copying the generated CSS back into `styles.css`, the client CSS drops from 13.24 KB to 8.2 KB, a 38% reduction.

### LESS Is More And Taming SASS

CSS precompilers such as LESS (`http://lesscss.org`) and SASS (`http://sass-lang.com`) add variables, mixins, imports, and nesting. They compile down to plain CSS for browsers.

Nested selectors can be convenient, but can also generate overly specific CSS.

```scss
#main{
     max-width: 1280px;
     width: 100%;

     #mainColumn{
          width: 65%;
          margin: 0 2% 0 0;
          display: inline-block;
          float: left;
     }

     #sideColumn{
          width: 33%;
          display: inline-block;
          float: left;
     }
}
```

Listing 3.1 shows LESS and SASS selector nesting.

Compiled CSS becomes:

```css
#main{
     max-width: 1280px;
     width: 100%;
}

#main #mainColumn{
     width: 65%;
     margin: 0 2% 0 0;
     display: inline-block;
     float: left;
}

#main #sideColumn{
     width: 33%;
     display: inline-block;
     float: left;
}
```

Listing 3.2 shows how nested selectors compile into more specific selectors. Compression and minification help with size, but not with the needless specificity itself. Limit nesting where practical.

### Don't Repeat Yourself

CSS often repeats identical properties across selectors. Repeated background colors, font styles, borders, and spacing rules create bloat and make maintenance harder.

### Going DRY

The DRY principle reduces redundancy wherever practical.

![Figure](/.attachments/)

_**Figure 3.4.** DRY principle example from the source PDF._
>
> Two selectors with the same `background` property are combined to save space and reduce repetition.

One approach is to identify common properties, then group selectors that share them. Selector naming can be content-oriented, such as `#navigation` or `.siteHeader`, or presentational, as in many framework classes. Either style can still use DRY.

### Finding Redundancies With csscss

`csscss` is a command-line tool for finding repeated CSS declarations. It requires Ruby's `gem` installer. macOS includes Ruby by default, and SASS users may already have `gem`.

Install `csscss`:

```sh
gem install csscss
```

Run it against the client stylesheet:

```sh
csscss styles.css -v --no-match-shorthand
```

The `-v` flag prints matching rules. The `--no-match-shorthand` flag prevents the tool from expanding shorthand properties into more explicit forms.

Example output:

```text
{#okayButton}, {#schedule} AND {.submitAppointment a} share 12 declarations
  - background: #c40a0a
  - border-bottom: 4px solid #630505
  - border-radius: 8px
  - color: #fff
  - display: inline-block
  - font-size: 20px
  - font-weight: 700
  - letter-spacing: -0.5px
  - line-height: 22px
  - padding: 12px 16px
  - text-decoration: none
  - text-transform: uppercase
```

Listing 3.3 shows a portion of `csscss` output.

Combine the repeated selectors:

```css
#okayButton,
#schedule,
.submitAppointment a{
    background: #c40a0a;
    border-bottom: 4px solid #630505;
    border-radius: 8px;
    color: #fff;
    display: inline-block;
    font-size: 20px;
    font-weight: 700;
    letter-spacing: -0.5px;
    line-height: 22px;
    padding: 12px 16px;
    text-decoration: none;
    text-transform: uppercase;
}
```

Listing 3.4 combines the CSS rule from `csscss` output.

Then remove the duplicated declarations from the original selectors, rerun `csscss`, and repeat.

Some output is less straightforward, especially across responsive breakpoints:

```text
{.greyStrip} AND {.phoneNumber} share 5 declarations
  - position: absolute
  - position: static
  - right: 0
  - right: auto
  - top: auto
```

Listing 3.5 shows problematic `csscss` output. Responsive CSS can contain different repeated values in different breakpoints, so combine only what is common across all relevant contexts.

After DRY cleanup, the stylesheet can shrink another 10%, to 7.42 KB. Across the chapter so far, the client CSS has dropped from 18.5 KB to 7.42 KB, roughly a 60% reduction.

### Segment CSS

CSS segmentation splits styles by page template. A single combined CSS file can help with caching if users navigate broadly, but it can also make first-time visitors download CSS for pages they never view.

![Figure](/.attachments/)

_**Figure 3.5.** segmented CSS navigation flow from the source PDF._
>
> A user requests `index.html` and downloads `styles.css`; only if the user navigates to `about.html` does the browser download `about.css`.

A data-driven segmentation strategy uses analytics. In Google Analytics, open the `Behavior` section and choose `Behavior Flow`.

![Figure](/.attachments/)

_**Figure 3.6.** Google Analytics Behavior menu screenshot from the source PDF._
>
> The `Behavior Flow` option appears in the `Behavior` submenu.

![Figure](/.attachments/)

_**Figure 3.7.** Google Analytics visitor flow chart from the source PDF._
>
> The visitor flow chart shows entry pages and subsequent navigation paths.

If most users land on the main page and few visit subpages, move subpage-specific CSS into separate files loaded only on those pages. If most templates are similar and styles are generalized, one stylesheet may still be best.

### Customize Framework Downloads

CSS frameworks can save development time, but unused framework code costs users bandwidth and parsing work. Frameworks such as Bootstrap and Foundation allow customized downloads.

![Figure](/.attachments/)

_**Figure 3.8.** Bootstrap customization screen from the source PDF._
>
> Bootstrap lets developers choose which framework features to include in a custom download.

Remove framework pieces you do not need, such as print CSS or table styles. After a project is built, prune anything still unused.

## Mobile-First Is User-First

Responsive web design uses one set of markup and changes presentation with CSS media queries. Those queries usually respond to viewport width with `min-width` or `max-width`.

### Mobile-First Vs. Desktop-First

Mobile-first and desktop-first are the two main responsive design approaches.

![Figure](/.attachments/)

_**Figure 3.9.** responsive design flow diagram from the source PDF._
>
> Mobile-first starts with mobile defaults and adds complexity as width increases. Desktop-first starts with desktop defaults and removes complexity as width decreases.

Both approaches start with foundational CSS outside media queries. In mobile-first CSS, those defaults are the mobile layout. In desktop-first CSS, they are the desktop layout.

Mobile-first is more user-focused because it starts from the least complex presentation and adds complexity as devices get more capable.

![Figure](/.attachments/)

_**Figure 3.10.** mobile versus desktop traffic chart from the source PDF._
>
> Mobile internet traffic approached half of all traffic by late 2015, according to StatCounter Global Stats.

Mobile devices often have less CPU and memory than desktops. They should not have to apply desktop styles, interpret media queries, and then override back down to mobile. Mobile-first CSS lets the least capable devices do the least work.

Most projects target three broad device classes: phones, tablets, and desktops. In mobile-first CSS, phone styles are the foundation, then tablet and desktop styles are added through breakpoints.

![Figure](/.attachments/)

_**Figure 3.11.** mobile-first breakpoint diagram from the source PDF._
>
> Layout complexity increases with screen resolution, using breakpoints such as `37.5em` and `62.5em`.

The chapter uses `em` units for breakpoints. Convert pixels to ems with:

```text
px / default font size = em
```

For example:

- `600px / 16px = 37.5em`
- `1000px / 16px = 62.5em`

`em` is context-specific. In media queries, the context is the default document font size. `rem` always refers to the root font size, but older browser support may affect whether it is safe for a project.

A mobile-first boilerplate:

```css
/* CSS resets should go here. */

html{
    font-size: 16px;
}

/* Mobile styles should go here. */

@media screen and (min-width: 37.5em){ /* 600px / 16px */
    /* Tablet styles should go here. */
}

@media screen and (min-width: 62.5em){ /* 1000px / 16px */
    /* Desktop styles should go here. */
}
```

Listing 3.6 shows a mobile-first CSS boilerplate.

Place resets first, then mobile defaults, then tablet styles, then desktop styles. Eric Meyer's CSS reset is available at `http://meyerweb.com/eric/tools/css/reset`.

Pick breakpoints based on the design, not on famous device widths. Resize until the layout breaks, add a breakpoint, and fix the layout there.

Include responsive CSS normally with a `<link>` tag, and add the viewport meta tag inside `<head>`:

```html
<meta name="viewport" content="width=device-width,initial-scale=1">
```

This tells the browser to render the page at the device screen width and start at 100% scale. Avoid disabling zoom because it can create accessibility problems.

### Mobilegeddon

In February 2015, Google announced a ranking change that took effect two months later. Mobile search results began favoring mobile-friendly sites. This pushed developers and content owners toward better mobile experiences.

### Using Google's Mobile-Friendly Guidelines

Google looks for two major signs of a good mobile experience:

- A properly configured viewport
- Responsiveness to viewport size

The viewport meta tag lets browsers size content to the device screen.

![Figure](/.attachments/)

_**Figure 3.12.** viewport comparison screenshot from the source PDF._
>
> A responsive site without the `<meta>` viewport tag forces users to zoom out; the same site with the tag displays correctly.

The page should also adapt to the viewport without horizontal scrolling. Google also checks other details, including legible type sizes and tap target spacing.

### Verifying A Site's Mobile-Friendliness

Google's Mobile-Friendly Test is available at `https://www.google.com/webmasters/tools/mobile-friendly/`.

![Figure](/.attachments/)

_**Figure 3.13.** Google Mobile-Friendly Test result screenshot from the source PDF._
>
> The Mobile-Friendly Test reports whether a page passes and lists issues when it fails.

If a site fails, start by adding the viewport meta tag and making the site responsive across device sizes.

## Performance-Tuning Your CSS

After reducing CSS size and adopting mobile-first design, tune CSS loading and rendering behavior.

### Avoiding The @import Declaration

Avoid `@import` in regular CSS. Unlike `<link>`, an `@import` inside a stylesheet is not discovered until that stylesheet downloads. This delays loading.

### @import Serializes Requests

Parallel requests happen at roughly the same time. Serialized requests happen one after another. `@import` serializes stylesheet requests when used inside an external CSS file.

![Figure](/.attachments/)

_**Figure 3.14.** serialized stylesheet request diagram from the source PDF._
>
> `styles.css` downloads first; only after it is parsed does the browser discover `@import url("fonts.css")` and request `fonts.css`.

Example:

```css
@import url("fonts.css");
```

Bundle same-type files where possible. When bundling is impractical, use HTML `<link>` tags instead of CSS `@import`.

### `<link>` Parallelizes Requests

The `<link>` tag is the best native method for loading CSS. The browser discovers stylesheet links while scanning HTML and can request them in parallel.

![Figure](/.attachments/)

_**Figure 3.15.** parallel stylesheet request diagram from the source PDF._
>
> Two stylesheet requests made with `<link>` tags can begin at the same time after the HTML is scanned.

In LESS and SASS, `@import` is different: the compiler uses it to bundle source files during development. The warning here applies to `@import` in regular browser-loaded CSS.

### Placing CSS In The `<head>`

Load CSS as early as possible by placing stylesheet `<link>` tags in the document `<head>`. This prevents flashes of unstyled content and improves rendering performance.

### Preventing The Flash Of Unstyled Content

A Flash of Unstyled Content happens when users briefly see a page before CSS applies.

![Figure](/.attachments/)

_**Figure 3.16.** Flash of Unstyled Content rendering timeline from the source PDF._
>
> Chrome briefly renders unstyled content because a stylesheet `<link>` is placed at the end of the document.

Browsers read HTML from top to bottom. If CSS is linked late, the browser can render the unstyled page first. Place CSS links in `<head>` to avoid this.

### Increasing Rendering Speed

CSS in `<head>` also speeds initial rendering. If CSS loads late, the browser may have to re-render and repaint the whole DOM.

![Figure](/.attachments/)

_**Figure 3.17.** rendering performance chart from the source PDF._
>
> Rendering and painting times are lower when CSS is included in `<head>` rather than at the end of the HTML document.

If you see stylesheet links outside `<head>`, move them into `<head>`.

### Using Faster Selectors

Simpler selectors save bytes and can help rendering. The chapter uses a benchmark at `http://jlwagner.net/webopt/ch03-selectors` to compare selector types.

### Constructing And Running The Benchmark

The selector benchmark uses several HTML files with identical structure and appearance but different selector types.

![Figure](/.attachments/)

_**Figure 3.18.** selector benchmark document structure from the source PDF._
>
> The test document contains a `div.contentContainer`, repeated sections, lists, and about 21,000 total elements.

Run each test by opening the console and executing:

```js
bench()
```

The test stores `div.contentContainer.innerHTML`, then removes and reinserts the content 100 times through chained `setTimeout` calls. Chrome's Timeline records the resulting rendering and painting activity.

Table 3.1 lists selector types used in the test.

| Selector type | Test case example, with `<li>` targeted |
| --- | --- |
| Tag | `li` |
| Descendant | `section ul li` |
| Class | `.listItem` |
| Direct child | `section > ul > li` |
| Overqualified | `div.contentContainer section.column ul.list li.listItem` |
| Sibling | `li + li` |
| Pseudo | `li:nth-child(odd)`, `li:nth-child(even)` |
| Attribute | `[data-list-item]` |

### Examining The Benchmark Results

Painting time was roughly 200 ms on average across tests, only about 1%-2% of total time. Rendering dominated.

![Figure](/.attachments/)

_**Figure 3.19.** CSS selector performance chart from the source PDF._
>
> Most selector types perform similarly, while sibling, pseudo-class, and attribute selectors are more expensive.

Treat the benchmark as a loose guideline. Real project profiling matters more. ID selectors were not benchmarked because IDs are usually unique and less representative of repeated page styling.

### Using Flexbox Where Possible

Traditional layout often depends on floats, display changes, margins, and padding. Flexbox is a modern layout engine that handles spacing, alignment, and justification on both axes. It is often simpler and can perform better.

### Comparing Box Model And Flexbox Styles

The benchmark compares two documents: one using box-model layout, one using flexbox. Each renders a four-column gallery from a single `<ul>` containing more than 3,000 `<li>` elements. The test is available at `http://jlwagner.net/webopt/ch03-box-model-vs-flexbox`, and can be run with:

```js
bench()
```

Box-model styling:

```css
.list{
     margin: 0 auto;
     width: 100%;
     font-size: 0;
}

.item{
     width: 24.25%;
     list-style: none;
     border: .0625rem solid #000;
     margin: 0 1% 1rem 0;
     display: inline-block;
     vertical-align: top;
}

.item:nth-child(4n+4){
     margin: 0 0 1rem;
}
```

Listing 3.7 shows box model styling.

Equivalent flexbox styling:

```css
.list{
     display: flex;
     justify-content: space-between;
     flex-flow: row wrap;
     margin: 0 auto;
     width: 100%;
}

.item{
     flex-basis: 24.25%;
     list-style: none;
     border: .0625rem solid #000;
     margin: 0 0 1rem;
}
```

Listing 3.8 shows flexbox styling.

`display: flex` turns each list item into a flex item. `flex-flow: row wrap` lets items wrap. `justify-content: space-between` spreads items across the row. `flex-basis` replaces the width rule. Flexbox removes the need for the `:nth-child` margin fix.

For a flexbox primer, see `https://css-tricks.com/snippets/css/a-guide-to-flexbox`.

### Examining The Benchmark Results

The benchmark combines rendering and painting times. Painting accounts for only about 60 ms, so rendering is the meaningful difference.

![Figure](/.attachments/)

_**Figure 3.20.** box model versus flexbox benchmark chart from the source PDF._
>
> Flexbox performs better than box-model layout in the Chrome benchmark. Lower is better.

Flexbox has broad support without vendor prefixes in modern browsers, and prefixed versions can extend support further.

## Working With CSS Transitions

Chapter 2 used CSS transitions to fix a janky modal animation. This section explains the mechanics and performance tradeoffs.

### Using CSS Transitions

CSS transitions are useful for simple, linear animations. Their advantages include:

- Broad support in modern browsers, and in older browsers such as Internet Explorer 10 with vendor prefixes
- More efficient CPU usage during complex DOM reflows, with the chapter's tests showing 22% better CPU performance
- No extra download overhead because transitions are built into the browser

Open `http://jlwagner.net/webopt/ch03-transition` and hover over the blue box.

![Figure](/.attachments/)

_**Figure 3.21.** CSS transition before-and-after image from the source PDF._
>
> The `.box` element before and after a `border-radius` transition.

The transition CSS:

```css
.box{
     width: 128px;
     height: 128px;
     background: #00a;
     transition: border-radius 2s ease-out;
}

.box:hover{
     border-radius: 50%;
}
```

Listing 3.9 shows a simple CSS hover-state transition.

The `transition` shorthand follows this form:

```css
transition: transition-property transition-duration transition-timing-function transition-delay;
```

The components are:

- `transition-property`: the CSS property to animate, such as `color` or `border-radius`
- `transition-duration`: the length of the transition, such as `2.5s` or `250ms`
- `transition-timing-function`: the easing behavior, such as `linear`, `ease`, `steps(...)`, or `cubic-bezier(...)`
- `transition-delay`: the delay before the transition starts

Multiple properties can be transitioned:

```css
.box{
     width: 64px;
     height: 64px;
     transition: width 2s ease-out, height 2s ease-out;
}
```

### Observing CSS Transition Performance

The chapter compares CSS transitions with jQuery's `animate()` method. Each test uses an HTML document with a `<ul>` containing 128 list items. The items grow from `5rem` to `24rem`, causing heavy DOM reflow. Chrome's Timeline records average memory usage, CPU time, and average FPS across five runs. Table 3.2 shows the averaged results.

| Transition type | jQuery `animate()` | CSS transition | Performance gain |
| --- | ---: | ---: | ---: |
| Avg. memory usage | 5.10 MB | 2.32 MB | +54.51% |
| CPU time | 2011.53 ms | 1572.02 ms | +22% |
| Avg. frames per second | 44.4 | 41.1 | +8% |

CSS transitions are best for simple UI effects such as hover states and off-canvas navigation. More complex animations may need JavaScript driven by `requestAnimationFrame()`, covered in chapter 8.

### Optimizing Transitions With The `will-change` Property

Before a CSS transition runs for the first time, the browser must determine what will change. Developers previously used `translateZ` as a hack to promote an element to a new stacking context and hint that GPU handling might be useful.

The `will-change` property replaces that vague hint with a specific one:

```css
will-change: property, [property]...
```

It accepts any valid animatable CSS property or comma-separated list of properties. Use it sparingly. This is bad:

```css
*,
*::before,
*::after{
     will-change: all;
}
```

That tells the browser every element might change, which can harm performance on complex pages.

This is also poor timing:

```css
#siteHeader a:hover{
     background-color: #0a0;
     will-change: background-color;
}
```

The browser does not have enough time to prepare. Instead, apply the hint earlier, such as on the parent hover state:

```css
#siteHeader:hover a{
    will-change: background-color;
}
```

JavaScript can also add `will-change` on demand:

```js
document.querySelector("#modal").style.display = "block";
document.querySelector("#modal button").style.willChange = "background-color";
```

Remove `will-change` after the relevant interaction ends. Treat it as a precise prediction, not a global optimization switch.
