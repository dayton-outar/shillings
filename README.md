# Shillings: The JSE Stock Tracker

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

Build docker image from Dockerfile for Harpoon. (Given that the `dotnet publish` command is ran on Harpoon to create the _build_ folder). Tagging with a version number is also important.

```bash
cd api
docker build -t krisys/harpoon:latest .
```

Run docker container for Harpoon.

Set external to 5000 but forward traffic internally to port 80. Port 80 is the default port when the dotnet application is published using `dotnet publish`.

```bash
docker run -d --name harpoon -p 5000:80 krisys/harpoon:latest
```

Build docker image from Dockerfile for UI. (Gien that the `npm run serve` command is ran to create _dist_ folder)

```bash
cd ui
docker build -t krisys/shillings:latest .
```

Run docker container for UI

```bash
docker run -d --name ui -p 8080:80 krisys/shillings:latest
```

For the database, the docker image would have instructions to transfer backup file into the app folder

```bash
docker build -t krisys/sex:latest db/.
```

When running this container, 

```bash
docker run -d --name shillings-db -p 1411:1433 -e ACCEPT_EULA Y -e MSSQL_SA_PASSWORD Password44
```

Using docker-compose in root folder

```bash
docker-compose up -d
```

Shutting down containers

```bash
docker-compose down
```

To enable Kubernetes to pull from a private repository

```bash
kubectl create secret docker-registry docker-hub-cred --docker-username <username> --docker-password <password>
```

To expose LoadBalancer externally use the following minikube command

```bash
minikube service <service>
```

You can also use port forwarding to reach the nodes. For example, to reach a service,

```bash
kubectl port-forward service/<service> 8080:80
```

Do I need [Fluentd](https://docs.fluentd.org/)?

## Role Models
1. [Simply Wall St](https://simplywall.st/)
2. [Google Finance](https://www.google.com/finance/)
3. [Yahoo Finance](https://finance.yahoo.com/)

## Further Reading

1. [How To Use the Official NGINX Docker Image](https://www.docker.com/blog/how-to-use-the-official-nginx-docker-image/)
2. [Host ASP.NET Core on Linux with Nginx](https://learn.microsoft.com/en-us/aspnet/core/host-and-deploy/linux-nginx?view=aspnetcore-7.0&tabs=linux-ubuntu)
3. [How to Configure Nginx as Reverse Proxy for Nodejs App](https://www.tecmint.com/nginx-as-reverse-proxy-for-nodejs-app/)
4. [How to run Node cron jobs inside a Docker container](https://www.tddapps.com/2016/05/05/how-to-run-node-cron-jobs-in-a-docker-container/)
5. [Writing .NET Application Services for Kubernetes](https://mikehadlow.com/posts/2022-06-24-writing-dotnet-services-for-kubernetes/)
6. [The Twelve-Factor App](https://12factor.net/)
7. [Quickstart: Run SQL Server Linux container images with Docker](https://learn.microsoft.com/en-us/sql/linux/quickstart-install-connect-docker?view=sql-server-ver16&pivots=cs1-bash)

## Tutorial Video

1. [25 VS Code Productivity Tips and Speed Hacks](https://youtu.be/ifTF3ags0XI)
2. [Learn Docker - DevOps with Node.js & Express](https://youtu.be/9zUHg7xjIqQ)
3. [Kubernetes 101](https://www.youtube.com/playlist?list=PL2_OBreMn7FoYmfx27iSwocotjiikS5BD)
4. [Kubernetes Tutorial for Beginners [FULL COURSE in 4 Hours]](https://youtu.be/X48VuDVv0do)
5. [How to Create Helm Charts - The Ultimate Guide](https://youtu.be/jUYNS90nq8U)
6. [How to Use Private Docker Registry Images | Kubernetes For Beginners | CKA Cert Prep](https://youtu.be/xYk6qCyXOY4)