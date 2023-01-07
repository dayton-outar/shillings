



UPDATE s SET 
s.[Reader] = 'function readStocksAndIndices() {
    let results = {
        indices: [],
        stocks: [],
    };
    const market = 3; // JSE Main Market Reference Number
    const urlSearchParams = new URLSearchParams(window.location.search);
    const params = Object.fromEntries(urlSearchParams.entries());
    //--    
    const tradeDate = params.date;

    let indices = document.querySelectorAll(''table'')[0];
    if (indices) {
        indices.querySelectorAll(''tbody > tr'').forEach((item) => {
            let cols = item.querySelectorAll(''td'');
            let value = cols[1] ? parseFloat(cols[1].textContent.trim().replace(/,/g, '''')) : 0;
            let change = cols[3] ? parseFloat(cols[3].textContent.trim().replace(/,/g, '''')) : 0;
            results.indices.push({
                marketNo: market,
                code: cols[0].querySelector(''a'').href.split(''indexCode='')[1],
                date: tradeDate,
                value: value,
                change: change
            });
        });
    }

    let ordinary = document.querySelectorAll(''table'')[1];
    if (ordinary) {
        ordinary.querySelectorAll(''tbody > tr'').forEach((item) => {
            let cols = item.querySelectorAll(''td'');
            let closingPrice = parseFloat(cols[3].textContent.trim().replace(/,/g, ''''));
            let priceChange = cols[4] ? parseFloat(cols[4].textContent.trim().replace(/,/g, '''')) : 0; 
            results.stocks.push({
                marketNo: market,
                code: cols[1].querySelector(''a'').href.split(''instrument='')[1].split(''-'')[0],
                name: cols[1].querySelector(''a'').title.trim(),
                volume: parseInt(cols[7].textContent.trim().replace(/,/g, ''''), 10),
                closing: closingPrice,
                change: priceChange,
                percentage: (priceChange / (closingPrice - priceChange)).toFixed(2),
                date: tradeDate
            });
        });
    }
    let preferred = document.querySelectorAll(''table'')[3];
    if (preferred) {
        preferred.querySelectorAll(''tbody > tr'').forEach((item) => {
            let cols = item.querySelectorAll(''td'');
            let closingPrice = parseFloat(cols[3].textContent.trim().replace(/,/g, ''''));
            let priceChange = cols[4] ? parseFloat(cols[4].textContent.trim().replace(/,/g, '''')) : 0;
            results.stocks.push({
                marketNo: market,
                code: cols[1].querySelector(''a'').href.split(''instrument='')[1].split(''-'')[0],
                name: cols[1].querySelector(''a'').title.trim(),
                volume: parseInt(cols[7].textContent.trim().replace(/,/g, ''''), 10),
                closing: closingPrice,
                change: priceChange,
                percentage: (priceChange / (closingPrice - priceChange)).toFixed(2),
                date: tradeDate
            });
        });
    }
    return results;
}'
FROM [stocks].[dbo].[DataSources] s
WHERE s.[No] = 2