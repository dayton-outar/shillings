# GraphQL API Server

The web api offers the service of communicating information from the stock tracker's database.

## Requirements

 * [.NET 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
 * [Entity Framework](https://docs.microsoft.com/en-us/ef/)
 * [Hot Chocolate](https://chillicream.com/docs/)

## Installation

Third party packages have been added from [Nuget](https://www.nuget.org/) to the projects that compose this GraphQL service. In order to install these package, perform the following command,

```bash
dotnet restore
```

The above command will have to be performed within the [O8Query](./O8Query) and [Harpoon](./Harpoon) folders before building the main project (which is [Harpoon](./Harpoon)).

## Usage

For any _dotnet_ project, once your terminal is set within the directory containing the _.csproj_ file you can,

- Build the application by performing
  > `dotnet build`
- Run the application (service is currently set to be exposed at port 5000 at _http://localhost:5000/_)
  > `dotnet run`
- Publish files for release onto a HTTP server via CGI
  > `dotnet publish -o ../build -c Release`

## Contributions

[Harpoon](./Harpoon) is main application that uses the [O8Query](./O8Query) class library, which contains the data models and the database context.

Types that exposed by this service are registered in [Harpoon](./Harpoon).

### Notes

Credit to [How to Use .NET Core CLI to Create a Multi-Project Solution](https://www.skylinetechnologies.com/Blog/Skyline-Blog/February_2018/how-to-use-dot-net-core-cli-create-multi-project) by Ben Buhr

#### Organizing Projects

The -o parameter lets you specify the output directory (which will get created in case it doesn’t exist). Once that command finishes, navigate into the folder and then execute the following commands:

[dotnet sln](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-sln)

```bash
dotnet new sln -o Harpoon
```

```bash
dotnet new classlib -o api/O8Query
```

```bash
dotnet new webapi -o api/Harpoon
```

```bash
dotnet sln Harpoon.sln add api/Harpoon/Harpoon.csproj api/O8Query/O8Query.csproj
```

#### Building, Running and Publishing

```bash
dotnet build O8Query/O8Query.csproj
```

```bash
dotnet run -p api/Harpoon.csproj
```

Perform `dotnet publish` command when you are ready to setup the web service on a CGI on an HTTP server.

```bash
dotnet publish Harpoon/Harpoon.csproj -o ./build -c Release
```

#### Adding Packages

[dotnet add package](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-add-package)

```bash
dotnet add package Newtonsoft.Json
```

```bash
dotnet add ToDo.csproj package Microsoft.Azure.DocumentDB.Core -v 1.0.0
```

```bash
dotnet add package Microsoft.AspNetCore.StaticFiles -s https://dotnet.myget.org/F/dotnet-core/api/v3/index.json
```

[dotnet add reference](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-add-reference)

```bash
dotnet add app/app.csproj reference lib/lib.csproj
```


#### Using EF Core CLI

[Entity Framework Core tools reference - .NET Core CLI](https://docs.microsoft.com/en-us/ef/core/cli/dotnet)

[Migrations Overview](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli)

[Create and Drop APIs](https://docs.microsoft.com/en-us/ef/core/managing-schemas/ensure-created)

Inside Data Library
```bash
dotnet ef migrations add InitialCreate
```

Apply migration to database
```bash
dotnet ef database update
```
#### Using GraphQL

Navigate to https://localhost:5001/graphql/ to get to GraphQL endpoint, which hosts [Banana Cake Pop](https://chillicream.com/docs/bananacakepop)

[Getting started with Hot Chocolate](https://chillicream.com/docs/hotchocolate/get-started)

[Get started with Hot Chocolate and Entity Framework](https://www.softwareis.cool/hotchocolate-and-efcore/)


Below query get first 10 from descending order of complete list in database

```graphql
{
  stockTradings(order: {date: DESC}) {
    nodes {
      security {
        code,
        security
      },
      volume,
      priceChange,
      percentage,
      date
    }
  }
}
```

Get the latest 50 stocks with code `bil` and `mil` that were traded recently

```graphql
query {
  stockTradings(
    first: 50
    where: { or: [{ security: { code: { eq: "bil" } } }, { security: { code: { eq: "mil" } } }] }
    order: {date: DESC}
  ) {
    edges {
      node {
        security {
          code,
          security
        },
        volume,
        priceChange,
        percentage,
        date
      }
    }
  }
}
```

```graphql
query {
  companies (
    order: { security: ASC}
    
  ) {
    edges {
      node {
        code,
        security,
        created
      }
    }
  }
}
```

Learnt about paging for Hot Chocolate [here](https://github.com/ChilliCream/hotchocolate/issues/2181)

Good query for UI table paging through content

```gql
query {
  stockTradings(
    first: 10
    where: { or: [{ security: { code: { eq: "bil" } } }, { security: { code: { eq: "mil" } } }] }
    order: {date: DESC}
  ) {
    edges {
      cursor
      node {
        security {
          code,
          security
        },
        volume,
        priceChange,
        percentage,
        date
      }
    }
    totalCount
    pageInfo {
      startCursor
      endCursor
      hasPreviousPage
      hasNextPage
    }
  }
}
```

Moving to next page

```gql
query {
  stockTradings(
    first: 10
    after: "MTk="
    where: { or: [{ security: { code: { eq: "bil" } } }, { security: { code: { eq: "mil" } } }] }
    order: {date: DESC}
  ) {
    edges {
      cursor
      node {
        security {
          code,
          security
        },
        volume,
        priceChange,
        percentage,
        date
      }
    }
    totalCount
    pageInfo {
      startCursor
      endCursor
      hasPreviousPage
      hasNextPage
    }
  }
}
```
#### Notes

Had to add [UseProjections] to get totalCount. Documentation on ChilliCream not very friendly

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

```csharp
using System;
using System.Linq;

namespace GettingCountries
{
    class Program
    {
        static void Main(string[] args)
        {
            var svc = new Countries.NET.CountriesService();

            var countries = svc.GetAll();

            foreach(var country in countries)
            {
                if (country.Currencies.Count() > 0)
                {
                    string currencyDetails = string.Empty;
                    try
                    {
                        var currency = TeixeiraSoftware.Finance.Currency.ByAlphabeticCode(country.Currencies.First().Code);

                        currencyDetails = string.Format(" ... ({0}: {1} --> {2} [{3}])", currency.AlphabeticCode, currency.NumericCode, currency.Name, currency.Sign);
                    }
                    catch { }

                    Console.WriteLine("{0} ... {1}{2}", country.CCA2, country.Name, currencyDetails);
                }
                else
                {
                    Console.WriteLine("{0} ... {1}", country.CCA2, country.Name);
                }
            }

            Console.ReadKey();
        }
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
7. [.NET 5 - GraphQL Example](https://github.com/binarythistle/S04E01---.NET-5-GraphQL-API)
8. [Entity Framework Core: Show Parameter Values in Logging](https://elanderson.net/2019/03/entity-framework-core-show-parameter-values-in-logging/)
9. [How do you show underlying SQL query in EF Core?](https://stackoverflow.com/questions/45893732/how-do-you-show-underlying-sql-query-in-ef-core)
10. [GraphQL Workshop](https://github.com/ChilliCream/graphql-workshop)
11. [Stored Procedure in Entity Framework Core Migrations](https://dotnetthoughts.net/creating-stored-procs-in-efcore-migrations/)
12. [Code-First Stored Procedure Entity Framework 6.0](https://www.c-sharpcorner.com/UploadFile/ff2f08/code-first-stored-procedure-entity-framework-6-0/?) by Jignesh Trivedi
13. [Working with Stored Procedure in Entity Framework Core](https://www.entityframeworktutorial.net/efcore/working-with-stored-procedure-in-ef-core.aspx)
14. [Using the FOR XML Clause to Return Query Results as XML](https://www.red-gate.com/simple-talk/sql/learn-sql-server/using-the-for-xml-clause-to-return-query-results-as-xml/) by Robert Sheldon
15. [XML columns in a Code-First application](https://stackoverflow.com/questions/12631290/xml-columns-in-a-code-first-application) - StackOverflow
16. [NUnit vs. XUnit vs. MSTest: Comparing Unit Testing Frameworks In C#](https://www.lambdatest.com/blog/nunit-vs-xunit-vs-mstest/) by Himanshu Sheth
17. [How to do Canary Deployments on Kubernetes](https://phoenixnap.com/kb/kubernetes-canary-deployments)
18. [Say hello to Hot Chocolate 12!](https://chillicream.com/blog/2021/09/27/hot-chocolate-12) - [ChilliCream](https://chillicream.com/)
19. [9 Ways To Secure your GraphQL API — GraphQL Security Checklist](https://www.apollographql.com/blog/graphql/security/9-ways-to-secure-your-graphql-api-security-checklist/) - [Apollo GraphQL](https://www.apollographql.com/)
20. [GraphQL Authentication and Authorization in DotNet 6 using MongoDB](https://medium.com/@mohsenasadi501/graphql-authentication-and-authorization-in-dotnet-6-using-mongodb-e1de0bfbe240) by [Mohsenasadi](https://medium.com/@mohsenasadi501)
21. [Clean Architecture Solution Template](https://github.com/jasontaylordev/CleanArchitecture) - [Jason Taylor](https://github.com/jasontaylordev)
22. [EF Core 5 Table Valued Functions Unable to translate collection subquery in projection since the parent query doesn't project key columns of all Exception](https://github.com/dotnet/efcore/issues/23830) - [Dotnet EF Core Github](https://github.com/dotnet/efcore)

## Tutorial Videos

1. [.NET 5 REST API Tutorial](https://www.youtube.com/playlist?list=PLeD0-5Hw0ZJ_GlY21kfzfQD-N17i8pdTS)
2. [Getting started with GraphQL and HotChocolate](https://youtu.be/Hh8L6I2BV7k)
3. [GraphQL Schema Stitching](https://youtu.be/ODBR7kZHp-s)
4. [Real-time Data fetching with GraphQL and Blazor](https://youtu.be/iDAYdrFHqGU)
5. [Elegant API Versioning in ASP.NET Core (Web API)](https://youtu.be/iVHtKG0eU_s) - [Nick Chapas](https://www.youtube.com/c/Elfocrash/)
6. [Setting up JWT support (Authentication) | ASP.NET Core 5 REST API Tutorial 9](https://youtu.be/M6AkbBaDGJE) - [Nick Chapas](https://www.youtube.com/c/Elfocrash/)
7. [10 C# Libraries To Save You Time And Energy](https://youtu.be/uS0hRJqamfU)
8. [Creating NuGet Packages the easy way with .NET Standard in C#](https://youtu.be/AF1y9gLcxjQ)