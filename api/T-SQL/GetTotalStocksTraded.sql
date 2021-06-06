
DECLARE @companyCode NVARCHAR(10) = ''

SELECT
    V.[SecurityCode],
    V.[Security],
    V.[Volume],
    V.[OpeningDate],
    O.[OpeningPrice],
    V.[ClosingDate],
    F.[ClosingPrice]
FROM (SELECT
        T.[SecurityCode],
        C.[Security],
        SUM(T.[Volume]) [Volume],
        MIN(CAST(T.[Date] AS DATE)) [OpeningDate],
        MAX(CAST(T.[Date] AS DATE)) [ClosingDate]
    FROM [stocks].[dbo].[StockTradings] T
        INNER JOIN [dbo].[Companies] C ON C.[Code] = T.[SecurityCode]
    WHERE CAST(T.[Date] AS DATE) BETWEEN '1999-04-01' AND '2021-06-05'
    GROUP BY T.[SecurityCode],
            C.[Security]) V
    INNER JOIN
    (SELECT
        T.[SecurityCode],
        (T.[ClosingPrice] - T.[PriceChange]) [OpeningPrice],
        CAST(T.[Date] AS DATE) [Date]
    FROM [dbo].[StockTradings] T) O ON O.[SecurityCode] = V.[SecurityCode] AND O.[Date] = V.OpeningDate
    INNER JOIN 
    (SELECT
        T.[SecurityCode],
        T.[ClosingPrice],
        CAST(T.[Date] AS DATE) [Date]
    FROM [dbo].[StockTradings] T) F ON F.[SecurityCode] = V.[SecurityCode] AND F.[Date] = V.[ClosingDate]
WHERE (@companyCode = '' OR V.[SecurityCode] = @companyCode)