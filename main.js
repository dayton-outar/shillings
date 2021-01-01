const fs = require('fs');
// ---
const moment = require('moment');
const Crawler = require("js-crawler");
const subject = 'https://www.firstglobal-bank.com/';
 
const crawler = new Crawler().configure(
  {
    ignoreRelative: false,
    depth: 2,
    shouldCrawl: function(url) {
      return url.indexOf(subject) >= 0;
    }
  });
 
let pages = [];

crawler.crawl({
  url: subject,
  success: function(page) {
    let css = page.content.match(/(?<=href=")[^"]+\.css/g);
    let js = page.content.match(/(?<=src=")[^"]+\.js/g);

    pages.push({
      url: page.url,
      //content: page.content,
      css,
      js
    });

    console.log('reading ...');
  },
  failure: function(page) {
    console.log(page.url, page.status);
  },
  finished: function(crawledUrls) {    
    pages.pagesCrawled = crawledUrls.length;

    console.log(`${pages.pagesCrawled} pages were crawled on ${subject}`);

    let tn = moment().unix();
    fs.writeFileSync(`pages-${tn}.json`, JSON.stringify(pages, null, 4));
  }
});