
SELECT
              debt.[CompanyCode]
            , debt.[StatementDate]
            , debt.[Amount] [Debt]
            , equity.[Amount] [Equity]
            , debt.[Amount] / equity.[Amount] [D/E]
FROM
(SELECT       f.[No]
            , f.[CompanyCode]
            , f.[StatementDate]
            , a.[Section]
            , SUM(a.[Amount]) [Amount]            
    FROM [stocks].[dbo].[StatementAnalytes] a
        INNER JOIN [stocks].[dbo].[FinancialReports] f ON f.[No] = a.[ReportNo]
    WHERE a.[Type] = 2
        AND (a.[Analyte] & 262144) = 262144 -- Loan
    GROUP BY f.[No], f.[CompanyCode], f.[StatementDate], a.[Section]) debt
INNER JOIN
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
    GROUP BY f.[No], f.[CompanyCode], f.[StatementDate], a.[Section]) equity ON debt.[No] = equity.[No]
ORDER BY debt.[StatementDate] DESC
