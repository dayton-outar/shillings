

SELECT
    C.[Security],
    T.[Volume],
    (T.[ClosingPrice] - T.[PriceChange]) [OpeningPrice],
    T.[PriceChange],
    T.[ClosingPrice],
    ( T.[Volume] * T.[ClosingPrice] ) [Cost]
FROM [stocks].[dbo].[StockTradings] T
    INNER JOIN [stocks].[dbo].[Companies] C ON C.[Code] = T.[SecurityCode]
WHERE CAST(T.[Date] AS date) = '2021-05-28'