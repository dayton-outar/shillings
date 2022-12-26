



UPDATE s SET 
s.[Reader] = 'function readIndices() {
    let results = [];
    let items = document.querySelectorAll(''table > tbody > tr'');
    items.forEach((item) => {
        let cols = item.querySelectorAll(''td'');
        results.push({
            indexNo: 1,
            date: cols[0].textContent.trim(),
            value: parseFloat(cols[1].textContent.trim().replace(/,/g, '''')),
            change: parseFloat(cols[2].textContent.trim().replace(/,/g, ''''))
        });
    });
    return results;
}'
FROM [stocks].[dbo].[DataSources] s
WHERE s.[No] = 4