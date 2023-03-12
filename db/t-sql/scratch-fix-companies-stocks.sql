-- UPDATE s SET
--     s.[CompanyCode] = 'proven'
-- FROM [stocks].[dbo].[Stocks] s
-- WHERE s.[CompanyCode] IN ( 'pbs9.75' )

SELECT TOP (1000) [Code]
      ,[Currency]
      ,[StockType]
      ,[IssuedShares]
      ,[OutstandingShares]
      ,[CompanyCode]
      ,[isListed]
      ,[Created]
      ,[Name]
  FROM [stocks].[dbo].[Stocks] s
  WHERE s.[CompanyCode] IN ( 'pbs' )


-- DELETE f FROM [dbo].[CompanyFileContent] f
-- WHERE f.[CompaniesCode] = 'pbs9.75'

INSERT INTO [dbo].[CompanyFileContent]
VALUES ( 'pbs', 20 );

-- UPDATE c SET
--     c.[Code] = 'pbs'
-- FROM [stocks].[dbo].[Companies] c
-- WHERE c.[Code] IN ( 'pbs9.75' )