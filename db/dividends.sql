

SELECT    d.[StockCode]
        , YEAR(d.[PaymentDate]) [Year]
        , d.[Currency]
        , COUNT(d.[StockCode]) [Count]
        , SUM(d.[Amount]) [Total]
FROM [stocks].[dbo].[Dividends] d
GROUP BY  d.[StockCode]
        , YEAR(d.[PaymentDate])
        , d.[Currency]