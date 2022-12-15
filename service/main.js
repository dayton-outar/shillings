const moment = require('moment'),
    puppeteer = require('puppeteer'),
    sleep = require('sleep'),
    Globalize = require('globalize'),
    requireFromString = require('require-from-string'),
    fs = require('fs');

const O8Q = require('./db.js');

Globalize.load( require( 'cldr-data' ).entireSupplemental() );
Globalize.load( require( 'cldr-data' ).entireMainFor( 'en' ) );

function readStocks() {
    let results = [];

    const urlSearchParams = new URLSearchParams(window.location.search);
    const params = Object.fromEntries(urlSearchParams.entries());
    //--
    const tradeDate = params.date;

    let ordinary = document.querySelectorAll('table')[1];
    if (ordinary) {
        ordinary.querySelectorAll('tbody > tr').forEach((item) => {
            let cols = item.querySelectorAll('td');
            let closingPrice = parseFloat(cols[3].textContent.trim().replace(/,/g, ''));
            let priceChange = cols[4] ? parseFloat(cols[4].textContent.trim().replace(/,/g, '')) : 0
            results.push({
                code: cols[1].querySelector('a').href.split('instrument=')[1].split('-')[0],
                security: cols[1].querySelector('a').title.trim(),
                volume: parseInt(cols[7].textContent.trim().replace(/,/g, ''), 10),
                closing: closingPrice,
                change: priceChange,
                percentage: (priceChange / (closingPrice - priceChange)).toFixed(2),
                date: tradeDate
            });
        });
    }

    let preferred = document.querySelectorAll('table')[3];
    if (preferred) {
        preferred.querySelectorAll('tbody > tr').forEach((item) => {
            let cols = item.querySelectorAll('td');
            let closingPrice = parseFloat(cols[3].textContent.trim().replace(/,/g, ''));
            let priceChange = cols[4] ? parseFloat(cols[4].textContent.trim().replace(/,/g, '')) : 0;
            results.push({
                code: cols[1].querySelector('a').href.split('instrument=')[1].split('-')[0],
                security: cols[1].querySelector('a').title.trim(),
                volume: parseInt(cols[7].textContent.trim().replace(/,/g, ''), 10),
                closing: closingPrice,
                change: priceChange,
                percentage: (priceChange / (closingPrice - priceChange)).toFixed(2),
                date: tradeDate
            });
        });
    }

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

function readCompanyDetails() {
    // Credit: https://stackoverflow.com/questions/901115/how-can-i-get-query-string-values-in-javascript
    const urlSearchParams = new URLSearchParams(window.location.search);
    const params = Object.fromEntries(urlSearchParams.entries());

    // const elSx = document.evaluate("//script[contains(., 'thru-date')]", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue;
    // let tradeDate = elSx.textContent ? elSx.textContent.match(/"thru-date":"([0-9]{4}-[0-9]{2}-[0-9]{2})"/)[1] : params.date;
    let tradeDate = params.date;
    const elSo = document.evaluate("//span[text()='Shares Outstanding:']", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue;
    const elMvSo = document.evaluate("//span[text()='Market Value of Shares Outstanding:']", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue;
    let stockCode = params.instrument.split('-')[0];

    let dividends = [];
    let tld = document.querySelectorAll('table')[2];

    if (tld) {
        let items = tld.querySelectorAll('tbody > tr');
        if (items) {
            items.forEach((item) => {
                let cols = item.querySelectorAll('td');
                if (cols[1] && cols[1].textContent.trim() === 'Dividend') {
                    let camt = cols[4].textContent.trim().split(' ');
                    dividends.push({
                        code: stockCode,
                        recordDate: cols[0] ? cols[0].textContent.trim() : '',
                        paymentDate: cols[3] ? cols[3].textContent.trim() : '',
                        currency: camt[0].trim(),
                        amount: parseFloat(camt[camt.length - 1].trim().replace(/,/g, ''))
                    });
                }
            });
        }
    }

    return {
        code: stockCode,
        date: tradeDate,
        outstandingShares: parseInt(elSo.nextElementSibling.textContent.split(' ')[0].trim().replace(/[,]/g, '')),
        marketCapitalization: parseFloat(elMvSo.nextElementSibling.textContent.trim().replace(/[$,]/g, '')),
        dividends
    }
}

function readIndices() {
    let results = [];
    let items = document.querySelectorAll('table > tbody > tr');
    items.forEach((item) => {
        let cols = item.querySelectorAll('td');
        results.push({
            index: 'JSE',
            date: cols[0].textContent.trim(),
            value: parseFloat(cols[1].textContent.trim().replace(/,/g, '')),
            change: parseFloat(cols[2].textContent.trim().replace(/,/g, ''))
        });
    });

    return results;
}

function readDividends() {
    let results = [];
    let items = document.querySelectorAll('table > tbody > tr');
    items.forEach((item) => {
        let cols = item.querySelectorAll('td');
        let camt = cols[5].textContent.trim().split(' ');
        results.push({
            code: cols[1].textContent.trim(),
            recordDate: cols[0].textContent.trim(),
            paymentDate: cols[4].textContent.trim(),
            currency: camt[0].trim(),
            amount: parseFloat(camt[camt.length - 1].trim().replace(/,/g, ''))
        });
    });

    return results;
}

// Adapted from https://www.toptal.com/puppeteer/headless-browser-puppeteer-tutorial done by Nick Chikovani
// TODO: Update Puppeteer, Moment, Pretty-Bytes and other packages to latest version
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
                    waitUntil: 'networkidle2',
                    timeout: 0
                });

                await page.waitForSelector('h1');

                let result = await page.evaluate(cb);
                response.push(result);
            }

            browser.close();

            return resolve(response.flat());
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

        await run([
                    `https://www.jamstockex.com/trading/trade-quotes/?market=main-market&date=${beginning.format('YYYY-MM-DD')}`//,
                    //`https://www.jamstockex.com/trading/trade-quotes/?market=junior-market&date=${beginning.format('YYYY-MM-DD')}`
                ], readStocks)
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

                await run([
                        `https://www.jamstockex.com/trading/trade-quotes/?market=main-market&date=${beginning.format('YYYY-MM-DD')}`//,
                        //`https://www.jamstockex.com/trading/trade-quotes/?market=junior-market&date=${beginning.format('YYYY-MM-DD')}`
                    ], readStocks)
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

    getIndices();
}

