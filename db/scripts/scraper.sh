export O8DBHOST=localhost
export MSSQLPORT=1401
export MSSQLUSER=SA
export MSSQLPWD=Password44

echo "$(date) ... Executing scraper"
/usr/local/bin/node /home/dayton/Documents/Projects/shillings/service/main.js stocks

# docker run --name scraper -itd -e MSSQLPWD='$MSSQLPWD' --network=root_default krisyslimited/reader:0417
# docker run -itd --network=multi-host-network busybox

## Production
#0 23 * * * /usr/bin/docker start -i root-scraper >> /root/my-cron.log