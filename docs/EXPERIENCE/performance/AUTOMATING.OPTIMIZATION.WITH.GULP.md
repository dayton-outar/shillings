# Automating Optimization With gulp

Optimization work can be repetitive: minify CSS, uglify JavaScript, optimize images, compile preprocessors, and repeat. gulp is a Node-based build system that automates those tasks so optimization becomes part of the workflow instead of a separate chore.

Project:

```text
http://gulpjs.com
```

## Introducing gulp

gulp is a Node-based streaming build system. It automates file-processing tasks and lets you focus on editing source files while the build system handles compilation, minification, optimization, and reloads.

> [!note]
> The source chapter assumes gulp 4. At the time of writing, gulp 4 was pending and gulp 3 was still the latest npm release, so some install commands depend on which version npm reports.

### Why Should I Use A Build System?

Without automation, compiling LESS might look like this:

![Figure](/.attachments/12-1-performance-less.css.png)

_**Figure 12.1.** Unautomated LESS workflow._
>
> Make changes to a LESS file, save changes, recompile CSS in the terminal, then reload the page.

That works, but it becomes tedious quickly. With a build system, the workflow becomes:

![Figure](/.attachments/12-2-performance-automated.workflow.less.css.png)

_**Figure 12.2.** Automated LESS workflow._
>
> Make changes and save. The build system recompiles CSS and reloads the page automatically.

gulp can also minify CSS, optimize images, minify HTML, process JavaScript, and run many other tasks through its plugin ecosystem.

### How gulp Works

gulp calls itself a streaming build system. A stream is a point in the build process where data is transformed.

#### How Streams Work

Streams can be chained.

![Figure](/.attachments/12-4-performance-multiple.streams.png)

_**Figure 12.4.** Chained streams compiling and minifying CSS._
>
> A LESS file becomes CSS in one stream, then minified CSS in another stream.

#### How Tasks Work

A task wraps one or more streams. It usually starts with source files from disk, pipes data through transforms, and writes output somewhere else.

Each task should usually focus on one concern, such as minifying HTML, compiling CSS, optimizing images, or processing JavaScript.

## Laying Down The Foundations

Before writing a `gulpfile`, set up the project folder structure and install gulp plus the required plugins.

### Structuring Your Project's Folders

gulp reads from a source folder and writes optimized output to a distribution folder.

Create a new project folder, then clone the Weekly Timber source into `src`:

```sh
git clone https://github.com/webopt/ch12-weekly-timber.git ./src
```

Create `dist` at the project root. The structure should look like:

```text
/
  src
    img
    js
    less
  dist
```

The exact structure can vary, but the idea is to keep editable source files separate from generated output.

### Installing gulp And Its Plugins

Install the gulp CLI globally:

```sh
npm install -g gulp-cli
```

Initialize the project:

```sh
npm init
```

This creates `package.json`, which records project metadata and dependencies.

#### Installing gulp Itself

Check the latest gulp version:

```sh
npm show gulp version
```

If npm reports gulp 4 or later:

```sh
npm install gulp --save
```

If npm reports gulp 3, install the gulp 4 branch from GitHub:

```sh
npm install gulpjs/gulp#4.0 --save
```

#### Essential Plugins

Install foundational plugins:

```sh
npm install gulp-util del gulp-livereload gulp-ext-replace --save
```

Table 12.1: Essential gulp plugins.

| Plugin name | Purpose |
| --- | --- |
| `gulp-util` | Used by some plugins to output terminal information, such as errors and diagnostics. |
| `del` | Deletes files and folders, useful for clean builds that rebuild `dist` from scratch. |
| `gulp-livereload` | Reloads the browser when files change. Requires a LiveReload browser plugin or compatible setup. |
| `gulp-ext-replace` | Changes destination file extensions, used here when converting PNG/JPEG images to `.webp`. |

#### HTML Minification Plugin

Install the HTML minifier:

```sh
npm install gulp-htmlmin --save
```

#### CSS-Related Plugins

Install LESS, PostCSS, and CSS optimization plugins:

```sh
npm install gulp-less gulp-postcss autoprefixer autorem cssnano --save
```

Table 12.2: CSS-related gulp plugins.

| Plugin name | Purpose |
| --- | --- |
| `gulp-less` | Compiles LESS into browser-readable CSS. |
| `gulp-postcss` | Runs PostCSS transformations. PostCSS plugin ecosystem: `http://postcss.org`. |
| `autoprefixer` | Adds vendor prefixes automatically for browser compatibility. |
| `autorem` | Converts `px` units into `rem` units. |
| `cssnano` | Minifies and optimizes CSS. Project: `http://cssnano.co`. |

#### JavaScript-Related Plugins

Install JavaScript optimization plugins:

```sh
npm install gulp-uglify gulp-concat --save
```

Table 12.3: JavaScript-related gulp plugins.

| Plugin name | Purpose |
| --- | --- |
| `gulp-uglify` | Uglifies JavaScript by removing whitespace and shortening code while preserving behavior. |
| `gulp-concat` | Concatenates JavaScript files. This is useful when generating an HTTP/1-friendly bundle. |

