DECLARE @start INT = 0,
        @page INT = 10,
        @sortBy TINYINT = 2,
        @sortOrder VARCHAR(4) = 'asc';

--- SOLVENCY ... INCLUDES ASSETS AND LIABILITIES
-- SELECT    ROW_NUMBER() OVER (ORDER BY CASE WHEN @sortBy = 0
--                                         AND @sortOrder = 'asc' THEN
--                                                 pvtSolvency.[CompanyCode]
--                                     END ASC,
--                                     CASE WHEN @sortBy = 0
--                                         AND @sortOrder = 'desc' THEN
--                                                 pvtSolvency.[CompanyCode]
--                                     END DESC,
--                                     CASE WHEN @sortBy = 1
--                                         AND @sortOrder = 'asc' THEN
--                                                 pvtSolvency.[StatementDate]
--                                     END ASC,
--                                     CASE WHEN @sortBy = 1
--                                         AND @sortOrder = 'desc' THEN
--                                                 pvtSolvency.[StatementDate]
--                                     END DESC,
--                                     CASE WHEN @sortBy = 2
--                                         AND @sortOrder = 'asc' THEN
--                                                 pvtSolvency.[8]
--                                     END ASC,
--                                     CASE WHEN @sortBy = 2
--                                         AND @sortOrder = 'desc' THEN
--                                                 pvtSolvency.[8]
--                                     END DESC) [Index]
SELECT
         pvtSolvency.[CompanyCode]
        , pvtSolvency.[StatementDate]        
--         , ISNULL(pvtSolvency.[8], 0) [Current Assets]
--         , ISNULL(pvtSolvency.[9], 0) [Current Liabilities]
--         , ISNULL(pvtSolvency.[8], 0) / ISNULL(pvtSolvency.[9], 0) [Ratio] -- Working Capital and Current Ratio
--         , COUNT(*) OVER () AS [Total]
FROM 
(   
SELECT    f.[CompanyCode]
            , f.[StatementDate]
            , a.[Section]
            , CASE WHEN (a.[Analyte] & 65536) = 65536 THEN
                1
                ELSE
                0
                END [Current]
            , CASE WHEN (a.[Analyte] & 262144) = 262144 THEN
                1
                ELSE
                0
                END [Debt] --Loan
            , CASE WHEN (a.[Analyte] & 512) = 512 THEN
                1
                ELSE
                0
                END [EquityType] -- Non-controlling
            , SUM(a.[Amount]) [Amount]            
    FROM [stocks].[dbo].[StatementAnalytes] a
        INNER JOIN [stocks].[dbo].[FinancialReports] f ON f.[No] = a.[ReportNo]
    WHERE a.[Type] = 2
        --AND (a.[Analyte] & 65536) = 65536
    GROUP BY f.[No], f.[CompanyCode], f.[StatementDate], a.[Section], (a.[Analyte] & 65536), (a.[Analyte] & 262144), (a.[Analyte] & 512)
    ) solvency -- Elements for Total Assets, Current Ratio and Debt-to-Equity
PIVOT 
(
    SUM(solvency.[Amount]) FOR solvency.[Current] IN ( [0], [1] )
) pvtSolvency
-- --WHERE CompanyCode = 'gk'
-- ORDER BY CASE WHEN @sortBy = 0
--             AND @sortOrder = 'asc' THEN
--                     pvtSolvency.[CompanyCode]
--          END ASC,
--          CASE WHEN @sortBy = 0
--             AND @sortOrder = 'desc' THEN
--                     pvtSolvency.[CompanyCode]
--          END DESC,
--          CASE WHEN @sortBy = 1
--             AND @sortOrder = 'asc' THEN
--                     pvtSolvency.[StatementDate]
--          END ASC,
--          CASE WHEN @sortBy = 1
--             AND @sortOrder = 'desc' THEN
--                     pvtSolvency.[StatementDate]
--          END DESC,
--          CASE WHEN @sortBy = 2
--             AND @sortOrder = 'asc' THEN
--                     pvtSolvency.[8]
--          END ASC,
--          CASE WHEN @sortBy = 2
--             AND @sortOrder = 'desc' THEN
--                     pvtSolvency.[8]
--          END DESC