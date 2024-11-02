# DevOps Notes

After developing a cluster of applications on the local machine, there comes a time when these applications need to be deployed into either a staging environment or a production environment, where it is more accessible to the public. Going public with an application will inevitably expose it to scrutiny of all kinds, especially to those who want to benefit from exploiting the applications vulnerability for their own self interests. Hence, it is important to be thorough when it comes to matters of security. Apart from security the speed of deployment will facilitate rapid response to customer feedback. The _DevOps_ phenomena has presented a set of tools and philosophy that can easily facilitate the rapid response to deploy changes to customers. So, while preparing this solution measures were taken to facilitate the _DevOps_ philosophy into planning and implementation.

Outlined herein is the journey taken from development stage to going live. Concepts of _Agile_ software methodology were incorporated in the project planning. So, an MVP (Minimal Viable Product) was determined for the first release and the idea is to _continuously improve_ the solution based on customer feedback hinged upon the main [vision](../README.md#vision-statement) throughout the life of this project.

Here's a overview of the DevOps progression,

1. Prepare docker containers from the MVP versions of all the applications within the cluster
2. Test the docker containers using the [Docker Compose](https://docs.docker.com/compose/) tool. (See the [docker-compose.yaml](../docker-compose.yml))
3. Purchase subscription from [Docker Hub](https://hub.docker.com/) registry and push docker containers into private registries
4. Test the docker containers within [Minikube](https://minikube.sigs.k8s.io/docs/) using [Kubernetes](https://kubernetes.io/) instead of Docker Compose
5. Purchase Kubernetes cluster and deploy containers from [Linode](https://www.linode.com/)
6. Purchase domain name from [GoDaddy](https://www.godaddy.com/)
7. Configure domain name on GoDaddy to use name servers on Linode.
   
   ![Edit Name Servers on GoDaddy](/.attachments/godaddy-nameservers.png)

8. Create domain on Linode   
9. Install Ingress Controller into Kubernetes cluster on Linode using Helm (`helm install ingress-nginx`)
10. Generate private key and Certificate Signing Request (.csr) file from ingress controller
11. Purchase SSL certificate from [GoDaddy](https://www.godaddy.com/) and use the content of the .csr file generated in prior step
12. Create TLS secret from the provided SSL certificate files
13. Apply ingress for domain name
14. Create A/AAAA Record for domain name using the external IP provided by the ingress that was applied in prior step
    
    ![A/AAAA record entry](/.attachments/linode-dns.png)

## Minikube

[Minikube](https://minikube.sigs.k8s.io/docs/) is a good sandbox for testing out the Kubernetes manifests that are prepared to deploy the containers needed in the cluster.

DevOps Engineers may encounter DNS issues when trying to get the pods to communicate with each other. See the discussion on this topic, [Coredns waiting on kubernetes indefinitely](https://github.com/coredns/coredns/discussions/4990).

## Linode

After creating a Kubernetes cluster, Linode provides a YAML file that is used to access the cluster. The step that is taken on the local machine to access the cluster involves exporting the KUBECONFIG environment variable by assigning it to the file path of the YAML file.

## Appendix

Going to need 4 types of containers:
1. NGINX running the static site
2. Dotnet 6 runtime for GraphQL API
3. MSSQL container hosting the database
4. Service running puppeteer on Node JS

Build docker image from Dockerfile for Harpoon. (Given that the `dotnet publish` command is ran on Harpoon to create the _build_ folder). Tagging with a version number is also important.

```bash
cd api
docker build -t krisys/harpoon:latest .
```
Before running harpoon environment variables must be set

```bash
HARPOON_DB_SRV=localhost
HARPOON_DB_PRT=1401
HARPOON_DB_DB=stocks
HARPOON_DB_USR=SA
HARPOON_DB_PWD=Password44
```

These environment variables must be set in the `/etc/environment` file. The changes can be reloaded with,

```bash
source /etc/environment
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
docker run -d --name shillings-db -p 1411:1433 -e ACCEPT_EULA Y -e SA_PASSWORD Password44
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
kubectl create secret docker-registry docker-hub-cred --docker-username=<username> --docker-password=<password> --docker-email=<email>
```

To create TLS secret

```bash
kubectl create secret tls <secret-name> --namespace <namespace> --key server.key --cert server.crt
```

Create generic secret
```bash
create secret generic shillings-db-secret --from-literal=password='<password>'
```

To expose LoadBalancer externally use the following minikube command

```bash
minikube service <service>
```

You can also use port forwarding to reach the nodes. For example, to reach a service,

```bash
kubectl port-forward service/<service> 8080:80
```

When addressing permission issues within minikube container

```bash
docker exec -it -u root minikube bash
```

When entering into container using `kubectl`,

```bash
kubectl exec -it [pod] -- bash
```

To copy a file from local machine to a pod,

```bash
kubectl cp /<path-to-your-file>/<file-name> <pod-name>:<fully-qualified-file-name> -c <container-name>
```

To copy a file from pod to local machine,

```bash
kubectl cp <pod-name>:<fully-qualified-file-name> /<path-to-your-file>/<file-name> -c <container-name>
```

## Docker Commands on Shared CPU

To run the scraper,

```bash
docker run --name root-scraper -itd -e O8DBHOST=db -e MSSQLPWD='[Password]' --network=root_default krisyslimited/reader:1.0
```
To run the api,

```bash
docker run -d --name root-api -p 5000:5000 -e ASPNETCORE_URLS=http://+:5000 -e HARPOON_DB_HST=db -e HARPOON_DB_PWD='[Password]' --network=root_default krisyslimited/harpoon:1.5
```

When changing UI, copy the files from `dist` folder to `/var/www/html` folder using scp.


Do I need [Fluentd](https://docs.fluentd.org/)?

## Further Reading

1. [How To Use the Official NGINX Docker Image](https://www.docker.com/blog/how-to-use-the-official-nginx-docker-image/)
2. [Host ASP.NET Core on Linux with Nginx](https://learn.microsoft.com/en-us/aspnet/core/host-and-deploy/linux-nginx?view=aspnetcore-7.0&tabs=linux-ubuntu)
3. [How to Configure Nginx as Reverse Proxy for Nodejs App](https://www.tecmint.com/nginx-as-reverse-proxy-for-nodejs-app/)
4. [How to run Node cron jobs inside a Docker container](https://www.tddapps.com/2016/05/05/how-to-run-node-cron-jobs-in-a-docker-container/)
5. [Writing .NET Application Services for Kubernetes](https://mikehadlow.com/posts/2022-06-24-writing-dotnet-services-for-kubernetes/)
6. [The Twelve-Factor App](https://12factor.net/)
7. [Quickstart: Run SQL Server Linux container images with Docker](https://learn.microsoft.com/en-us/sql/linux/quickstart-install-connect-docker?view=sql-server-ver16&pivots=cs1-bash)
8. [Example: Deploying WordPress and MySQL with Persistent Volumes](https://kubernetes.io/docs/tutorials/stateful-application/mysql-wordpress-persistent-volume/)
9. [Quickstart: Deploy a SQL Server container with Azure Kubernetes Services (AKS)](https://learn.microsoft.com/en-us/sql/linux/quickstart-sql-server-containers-kubernetes?view=sql-server-ver16)
10. [Deploy SQL Server Linux containers on Kubernetes with StatefulSets](https://learn.microsoft.com/en-us/sql/linux/sql-server-linux-kubernetes-best-practices-statefulsets?view=sql-server-ver16)
11. [Statefulset vs Deployment | Differences & Use Cases](https://www.containiq.com/post/statefulset-vs-deployment#:~:text=A%20StatefulSet%20is%20better%20suited,servers%20like%20Nginx%20and%20Apache.)
12. [Backup Databases on Kubernetes With VolumeSnapshots](https://www.percona.com/blog/backup-databases-on-kubernetes-with-volumesnapshots/)
13. [Kubernetes: how to debug CrashLoopBackOff](https://stackoverflow.com/questions/44673957/kubernetes-how-to-debug-crashloopbackoff)
14. [Minikube – /opt/mssql/bin/sqlservr: Error: The system directory [/.system] could not be created](https://mycsharpdeveloper.wordpress.com/2022/10/30/minikube-opt-mssql-bin-sqlservr-error-the-system-directory-system-could-not-be-created/)
15. [SQL Server Docker container immediately exiting](https://stackoverflow.com/questions/72383490/sql-server-docker-container-immediately-exiting)
16. [Pull an Image from a Private Registry](https://kubernetes.io/docs/tasks/configure-pod-container/pull-image-private-registry/)
17. [How To Use minikube for Local Kubernetes Development and Testing](https://www.digitalocean.com/community/tutorials/how-to-use-minikube-for-local-kubernetes-development-and-testing)
18. [How To Configure Ingress TLS/SSL Certificates in Kubernetes](https://devopscube.com/configure-ingress-tls-kubernetes/) by [Bibin Wilson](https://devopscube.com/author/bibinwilson/)
19. [How to add an SSL to your website — The ultimate guide on SSLs](https://www.godaddy.com/garage/ssl-ultimate-guide/)
20. [Deploying NGINX Ingress on Linode Kubernetes Engine](https://www.linode.com/docs/guides/deploy-nginx-ingress-on-lke/)
21. [Edit my domain nameservers](https://ie.godaddy.com/help/edit-my-domain-nameservers-664)
22. [Guides - Manage DNS Records](https://www.linode.com/docs/products/networking/dns-manager/guides/manage-dns-records/)
23. [NGINX: Generate CSRs (Certificate Signing Requests)](https://ie.godaddy.com/help/nginx-generate-csrs-certificate-signing-requests-3601)
24. [Kubernetes service - Loadbalancer with HTTPS](https://stackoverflow.com/questions/50950590/kubernetes-service-loadbalancer-with-https)
25. [How To Set Up a Firewall with UFW on Ubuntu 18.04](https://www.digitalocean.com/community/tutorials/how-to-set-up-a-firewall-with-ufw-on-ubuntu-18-04)
26. [How To Install and Use Docker Compose on Ubuntu 22.04](https://www.digitalocean.com/community/tutorials/how-to-install-and-use-docker-compose-on-ubuntu-22-04)
27. [How to copy files from one machine to another using ssh](https://unix.stackexchange.com/questions/106480/how-to-copy-files-from-one-machine-to-another-using-ssh)
28. [How To Install Nginx on Ubuntu 22.04](https://www.digitalocean.com/community/tutorials/how-to-install-nginx-on-ubuntu-22-04)
29. [Nginx Redirect HTTP to HTTPS](https://linuxhint.com/nginx-redirect-http-https/)

## Tutorial Video

1. [Learn Docker - DevOps with Node.js & Express](https://youtu.be/9zUHg7xjIqQ)
2. [Kubernetes 101](https://www.youtube.com/playlist?list=PL2_OBreMn7FoYmfx27iSwocotjiikS5BD)
3. [Kubernetes Tutorial for Beginners [FULL COURSE in 4 Hours]](https://youtu.be/X48VuDVv0do)
4. [How to Create Helm Charts - The Ultimate Guide](https://youtu.be/jUYNS90nq8U)
5. [How to Use Private Docker Registry Images | Kubernetes For Beginners | CKA Cert Prep](https://youtu.be/xYk6qCyXOY4)
6. [Kubernetes StatefulSet simply explained | Deployment vs StatefulSet](https://youtu.be/pPQKAR1pA9U)
7. [Understanding StatefulSets in Kubernetes](https://youtu.be/zj6r_EEhv6s)
8. [Persistent Volumes on Kubernetes for beginners](https://youtu.be/ZxC6FwEc9WQ)
9. [Kubernetes Backup and Restore made easy!](https://youtu.be/01qcYSck1c4)
10. [Kubernetes Cron/CronJobs in 10 minutes](https://youtu.be/PUhqw0laR3A)
11. [Understanding Logging: Containers & Microservices](https://youtu.be/MMVdkzeQ848)
12. [[ Kube 34 ] Monitor Kubernetes Logs using EFK stack - Elasticsearch, FluentBit & Kibana](https://youtu.be/8nWh1GLd7nY)
13. [Kubernetes Secrets in 5 Minutes!](https://youtu.be/cQAEK9PBY8U)
14. [Kubernetes Secret Management Explained](https://youtu.be/o36yTfGDmZ0)
15. [How to Set Up SSL with NGINX](https://youtu.be/X3Pr5VATOyA) - [NGINX](https://www.youtube.com/@nginx_official)