const args = process.argv.slice(2);

if (args.length > 3) {
    console.log('Too many parameters provided');
    process.exit(1);
}

switch (args[0]) {
    case 'read-companies':
        getCompanies();

        break;
    
    case 'read-indices':
        getIndices();

        break;

    case 'test':
        console.log('Running in test ...');
        performTest();

        break;

    default:
        getStocks();        

        break;
}

async function performTest() {
    // const currency = 'jmd';
    // const beginning = moment('2022-01-01');
    // const ending = moment('2022-12-15');
    // const urls = [
    //     `https://www.jamstockex.com/trading/corporate-actions/?instrumentCode=jbg-${currency}&fromDate=${beginning.format('YYYY-MM-DD')}&thruDate=${ending.format('YYYY-MM-DD')}`,
    //     `https://www.jamstockex.com/trading/corporate-actions/?instrumentCode=gk-${currency}&fromDate=${beginning.format('YYYY-MM-DD')}&thruDate=${ending.format('YYYY-MM-DD')}`
    // ];

    const tradeDate = moment('2022-12-01');
    const response = await O8Q.getMarketSources();

    if (response.success) {
        for(const source of response.data) {
            const url = source.Endpoint.replace('{{date}}', tradeDate.format('YYYY-MM-DD'));
            const cb = requireFromString(`module.exports = ${source.Reader}`);

            run([url], cb)
                .then(console.log)
                .catch(console.error);
        }
    } else {
        console.error(response.message);
    }
}

function getStocks() {

    if (args[0]) {
        // Validate date pattern as YYYY-MM-DD
        if (!/^\d{4}[-](0?[1-9]|1[012])[-](0?[1-9]|[12][0-9]|3[01])$/.test(args[0])) {
            console.log('This date format is not acceptable');
            process.exit(1);
        }

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
        run([`https://www.jamstockex.com/listings/listed-companies/`], readCompanies)
            .then(companies => {

                getCompanyDetails(companies); // FIX: Sloppy. Trying to get this to work

                resolve(companies);
            })
            .catch(reject)
    });
}

