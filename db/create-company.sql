SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Dayton Outar
-- Create date: Sep 4, 2022
-- Description:	Creates company details
-- =============================================
CREATE PROCEDURE [dbo].[CreateCompany]
    @company XML
AS
    BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;
    --
    DECLARE @companyCode NVARCHAR(20) = '',
            @companyName NVARCHAR(MAX) = '',
            @created DATETIME2 = GETDATE(),
            @about NVARCHAR(MAX) = '',
            @countryCode NVARCHAR(2) = '',
            @founded DATE,
            @totalEmployed INT = 0,
            @webSite NVARCHAR(2100) = '',
            @wiki NVARCHAR(2100) = '';

	SELECT	@companyCode    = c.x.query('Code').value('.', 'nvarchar(20)'),
            @companyName    = c.x.query('Name').value('.', 'nvarchar(max)'),
            @about          = c.x.query('About').value('.', 'nvarchar(max)'),
            @wiki           = c.x.query('Wiki').value('.', 'nvarchar(2100)'),
            @webSite        = c.x.query('WebSite').value('.', 'nvarchar(2100)'),
            @totalEmployed  = c.x.query('TotalEmployed').value('.', 'int'),
            @founded        = c.x.query('Founded').value('.', 'date'),
            @countryCode    = c.x.query('CountryCode').value('.', 'nvarchar(2)')
    FROM    @company.nodes('Company') c ( x );

    DECLARE @tblFiles TABLE
    (
        [No] BIGINT,
        [Type] INT NOT NULL,
        [FileName] NVARCHAR(256) NOT NULL,
        [Content] VARBINARY(MAX) NOT NULL,
        [ContentSize] INT NOT NULL,
        [ContentType] NVARCHAR(50) NOT NULL,
        [Created] DATETIME2 NOT NULL
    );

    INSERT INTO @tblFiles
    (
        [No] ,
        [Type] ,
        [FileName] ,
        [Content] ,
        [ContentSize] ,
        [ContentType] ,
        [Created]
    )
    SELECT	f.x.query('FileContent/No').value('.', 'bigint') [No],
            f.x.query('FileContent/TypeInt').value('.', 'int') [Type],
            f.x.query('FileContent/FileName').value('.', 'nvarchar(256)') [FileName],
            f.x.query('FileContent/Content').value('.', 'varbinary(max)') [Content],
            f.x.query('FileContent/ContentSize').value('.', 'int') [ContentSize],
            f.x.query('FileContent/ContentType').value('.', 'nvarchar(50)') [ContentType],
            @created [Created]
    FROM    @company.nodes('Company/Files') f ( x );

    DECLARE @tblIFiles TABLE
    (
        [No] BIGINT
    );

    BEGIN TRY
        BEGIN TRANSACTION;
    
        INSERT INTO [dbo].[Companies]
            (
                [Code] ,
                [Name] ,
                [About] ,
                [Wiki] ,
                [WebSite] ,
                [TotalEmployed] ,
                [Founded] ,
                [CountryCode],
                [Created]
            )
        VALUES 
            (
                @companyCode ,
                @companyName ,
                @about ,
                @wiki ,
                @webSite ,
                @totalEmployed ,
                @founded ,
                @countryCode ,
                @created
            );

        -- Do Insertions
        INSERT INTO [dbo].[Files]
            (
                [Type] ,
                [FileName] ,
                [Content] ,
                [ContentSize] ,
                [ContentType] ,
                [Created]
            )
        OUTPUT inserted.[No] INTO @tblIFiles
        SELECT  t.[Type] ,
                t.[FileName] ,
                t.[Content] ,
                t.[ContentSize] ,
                t.[ContentType] ,
                t.[Created]
        FROM @tblFiles t            
        WHERE   NOT EXISTS ( SELECT ''
                            FROM [dbo].[Files] f
                                INNER JOIN [dbo].[CompanyFileContent] x ON x.[FilesNo] = t.[No]
                            WHERE f.[No] = t.[No] AND x.[CompaniesCode] = @companyCode);

        INSERT INTO [dbo].[CompanyFileContent]
            (
                [CompaniesCode],
                [FilesNo]
            )
        SELECT  @companyCode,
                i.[No]
        FROM @tblIFiles i;

        COMMIT TRANSACTION;

    END TRY
    BEGIN CATCH
        
        ROLLBACK TRANSACTION;
        THROW;

    END CATCH;   

END
GO
