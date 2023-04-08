# Backup file
## bkfile="stocks-$(date '+%Y-%m-%d').bak"
bkfile="stocks.bak"

# Backup database
sqlcmd -S localhost,1401 -U SA -P "Password44" -Q "BACKUP DATABASE [stocks] TO DISK = N'/var/opt/mssql/bkup/$bkfile'"
cp /var/lib/docker/volumes/sql1data/_data/bkup/$bkfile /home/dayton/Documents/Projects/shillings/db/bkup
chmod 777 /home/dayton/Documents/Projects/shillings/db/bkup/$bkfile

# Remove file from container
docker exec zeus-sql rm /var/opt/mssql/bkup/$bkfile