function getCompanyDetails(companies) {
    let urls = [];
    let x = 0;

    for (const company of companies) {
        if (company.listed) {
            // Spawning too many threads of puppeteer process
            urls.push(`https://www.jamstockex.com/trading/instruments/?instrument=${company.code}-${company.currency}&date=${ moment().format('YYYY-MM-DD') }`);
        }
    }

    run(urls, readCompanyDetails) // This can take about 20 minutes
        .then(o => {
            // Map and merge arrays
            const mergedO = o.map(el => {
                company = companies.find(cd => cd.code == el.code);

                return {
                    ...company,
                    ...el
                }
            });

            if (mergedO.length > 0) {

                O8Q.updateCompany({
                        companies: mergedO
                    })
                    .then(console.log)
                    .catch(console.error);
            }
        })
        .catch(console.error);
}

function getDividends(companies, beginning, ending) {
    let urls = [];

    for (const company of companies) {
        if (company.listed) {
            // Spawning too many threads of puppeteer process
            urls.push(`https://www.jamstockex.com/trading/corporate-actions/?instrumentCode=${company.code}-${company.currency}&fromDate=${beginning.format('YYYY-MM-DD')}&thruDate=${ending.format('YYYY-MM-DD')}`);
        }
    }

    run(urls, readDividends) // This can take about 20 minutes
        .then(dividends => {
            for (const dividend of dividends) {
                dividend.title = `Dividends payout declared at ${ Globalize( 'en' ).currencyFormatter( 'USD' )( dividend.amount ) } per stock unit`;
                dividend.declarationDate = moment(new Date(dividend.recordDate)).format('YYYY-MM-DD');
                dividend.recordDate = moment(new Date(dividend.recordDate)).format('YYYY-MM-DD');
                dividend.paymentDate = moment(new Date(dividend.paymentDate)).format('YYYY-MM-DD');
            }

            if (dividends.length > 0) {

                O8Q.updateDividends({
                        dividends
                    })
                    .then(console.log)
                    .catch(console.error);
                    
            }
        })
        .catch(console.error);
}

function getIndices() {
    beginning = moment();
    ending = moment();

    if (args[0] == 'read-indices') {
        if (args[1]) {
            // Validate date pattern as YYYY-MM-DD
            if (!/^\d{4}[-](0?[1-9]|1[012])[-](0?[1-9]|[12][0-9]|3[01])$/.test(args[1])) {
                console.log('This date format is not acceptable');
                process.exit(1);
            }

            if (!moment(args[1]).isValid()) {
                console.log(`Begin date, ${args[1]}, is invalid`);
                process.exit(1);
            }
        }

        if (args[2]) {
            if (args[2] !== '++') {
                if (!moment(args[2]).isValid()) {
                    console.log(`End date, ${args[2]}, is invalid`);
                    process.exit(1);
                }
            }
        }

        beginning = moment(args[1]);
        ending = moment(args[2]);
    } else {
        if (args[0]) {
            // Validate date pattern as YYYY-MM-DD
            if (!/^\d{4}[-](0?[1-9]|1[012])[-](0?[1-9]|[12][0-9]|3[01])$/.test(args[0])) {
                console.log('This date format is not acceptable');
                process.exit(1);
            }

            if (!moment(args[0]).isValid()) {
                console.log(`Begin date, ${args[1]}, is invalid`);
                process.exit(1);
            }
        }

        if (args[1]) {
            if (args[1] !== '++') {
                if (!moment(args[1]).isValid()) {
                    console.log(`End date, ${args[2]}, is invalid`);
                    process.exit(1);
                }
            }
        }

        beginning = moment(args[0]);
        ending = moment(args[1]);
    }

    if (beginning.isSameOrBefore(ending)) {

        console.log(`Get indices from ${beginning.format('YYYY-MM-DD')} to ${ending.format('YYYY-MM-DD')} ...`);

        run([`https://www.jamstockex.com/trading/indices/index-history/?indexCode=jse-index&fromDate=${beginning.format('YYYY-MM-DD')}&thruDate=${ending.format('YYYY-MM-DD')}`], readIndices)
            .then(indices => {
                for (const index of indices) {
                    index.date = moment(new Date(index.date)).format('YYYY-MM-DD');
                }

                if (indices.length > 0) {

                    O8Q.updateIndices({
                            indices
                        })
                        .then(console.log)
                        .catch(console.error);
                }

            })
            .catch(console.error);
    } else {
        let message = moment().isBefore(moment(beginning.format('YYYY-MM-DD'))) ?
            'Date has not yet arrived for scraping. Too far in the future' : `Invalid date range`;
        console.log(message);
    }
}