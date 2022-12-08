DECLARE @start INT = 0,
        @page INT = 10,
        @sortBy TINYINT = 2,
        @sortOrder VARCHAR(4) = 'asc';

--- SOLVENCY ... INCLUDES ASSETS AND LIABILITIES
SELECT    ROW_NUMBER() OVER (ORDER BY CASE WHEN @sortBy = 0
                                        AND @sortOrder = 'asc' THEN
                                                pvtSolvency.[CompanyCode]
                                    END ASC,
                                    CASE WHEN @sortBy = 0
                                        AND @sortOrder = 'desc' THEN
                                                pvtSolvency.[CompanyCode]
                                    END DESC,
                                    CASE WHEN @sortBy = 1
                                        AND @sortOrder = 'asc' THEN
                                                pvtSolvency.[StatementDate]
                                    END ASC,
                                    CASE WHEN @sortBy = 1
                                        AND @sortOrder = 'desc' THEN
                                                pvtSolvency.[StatementDate]
                                    END DESC,
                                    CASE WHEN @sortBy = 2
                                        AND @sortOrder = 'asc' THEN
                                                pvtSolvency.[8]
                                    END ASC,
                                    CASE WHEN @sortBy = 2
                                        AND @sortOrder = 'desc' THEN
                                                pvtSolvency.[8]
                                    END DESC) [Index]
        , pvtSolvency.[CompanyCode]
        , pvtSolvency.[StatementDate]        
        , ISNULL(pvtSolvency.[8], 0) [Current Assets]
        , ISNULL(pvtSolvency.[9], 0) [Current Liabilities]
        , ISNULL(pvtSolvency.[8], 0) / ISNULL(pvtSolvency.[9], 0) [Ratio] -- Working Capital and Current Ratio
        , COUNT(*) OVER () AS [Total]
FROM 
(   SELECT    f.[CompanyCode]
            , f.[StatementDate]
            , a.[Section]
            , SUM(a.[Amount]) [Amount]            
    FROM [stocks].[dbo].[StatementAnalytes] a
        INNER JOIN [stocks].[dbo].[FinancialReports] f ON f.[No] = a.[ReportNo]
    WHERE a.[Type] = 2
        AND (a.[Analyte] & 65536) = 65536
    GROUP BY f.[No], f.[CompanyCode], f.[StatementDate], a.[Section]) solvency
    -- Debt as in Loan to Equity Ratio needed as well
PIVOT 
(
    SUM(solvency.[Amount]) FOR solvency.[Section] IN ( [8], [9] )
) pvtSolvency
--WHERE CompanyCode = 'gk'
ORDER BY CASE WHEN @sortBy = 0
            AND @sortOrder = 'asc' THEN
                    pvtSolvency.[CompanyCode]
         END ASC,
         CASE WHEN @sortBy = 0
            AND @sortOrder = 'desc' THEN
                    pvtSolvency.[CompanyCode]
         END DESC,
         CASE WHEN @sortBy = 1
            AND @sortOrder = 'asc' THEN
                    pvtSolvency.[StatementDate]
         END ASC,
         CASE WHEN @sortBy = 1
            AND @sortOrder = 'desc' THEN
                    pvtSolvency.[StatementDate]
         END DESC,
         CASE WHEN @sortBy = 2
            AND @sortOrder = 'asc' THEN
                    pvtSolvency.[8]
         END ASC,
         CASE WHEN @sortBy = 2
            AND @sortOrder = 'desc' THEN
                    pvtSolvency.[8]
         END DESC