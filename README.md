# Octopussimizer

Initially this application was built to crawl through a web site to identify all CSS styles and to optimize the CSS files to remove irrelevant styles for each page. It was a file optimization tool specifically for decreasing the payload of the CSS files. This application is now used to scrape data from pages that contain data with daily summary of stock trades. It uses a cluster of applications to achieve this objective.

## Requirements

So, the main idea for optimizing a page or, better yet, a web site is to,

 * [Node](https://nodejs.org/en/) 14.15 or greater
 * [Vue](https://vuejs.org/)
 * [Vuex](https://vuex.vuejs.org/)
 * [Apollo](https://www.apollographql.com/docs/react/)
 * [Buefy](https://buefy.org/)
 * [HighCharts](https://www.highcharts.com/)
 * [.NET 5](https://dotnet.microsoft.com/download/dotnet/5.0)
 * [Entity Framework](https://docs.microsoft.com/en-us/ef/)
 * [Hot Chocolate](https://chillicream.com/docs/)

All the above should be in the core library of the software.

## Installation

...

## Usage

...

## Contributions

...

## Developer Notes

## Cron

[How to Set Up a Cron Job in Linux](https://phoenixnap.com/kb/set-up-cron-job-linux)

| Description | Crontab Syntax |
| :--- | :--- |
| Hourly | `0 * * * *` |
| Dailly | `0 0 * * *` |
| Weekly | `0 0 * * 0` |
| Monthly | `0 0 1 * *` |
| Annually | `0 0 1 1 *` |
| Everyday at 12 PM for the first 6 months of the year | `0 11 * 1-6 *` |

Grant _scraper.sh_ executable permissions
```bash
chmod +x [host directory]/scripts/scraper.sh
```

## Further Reading

1. [GraphQL Pagination and Sorting](https://blog.reactioncommerce.com/how-to-implement-graphql-pagination-and-sorting/)
2. [Vue Apollo v4: the first look](https://dev.to/n_tepluhina/vue-apollo-v4-the-first-look-c32)
3. [Vue Apollo: Smart Query](https://apollo.vuejs.org/api/smart-query.html#options)
4. [Entity Framework Core: Show Parameter Values in Logging](https://elanderson.net/2019/03/entity-framework-core-show-parameter-values-in-logging/)
5. [How do you show underlying SQL query in EF Core?](https://stackoverflow.com/questions/45893732/how-do-you-show-underlying-sql-query-in-ef-core)
6. [GraphQL Workshop](https://github.com/ChilliCream/graphql-workshop)
7. [Stored Procedure in Entity Framework Core Migrations](https://dotnetthoughts.net/creating-stored-procs-in-efcore-migrations/)
8. [Code-First Stored Procedure Entity Framework 6.0](https://www.c-sharpcorner.com/UploadFile/ff2f08/code-first-stored-procedure-entity-framework-6-0/?) by Jignesh Trivedi
9. [Working with Stored Procedure in Entity Framework Core](https://www.entityframeworktutorial.net/efcore/working-with-stored-procedure-in-ef-core.aspx)
10. [Combining GraphQL and Vuex](https://markus.oberlehner.net/blog/combining-graphql-and-vuex/) by Markus Oberlehner

## Video Tutorial References

1. [Vuex Tutorial](https://www.youtube.com/playlist?list=PL4cUxeGkcC9i371QO_Rtkl26MwtiJ30P2) by Net Ninja
2. [Vue JS 2](https://www.youtube.com/playlist?list=PL4cUxeGkcC9gQcYgjhBoeQH7wiAyZNrYa) by Net Ninja