SELECT [Code]
      ,[Name]
      ,[Created]
      ,[About]
      ,[CountryCode]
      ,[Founded]
      ,[TotalEmployed]
      ,[WebSite]
      ,[Wiki]
  FROM [stocks].[dbo].[Companies] c
  WHERE NOT EXISTS (
    SELECT ''
    FROM [dbo].[CompanyIndustry] x
    WHERE x.[CompaniesCode] = c.[Code]
  )