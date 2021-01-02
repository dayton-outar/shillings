const puppeteer = require( 'puppeteer' );


(async () => {
    const browser = await puppeteer.launch();
    const page = await browser.newPage();
    //await page.goto('https://www.firstglobal-bank.com');
    //await page.screenshot({path: 'firstglobal-bank.png'});

    // Enable both JavaScript and CSS coverage
    await Promise.all([
        page.coverage.startJSCoverage(),
        page.coverage.startCSSCoverage()
    ]);
    // Navigate to page
    await page.goto('https://www.firstglobal-bank.com');
    // Disable both JavaScript and CSS coverage
    const [jsCoverage, cssCoverage] = await Promise.all([
        page.coverage.stopJSCoverage(),
        page.coverage.stopCSSCoverage(),
    ]);

    /*
    let totalCSSBytes = 0;
    let usedCSSBytes = 0;
    console.log('CSS Coverage\n');
    for (const entry of cssCoverage) {        
        totalCSSBytes += entry.text.length;
        for (const range of entry.ranges) {
            console.log('%s %s', range.end, range.start);
            usedCSSBytes += range.end - range.start - 1;
        }
    }
    */

    const tally = (accumulator, val) => {
        return accumulator + (val.end - val.start - 1);
    }

    let totalJSBytes = 0;
    let usedJSBytes = 0;
    let js = []
    console.log('JS Coverage\n');
    for (const entry of jsCoverage) { // Each entry has properties: url, ranges { start, end }, text 
        totalJSBytes += entry.text.length;
        usedJSBytes += entry.ranges.reduce(tally, 0);

        js.push({ url: entry.url, usage: ( usedJSBytes / totalJSBytes ), totalBytes: entry.text.length, totalRanges: entry.ranges.length, ranges: entry.ranges })
    }
    console.log(`Used: ${usedJSBytes / totalJSBytes * 100}%`);


    let unUsed = js.filter( u => u.usage <= 0.5 );
    unUsed.forEach( val => {
        console.log( val.url, `${parseFloat(val.usage * 100).toFixed(2)}%` );
    })
    //console.log();

    /*
    let totalBytes = 0;
    let usedBytes = 0;
    const coverage = [...jsCoverage, ...cssCoverage];
    console.log('Total Coverage\n');
    for (const entry of coverage) {
        totalBytes += entry.text.length;
        for (const range of entry.ranges) {
            console.log('%s %s', range.end, range.start);
            usedBytes += range.end - range.start - 1;
        }
    }
    console.log(`Bytes used: ${usedBytes / totalBytes * 100}%`);
    */

    await browser.close();
  })();