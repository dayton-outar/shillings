const puppeteer = require('puppeteer');
const xml2json = require('xml-js');
const moment = require('moment');

const args = process.argv.slice(2);

// Adapted from https://www.toptal.com/puppeteer/headless-browser-puppeteer-tutorial done by Nick Chikovani
function run ( url = "https://www.jamstockex.com/market-data/summaries/" ) {
    return new Promise( async ( resolve, reject ) => {
        try {

            const browser = await puppeteer.launch();
            const page = await browser.newPage();
            await page.setRequestInterception( true );
            page.on('request', (request) => {
                if (request.resourceType() === 'document') {
                    request.continue();
                } else {
                    request.abort();
                }
            });
            await page.goto( url );
            //let currentPage = 1;
            let stocks = [];
            //while (currentPage <= pagesToScrape) {
                await page.waitForSelector('h3 + table');
                stocks = await page.evaluate(() => {
                    let results = [];
                    let items = document.querySelectorAll('table > tbody > tr');
                    items.forEach((item) => {
                        results.push({
                            code: item.querySelector('a').href.split('=')[1],
                            security:  item.querySelectorAll('td')[0].textContent.trim(),
                            volume: item.querySelectorAll('td')[1].textContent.trim(),
                            closing: item.querySelectorAll('td')[2].textContent.trim(),
                            change: item.querySelectorAll('td')[3] ? item.querySelectorAll('td')[3].textContent.trim() : 0,
                            percentage: item.querySelectorAll('td')[4] ? item.querySelectorAll('td')[4].textContent.trim() : 0//,
                            //date: logged
                        });
                    });
                    return results;
                });
                
                /*
                if (currentPage < pagesToScrape) {
                    await Promise.all([
                        await page.waitForSelector('a.morelink'),
                        await page.click('a.morelink'),
                        await page.waitForSelector('a.storylink')
                    ])
                }
                */
                //currentPage++;
            //}
            browser.close();
            return resolve( stocks );
        } catch (e) {
            return reject(e);
        }
    })
}

run( ).then( ( stocks ) => {
    let trades = {
        stocks
    }
    console.log( xml2json.json2xml( trades, { compact: true, ignoreComment: true, spaces: 4 }) );
} ).catch( console.error );

// Avoid weekends
//run( "https://www.jamstockex.com/market-data/summaries/?market=main-market&date=2000-01-04" ).then( console.log ).catch( console.error );