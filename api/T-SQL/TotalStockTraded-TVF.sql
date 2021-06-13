SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Dayton Outar
-- Create date: June 6, 2021
-- Description:	Gets total volume moved over a period including opening and closing date
-- =============================================
CREATE OR ALTER FUNCTION [dbo].[TotalStocksTraded] 
(
	@companyCode NVARCHAR(MAX) = '',
    @begin DATE,
    @end DATE
)
RETURNS TABLE
AS
RETURN
    SELECT
        V.[Code],
        V.[Security],
        V.[Volume],
        V.[OpeningDate],
        O.[OpeningPrice],
        V.[ClosingDate],
        F.[ClosingPrice],
        H.[HighestPrice],
        L.[LowestPrice],
        ROUND(((F.[ClosingPrice] - O.[OpeningPrice]) / O.[OpeningPrice]) * 100, 2) [Percentage],
        (SELECT
            T.[ClosingPrice],
            T.[Date]
        FROM [dbo].[StockTradings] T
            INNER JOIN [dbo].[Companies] C ON C.[Code] = T.[SecurityCode]
        WHERE T.[SecurityCode] = V.[Code] AND CAST(T.[Date] AS DATE) BETWEEN V.[OpeningDate] AND V.[ClosingDate]
        FOR JSON AUTO) AS [Prices]
        --FOR XML RAW ('Price'), ROOT ('Prices'), ELEMENTS
    FROM (SELECT
            C.[Code],
            C.[Security],
            SUM(T.[Volume]) [Volume],
            MIN(CAST(T.[Date] AS DATE)) [OpeningDate],
            MAX(CAST(T.[Date] AS DATE)) [ClosingDate]
        FROM [dbo].[Companies] C
            INNER JOIN [stocks].[dbo].[StockTradings] T ON T.[SecurityCode] = C.[Code]
        WHERE CAST(T.[Date] AS DATE) BETWEEN @begin AND @end
        GROUP BY C.[Code],
                C.[Security]) V
        INNER JOIN
        (SELECT
            T.[SecurityCode],
            (T.[ClosingPrice] - T.[PriceChange]) [OpeningPrice],
            CAST(T.[Date] AS DATE) [Date]
        FROM [dbo].[StockTradings] T) O ON O.[SecurityCode] = V.[Code] AND O.[Date] = V.OpeningDate
        INNER JOIN 
        (SELECT
            T.[SecurityCode],
            T.[ClosingPrice],
            CAST(T.[Date] AS DATE) [Date]
        FROM [dbo].[StockTradings] T) F ON F.[SecurityCode] = V.[Code] AND F.[Date] = V.[ClosingDate]
        INNER JOIN
        (SELECT
            T.[SecurityCode],
            MAX(T.[ClosingPrice]) [HighestPrice]
        FROM [dbo].[StockTradings] T
        GROUP BY T.[SecurityCode]) H ON H.[SecurityCode] = V.[Code]
        INNER JOIN
        (SELECT
            T.[SecurityCode],
            MIN(T.[ClosingPrice]) [LowestPrice]
        FROM [dbo].[StockTradings] T
        GROUP BY T.[SecurityCode]) L ON L.[SecurityCode] = V.[Code]
    WHERE (@companyCode = '' OR EXISTS( SELECT '' FROM STRING_SPLIT(@companyCode, ',') WHERE SUBSTRING(value, 2, LEN(value) - 2) = V.Code) );