SELECT  --t.[No]
--       --, 
      s.[Code]
      , s.[MarketNo]
--     --   ,[Volume]
--     --   ,[ClosingPrice]
--     --   ,[PriceChange]
--     --   ,[Percentage]
      , [Date]
      , [LogNo]
      , COUNT(*)
    --   ,[MarketCapitalization]
    --   ,[StockNo]
-- DELETE t
  FROM [stocks].[dbo].[StockTradings] t
    INNER JOIN [stocks].[dbo].[Stocks] s ON t.[StockNo] = s.[No]
WHERE --t.[No] < 261062
    --AND 
    s.[MarketNo] = 3
    --AND t.[LogNo] < 145737
    AND t.[Date] >= '2022-01-03' -- 2022-01-03 (45219) and 2022-04-01 (75268) triplicated
GROUP BY --t.[No]
      --, 
      s.[Code]
      , s.[MarketNo]
      , [Date]
      , [LogNo]
--HAVING COUNT(*) <= 2
--ORDER BY t.[No] ASC