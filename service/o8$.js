#!/usr/bin/env node

const moment = require('moment'),
    puppeteer = require('puppeteer'),
    sleep = require('sleep');

const O8Q = require('./db.js');

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
                        volume: parseInt( item.querySelectorAll('td')[1].textContent.trim().replace(/,/g, '') ),
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

// Stocks do not print on a Friday, Saturday nor Sunday. JSE Stocks begin at 1999-09-27
function runner( bringToCurrentDate, begin, end, rest = 2 ) {
    beginning = (begin) ? moment( begin ) : moment();
    ending = (end) ? moment( end ) : ( (bringToCurrentDate) ? moment() : moment( begin ) );

    if ( moment( beginning.format('YYYY-MM-DD') ).isSame( moment( ending.format('YYYY-MM-DD') ) ) ) {
        
        console.log( `Running scraper for ${beginning.format('YYYY-MM-DD')}` );

        run( `https://www.jamstockex.com/market-data/summaries/?market=main-market&date=${beginning.format('YYYY-MM-DD')}` )
            .then( stocks => {
                    let tradings = {
                        stocks
                    };
                    
                    console.log( `${stocks.length} trades pulled ${beginning.format('YYYY-MM-DD')}` );

                    O8Q.updateStocks( tradings )
                        .then( r => console.log(r.message) )
                        .catch( e => console.error(e.message) );
                }
            )
            .catch( console.error );
    } else {
        if ( moment( beginning.format('YYYY-MM-DD') ).isBefore( moment( ending.format('YYYY-MM-DD') ) ) ) {
            
            console.log( `Run scraper from ${beginning.format('YYYY-MM-DD')} to ${ending.format('YYYY-MM-DD')} ...` );

            while ( moment( beginning.format('YYYY-MM-DD') ).isBefore( moment( ending.format('YYYY-MM-DD') ) ) ) {

                console.log( `Reading stocks for ${beginning.format('YYYY-MM-DD')}` );

                run( `https://www.jamstockex.com/market-data/summaries/?market=main-market&date=${beginning.format('YYYY-MM-DD')}` )
                    .then( stocks => {
                            let tradings = {
                                stocks
                            };

                            console.log( `${stocks.length} trades pulled on ${beginning.format('YYYY-MM-DD')}` );

                            O8Q.updateStocks( tradings )
                                .then( r => console.log(r.message) )
                                .catch( e => console.error(e.message) );
                        }
                    )
                    .catch( console.error );
                
                console.log( `Sleeping for ${rest} seconds`);
                sleep.sleep( rest );
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

const args = process.argv.slice(3);

if ( args.length > 2 ) {
    console.log( 'Too many parameters provided' );
    process.exit(1);
}

if ( args[0] ) {
    if ( !moment(args[0]).isValid() ) {
        console.log( `Begin date, ${args[0]}, is invalid` );
        process.exit(1);
    }
}

if ( args[1] ) {
    if ( args[1] !== '++' ) {
        if ( !moment(args[1]).isValid() ) {
            console.log( `End date, ${args[1]}, is invalid` );
            process.exit(1);
        }
    }
}

if ( args.length == 1 ) {
    runner( false, moment( args[0] ).format('YYYY-MM-DD') );  
} else {
    if ( args[1] === '++' ) {
        runner( true, moment( args[0] ).format('YYYY-MM-DD') );
    } else {
        runner( false, moment( args[0] ).format('YYYY-MM-DD'), moment( args[1] ).format('YYYY-MM-DD') );
    }
}