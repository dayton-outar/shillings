DECLARE @report XML = '<FinancialReport><No>4</No><Company><Code>gk</Code><Name>GRACEKENNEDY LIMITED</Name><Industry /><About /><TotalEmployed>0</TotalEmployed><Wiki /><WebSite /><Founded>1779-01-01T05:07:00Z</Founded><CountryCode /><Created>1999-10-04T05:00:00Z</Created><Industries /><Announcements /></Company><Period>2</Period><StatementDate>2009-12-31T05:00:00Z</StatementDate><Log><No>0</No><Type>Announcement</Type><Event>Information</Event><Details>GK Annual Report</Details><Logged>2022-05-08T05:00:00Z</Logged></Log><IsAudited>true</IsAudited><Analytes><StatementAnalyte><No>1</No><Sequence>1</Sequence><Description>Total Revenues</Description><Type>1</Type><Section>1</Section><Analyte>1</Analyte><Amount>57406415000</Amount></StatementAnalyte><StatementAnalyte><No>2</No><Sequence>1</Sequence><Description>Cash and deposits</Description><Type>2</Type><Section>7</Section><Analyte>69632</Analyte><Amount>10608376000</Amount></StatementAnalyte></Analytes></FinancialReport>';

-- EXEC [dbo].[CreateFinancialReport] @report;

EXEC [dbo].[UpdateFinancialReport] @report;