DECLARE @period INT,
        @begin DATE,
        @end DATE;

--- SOLVENCY: Elements for Total Assets, Current Ratio and Debt-to-Equity
SELECT    totalAssets.[No]
        , totalAssets.[CompanyCode]
        , totalAssets.[StatementDate]
        , totalAssets.[Total]
        , workingCapital.[Ratio]
        , debtToEquity.[Ratio]
FROM
(SELECT    pvtAssets.[No]
        , pvtAssets.[CompanyCode]
        , pvtAssets.[StatementDate] 
        , pvtAssets.[8] [Total]
FROM 
(   
    SELECT    f.[No]
            , f.[CompanyCode]
            , f.[StatementDate]
            , a.[Section]
            , SUM(a.[Amount]) [Amount]            
    FROM [stocks].[dbo].[StatementAnalytes] a
        INNER JOIN [stocks].[dbo].[FinancialReports] f ON f.[No] = a.[ReportNo]
    WHERE a.[Type] = 2
        AND f.[Period] = @period
        AND f.[StatementDate] BETWEEN @begin AND @end
    GROUP BY f.[No], f.[CompanyCode], f.[StatementDate], a.[Section]
) assets
PIVOT 
(
    SUM(assets.[Amount]) FOR assets.[Section] IN ( [8] )
) pvtAssets) totalAssets
INNER JOIN
(SELECT    pvtWc.[No]
        , pvtWc.[CompanyCode]
        , pvtWc.[StatementDate] 
        , pvtWc.[8] / pvtWc.[9] [Ratio]
FROM 
(   
    SELECT    f.[No]
            , f.[CompanyCode]
            , f.[StatementDate]
            , a.[Section]
            , SUM(a.[Amount]) [Amount]            
    FROM [stocks].[dbo].[StatementAnalytes] a
        INNER JOIN [stocks].[dbo].[FinancialReports] f ON f.[No] = a.[ReportNo]
    WHERE a.[Type] = 2
        AND (a.[Analyte] & 65536) = 65536
        AND f.[Period] = @period
        AND f.[StatementDate] BETWEEN @begin AND @end
    GROUP BY f.[No], f.[CompanyCode], f.[StatementDate], a.[Section]
) wc
PIVOT 
(
    SUM(wc.[Amount]) FOR wc.[Section] IN ( [8], [9] )
) pvtWc) workingCapital ON totalAssets.[No] = workingCapital.[No]
INNER JOIN
(SELECT    pvtDe.[No]
        , pvtDe.[CompanyCode]
        , pvtDe.[StatementDate] 
        , ISNULL(pvtDe.[9], 0) / pvtDe.[10] [Ratio]
FROM 
(  
    SELECT    f.[No]
            , f.[CompanyCode]
            , f.[StatementDate]
            , a.[Section]
            , SUM(a.[Amount]) [Amount]            
    FROM [stocks].[dbo].[StatementAnalytes] a
        INNER JOIN [stocks].[dbo].[FinancialReports] f ON f.[No] = a.[ReportNo]
    WHERE a.[Type] = 2
        AND f.[Period] = @period
        AND f.[StatementDate] BETWEEN @begin AND @end
        AND ( ( a.[Section] = 9 AND (a.[Analyte] & 262144) = 262144 ) OR ( a.[Section] = 10 AND (a.[Analyte] & 512) = 0 ) )
    GROUP BY f.[No], f.[CompanyCode], f.[StatementDate], a.[Section]
) de
PIVOT 
(
    SUM(de.[Amount]) FOR de.[Section] IN ( [9], [10] )
) pvtDe) debtToEquity ON totalAssets.[No] = debtToEquity.[No]