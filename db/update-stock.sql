SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Dayton Outar
-- Create date: Sep 3, 2022
-- Description:	Modifies stock details
-- =============================================
CREATE PROCEDURE [dbo].[UpdateStock]
    @stock XML
AS
    BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;
    --
    DECLARE @stockCode NVARCHAR(20) = '',
            @stockName NVARCHAR(MAX) = '',
            @created DATETIME2 = GETDATE(),
            @currency NVARCHAR(3) = 'JMD',
            @companyCode NVARCHAR(20) = '',
            @issuedShares INT = 0,
            @outstandingShares INT = 0,
            @stockType NVARCHAR(50) = 'ORDINARY',
            @isListed BIT = 1;

	SELECT	@stockCode          = s.x.query('Code').value('.', 'nvarchar(20)'),
            @stockName          = s.x.query('Name').value('.', 'nvarchar(max)'),
            @currency           = s.x.query('Currency').value('.', 'nvarchar(3)'),
            @stockType          = s.x.query('StockType').value('.', 'nvarchar(50)'),
            @issuedShares       = s.x.query('IssuedShares').value('.', 'int'),
            @outstandingShares  = s.x.query('OutstandingShares').value('.', 'int'),
            @companyCode        = s.x.query('Company/Code').value('.', 'nvarchar(20)'),
            @isListed           = s.x.query('isListed').value('.', 'bit'),
            @created            = s.x.query('Created').value('.', 'date')  
    FROM    @stock.nodes('Stock') s ( x );

    DECLARE @tblMarketIndices TABLE
    (
        [IndicesNo] BIGINT NOT NULL
    );

    INSERT INTO @tblMarketIndices
    (
        [IndicesNo]
    )
    SELECT	i.x.query('No').value('.', 'bigint') [No]
    FROM    @stock.nodes('Stock/Indices/MarketIndex') i ( x );

    BEGIN TRY
        BEGIN TRANSACTION;
    
        UPDATE s SET
            s.[Name]                = @stockName,
            s.[Currency]            = @currency,
            s.[CompanyCode]         = @companyCode,
            s.[StockType]           = @stockType,
            s.[IssuedShares]        = @issuedShares,
            s.[OutstandingShares]   = @outstandingShares,
            s.[isListed]            = @isListed,
            s.[Created]             = @created
        FROM [dbo].[Stocks] s
        WHERE s.[Code] = @stockCode;

        -- Updating industries
        -- Do Deletions
        DELETE i FROM [dbo].[MarketIndexStock] i
        WHERE i.[StocksCode] = @stockCode;

        -- Do Insertions
        INSERT INTO [dbo].[MarketIndexStock]
            (
                [StocksCode],
                [IndicesNo]
            )
        SELECT  @stockCode,
                i.[IndicesNo]
        FROM @tblMarketIndices i;

        COMMIT TRANSACTION;

    END TRY
    BEGIN CATCH
        
        ROLLBACK TRANSACTION;
        THROW;

    END CATCH;   

END
GO