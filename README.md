# Shillings

***Shillings*** is the first story-based stock trading platform.

## Vision Statement

_To be the complete playground for stock investor's worldwide_

## Mission Statement

_To empower stock investors globally by providing an immersive platform that offers a story-based approach to understanding the development and performance of businesses._

## Requirements

 - [Kubernetes](https://kubernetes.io/)
   - [Docker](https://www.docker.com/)
 - [VueJS](https://vuejs.org/)
 - [.NET](https://dotnet.microsoft.com/)
 - [Node](https://nodejs.org/en/)
 - [Microsoft SQL Server 2019](https://www.microsoft.com/en-us/sql-server/sql-server-2019)

There was intention to create a [Helm](https://helm.sh/) chart to deploy this distributed application on a Kubernetes platform. For now, the _docker-compose.yml_ file in the root can be used.

## File Structure

This project contains 3 applications and a database management system. Within the file structure are the business plan documentation that inspires the project and scripts used to deploy the applications and the database management system.

Here's a breakdown,

1. [ui](./ui/)
   
   Contains the single-page application written in VueJS

2. [service](./service/)
   
   Contains the Node.js application that is used to gather stock information from sources such as Jamaica Stock Exchange

3. [api](./api/)
   
   Contains the DotNet application that serves up a GraphQL API

4. [db](./db/)
   
   Contains backup file of database containing stock information from 1998 to 2024. Also includes bash and T-SQL scripts used to maintain the database.

5. [devops](./devops/)
   
   Contains kubernetes manifests to deploy the network of applications on a hosting platform. It also includes a docker compose manifest for simpler deployment without Kubernetes.

6. [graphics](./graphics/)
   
   Contains [Gimp](https://www.gimp.org/) files used to create logo

7. [proxy](./proxy/)

   Contains [NGINX](https://nginx.org/en/) file used to configure proxy pass for API on local shared hosting.

## Installation

To install this distributed application perform the following command at the root folder,

```
docker compose up -d
```

After the docker virtual environment is up and running, ***the database will be empty***. To fill the database consider restoring the backup file, [stocks.bak](./db/bkup/stocks.bak). The [scripts](./db/scripts/) folder contains bash scripts that can be used to perform the restore.

***N.B. Some troubleshooting maybe necessary to get the application function-ready.***

***N.B. Please see the [IdentityService.cs](./api/Harpoon/IdentityService.cs) to sign into the back-office at http://localhost:8080/login***

## Usage

...

## Contributions

I expect that certain code sharing etiquette will be observed. Contributors are expected to fork a clone of this repo and make changes in their own copy, then create a pull request if they wish to suggest changes to this repo.

## Role Models
1. [Simply Wall St](https://simplywall.st/)
2. [Google Finance](https://www.google.com/finance/)
3. [Yahoo Finance](https://finance.yahoo.com/)