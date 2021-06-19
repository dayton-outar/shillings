# Octopussimizer: The JSE Stock Tracker

Initially this application was built to crawl through a web site to identify all CSS styles and to optimize the CSS files to remove irrelevant styles for each page. It was a file optimization tool specifically for decreasing the payload of the CSS files. This application is now used to scrape data from pages that contain data with daily summary of stock trades. It uses a cluster of applications to achieve this objective.

## Requirements

 - [Kubernetes](https://kubernetes.io/)
   - [Minikube](https://minikube.sigs.k8s.io/docs/)
   - [Helm](https://helm.sh/)
   - [Docker](https://www.docker.com/)
 - [NGINX](https://www.nginx.com/)
 - [Node](https://nodejs.org/en/)
 - [.NET](https://dotnet.microsoft.com/)
 - [Microsoft SQL Server 2019](https://www.microsoft.com/en-us/sql-server/sql-server-2019)

## Installation

...

## Usage

...

## Contributions

...

I expect that certain code sharing etiquette will be observed. Contributors are expected to fork a clone of this repo and make changes in their own copy, then create a pull request if they wish to suggest changes to this repo.

## Notes

Going to need 4 types of containers:
1. NGINX running the static site
2. NGINX running the dotnet GraphQL API
3. MSSQL container hosting the database
4. Cron service running node

Do I need [Fluentd](https://docs.fluentd.org/)?