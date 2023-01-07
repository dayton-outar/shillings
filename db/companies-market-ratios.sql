

(SELECT   f.[No]
            , f.[CompanyCode]
            , f.[StatementDate]
            , a.[Section]
            , a.[Amount] [eps]
    FROM [stocks].[dbo].[StatementAnalytes] a
        INNER JOIN [stocks].[dbo].[FinancialReports] f ON f.[No] = a.[ReportNo]
    WHERE a.[Type] = 1 AND ( a.[Section] = 6 AND ( ( a.[Analyte] & 1024 ) = 1024 ) ))



-- Almost 1 second for 15 rows ... Not good
SELECT
              shares.[CompanyCode]
            , shares.[StatementDate]
            , shares.[Amount] [Shares Outstanding]
            , equity.[Amount] [Equity]
            , equity.[Amount] / shares.[Amount] [bvs]
FROM
(SELECT        f.[No]
            , f.[CompanyCode]
            , f.[StatementDate]
            , a.[Section]
            , SUM(a.[Amount]) [Amount]            
    FROM [stocks].[dbo].[StatementAnalytes] a
        INNER JOIN [stocks].[dbo].[FinancialReports] f ON f.[No] = a.[ReportNo]
    WHERE a.[Type] = 2
        AND a.[Section] = 10
        AND (a.[Analyte] & 512) <> 512 -- Non-controlling
    GROUP BY f.[No], f.[CompanyCode], f.[StatementDate], a.[Section]) equity
    INNER JOIN
(SELECT        f.[No]
            , f.[CompanyCode]
            , f.[StatementDate]
            , a.[Section]
            , SUM(a.[Amount]) [Amount]            
    FROM [stocks].[dbo].[StatementAnalytes] a
        INNER JOIN [stocks].[dbo].[FinancialReports] f ON f.[No] = a.[ReportNo]
    WHERE a.[Type] = 1
        AND a.[Section] = 7 -- Shares Outsanding
    GROUP BY f.[No], f.[CompanyCode], f.[StatementDate], a.[Section]) shares ON equity.[No] = shares.[No]