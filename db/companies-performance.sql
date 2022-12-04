-- SELECT    f.[No]
--         , c.[Name]
--         , f.[Period]
--         , f.[StatementDate]
--         , f.[IsAudited]
-- FROM [stocks].[dbo].[FinancialReports] f
--     INNER JOIN [stocks].[dbo].[Companies] c ON f.[CompanyCode] = c.[Code]

-- SELECT    c.[Code]
--         , c.[Name] 
--         , f.[StatementDate]
--         , a.[Section]
--         , SUM(a.[Amount]) OVER(PARTITION BY a.[Section]) [Total]
--         --, a.[Sequence]
--         -- , a.[Description]
--         -- , a.[Type]
--         -- , a.[Section]
--         -- , a.[Analyte]
--         -- , a.[Amount]
-- FROM [stocks].[dbo].[StatementAnalytes] a
--     INNER JOIN [stocks].[dbo].[FinancialReports] f ON f.[No] = a.[ReportNo]
--     INNER JOIN [stocks].[dbo].[Companies] c ON f.[CompanyCode] = c.[Code]
-- WHERE a.[Type] = 1
-- --GROUP BY c.[Code], c.[Name], f.[StatementDate]
-- ORDER BY f.[StatementDate]

DBCC DROPCLEANBUFFERS;
DBCC FREEPROCCACHE;
GO

--- INCOME TOTALS ... INCLUDES REVENUE
SELECT    pvtEarnings.[No]
        , pvtEarnings.[CompanyCode]
        , pvtEarnings.[StatementDate]        
        , ISNULL(pvtEarnings.[1], 0) [Revenues]
        , ( ISNULL(pvtEarnings.[1], 0) + ISNULL(pvtEarnings.[3], 0) ) - ( ISNULL(pvtEarnings.[2], 0) +  ISNULL(pvtEarnings.[4], 0)) [Earnings]
        --, pvtEarnings.[7] [SharesOutstanding]
        , pvtEarnings.[eps]
FROM 
(SELECT   i.[No]
        , i.[CompanyCode]
        , i.[StatementDate]
        , i.[Section]
        , e.[Amount] [eps]
        , i.[Amount]        
FROM
    (SELECT   f.[No]
            , f.[CompanyCode]
            , f.[StatementDate]
            , a.[Section]
            , SUM(a.[Amount]) [Amount]
    FROM [stocks].[dbo].[StatementAnalytes] a
        INNER JOIN [stocks].[dbo].[FinancialReports] f ON f.[No] = a.[ReportNo]
    WHERE a.[Type] = 1 AND a.[Section] <> 6
    GROUP BY f.[No], f.[CompanyCode], f.[StatementDate], a.[Section]) i
    LEFT JOIN
    (SELECT   f.[No]
            , f.[CompanyCode]
            , f.[StatementDate]
            , a.[Section]
            , a.[Amount]
    FROM [stocks].[dbo].[StatementAnalytes] a
        INNER JOIN [stocks].[dbo].[FinancialReports] f ON f.[No] = a.[ReportNo]
    WHERE a.[Type] = 1 AND ( a.[Section] = 6 AND ( a.[Analyte] = 1024 OR a.[Analyte] = 3072 ))) e ON i.[No] = e.[No]) earnings
PIVOT 
(
    SUM(earnings.[Amount]) FOR earnings.[Section] IN ( [1], [2], [3], [4] )
) pvtEarnings
ORDER BY pvtEarnings.[StatementDate]