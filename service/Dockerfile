FROM node:16-buster-slim

RUN apt-get update 
RUN apt-get install -y apt-utils
RUN apt-get install -y wget
RUN wget https://dl.google.com/linux/direct/google-chrome-stable_current_amd64.deb
RUN apt-get install -y ./google-chrome-stable_current_amd64.deb

ENV NODE_ENV=production
ENV O8DBHOST=localhost
ENV MSSQLPORT=1433
ENV MSSQLUSER=sa
ENV MSSQLPWD=Password44

COPY . /usr/src/app

WORKDIR /usr/src/app

ENTRYPOINT [ "node", "main.js", "stocks"]