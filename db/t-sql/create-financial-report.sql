SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Dayton Outar
-- Create date: May 15, 2022
-- Description:	Stores financial report including statement items
-- =============================================
CREATE PROCEDURE [dbo].[CreateFinancialReport]
    @report XML
AS
    BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    --
    DECLARE @no BIGINT = 0,
            @logNo BIGINT = 0,
            @companyCode NVARCHAR(20) = '',
            @period INT = 0,
            @statementDate DATE = NULL,
            @isAudited BIT = NULL,
            @logDetails NVARCHAR(MAX) = '';
	
    SELECT  @logDetails = d.x.query('Details').value('.', 'nvarchar(max)')
    FROM    @report.nodes('FinancialReport/Log') d ( x );

	SELECT	@companyCode = d.x.query('Company/Code').value('.', 'nvarchar(20)'),
        	@period = d.x.query('Period').value('.', 'int'),
        	@statementDate = d.x.query('StatementDate').value('.', 'date'),
        	@isAudited = d.x.query('IsAudited').value('.', 'bit') --,
	FROM    @report.nodes('FinancialReport') d ( x );

    INSERT INTO [dbo].[Logs]
        (
            [Details] ,
            [Event] ,
            [Type] ,
            [Logged]
        )
        VALUES
        (
            @logDetails ,
            0 ,
            2 ,
            GETDATE()
        );
    SELECT @logNo = SCOPE_IDENTITY();

    INSERT INTO [dbo].[FinancialReports]
		(
			[CompanyCode] ,
			[Period] ,
			[StatementDate] ,
			[IsAudited] ,
            [LogNo]
		)
        VALUES
        (
            @companyCode ,
            @period ,
            @statementDate ,
            @isAudited ,
            @logNo
        );
    SELECT @no = SCOPE_IDENTITY();

    INSERT INTO [dbo].[StatementAnalytes]
        (
            [ReportNo] ,
            [Sequence] ,
            [Description] ,
            [Type] ,
            [Section] ,
            [Analyte] ,
            [Amount]
        )
    SELECT	@no ,
            d.x.query('Sequence').value('.', 'int') [Sequence],
		    d.x.query('Description').value('.', 'nvarchar(100)') [Description],
            d.x.query('Type').value('.', 'int') [Type],
            d.x.query('Section').value('.', 'nvarchar(100)') [Section],
            d.x.query('Analyte').value('.', 'nvarchar(100)') [Analyte],
            d.x.query('Amount').value('.', 'decimal(18,2)') [Amount]
    FROM    @report.nodes('FinancialReport/Analytes/StatementAnalyte') d ( x )

END
GO
