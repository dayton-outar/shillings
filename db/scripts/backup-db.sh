# Backup file
## bkfile="stocks-$(date '+%Y-%m-%d').bak"
bkfile="stocks.bak"

# Backup database
kubectl exec -it mssql-0 -- /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P $MSSQL_SA_PASSWORD -Q "BACKUP DATABASE [stocks] TO DISK = N'/var/opt/mssql/bkup/$bkfile'"
# Use secure copy to copy file from container to host if not using kubernetes
kubectl cp mssql-0:/var/opt/mssql/bkup/stocks.bak /home/dayton/Documents/Projects/shillings/db/bkup/$bkfile

# Remove file from container
kubectl exec -it mssql-0 -- rm /var/opt/mssql/bkup/$bkfile