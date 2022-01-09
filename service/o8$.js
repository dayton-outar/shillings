const moment = require('moment'),
    puppeteer = require('puppeteer'),
    sleep = require('sleep');

const O8Q = require('./db.js');

function readStocks() {
    let results = [];
    let items = document.querySelectorAll('table > tbody > tr');
    items.forEach((item) => {
        let cols = item.querySelectorAll('td');
        results.push({
            code: item.querySelector('a').href.split('=')[1],
            security: cols[0].textContent.trim(),
            volume: parseInt(cols[1].textContent.trim().replace(/,/g, ''), 10),
            closing: parseFloat(cols[2].textContent.trim().replace(/,/g, '')),
            change: cols[3] ? parseFloat(cols[3].textContent.trim().replace(/,/g, '')) : 0,
            percentage: cols[4] ? parseFloat(cols[4].textContent.trim().replace(/,/g, '')) : 0,
            date: document.querySelector('#dateInput').value
        });
    });
    return results;
}

function readCompanies() {
    let results = [];
    let items = document.querySelectorAll('table > tbody > tr');
    items.forEach((item) => {
        let cols = item.querySelectorAll('td');
        if (cols[1]) {
            results.push({
                code: cols[1].textContent.trim(),
                security: cols[0].textContent.trim(),
                currency: cols[2].textContent.trim(),
                industry: cols[3].textContent.trim(),
                type: cols[4].textContent.trim(),
                listed: cols[0].querySelector('a') ? true : false
            });
        }
    });

    return results;
}

function readOutstandingSharesMarketCapitalization() {
    // Credit: https://stackoverflow.com/questions/901115/how-can-i-get-query-string-values-in-javascript
    const urlSearchParams = new URLSearchParams(window.location.search);
    const params = Object.fromEntries(urlSearchParams.entries());
    
    console.log(params);

    let rows = document.querySelectorAll('table')[1].querySelectorAll('tbody > tr');
    return {
        outstandingShares: parseInt(rows[1].querySelectorAll('td')[0].textContent.split(' ')[0].trim().replace(/[,]/g, '')),
        marketCapitalization: parseFloat(rows[0].querySelectorAll('td')[0].textContent.trim().replace(/[$,]/g, ''))
    }
}

// Adapted from https://www.toptal.com/puppeteer/headless-browser-puppeteer-tutorial done by Nick Chikovani
async function run(urls, cb) {
    return await new Promise(async (resolve, reject) => {
        try {

            const browser = await puppeteer.launch({
                args: ['--no-sandbox', '--disable-setuid-sandbox']
            });
            const page = await browser.newPage();

            let response = [];

            // Credit: https://github.com/puppeteer/puppeteer/issues/594
            for (const url of urls) {
                await page.goto(url, {
                    waitUntil: 'networkidle2'
                });

                await page.waitForSelector('h1');

                let result = await page.evaluate(cb);
                response.push(result);
            }

            browser.close();

            return resolve( response.flat() );
        } catch (e) {
            return reject(e);
        }
    })
}

