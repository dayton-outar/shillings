# API

## Notes

Querying GetTotalTrades is queried as shown below

```gql
query {
  totalTrades
  (
    companyCode: ""
    begin: "2021-05-03T00:00:00.0000000Z"
    end: "2021-06-03T00:00:00.0000000Z") {
    code,
    security,
    volume,
    openingDate,
    openingPrice,
    closingDate,
    closingPrice,
    percentage
  }
}
```

## Further Reading

1. [ASP.NET Core Fundamentals](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/?view=aspnetcore-5.0&tabs=linux)
2. [Entity Framework](https://entityframework.net/)
3. [Data Seeding](https://docs.microsoft.com/en-us/ef/core/modeling/data-seeding)
4. [Calling Stored Procedures with the Entity Framework in .NET 5](https://www.codemag.com/Article/2101031/Calling-Stored-Procedures-with-the-Entity-Framework-in-.NET-5)
5. [Fixing Entity Framework Validation 30000 No Type Specified for the Decimal Column](https://mattferderer.com/entity-framework-no-type-was-specified-for-the-decimal-column) by Matt Ferderer
6. [SQL Server Table-valued Functions](https://www.sqlservertutorial.net/sql-server-user-defined-functions/sql-server-table-valued-functions/)