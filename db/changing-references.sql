-- ALTER TABLE [StockTradings] ADD [StockNo] bigint NOT NULL DEFAULT CAST(0 AS bigint);
-- GO
-- ALTER TABLE [MarketIndexStock] ADD [StocksNo] bigint NOT NULL DEFAULT CAST(0 AS bigint);
-- GO
-- ALTER TABLE [Dividends] ADD [StockNo] bigint NOT NULL DEFAULT CAST(0 AS bigint);
-- GO
-- ALTER TABLE [OutstandingSharesLog] ADD [StockNo] bigint NOT NULL DEFAULT CAST(0 AS bigint);
-- GO

-- UPDATE t SET
-- t.[StockNo] = s.[No]
-- FROM [stocks].[dbo].[StockTradings] t
--     INNER JOIN [stocks].[dbo].[Stocks] s ON t.[SecurityCode] = s.[Code]

-- UPDATE x SET
-- x.[StocksNo] = s.[No]
-- FROM [stocks].[dbo].[MarketIndexStock] x
--     INNER JOIN [stocks].[dbo].[Stocks] s ON x.[StocksCode] = s.[Code]

-- UPDATE d SET
-- d.[StockNo] = s.[No]
-- FROM [stocks].[dbo].[Dividends] d
--     INNER JOIN [stocks].[dbo].[Stocks] s ON d.[StockCode] = s.[Code]

-- UPDATE l SET
-- l.[StockNo] = s.[No]
-- FROM [stocks].[dbo].[OutstandingSharesLog] l
--     INNER JOIN [stocks].[dbo].[Stocks] s ON l.[Code] = s.[Code]

ALTER TABLE [OutstandingSharesLog] ADD CONSTRAINT [PK_OutstandingSharesLog] PRIMARY KEY ([No]);
GO