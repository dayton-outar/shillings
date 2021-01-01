var Crawler = require("js-crawler");
 
var crawler = new Crawler().configure(
  {
    ignoreRelative: false,
    depth: 2,
    shouldCrawl: function(url) {
      return url.indexOf('https://www.jncb.com') >= 0;
    }
  });
 
crawler.crawl({
  url: "https://www.jncb.com",
  success: function(page) {
    //(?<=href=")[^"]+\.css
    let css = page.content.match(/(?<=href=")[^"]+\.css/g);
    console.log(css);
    let js = page.content.match(/(?<=src=")[^"]+\.js/g);
    console.log(js);

    console.log(page.url);
  },
  failure: function(page) {
    console.log(page.url, page.status);
  },
  finished: function(crawledUrls) {
    console.log(crawledUrls);
  }
});