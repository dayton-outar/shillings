# Backup file
## bkfile="stocks-$(date '+%Y-%m-%d').bak"
bkfile="stocks.bak"

# Backup database
kubectl exec -it mssql-0 -- /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P $SA_PASSWORD -Q "BACKUP DATABASE [stocks] TO DISK = N'/var/opt/mssql/bkup/$bkfile'"
# Use secure copy to copy file from container to host if not using kubernetes
# scp root@[remote ip address]:/root/mssql/bkup/stocks.bak /home/dayton/Documents/Projects/shillings/db/bkup/stocks.bak
kubectl cp mssql-0:/root/mssql/bkup/stocks.bak /home/dayton/Documents/Projects/shillings/db/bkup/$bkfile

# Remove file from container
kubectl exec -it mssql-0 -- rm /var/opt/mssql/bkup/$bkfile