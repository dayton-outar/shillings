

SELECT 
SUM(VTC.[Cost])
FROM 
(SELECT
    C.[Security],
    T.[Volume],
    T.[ClosingPrice],
    (T.[ClosingPrice] - T.[PriceChange]) [OpeningPrice],
    ( T.[Volume] * T.[ClosingPrice] ) [Cost]
FROM [stocks].[dbo].[StockTradings] T
    INNER JOIN [stocks].[dbo].[Companies] C ON C.[Code] = T.[SecurityCode]
WHERE CAST(T.[Date] AS date) = '2021-05-28') VTC