#### Image-Processing Plugins

Install image optimization plugins:

```sh
npm install gulp-imagemin imagemin-webp imagemin-jpeg-recompress \
    imagemin-pngquant imagemin-gifsicle imagemin-svgo --save
```

Table 12.4: Plugins related to image optimization.

| Plugin name | Purpose |
| --- | --- |
| `gulp-imagemin` | Provides the base imagemin functionality for automated image optimization. |
| `imagemin-webp` | Converts images into WebP. |
| `imagemin-jpeg-recompress` | Optimizes JPEG images. |
| `imagemin-pngquant` | Optimizes PNG images. |
| `imagemin-gifsicle` | Optimizes GIF images. |
| `imagemin-svgo` | Optimizes SVG images. |

## Writing gulp Tasks

gulp tasks pipe data through streams. This section builds the `gulpfile`.

### The Anatomy Of A gulp Task

A gulp task can be defined by writing a function and passing it to `gulp.task`:

```js
function minifyHTML(){
    // Task code
}

gulp.task(minifyHTML);
```

#### Reading Source Files

Use `gulp.src` to read files:

```js
function minifyHTML(){
    return gulp.src("src/*.html");
}
```

The file pattern is a glob. Examples:

- `img/*` matches everything in `img`.
- `img/**` matches everything in `img` and its subfolders.
- `img/*.png` matches PNG images in `img`.
- `img/**/*.png` matches PNG images in `img` and its subfolders.
- `img/**/*.{png,jpg}` matches PNG and JPEG images in `img` and its subfolders.
- `!img/**/*.svg` excludes SVG images in `img` and its subfolders.

Glob primer:

```text
https://github.com/isaacs/node-glob#glob-primer
```

#### Moving Data Through A Stream

Use `pipe` to pass data to plugins:

```js
function minifyHTML(){
    return gulp.src("src/*.html")
        .pipe(htmlmin());
}
```

#### Writing Data To Disk

Use `gulp.dest` to write transformed output:

```js
function minifyHTML(){
    return gulp.src("src/*.html")
        .pipe(htmlmin())
        .pipe(gulp.dest("dist"));
}
```

### Writing The Core Tasks

gulp looks for `gulpfile.js` in the current working directory. If found, it can run any task defined inside it.

Finished build system:

```sh
git clone https://github.com/webopt/ch12-gulp.git
```

#### Importing Modules

Create `gulpfile.js` in the project root.

Listing 12.1 imports all modules needed for the gulpfile:

```js
var gulp = require("gulp"),
    util = require("gulp-util"),
    del = require("del"),
    livereload = require("gulp-livereload"),
    extReplace = require("gulp-ext-replace"),
    htmlmin = require("gulp-htmlmin"),
    less = require("gulp-less"),
    postcss = require("gulp-postcss"),
    autoprefixer = require("autoprefixer"),
    autorem = require("autorem"),
    cssnano = require("cssnano"),
    uglify = require("gulp-uglify"),
    concat = require("gulp-concat"),
    imagemin = require("gulp-imagemin"),
    jpegRecompress = require("imagemin-jpeg-recompress"),
    pngQuant = require("imagemin-pngquant"),
    svgo = require("imagemin-svgo"),
    gifsicle = require("imagemin-gifsicle"),
    webp = require("imagemin-webp");
```

#### Minifying HTML

Listing 12.2 defines the HTML minification task:

```js
function minifyHTML(){
    var src = "src/**/*.html",
        dest = "dist";

    return gulp.src(src)
        .pipe(htmlmin({
            collapseWhitespace: true,
            removeComments: true
        }))
        .pipe(gulp.dest(dest))
        .pipe(livereload());
}

gulp.task(minifyHTML);
```

HTML minifier options:

```text
https://github.com/kangax/html-minifier#options-quick-reference
```

Run the task:

```sh
gulp minifyHTML
```

Example output:

```text
[13:47:33] Using gulpfile /var/www/ch12-gulp/gulpfile.js
[13:47:33] Starting 'minifyHTML'...
[13:47:33] Finished 'minifyHTML' after 64 ms
```

#### Building LESS Files And Using PostCSS

Listing 12.3 defines the LESS compilation and CSS optimization task:

```js
function buildCSS(){
    var src = "src/less/main.less",
        dest = "dist/css";

    return gulp.src(src)
        .pipe(less()
        .on("error", function(err){
            util.log(err);
            this.emit("end");
        }))
        .pipe(postcss([
            autoprefixer({
                browsers: ["last 4 versions"]
            }),
            autorem(),
            cssnano()
        ]))
        .pipe(gulp.dest(dest))
        .pipe(livereload());
}

gulp.task(buildCSS);
```

Run it:

```sh
gulp buildCSS
```

The optimized CSS is written to `dist/css/main.css`.

#### Uglifying And Concatenating Scripts

Listing 12.4 defines the JavaScript uglification task:

