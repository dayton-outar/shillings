USE [master]
GO
/****** Object:  Database [stocks]    Script Date: 18/1/2021 7:58:34 am ******/
CREATE DATABASE [stocks]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'stocks', FILENAME = N'/var/opt/mssql/data/stocks.mdf', MAXSIZE = UNLIMITED, FILEGROWTH = 102400KB )
 LOG ON 
( NAME = N'stocks_log', FILENAME = N'/var/opt/mssql/data/stocks_log.ldf', MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [stocks] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [stocks].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [stocks] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [stocks] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [stocks] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [stocks] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [stocks] SET ARITHABORT OFF 
GO
ALTER DATABASE [stocks] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [stocks] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [stocks] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [stocks] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [stocks] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [stocks] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [stocks] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [stocks] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [stocks] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [stocks] SET  DISABLE_BROKER 
GO
ALTER DATABASE [stocks] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [stocks] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [stocks] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [stocks] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [stocks] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [stocks] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [stocks] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [stocks] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [stocks] SET  MULTI_USER 
GO
ALTER DATABASE [stocks] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [stocks] SET DB_CHAINING OFF 
GO
ALTER DATABASE [stocks] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [stocks] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [stocks] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [stocks] SET QUERY_STORE = OFF
GO
-- Switch to stocks Database
USE [stocks]
GO
-- Companies
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Companies](
	[Code] [nvarchar](20) NOT NULL,
	[Security] [nvarchar](max) NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[Currency] [nvarchar](3) NOT NULL,
	[Industry] [nvarchar](50) NOT NULL,
	[OutstandingShares] [int] NOT NULL,
	[StockType] [nvarchar](50) NULL,
	[isListed] [bit] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
ALTER TABLE [dbo].[Companies] ADD  CONSTRAINT [PK_Companies] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Companies] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [Created]
GO
ALTER TABLE [dbo].[Companies] ADD  DEFAULT (N'') FOR [Currency]
GO
ALTER TABLE [dbo].[Companies] ADD  DEFAULT (N'') FOR [Industry]
GO
ALTER TABLE [dbo].[Companies] ADD  DEFAULT ((0)) FOR [OutstandingShares]
GO
ALTER TABLE [dbo].[Companies] ADD  DEFAULT (CONVERT([bit],(0))) FOR [isListed]
GO
-- OutstandingSharesLog
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OutstandingSharesLog](
	[Code] [nvarchar](20) NOT NULL,
	[OutstandingShares] [bigint] NOT NULL,
	[LogNo] [bigint] NULL,
	[No] [bigint] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[OutstandingSharesLog] ADD  CONSTRAINT [PK_OutstandingSharesLog] PRIMARY KEY CLUSTERED 
(
	[No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_OutstandingShares_LogNo] ON [dbo].[OutstandingSharesLog]
(
	[LogNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[OutstandingSharesLog]  WITH CHECK ADD  CONSTRAINT [FK_OutstandingSharesLog_Companies_Code] FOREIGN KEY([Code])
REFERENCES [dbo].[Companies] ([Code])
GO
ALTER TABLE [dbo].[OutstandingSharesLog] CHECK CONSTRAINT [FK_OutstandingSharesLog_Companies_Code]
GO
ALTER TABLE [dbo].[OutstandingSharesLog]  WITH CHECK ADD  CONSTRAINT [FK_OutstandingSharesLog_Logs_LogNo] FOREIGN KEY([LogNo])
REFERENCES [dbo].[Logs] ([No])
GO
ALTER TABLE [dbo].[OutstandingSharesLog] CHECK CONSTRAINT [FK_OutstandingSharesLog_Logs_LogNo]
GO
-- StockTradings
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockTradings](
	[No] [bigint] IDENTITY(1,1) NOT NULL,
	[SecurityCode] [nvarchar](20) NULL,
	[Volume] [bigint] NOT NULL,
	[ClosingPrice] [decimal](18, 2) NOT NULL,
	[PriceChange] [decimal](18, 2) NOT NULL,
	[Percentage] [decimal](18, 2) NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[LogNo] [bigint] NULL,
	[MarketCapitalization] [decimal](18, 2) NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[StockTradings] ADD  CONSTRAINT [PK_StockTradings] PRIMARY KEY CLUSTERED 
(
	[No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_StockTradings_LogNo] ON [dbo].[StockTradings]
(
	[LogNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
CREATE NONCLUSTERED INDEX [IX_StockTradings_SecurityCode] ON [dbo].[StockTradings]
(
	[SecurityCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[StockTradings] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [Date]
GO
ALTER TABLE [dbo].[StockTradings] ADD  DEFAULT ((0.0)) FOR [MarketCapitalization]
GO
ALTER TABLE [dbo].[StockTradings]  WITH CHECK ADD  CONSTRAINT [FK_StockTradings_Companies_SecurityCode] FOREIGN KEY([SecurityCode])
REFERENCES [dbo].[Companies] ([Code])
GO
ALTER TABLE [dbo].[StockTradings] CHECK CONSTRAINT [FK_StockTradings_Companies_SecurityCode]
GO
ALTER TABLE [dbo].[StockTradings]  WITH CHECK ADD  CONSTRAINT [FK_StockTradings_Logs_LogNo] FOREIGN KEY([LogNo])
REFERENCES [dbo].[Logs] ([No])
GO
ALTER TABLE [dbo].[StockTradings] CHECK CONSTRAINT [FK_StockTradings_Logs_LogNo]
GO
-- Stock Index

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockIndices](
	[No] [bigint] IDENTITY(1,1) NOT NULL,
	[Index] [nvarchar](20) NOT NULL,
	[Value] [decimal](18, 2) NOT NULL,
	[ValueChange] [decimal](18, 2) NOT NULL,
	[LogNo] [bigint] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[StockIndices] ADD  CONSTRAINT [PK_StockIndices] PRIMARY KEY CLUSTERED 
(
	[No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_StockIndices_LogNo] ON [dbo].[StockIndices]
(
	[LogNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[StockIndices]  WITH CHECK ADD  CONSTRAINT [FK_StockIndices_Logs_LogNo] FOREIGN KEY([LogNo])
REFERENCES [dbo].[Logs] ([No])
GO
ALTER TABLE [dbo].[StockIndices] CHECK CONSTRAINT [FK_StockIndices_Logs_LogNo]
GO

-- Procedures
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Dayton Outar
-- Create date: April 29, 2021
-- Modified:	March 6, 2022
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
		[OutstandingShares] BIGINT NOT NULL,
		[Created] DATETIME2 NOT NULL
	);

	INSERT INTO #tblCompanies
	(
		[Code],
		[Security],
		[OutstandingShares],
		[Created]
	)
    SELECT	d.x.query('./code').value('.', 'nvarchar(20)') [Code],
			d.x.query('./security').value('.', 'nvarchar(max)') [Security],
			0 [OutstandingShares],
			d.x.query('./date').value('.', 'datetime2') [Date]
    FROM @stocks.nodes('stocks') d(x);

	-- INSERT INTO [dbo].[Companies]
	-- (
	-- 	[Code] ,
	-- 	[Security],
	-- 	[OutstandingShares],
	-- 	[Created]
	-- )
	-- SELECT  [Code] ,
	-- 		[Security] ,
	-- 		[OutstandingShares],
	-- 		[Created]
	-- FROM    #tblCompanies
	-- WHERE   NOT EXISTS (
	-- 	SELECT  [Code]
	-- 	FROM    [dbo].[Companies] X
	-- 	WHERE   X.[Code] = #tblCompanies.[Code]);

	INSERT INTO [dbo].[Stocks]
	(
		[Code],
		[Name],
		[OutstandingShares],
		[Created]
	)
	SELECT  [Code] ,
			[Security] ,
			[OutstandingShares],
			[Created]
	FROM    #tblCompanies
	WHERE   NOT EXISTS (
		SELECT  [Code]
		FROM    [dbo].[Stocks] X
		WHERE   X.[Code] = #tblCompanies.[Code]);

	DROP TABLE #tblCompanies;

END
GO

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

    IF NOT EXISTS ( SELECT '' FROM [dbo].[Logs] L WHERE L.[Logged] = @logged AND L.[Type] = 4 ) AND @totalStocks > 0
    BEGIN
        --
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

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Dayton Outar
-- Create date: June 6, 2021
-- Modified:    March 8, 2022
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
        V.[Name] [Security],
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
            INNER JOIN [dbo].[Stocks] S ON S.[Code] = T.[SecurityCode]
        WHERE T.[SecurityCode] = V.[Code] AND CAST(T.[Date] AS DATE) BETWEEN V.[OpeningDate] AND V.[ClosingDate]
        ORDER BY T.[Date]
        FOR JSON AUTO) AS [Prices]
        --FOR XML RAW ('Price'), ROOT ('Prices'), ELEMENTS
    FROM (SELECT
            S.[Code],
            S.[Name],
            SUM(T.[Volume]) [Volume],
            MIN(CAST(T.[Date] AS DATE)) [OpeningDate],
            MAX(CAST(T.[Date] AS DATE)) [ClosingDate]
        FROM [dbo].[Stocks] S
            INNER JOIN [stocks].[dbo].[StockTradings] T ON T.[SecurityCode] = S.[Code]
        WHERE CAST(T.[Date] AS DATE) BETWEEN @begin AND @end
        GROUP BY S.[Code],
                S.[Name]) V
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

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Dayton Outar
-- Create date: Jan 9, 2022
-- Description:	Updates companies' details
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[UpdateCompaniesDetails] 
	@companies XML
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	CREATE TABLE #tblCompanies (
		[Code] NVARCHAR(20) NOT NULL,
		[Security] NVARCHAR(MAX) NOT NULL,
		[Currency] NVARCHAR(3) NOT NULL,
		[Industry] NVARCHAR(50) NOT NULL,		
		[StockType] NVARCHAR(50) NULL,		
		[isListed] BIT NOT NULL,
		[OutstandingShares] BIGINT NOT NULL,
		[MarketCapitalization] DECIMAL(18, 2) NOT NULL,
		[Date] DATETIME2(7) NOT NULL
	);

	CREATE TABLE #tblDividends (
		[Code] NVARCHAR(20) NOT NULL,
		[RecordDate] DATE NOT NULL,
        [PaymentDate] DATE NOT NULL,
        [Currency] NVARCHAR(3) NOT NULL,
        [Amount] DECIMAL(18, 4) NOT NULL
	);

	INSERT INTO #tblCompanies
	(
		[Code],
		[Security],
		[Currency],
		[Industry],
		[StockType],
		[isListed],
		[OutstandingShares],
		[MarketCapitalization],
		[Date]
	)
    SELECT	d.x.query('./code').value('.', 'nvarchar(20)') [Code],
			d.x.query('./security').value('.', 'nvarchar(max)') [Security],
			d.x.query('./currency').value('.', 'nvarchar(3)') [Currency],
			d.x.query('./industry').value('.', 'nvarchar(50)') [Industry],
			d.x.query('./type').value('.', 'nvarchar(50)') [StockType],
			d.x.query('./listed').value('.', 'bit') [isListed],
			d.x.query('./outstandingShares').value('.', 'bigint') [OutstandingShares],
			d.x.query('./marketCapitalization').value('.', 'decimal(18,2)') [MarketCapitalization],
			d.x.query('./date').value('.', 'datetime') [Date]
    FROM @companies.nodes('companies') d(x);

	INSERT INTO #tblDividends
	(
		[Code] ,
		[RecordDate] ,
		[PaymentDate] ,
        [Currency] ,
        [Amount]
	)
	SELECT	q.x.query('./code').value('.', 'nvarchar(20)') [SecurityCode],
            q.x.query('./recordDate').value('.', 'date') [RecordDate],
            q.x.query('./paymentDate').value('.', 'date') [PaymentDate],
			q.x.query('./currency').value('.', 'nvarchar(3)') [Currency],
            q.x.query('./amount').value('.', 'decimal(18,4)') [Amount]            
    FROM @companies.nodes('companies/dividends') q(x);

	BEGIN TRY
        BEGIN TRANSACTION;

		INSERT INTO [dbo].[Dividends]
        (
            [StockCode] ,
            [Currency] ,
            [Amount] ,
            [RecordDate] ,
            [PaymentDate]
        )
        SELECT  td.[Code] ,
                td.[Currency] ,
                td.[Amount] ,
                td.[RecordDate] ,
                td.[PaymentDate]
        FROM [#tblDividends] td
        WHERE NOT EXISTS( SELECT '' FROM [dbo].[Dividends] d WHERE d.[StockCode] = td.[Code] AND d.[RecordDate] = td.[RecordDate] );

		INSERT INTO [dbo].[OutstandingSharesLog]
        (
            [Code] ,
			[OutstandingShares],
            [LogNo]
        )
		SELECT 	t.[Code],
				t.[OutstandingShares],
				l.[No]
		FROM [dbo].[StockTradings] s
			INNER JOIN [dbo].[Logs] l ON s.[LogNo] = l.[No]
			INNER JOIN #tblCompanies t ON s.[SecurityCode] = t.[Code]
			INNER JOIN [dbo].[Stocks] c ON c.[Code] = t.[Code]
		WHERE l.[Logged] = t.[Date]
			AND t.[OutstandingShares] <> c.[OutstandingShares];

		UPDATE c SET
			[Name] = t.[Security],
			[Currency] = t.[Currency],
			--[Industry] = t.[Industry],
			[OutstandingShares] = t.[OutstandingShares],
			[StockType] = t.[StockType],
			[isListed] = t.[isListed]
		FROM [dbo].[Stocks] c
			INNER JOIN #tblCompanies t ON c.[Code] = t.[Code];
		
		UPDATE c SET
			[isListed] = 0
		FROM [dbo].[Stocks] c
		WHERE NOT EXISTS(SELECT '' FROM #tblCompanies t WHERE t.[Code] = c.[Code]);

		UPDATE s SET
			[MarketCapitalization] = t.[MarketCapitalization]
		FROM [dbo].[StockTradings] s
			INNER JOIN [dbo].[Logs] l ON s.[LogNo] = l.[No]
			INNER JOIN #tblCompanies t ON s.[SecurityCode] = t.[Code]
		WHERE l.[Logged] = t.[Date];

	    COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        
        ROLLBACK TRANSACTION;

    END CATCH;

	DROP TABLE [#tblDividends];
	DROP TABLE [#tblCompanies];

END
GO

--
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Dayton Outar
-- Create date: January 11, 2022
-- Modified:    March 6, 2022
-- Description:	Updates stock indices
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[UpdateStockIndices] 
	@indices XML
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	CREATE TABLE #tblIndices (
		[Index] NVARCHAR(20) NOT NULL,
		[Value] DECIMAL(18, 2) NOT NULL,
		[ValueChange] DECIMAL(18, 2) NOT NULL,
        [Date] DATETIME2(7) NOT NULL
	);

	INSERT INTO #tblIndices
	(
		[Index],
		[Value] ,
		[ValueChange],
        [Date]
	)
    SELECT	d.x.query('./index').value('.', 'nvarchar(20)') [Index],
			d.x.query('./value').value('.', 'decimal(18,2)') [Value],
            d.x.query('./change').value('.', 'decimal(18,2)') [ValueChange],
            d.x.query('./date').value('.', 'datetime2') [ValueChange]
    FROM @indices.nodes('indices') d(x);

    INSERT INTO [dbo].[StockIndices]
    (
        [Value] ,
        [ValueChange] ,
        [LogNo] ,
        [MarketIndexNo]
    )
    SELECT  i.[Value] ,
            i.[ValueChange] ,
            l.[No] ,
            m.[No]
    FROM [#tblIndices] i
        INNER JOIN [dbo].[MarketIndices] m ON i.[Index] = m.[MarketCode],
        [dbo].[Logs] l
    WHERE i.[Date] = l.[Logged] 
        AND l.[Event] = 0
        AND l.[Type] = 4
        AND NOT EXISTS(SELECT '' FROM [dbo].[StockIndices] e WHERE e.[LogNo] = l.[No]);

	DROP TABLE #tblIndices;

END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Dayton Outar
-- Create date: March 6, 2022
-- Description:	Updates stock dividends
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[UpdateStockDividends] 
	@dividends XML
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	CREATE TABLE #tblDividends (
		[Code] NVARCHAR(20) NOT NULL,
        [Title] NVARCHAR(MAX) NOT NULL,
		[RecordDate] DATE NOT NULL,
        [PaymentDate] DATE NOT NULL,
        [Date] DATETIME2(7) NOT NULL,
        [Currency] NVARCHAR(3) NOT NULL,
        [Amount] DECIMAL(18, 4) NOT NULL
	);

    -- CREATE TABLE #tblLogs (
	-- 	[No] BIGINT NOT NULL,
    --     [Event] INT NOT NULL,
    --     [Type] INT NOT NULL,
    --     [Details] NVARCHAR(max) NOT NULL,
    --     [Logged] DATETIME2(7) NOT NULL,
    --     [Code] NVARCHAR(20) NOT NULL     
	-- );

	INSERT INTO #tblDividends
	(
		[Code] ,
        [Title] ,
		[RecordDate] ,
		[PaymentDate] ,
        [Date] ,
        [Currency] ,
        [Amount]
	)
    SELECT	d.x.query('./code').value('.', 'nvarchar(20)') [SecurityCode],
            d.x.query('./title').value('.', 'nvarchar(max)') [Title],
            d.x.query('./recordDate').value('.', 'date') [RecordDate],
            d.x.query('./paymentDate').value('.', 'date') [PaymentDate],
            d.x.query('./declarationDate').value('.', 'date') [Date],
			d.x.query('./currency').value('.', 'nvarchar(3)') [Currency],
            d.x.query('./amount').value('.', 'decimal(18,4)') [Amount]            
    FROM @dividends.nodes('dividends') d(x);

    --SELECT @totalDividends = COUNT([SecurityCode]) FROM #tblTradings;

    -- BEGIN TRY
    --     BEGIN TRANSACTION;

        -- INSERT INTO [dbo].[Logs]
        -- (
        --     [Event] ,
        --     [Type] ,
        --     [Details] ,
        --     [Logged]
        -- )
        -- VALUES ( 0, 1, CONVERT( VARCHAR(10), @totalDividends ) + ' dividends updated', @logged);
        -- SELECT @logNo = SCOPE_IDENTITY();

        -- INSERT INTO [dbo].[Logs]
        -- (
        --     [Event] ,
        --     [Type] ,
        --     [Details] ,
        --     [Logged]
        -- )
        -- OUTPUT  inserted.[No] ,
        --         inserted.[Event] ,
        --         inserted.[Type] ,
        --         inserted.[Details] ,
        --         inserted.[Logged] ,
        --         td.[Code]
        --     INTO [#tblLogs] ([No], [Event], [Type], [Details], [Logged], [Code])
        -- SELECT  0 [Event] ,
        --         2 [Type] ,
        --         td.[Title],
        --         td.[Date]
        -- FROM [#tblDividends] td
        -- WHERE NOT EXISTS(SELECT '' 
        --                 FROM [dbo].[Dividends] d
        --                     INNER JOIN [dbo].[Logs] l ON d.[LogNo] = l.[No]
        --                 WHERE l.[Logged] = td.[Date]
        --                     AND d.[StockCode] = td.[Code]);

        INSERT INTO [dbo].[Dividends]
        (
            [StockCode] ,
            [Currency] ,
            [Amount] ,
            [RecordDate] ,
            [PaymentDate] --,
            --[LogNo]
        )
        SELECT  td.[Code] ,
                td.[Currency] ,
                td.[Amount] ,
                td.[RecordDate] ,
                td.[PaymentDate] --,
                --tl.[No]
        FROM [#tblDividends] td
        WHERE NOT EXISTS( SELECT '' FROM [dbo].[Dividends] d WHERE d.[StockCode] = td.[Code] AND d.[RecordDate] = td.[RecordDate] );
        --     INNER JOIN [#tblLogs] tl ON td.[Code] = tl.[Code]
        -- WHERE NOT EXISTS(SELECT '' FROM [dbo].[Logs] l WHERE l.[No] = tl.[No]);

    --     COMMIT TRANSACTION;
    -- END TRY
    -- BEGIN CATCH
        
    --     ROLLBACK TRANSACTION;

    -- END CATCH;

    -- DROP TABLE [#tblLogs];
	DROP TABLE [#tblDividends];

END
GO