FROM node:16-buster-slim

RUN apt-get install -y libappindicator1 fonts-liberation libasound2 libatk-bridge2.0-0 libatspi2.0-0 libdrm2 libgtk-3-0 libnspr4 libnss3 libx11-xcb1 libxkbcommon0 xdg-utils
RUN wget https://dl.google.com/linux/direct/google-chrome-stable_current_amd64.deb
RUN dpkg -i google-chrome*.deb

ENV NODE_ENV=production
ENV O8DBHOST=localhost
ENV MSSQLPORT=1433
ENV MSSQLUSER=sa
ENV MSSQLPWD=Password44

COPY . /usr/src/app

WORKDIR /usr/src/app

ENTRYPOINT [ "node", "main.js", "stocks"]