# Backup file
## bkfile="stocks-$(date '+%Y-%m-%d').bak"
bkfile="stocks.bak"

# Backup database
k exec -it mssql-0 -- /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P 'Password44' -Q "BACKUP DATABASE [stocks] TO DISK = N'/var/opt/mssql/bkup/$bkfile'"
k cp mssql-0:/var/opt/mssql/bkup/stocks.bak /home/dayton/Documents/Projects/shillings/db/bkup/$bkfile

# Remove file from container
k exec -it mssql-0 -- rm /var/opt/mssql/bkup/$bkfile