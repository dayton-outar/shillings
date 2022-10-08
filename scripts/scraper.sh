export O8DBHOST=localhost
export MSSQLPORT=1401
export MSSQLUSER=SA
export MSSQLPWD=Password44

echo "$(date) ... Executing scraper"
/usr/local/bin/node /home/dayton/Documents/Projects/shillings/service/main.js
