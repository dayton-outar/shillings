SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Dayton Outar
-- Create date: May 15, 2022
-- Description:	Modifies financial report including statement items
-- =============================================
CREATE PROCEDURE [dbo].[UpdateFinancialReport]
    @report XML
AS
    BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    --
    DECLARE @no BIGINT = 0,
            @companyCode NVARCHAR(20) = '',
            @period INT = 0,
            @statementDate DATE = NULL,
            @isAudited BIT = NULL;
        
    DECLARE @tblStatements TABLE
    (
        [No] BIGINT,
        [ReportNo] BIGINT NOT NULL,
        [Sequence] INT NOT NULL,
        [Description] NVARCHAR(100) NOT NULL,
        [Type] INT NOT NULL,
        [Section] INT NOT NULL,
        [Analyte] INT NOT NULL,
        [Amount] DECIMAL(18,2) NOT NULL
    );

	SELECT	@no = d.x.query('No').value('.', 'bigint'),
            @companyCode = d.x.query('Company/Code').value('.', 'nvarchar(20)'),
        	@period = d.x.query('Period').value('.', 'int'),
        	@statementDate = d.x.query('StatementDate').value('.', 'date'),
        	@isAudited = d.x.query('IsAudited').value('.', 'bit')
	FROM    @report.nodes('FinancialReport') d ( x );

    UPDATE f SET
        f.[CompanyCode] = @companyCode ,
        f.[Period] = @period ,
        f.[StatementDate] = @statementDate ,
        f.[IsAudited] = @isAudited
    FROM [dbo].[FinancialReports] f
    WHERE f.[No] = @no;

    INSERT INTO @tblStatements
        (
            [ReportNo] ,
            [No] ,            
            [Sequence] ,
            [Description] ,
            [Type] ,
            [Section] ,
            [Analyte] ,
            [Amount]
        )
    SELECT	@no ,
            d.x.query('No').value('.', 'bigint') [No],
            d.x.query('Sequence').value('.', 'int') [Sequence],
		    d.x.query('Description').value('.', 'nvarchar(100)') [Description],
            d.x.query('Type').value('.', 'int') [Type],
            d.x.query('Section').value('.', 'int') [Section],
            d.x.query('Analyte').value('.', 'int') [Analyte],
            d.x.query('Amount').value('.', 'decimal(18,2)') [Amount]
    FROM    @report.nodes('FinancialReport/Analytes/StatementAnalyte') d ( x );

    -- Do Updates 
    UPDATE  i SET     
        i.[Sequence] = t.[Sequence] ,
        i.[Description] = t.[Description] ,
        i.[Type] = t.[Type] ,
        i.[Section] = t.[Section]
    FROM    [dbo].[StatementAnalytes] i
            INNER JOIN @tblStatements t ON i.[No] = t.[No]
    WHERE   i.[ReportNo] = @no;

    -- Do Deletions
    DELETE i FROM [dbo].[StatementAnalytes] i
    WHERE   NOT EXISTS ( SELECT ''
                         FROM @tblStatements t
                         WHERE  t.[No] = i.[No] )
        AND i.[ReportNo] = @no;

    -- Do Insertions
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
    SELECT  t.[ReportNo] ,
            t.[Sequence] ,
            t.[Description] ,
            t.[Type] ,
            t.[Section] ,
            t.[Analyte] ,
            t.[Amount]
    FROM @tblStatements t
    WHERE   NOT EXISTS ( SELECT ''
                         FROM [dbo].[StatementAnalytes] i
                         WHERE i.[No] = t.[No] )
    AND t.[ReportNo] = @no;    

END
GO
