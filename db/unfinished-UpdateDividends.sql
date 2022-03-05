SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Dayton Outar
-- Create date: March 5, 2022
-- Description:	Updates stock dividends
-- =============================================
CREATE PROCEDURE [dbo].[UpdateStockDividends] 
	@dividends XML
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	CREATE TABLE #tblDividends (
		[Code] NVARCHAR(20) NOT NULL,
		[RecordDate] DATE NOT NULL,
        [PaymentDate] DATE NOT NULL,
        [Date] DATETIME2(7) NOT NULL,
        [Currency] NVARCHAR(3) NOT NULL,
        [Amount] DECIMAL(18, 4) NOT NULL,
	);

	INSERT INTO #tblDividends
	(
		[Code] ,
		[RecordDate] ,
		[PaymentDate] ,
        [Date] ,
        [Currency] ,
        [Amount]
	)
    SELECT	d.x.query('./code').value('.', 'nvarchar(20)') [SecurityCode],
            d.x.query('./recordDate').value('.', 'date') [RecordDate],
            d.x.query('./paymentDate').value('.', 'date') [PaymentDate],
            d.x.query('./declarationDate').value('.', 'date') [Date],
			d.x.query('./currency').value('.', 'nvarchar(3)') [Currency],
            d.x.query('./amount').value('.', 'decimal(18,4)') [Amount]            
    FROM @dividends.nodes('dividends') d(x);


        BEGIN TRY
            BEGIN TRANSACTION;

            INSERT INTO [dbo].[Logs]
            (
                [Event] ,
                [Type] ,
                [Details] ,
                [Logged]
            )
            VALUES ( 0, 4, CONVERT( VARCHAR(10), @totalStocks ) + ' stocks traded', @logged);
            SELECT @logNo = SCOPE_IDENTITY();

    INSERT INTO [dbo].[Dividends]
    (
        [Index] ,
        [Value] ,
        [ValueChange] ,
        [LogNo] 
    )
    SELECT  i.[Index] ,
            i.[Value] ,
            i.[ValueChange] ,
            l.[No]
    FROM [#tblIndices] i,
        [dbo].[Logs] l
    WHERE i.[Date] = l.[Logged] 
        AND l.[Event] = 0
        AND NOT EXISTS(SELECT '' FROM [dbo].[StockIndices] e WHERE e.[LogNo] = l.[No]);

            COMMIT TRANSACTION;
        END TRY
        BEGIN CATCH
        
            ROLLBACK TRANSACTION;

        END CATCH;

	DROP TABLE #tblIndices;

END
GO
