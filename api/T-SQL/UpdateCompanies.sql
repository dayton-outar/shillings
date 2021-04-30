SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Dayton Outar
-- Create date: April 29, 2021
-- Description:	Updates companies list
-- =============================================
CREATE PROCEDURE [dbo].[UpdateCompanies] 
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
