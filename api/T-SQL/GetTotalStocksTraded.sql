SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Dayton Outar
-- Create date: June 6, 2021
-- Description:	Gets total volume moved over a period including opening and closing date
-- =============================================
CREATE PROCEDURE [dbo].[GetTotalStocksTraded] 
	@companyCode NVARCHAR(10) = '',
    @begin DATE,
    @end DATE
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT
        V.[Code],
        V.[Security],
        V.[Volume],
        V.[OpeningDate],
        O.[OpeningPrice],
        V.[ClosingDate],
        F.[ClosingPrice]
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
    WHERE (@companyCode = '' OR V.[Code] = @companyCode);

END
GO