# We choose exact tag (not 'latest'), to be sure that new version wont break creating image
FROM mcr.microsoft.com/mssql/server:2019-CU3-ubuntu-18.04

USER root

# Create app directory
RUN mkdir -p /app /var/opt/mssql/bkup

WORKDIR /app

# Copy initialization scripts
COPY ./scripts /app
# Copy backup file
COPY ./bkup/stocks.bak /var/opt/mssql/bkup

# Grant permissions for the restore script
RUN chmod +x /app/restore-db.sh

# Expose port 1433 in case accesing from other container
EXPOSE 1433

# This container will run without explicit command, so we need to run restore-db.sh script within container