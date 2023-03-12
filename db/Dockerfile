# We choose exact tag (not 'latest'), to be sure that new version wont break creating image
FROM mcr.microsoft.com/mssql/server:2019-CU3-ubuntu-18.04

USER root
# Create app directory
RUN mkdir -p /app

# Create backup directory
RUN mkdir -p /var/opt/mssql/bkup

WORKDIR /app

# Copy backup file
COPY ./*.bak /var/opt/mssql/bkup

# Copy initialization scripts
COPY ./*.sh /app

# Grant permissions for the run-initialization script to be executable
RUN chmod +x /app/run-initialization.sh

# Expose port 1433 in case accesing from other container
EXPOSE 1433

# Run Microsoft SQl Server and initialization script (at the same time)
# Note: If you want to start MsSQL only (without initialization script) you can comment bellow line out, CMD entry from base image will be taken
CMD /bin/bash ./entrypoint.sh