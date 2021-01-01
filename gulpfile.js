const { series, parallel, src, dest } = require('gulp');
const rename = require('gulp-rename');
const download = require('gulp-download');
const purify = require('gulp-purifycss');
const wget = require('wget');

const assets = {
    src: {
        fonts: [
            './node_modules/font-awesome/fonts/*',
            './node_modules/@fortawesome/fontawesome-free/webfonts/*',
            './src/fonts/*'
        ],
        css: [
            //'./assets/css/*.css',
            'https://www.jncb.com/visadebit/assets/bootstrap/css/bootstrap.min.css'
        ],
        images: [ './assets/images/*' ],
        js: [ './assets/js/*.js' ],
        html: [
            'https://www.jncb.com/'
        ]
    },
    raw: {
        css: [ './assets/css/*.css' ],
        html: [ './assets/html/*.html' ]
    },
    dest: {
        fonts: './assets/fonts',
        css: './assets/css',
        images: './assets/images',
        js: './assets/js',
        html: './assets/html'
    },
    opt: {
        css: './assets/css/opt',
    }
};

let wgd;
function downloadPages(cb) {
    //return download(assets.src.html)
    //    .pipe(dest(assets.dest.html));

    wgd = wget.download(assets.src.html[0], assets.dest.html);
    wgd.on('error', function(err) {
        console.log(err);
    });
    wgd.on('end', function(output) {
        console.log(output);
    });
    wgd.on('progress', function(progress) {
        // code to show progress bar
    });
    
    cb();
}

async function downloadStyles() {
    return download(assets.src.css)
        .pipe(dest(assets.dest.css));
}

async function optimizeStyles() {
    return src(assets.raw.css)
        .pipe(purify(assets.raw.html))
        .pipe(rename({
            suffix: '.opt'
        }))
        .pipe(dest(assets.opt.css));
}

async function optimizeScripts() {
    return src(assets.src.js)
        .pipe(dest(assets.dest.js));
}

exports.pages = downloadPages;
exports.downloadstyles = downloadStyles;
exports.styles = optimizeStyles;
exports.scripts = optimizeScripts;
exports.default = series( downloadPages, downloadStyles, parallel( optimizeStyles, optimizeScripts ) );