```js
function uglifyJS(){
    var src = "src/js/**/*.js",
        dest = "dist/js";

    return gulp.src(src)
        .pipe(uglify())
        .pipe(gulp.dest(dest))
        .pipe(livereload());
}

gulp.task(uglifyJS);
```

Listing 12.5 defines the script concatenation task:

```js
function concatJS(){
    var src = ["dist/**/*.js", "!dist/js/scripts.js"],
        dest = "dist/js",
        concatScript = "scripts.js";

    return gulp.src(src)
        .pipe(concat(concatScript))
        .pipe(gulp.dest(dest))
        .pipe(livereload());
}

gulp.task(concatJS);
```

`concatJS` depends on `uglifyJS` running first because it concatenates the optimized files from `dist`. The source glob excludes `dist/js/scripts.js` so the concatenated file does not recursively include itself.

#### Performing Image Optimization

Listing 12.6 optimizes PNGs, JPEGs, GIFs, and SVGs with imagemin:

```js
function imageminMain(){
    var src = "src/img/**/*.{png,jpg,svg,gif}",
        dest = "dist/img";

    return gulp.src(src)
        .pipe(imagemin([
            jpegRecompress({
                max: 90
            }),
            pngQuant({
                quality: "45-90"
            }),
            gifsicle(),
            svgo()
        ]))
        .pipe(gulp.dest(dest))
        .pipe(livereload());
}

gulp.task(imageminMain);
```

Imagemin plugins:

```text
https://www.npmjs.com/browse/keyword/imageminplugin
```

Listing 12.7 defines the WebP conversion task:

```js
function imageminWebP(){
    var src = "src/img/**/*.{jpg,png}",
        dest = "dist/img";

    return gulp.src(src)
        .pipe(imagemin([
            webp({
                quality: 65
            })
        ]))
        .pipe(extReplace(".webp"))
        .pipe(gulp.dest(dest))
        .pipe(livereload());
}

gulp.task(imageminWebP);
```

Run both image tasks:

```sh
gulp imageminMain imageminWebP
```

The output in `dist/img` includes optimized source-format images and WebP versions.

### Writing The Utility Tasks

The core tasks still require manual commands. Utility tasks add automation:

- A watch task that observes files and runs relevant tasks when changes happen.
- A clean/build workflow for producing production-ready output.

#### Writing The Watch Task

`gulp.watch` accepts a file glob and one or more tasks to run when files change.

Listing 12.8 defines the watch task as the default task:

```js
function watch(){
    livereload.listen();

    gulp.watch("src/**/*.html", minifyHTML);
    gulp.watch("src/less/**/*.less", buildCSS);
    gulp.watch("src/js/**/*.js", gulp.series(uglifyJS, concatJS));
    gulp.watch("src/img/**/*.{png,jpg,svg,gif}",
               gulp.parallel(imageminMain, imageminWebP));
}

gulp.task("default", watch);
```

The `default` task runs when you type only:

```sh
gulp
```

Install a LiveReload browser extension and enable it for the page.

Chrome Web Store:

```text
https://chrome.google.com/webstore
```

LiveReload:

```text
livereload.com
```

Example terminal output:

```text
[22:36:46] Using gulpfile /private/var/www/ch12-gulp/gulpfile.js
[22:36:46] Starting 'default'...
```

Run a local server that serves `dist`, enable LiveReload in the browser, then edit files in `src`. Relevant tasks run automatically and reload the page.

`gulp.series` runs tasks one after another. `gulp.parallel` runs tasks at the same time. The JavaScript tasks use `series` because `concatJS` depends on `uglifyJS`. The image tasks can run in parallel.

#### Writing The Build Task

The build task runs the core build tasks:

```js
gulp.task("build", gulp.parallel(minifyHTML, buildCSS, uglifyJS,
    imageminMain, imageminWebP, gulp.series(uglifyJS, concatJS)));
```

Run it:

```sh
gulp build
```

#### Writing The Clean Task

Use `del` to remove `dist` before producing a clean build:

```js
function clean(){
    return del(["dist"]);
}

gulp.task(clean);
```

Vinyl reference:

```text
https://github.com/gulpjs/vinyl
```

Run a clean production build:

```sh
gulp clean
gulp build
```

## Going A Little Further With gulp Plugins

gulp has a large plugin ecosystem:

```text
http://gulpjs.com/plugins
```

Useful plugins include:

- `gulp-changed`: processes only files changed since the last build, useful for slow tasks such as image optimization.
- `gulp-nunjucks`: integrates Mozilla's Nunjucks templating engine for reusable HTML partials and static-site templating. Nunjucks: `https://mozilla.github.io/nunjucks`.
- `gulp-inline`: inlines files automatically, useful for HTTP/1-focused workflows that still rely on inlining.
- `gulp-spritesmith`: generates image sprites and CSS from separate image files, useful for HTTP/1.
- `gulp-sass`: compiles SASS to CSS, similar in role to `gulp-less`.
- `gulp-uncss`: wraps the UnCSS tool from chapter 3 and removes unused CSS automatically.

If no plugin exists for a task, you can write valid Node code inside a gulp task. Plugin authoring guidelines:

```text
http://mng.bz/109I
```
