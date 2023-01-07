


SELECT
              receivables.[CompanyCode]
            , receivables.[StatementDate]
            , revenues.[Amount] [Revenues]
            , receivables.[Amount] [Receivables]            
            , CONVERT(INT, ROUND( 365 / ( revenues.[Amount] / receivables.[Amount] ), 0)) [Turnover]
FROM
(SELECT       f.[No]
            , f.[CompanyCode]
            , f.[StatementDate]
            , a.[Section]
            , SUM(a.[Amount]) [Amount]            
    FROM [stocks].[dbo].[StatementAnalytes] a
        INNER JOIN [stocks].[dbo].[FinancialReports] f ON f.[No] = a.[ReportNo]
    WHERE a.[Type] = 2
        AND (a.[Analyte] & 16384) = 16384 -- Receivables
    GROUP BY f.[No], f.[CompanyCode], f.[StatementDate], a.[Section]) receivables
    INNER JOIN
(SELECT       f.[No]
            , f.[CompanyCode]
            , f.[StatementDate]
            , a.[Section]
            , SUM(a.[Amount]) [Amount]            
    FROM [stocks].[dbo].[StatementAnalytes] a
        INNER JOIN [stocks].[dbo].[FinancialReports] f ON f.[No] = a.[ReportNo]
    WHERE a.[Type] = 1
        AND a.[Section] = 1
    GROUP BY f.[No], f.[CompanyCode], f.[StatementDate], a.[Section]) revenues ON receivables.[No] = revenues.[No]
ORDER BY receivables.[StatementDate] DESC


SELECT
              inventories.[CompanyCode]
            , inventories.[StatementDate]
            , costOfSales.[Amount] [Cost of Sales]
            , inventories.[Amount] [Inventories]            
            , CONVERT(INT, ROUND( 365 / ( costOfSales.[Amount] / inventories.[Amount] ), 0)) [Turnover]
FROM
(SELECT       f.[No]
            , f.[CompanyCode]
            , f.[StatementDate]
            , a.[Section]
            , SUM(a.[Amount]) [Amount]            
    FROM [stocks].[dbo].[StatementAnalytes] a
        INNER JOIN [stocks].[dbo].[FinancialReports] f ON f.[No] = a.[ReportNo]
    WHERE a.[Type] = 2
        AND (a.[Analyte] & 8192) = 8192 -- Inventories
    GROUP BY f.[No], f.[CompanyCode], f.[StatementDate], a.[Section]) inventories
    INNER JOIN
(SELECT       f.[No]
            , f.[CompanyCode]
            , f.[StatementDate]
            , a.[Section]
            , SUM(a.[Amount]) [Amount]            
    FROM [stocks].[dbo].[StatementAnalytes] a
        INNER JOIN [stocks].[dbo].[FinancialReports] f ON f.[No] = a.[ReportNo]
    WHERE a.[Type] = 1
        AND a.[Section] = 2
        AND (a.[Analyte] & 2) = 2 -- Direct
    GROUP BY f.[No], f.[CompanyCode], f.[StatementDate], a.[Section]) costOfSales ON inventories.[No] = costOfSales.[No]
ORDER BY inventories.[StatementDate] DESC