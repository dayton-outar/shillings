using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Harpoon.Migrations
{
    public partial class UpdateCompaniesStocksAndTotalStocksTradedTVF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // UpdateCompanies Stored Procedure
            migrationBuilder.Sql(
                @"EXEC('
                    SET ANSI_NULLS ON
                    GO
                    SET QUOTED_IDENTIFIER ON
                    GO
                    -- =============================================
                    -- Author:		Dayton Outar
                    -- Create date: April 29, 2021
                    -- Description:	Updates companies list
                    -- =============================================
                    CREATE OR ALTER PROCEDURE [dbo].[UpdateCompanies] 
                        @stocks XML
                    AS
                    BEGIN
                        -- SET NOCOUNT ON added to prevent extra result sets from
                        -- interfering with SELECT statements.
                        SET NOCOUNT ON;

                        CREATE TABLE #tblCompanies (
                            [Code] NVARCHAR(20) NOT NULL,
                            [Security] NVARCHAR(MAX) NOT NULL,
                            [Created] DATETIME2 NOT NULL
                        );

                        INSERT INTO #tblCompanies
                        (
                            [Code],
                            [Security],
                            [Created]
                        )
                        SELECT	d.x.query('./code').value('.', 'nvarchar(20)') [Code],
                                d.x.query('./security').value('.', 'nvarchar(max)') [Security],
                                d.x.query('./date').value('.', 'datetime2') [Date]
                        FROM @stocks.nodes('stocks') d(x);

                        INSERT INTO [dbo].[Companies]
                        (
                            [Code] ,
                            [Security],
                            [Created]
                        )
                        SELECT  [Code] ,
                                [Security] ,
                                [Created]
                        FROM    #tblCompanies
                        WHERE   NOT EXISTS (
                            SELECT  [Code]
                            FROM    [dbo].[Companies] X
                            WHERE   X.[Code] = #tblCompanies.[Code]);

                        DROP TABLE #tblCompanies;

                    END
                    GO
                ')");
            
            // UpdateStockTradings Stored Pricedure
            migrationBuilder.Sql(
                @"EXEC('
                    SET ANSI_NULLS ON
                    GO
                    SET QUOTED_IDENTIFIER ON
                    GO
                    -- =============================================
                    -- Author:		Dayton Outar
                    -- Create date: April 30, 2021
                    -- Description:	Updates stock tradings
                    -- =============================================
                    CREATE OR ALTER PROCEDURE [dbo].[UpdateStockTradings] 
                        @stocks XML
                    AS
                    BEGIN
                        -- SET NOCOUNT ON added to prevent extra result sets from
                        -- interfering with SELECT statements.
                        SET NOCOUNT ON;

                        EXEC [dbo].[UpdateCompanies] @stocks;

                        DECLARE @logged DATE;
                        DECLARE @totalStocks INT;
                        DECLARE @logNo BIGINT;

                        CREATE TABLE #tblTradings (
                            [SecurityCode] NVARCHAR(20) NOT NULL,
                            [Volume] [bigint] NOT NULL,
                            [ClosingPrice] [decimal](18, 2) NOT NULL,
                            [PriceChange] [decimal](18, 2) NOT NULL,
                            [Percentage] [decimal](18, 2) NOT NULL,
                            [Date] [datetime2](7) NOT NULL
                        );

                        INSERT INTO #tblTradings
                        (
                            [SecurityCode],
                            [Volume] ,
                            [ClosingPrice] ,
                            [PriceChange] ,
                            [Percentage] ,
                            [Date]
                        )
                        SELECT	d.x.query('./code').value('.', 'nvarchar(20)') [SecurityCode],
                                d.x.query('./volume').value('.', 'bigint') [Volume],
                                d.x.query('./closing').value('.', 'decimal(18,2)') [ClosingPrice],
                                d.x.query('./change').value('.', 'decimal(18,2)') [PriceChange],
                                d.x.query('./percentage').value('.', 'decimal(18,2)') [Percentage],
                                d.x.query('./date').value('.', 'datetime2') [Date]
                        FROM @stocks.nodes('stocks') d(x);

                        SELECT @logged = MIN([Date]) FROM #tblTradings;
                        SELECT @totalStocks = COUNT([SecurityCode]) FROM #tblTradings;

                        IF NOT EXISTS ( SELECT '' FROM [dbo].[Logs] L WHERE L.[Logged] = @logged ) AND @totalStocks > 0
                        BEGIN
                            --
                            BEGIN TRY
                                BEGIN TRANSACTION;

                                INSERT INTO [dbo].[Logs]
                                (
                                    [Event] ,
                                    [Details] ,
                                    [Logged]
                                )
                                VALUES ( 0, CONVERT( VARCHAR(10), @totalStocks ) + ' stocks traded', @logged);
                                SELECT @logNo = SCOPE_IDENTITY();

                                INSERT INTO [dbo].[StockTradings]
                                (
                                    [SecurityCode] ,
                                    [LogNo] ,
                                    [Volume] ,
                                    [ClosingPrice] ,
                                    [PriceChange] ,
                                    [Percentage] ,
                                    [Date]
                                )
                                SELECT  [SecurityCode],
                                        @logNo ,
                                        [Volume] ,
                                        [ClosingPrice] ,
                                        [PriceChange] ,
                                        [Percentage] ,
                                        [Date]
                                FROM    #tblTradings;

                                COMMIT TRANSACTION;
                            END TRY
                            BEGIN CATCH
                            
                                ROLLBACK TRANSACTION;

                            END CATCH;
                            --
                        END

                        DROP TABLE #tblTradings;

                    END
                    GO
                ')");
            
            // TotalStocksTraded Table-Valued Function
            migrationBuilder.Sql(
                @"EXEC('
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
                    GO
                ')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"EXEC('DROP PROCEDURE IF EXISTS [dbo].[UpdateCompanies];')");
            
            migrationBuilder.Sql(
                @"EXEC('DROP PROCEDURE IF EXISTS [dbo].[UpdateStockTradings];')");

            migrationBuilder.Sql(
                @"EXEC('DROP FUNCTION IF EXISTS [dbo].[TotalStocksTraded];')");
        }
    }
}
