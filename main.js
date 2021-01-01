const Crawler = require("js-crawler");
 
const crawler = new Crawler().configure(
  {
    ignoreRelative: false,
    depth: 2,
    shouldCrawl: function(url) {
      return url.indexOf('https://www.jncb.com') >= 0;
    }
  });
 
let pages = [];

crawler.crawl({
  url: "https://www.jncb.com",
  success: function(page) {
    //(?<=href=")[^"]+\.css
    let css = page.content.match(/(?<=href=")[^"]+\.css/g);
    let js = page.content.match(/(?<=src=")[^"]+\.js/g);

    pages.push({
      url: page.url,
      //content: page.content,
      css,
      js
    });

    if (pages.length == 1) {
      console.log(pages);
    } else {
      console.log(page.url);
    }
  },
  failure: function(page) {
    console.log(page.url, page.status);
  },
  finished: function(crawledUrls) {
    console.log(crawledUrls);
  }
});