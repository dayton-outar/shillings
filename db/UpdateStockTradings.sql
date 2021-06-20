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
