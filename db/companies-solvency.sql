

--- SOLVENCY ... INCLUDES ASSETS AND LIABILITIES
SELECT    pvtSolvency.[No]
        , pvtSolvency.[CompanyCode]
        , pvtSolvency.[StatementDate]        
        , ISNULL(pvtSolvency.[8], 0) [Current Assets]
        , ISNULL(pvtSolvency.[9], 0) [Current Liabilities]
        , ISNULL(pvtSolvency.[8], 0) / ISNULL(pvtSolvency.[9], 0) [Ratio] -- Working Capital and Current Ratio
FROM 
(   SELECT   f.[No]
            , f.[CompanyCode]
            , f.[StatementDate]
            , a.[Section]
            , SUM(a.[Amount]) [Amount]
    FROM [stocks].[dbo].[StatementAnalytes] a
        INNER JOIN [stocks].[dbo].[FinancialReports] f ON f.[No] = a.[ReportNo]
    WHERE a.[Type] = 2
        AND (a.[Analyte] & 65536) > 0
    GROUP BY f.[No], f.[CompanyCode], f.[StatementDate], a.[Section]) solvency
    -- Debt as in Loan to Equity Ratio needed as well
PIVOT 
(
    SUM(solvency.[Amount]) FOR solvency.[Section] IN ( [8], [9] )
) pvtSolvency
--WHERE CompanyCode = 'gk'
--ORDER BY pvtSolvency.[1] DESC
-- ORDER BY pvtSolvency.[StatementDate] DESC