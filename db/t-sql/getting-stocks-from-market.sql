SELECT [Code]
      ,[Name]
      ,[Currency]
      ,[StockType]
      ,[IssuedShares]
      ,[OutstandingShares]
      ,[CompanyCode]
      ,[isListed]
      ,[Created]
FROM [stocks].[dbo].[Stocks] s
WHERE EXISTS(SELECT '' 
       FROM [stocks].[dbo].[MarketIndexStock] mis
            INNER JOIN [stocks].[dbo].[MarketIndices] m ON m.[No] = mis.[IndicesNo]
       WHERE m.[MarketCode] = 'jse' AND mis.[StocksCode] = s.[Code])