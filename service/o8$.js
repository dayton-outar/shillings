#!/usr/bin/env node

const moment = require('moment');
const puppeteer = require('puppeteer');
const xml2json = require('xml-js');
const sleep = require('sleep');
//const moment = require('moment');

//const args = process.argv.slice(2);

// Adapted from https://www.toptal.com/puppeteer/headless-browser-puppeteer-tutorial done by Nick Chikovani
function run(url = "https://www.jamstockex.com/market-data/summaries/") {
    return new Promise(async (resolve, reject) => {
        try {

            const browser = await puppeteer.launch();
            const page = await browser.newPage();
            await page.setRequestInterception(true);
            page.on('request', (request) => {
                if (request.resourceType() === 'document') {
                    request.continue();
                } else {
                    request.abort();
                }
            });
            await page.goto(url);

            let stocks = [];

            await page.waitForSelector('h1');
            stocks = await page.evaluate(() => {
                let results = [];
                let items = document.querySelectorAll('table > tbody > tr');
                items.forEach((item) => {
                    results.push({
                        code: item.querySelector('a').href.split('=')[1],
                        security: item.querySelectorAll('td')[0].textContent.trim(),
                        volume: item.querySelectorAll('td')[1].textContent.trim(),
                        closing: item.querySelectorAll('td')[2].textContent.trim(),
                        change: item.querySelectorAll('td')[3] ? item.querySelectorAll('td')[3].textContent.trim() : 0,
                        percentage: item.querySelectorAll('td')[4] ? item.querySelectorAll('td')[4].textContent.trim() : 0,
                        date: document.querySelector('#dateInput').value
                    });
                });
                return results;
            });

            browser.close();
            return resolve(stocks);
        } catch (e) {
            return reject(e);
        }
    })
}

// Stocks do not print on a Friday, Saturday nor Sunday
/*
run( "https://www.jamstockex.com/market-data/summaries/?market=main-market&date=1999-09-27" ).then((stocks) => {
    let trades = {
        stocks
    }
    console.log(xml2json.json2xml(trades, {
        compact: true,
        ignoreComment: true,
        spaces: 4
    }));
}).catch(console.error);
*/

function runner( bringToCurrentDate, begin, end ) {
    beginning = (begin) ? moment( begin ) : moment();
    ending = (end) ? moment( end ) : ( (bringToCurrentDate) ? moment() : moment( begin ) );

    if ( moment( beginning.format('YYYY-MM-DD') ).isSame( moment( ending.format('YYYY-MM-DD') ) ) ) {
        console.log( `Running scraper for ${beginning.format('YYYY-MM-DD')} ...` );
        run( `https://www.jamstockex.com/market-data/summaries/?market=main-market&date=${beginning.format('YYYY-MM-DD')}` )
            .then( (stocks) => {
                    let trades = {
                        stocks
                    };
                    console.log(xml2json.json2xml(trades, {
                        compact: true,
                        ignoreComment: true,
                        spaces: 4
                    }));
                }
            )
            .catch( console.error );
    } else {
        if ( moment( beginning.format('YYYY-MM-DD') ).isBefore( moment( ending.format('YYYY-MM-DD') ) ) ) {
            console.log( `Run scraper from ${beginning.format('YYYY-MM-DD')} to ${ending.format('YYYY-MM-DD')} ...` );

            while ( moment( beginning.format('YYYY-MM-DD') ).isBefore( moment( ending.format('YYYY-MM-DD') ) ) ) {
                run( `https://www.jamstockex.com/market-data/summaries/?market=main-market&date=${beginning.format('YYYY-MM-DD')}` )
                    .then( (stocks) => {
                            let trades = {
                                stocks
                            };
                            console.log(xml2json.json2xml(trades, {
                                compact: true,
                                ignoreComment: true,
                                spaces: 4
                            }));
                        }
                    )
                    .catch( console.error );
                
                console.log('Sleeping for 5 seconds');
                sleep.sleep(5);
                beginning.add(1, 'd');
            }
        } else {
            let message = moment().isBefore( moment( beginning.format('YYYY-MM-DD') ) ) ? 
                            'Date has not yet arrived for scraping. Too far in the future' : `Invalid date range`;
            console.log( message );

            return;
        }
    }
}


runner( false, '1999-11-01', '1999-11-15' );

/*
if (o8args.dates) {
    console.log(`Beginning at ${o8args.dates}`);
}

console.log( "Got everything, now let's begin" );
*/