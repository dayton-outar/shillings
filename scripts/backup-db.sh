# Backup file
bkfile="stocks-$(date '+%Y-%m-%d').bak"

# Backup database
sqlcmd -S localhost,1401 -U SA -P "Password44" -Q "BACKUP DATABASE [stocks] TO DISK = N'/var/opt/mssql/bkup/$bkfile'"
cp /var/lib/docker/volumes/sql1data/_data/bkup/$bkfile /media/dayton/SAMSUNG/_portfolio/bak
chmod 777 /media/dayton/SAMSUNG/_portfolio/bak/$bkfile

# Remove file from container
#docker exec zeus-sql rm /var/opt/mssql/bkup/$bkfile