// Stocks do not print on a Friday, Saturday nor Sunday. JSE Stocks begin at 1999-09-27
async function runner(bringToCurrentDate, begin, end, rest = 2) {
    beginning = (begin) ? moment(begin) : moment();
    ending = (end) ? moment(end) : ((bringToCurrentDate) ? moment() : moment(begin));

    if (moment(beginning.format('YYYY-MM-DD')).isSame(moment(ending.format('YYYY-MM-DD')))) {

        console.log(`Running scraper for ${beginning.format('YYYY-MM-DD')}`);

        await run([`https://www.jamstockex.com/market-data/summaries/?market=main-market&date=${beginning.format('YYYY-MM-DD')}`], readStocks)
            .then(stocks => {
                let tradings = {
                    stocks
                };

                if (tradings.stocks.length > 0) {
                    console.log(`${tradings.stocks.length} trades pulled ${tradings.stocks[0].date}`);

                    O8Q.updateStocks(tradings)
                        .then(r => console.log(r.message))
                        .catch(e => console.error(e.message));
                }
            })
            .catch(console.error);
    } else {
        if (moment(beginning.format('YYYY-MM-DD')).isBefore(moment(ending.format('YYYY-MM-DD')))) {

            console.log(`Run scraper from ${beginning.format('YYYY-MM-DD')} to ${ending.format('YYYY-MM-DD')} ...`);

            while (moment(beginning.format('YYYY-MM-DD')).isBefore(moment(ending.format('YYYY-MM-DD')))) {

                console.log(`Reading stocks for ${beginning.format('YYYY-MM-DD')}`);

                await run([`https://www.jamstockex.com/market-data/summaries/?market=main-market&date=${beginning.format('YYYY-MM-DD')}`], readStocks)
                    .then(stocks => {
                        let tradings = {
                            stocks
                        };

                        if (tradings.stocks.length > 0) {
                            console.log(`${tradings.stocks.length} trades pulled on ${tradings.stocks[0].date}`);

                            O8Q.updateStocks(tradings)
                                .then(r => console.log(r.message))
                                .catch(e => console.error(e.message));
                        }
                    })
                    .catch(console.error);

                console.log(`Sleeping for ${rest} seconds`);
                sleep.sleep(rest);
                beginning.add(1, 'd');
            }
        } else {
            let message = moment().isBefore(moment(beginning.format('YYYY-MM-DD'))) ?
                'Date has not yet arrived for scraping. Too far in the future' : `Invalid date range`;
            console.log(message);
        }
    }
}

const args = process.argv.slice(2);

if (args.length > 2) {
    console.log('Too many parameters provided');
    process.exit(1);
}

switch (args[0]) {
    case 'read-companies':
        getCompanies();

        break;
    default:
        getStocks();
}

function getStocks() {
    // Validate date pattern as YYYY-MM-DD
    if (!/^\d{4}[-](0?[1-9]|1[012])[-](0?[1-9]|[12][0-9]|3[01])$/.test(args[0])) {
        console.log('This date format is not acceptable');
        process.exit(1);
    }

    if (args[0]) {
        if (!moment(args[0]).isValid()) {
            console.log(`Begin date, ${args[0]}, is invalid`);
            process.exit(1);
        }
    }

    if (args[1]) {
        if (args[1] !== '++') {
            if (!moment(args[1]).isValid()) {
                console.log(`End date, ${args[1]}, is invalid`);
                process.exit(1);
            }
        }
    }

    if (args.length == 0) {
        runner(false, moment().format('YYYY-MM-DD'));
    } else if (args.length == 1) {
        runner(false, moment(args[0]).format('YYYY-MM-DD'));
    } else {
        if (args[1] === '++') {
            runner(true, moment(args[0]).format('YYYY-MM-DD'));
        } else {
            runner(false, moment(args[0]).format('YYYY-MM-DD'), moment(args[1]).format('YYYY-MM-DD'));
        }
    }
}

function getCompanies() {
    return new Promise((resolve, reject) => {
        run([`https://www.jamstockex.com/market-data/listed-companies/`], readCompanies)
            .then(companies => {

                getOutstandingSharesAndMarketCapitalization(companies); // FIX: Sloppy. Trying to get this to work

                resolve(companies);
            })
            .catch(reject)
    });
}

function getOutstandingSharesAndMarketCapitalization(companies) {
    let urls = [];
    let x = 0;
    console.log(companies);
    for (const company of companies) {
        if (company.listed) {
            console.log(`Getting outstanding shares for ${company.security} ...`);
            // Spawning too many threads of puppeteer process
            urls.push(`https://www.jamstockex.com/market-data/instruments/?symbol=${company.code}`);
            x++;
            console.log(x);
            if (x === 4)
                break;
        }
    }

    run(urls, readOutstandingSharesMarketCapitalization)
        .then(console.log)
        .catch(console.error);
}