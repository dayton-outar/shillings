const fs = require('fs');
const url = require('url');
// ---
const moment = require('moment');
const dfs = require('download-file-sync');
const prettier = require("prettier");
const prettyBytes = require('pretty-bytes');
const purify = require("purify-css")
const Stopwatch = require('statman-stopwatch');
const sw = new Stopwatch();

let delta; 
sw.start(); // Start the clock

var file = 'pages-1609516736.json';
let rawdata = fs.readFileSync(file);
let siteData = JSON.parse(rawdata);

delta = sw.read();
console.log( `Read file ... ${delta}` );

const subjectUrl = url.parse(siteData[0].url);
const baseRef = `${subjectUrl.protocol}//${subjectUrl.hostname}`;

let cssContent = '';
siteData[0].css.forEach( function ( val ) {
    let cssUrl = url.resolve( baseRef, val );

    cssContent = cssContent.concat( "/**----------- COMBINED -----------**/" ).concat( dfs( cssUrl ) );

});

delta = sw.read();
console.log( `Completed downloading all CSS ... ${delta}` );

let cssContentSize = prettyBytes(Buffer.byteLength(cssContent, 'utf8'));
console.log( `${cssContentSize}` );

//let cssPretty = prettier.format(cssContent, { semi: false, parser: "css" });
let tn = moment().unix();
//fs.writeFileSync(`style-${tn}.css`, cssPretty);

let jsContent = '';
siteData[0].js.forEach( function ( val, index ) {
    let jsUrl = url.resolve( baseRef, val );

    console.log( jsUrl );
    try {
        jsContent = dfs( jsUrl );

        let jfs = prettyBytes( Buffer.byteLength( jsContent, 'utf8' ) );
        console.log( `${jfs}` ); // Console thread exiting before this callback is returned

    } catch (e) {
        console.log( `Problem at ${index}` );
        //console.log(e);
    }
    //console.log( jsContent );
    //jsContent = jsContent.concat( "/**----------- COMBINED -----------**/" ).concat( dfs( jsUrl ) );

});

let htmlContent = dfs( siteData[0].url );

let content = htmlContent.concat( '\n' ).concat(jsContent);

purify(content, cssContent, { minify: true, output: `opt.style.${tn}.css` }, async function (purifiedResult) {
    let pfs = await prettyBytes( Buffer.byteLength( purifiedResult, 'utf8' ) );
    console.log( `${pfs}` ); // Console thread exiting before this callback is returned
});

sw.stop();
delta = sw.read();
console.log( `Completed storing ... ${delta}` );