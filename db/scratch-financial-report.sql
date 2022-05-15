DECLARE @reports XML = '<FinancialReport><No>0</No><Company><Code>gk</Code><Name>GRACEKENNEDY LIMITED</Name><Industry /><About /><TotalEmployed>0</TotalEmployed><Wiki /><WebSite /><Founded>1779-01-01T05:07:00Z</Founded><CountryCode /><Created>1999-10-04T05:00:00Z</Created><Industries /><Announcements /></Company><Period>2</Period><StatementDate>2009-12-31T05:00:00Z</StatementDate><Log><No>0</No><Type>Announcement</Type><Event>Information</Event><Details>GK Annual Report</Details><Logged>2022-05-08T05:00:00Z</Logged></Log><IsAudited>true</IsAudited><Analytes><StatementAnalyte><No>0</No><Sequence>1</Sequence><Description>Revenues</Description><Type>1</Type><Section>1</Section><Analyte>1</Analyte><Amount>57406415000</Amount></StatementAnalyte><StatementAnalyte><No>0</No><Sequence>1</Sequence><Description>Cash and deposits</Description><Type>2</Type><Section>7</Section><Analyte>69632</Analyte><Amount>10608376000</Amount></StatementAnalyte></Analytes></FinancialReport>';
DECLARE @logDetails NVARCHAR(MAX) = '';

SELECT  @logDetails = d.x.query('Details').value('.', 'nvarchar(max)')
FROM    @reports.nodes('FinancialReport/Log') d ( x );

SELECT @logDetails;

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

SELECT	d.x.query('No').value('.', 'bigint') [No],
		d.x.query('Company/Code').value('.', 'nvarchar(20)') [CompanyCode],
        d.x.query('Period').value('.', 'int') [Period],
        d.x.query('StatementDate').value('.', 'date') [StatementDate],
        d.x.query('IsAudited').value('.', 'bit') [IsAudited],
        7 [LogNo]
FROM    @reports.nodes('FinancialReport') d ( x )

INSERT INTO @tblStatements
        (
            [No] ,
            [ReportNo] ,            
            [Sequence] ,
            [Description] ,
            [Type] ,
            [Section] ,
            [Analyte] ,
            [Amount]
        )
SELECT	d.x.query('No').value('.', 'bigint') [No],
        7 [ReportNo] , -- Make up a number
        d.x.query('Sequence').value('.', 'int') [Sequence],
		d.x.query('Description').value('.', 'nvarchar(100)') [Description],
        d.x.query('Type').value('.', 'int') [Type],
        d.x.query('Section').value('.', 'nvarchar(100)') [Section], -- Convert to integer equivalent of enum
        d.x.query('Analyte').value('.', 'nvarchar(100)') [Analyte], -- Convert to integer equivalent of enum
        d.x.query('Amount').value('.', 'decimal(18,2)') [Amount]
FROM    @reports.nodes('FinancialReport/Analytes/StatementAnalyte') d ( x );

SELECT *
FROM @tblStatements;