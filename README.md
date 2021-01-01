# Octopussimizer

Crawling through a web site to find all its pages and feel through each page with the tentacles of an octopus to perform page optimization by decreasing file size where necessary and making use of minifying and bundling tools.

## The Approach

So, the main idea for optimizing a page or, better yet, a web site is to,

 * Remove unused (or irrelevant) styles from the stylesheets linked by each page in order to decrease file size
 * Minify JavaScript (JS) files by removing as much white space as possible in order to decrease file size
 * Bundle CSS and JS files into one file so as to decrease roundtrips to the server

All the above should be in the core library of the software.

## Developer Notes

 * [December 30, 2020] Spent some time doing research on UnCSS. Thanks to IZ, he found out that UnCSS ignores CSS style references in JS files
 * [December 30, 2020] Found out about PurifyCSS and PurgeCSS. PurgeCSS has a better presentation in the delivery of their documentation but is it better than PurifyCSS
 * [December 30, 2020] Thanks to IZ. PurifyCSS reads references in JS associated files as well as HTML. The only problem is that PurifyCSS requires the files to be referenced via file system and not URL
 * [December 31, 2020] Using [Gulp](https://gulpjs.com/) to test out PurgeCSS
 * [December 31, 2020] PurgeCSS was too frustrating to work in Gulp. It was disappointing
 * [December 31, 2020] PurifyCSS was better in Gulp
 * [December 31, 2020] Had to use [gulp-download](https://www.npmjs.com/package/gulp-download) to download files from URL but there is an issue. It has to reference the filename in the URL. So, https://www.jncb.com causes it to through an error
 * [December 31, 2020] Trying to find an alternative to [gulp-download](https://www.npmjs.com/package/gulp-download) and found [wget](https://www.npmjs.com/package/wget) but it does not work well in Gulp. (I begin to get the feeling that I need to get out of the straitjacket of Gulp and go plain NodeJS scripting)
 * [December 31, 2020] After a getting the keywords wrong a few times, I pounce upon [js-crawler](https://www.npmjs.com/package/js-crawler). This allows me to crawl through a web site to find every reference starting from the home page. I can build out a site map with this.
 * [January 1, 2020 @ 6:30 PM] Equipped with the previous research and project goals provided by JD, I created Octopussimizer. A Node JS scratchpad for testing out ideas for the core solution of web site optimization
 * [January 1, 2020] While reading [this StackOverflow entry](https://stackoverflow.com/questions/1679507/getting-all-css-used-in-html-file/31460383), I realized that we may have to consider inline styles. Or do we?
 * [January 1, 2020] [Find CSS files with Regex](https://stackoverflow.com/questions/30866169/how-to-find-css-files-with-regex) may prove useful
 * [January 1, 2020] Crawling through sites and pulling CSS references for each page crawled but the crawler hangs after a some time running. Not sure the reason.
 * [January 1, 2020] Need to classify externally referenced CSS files different from relative referenced files
 * [January 1, 2020 @ 8:30 PM] Also pullying all JS files referenced by page through js-crawler. Just need to know the reason it stops
 * [January 1, 2020] Learnt of generic syntax in some referenced files through [this StackOverflow entry](https://stackoverflow.com/questions/550038/is-it-valid-to-replace-http-with-in-a-script-src-http).
 * [January 1, 2020] What if some of the files referenced by a web page were not used at all? I guess bundling relevant styles into one file would solve this problem
 * [January 1, 2020] Doesn't [appear](https://github.com/antivanov/js-crawler/issues/58) anyone is maintaining this JS package anymore.
 * [January 1, 2020] So, the new plan is to try out [crawler](https://www.npmjs.com/package/crawler). It has a lot more recent activity going on but I don't see a feature that I have been using in js-crawler and that feature is to specify what urls should be crawled.
 * [January 1, 2020] Disappointed in crawler. This isn't much different from what wget offers