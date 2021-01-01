var Crawler = require("js-crawler");
 
var crawler = new Crawler().configure({ignoreRelative: false, depth: 2});
 
crawler.crawl({
  url: "https://www.billexpressonline.com",
  success: function(page) {
    console.log(page.url);
  },
  failure: function(page) {
    console.log(page.status);
  },
  finished: function(crawledUrls) {
    console.log(crawledUrls);
  }
});