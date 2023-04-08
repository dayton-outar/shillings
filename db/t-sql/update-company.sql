SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Dayton Outar
-- Create date: Sep 3, 2022
-- Description:	Modifies company details
-- =============================================
CREATE PROCEDURE [dbo].[UpdateCompany]
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
    SELECT	f.x.query('No').value('.', 'bigint') [No],
            f.x.query('TypeInt').value('.', 'int') [Type],
            f.x.query('FileName').value('.', 'nvarchar(256)') [FileName],
            f.x.query('Content').value('.', 'varbinary(max)') [Content],
            f.x.query('ContentSize').value('.', 'int') [ContentSize],
            f.x.query('ContentType').value('.', 'nvarchar(50)') [ContentType],
            @created [Created]
    FROM    @company.nodes('Company/Files/FileContent') f ( x );

    DECLARE @tblIFiles TABLE
    (
        [No] BIGINT
    );

    DECLARE @tblIndustries TABLE
    (
        [No] BIGINT NOT NULL,
        [Name] NVARCHAR(MAX) NOT NULL,
        [Wiki] NVARCHAR(2100) NOT NULL
    );

    INSERT INTO @tblIndustries
    (
        [No],
        [Name],
        [Wiki]
    )
    SELECT	i.x.query('No').value('.', 'bigint') [No],
            i.x.query('Name').value('.', 'nvarchar(max)') [Name],
            i.x.query('Wiki').value('.', 'nvarchar(2100)') [Wiki]
    FROM    @company.nodes('Company/Industries/Industry') i ( x );

    BEGIN TRY
        BEGIN TRANSACTION;
    
        UPDATE c SET
            c.[Name] = @companyName ,
            c.[About] = @about ,
            c.[Wiki] = @wiki ,
            c.[WebSite] = @webSite ,
            c.[TotalEmployed] = @totalEmployed ,
            c.[Founded] = @founded ,
            c.[CountryCode] = @countryCode
        FROM [dbo].[Companies] c
        WHERE c.[Code] = @companyCode;

        -- Updating industries
        -- Do Deletions
        DELETE i FROM [dbo].[CompanyIndustry] i
        WHERE i.[CompaniesCode] = @companyCode;

        -- Do Insertions
        INSERT INTO [dbo].[CompanyIndustry]
            (
                [CompaniesCode],
                [IndustriesNo]
            )
        SELECT  @companyCode,
                i.[No]
        FROM @tblIndustries i;

        -- Updating files
        -- Do Updates 
        UPDATE  f SET     
            f.[FileName] = t.[FileName],
            f.[Content] = t.[Content] ,
            f.[ContentSize] = t.[ContentSize] ,
            f.[ContentType] = t.[ContentType]
        FROM    [dbo].[Files] f
                INNER JOIN [dbo].[CompanyFileContent] x ON x.[FilesNo] = f.[No]
                INNER JOIN @tblFiles t ON t.[No] = f.[No]
        WHERE   x.[CompaniesCode] = @companyCode;

        -- Do Deletions
        DELETE f FROM [dbo].[Files] f
                INNER JOIN [dbo].[CompanyFileContent] x ON x.[FilesNo] = f.[No]
        WHERE   NOT EXISTS ( SELECT ''
                            FROM @tblFiles t
                            WHERE  t.[No] = f.[No] )
            AND x.[CompaniesCode] = @companyCode;

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
