#!/bin/bash

# Wait for SQL Server to start up
until /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "$SA_PASSWORD" -Q "SELECT 1" &> /dev/null
do
    echo "Waiting for SQL Server to start..."
    sleep 15
done

# Restore the database
echo "Restoring database from backup..."
/opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "$SA_PASSWORD" -Q "RESTORE DATABASE [stocks] FROM DISK = N'/var/opt/mssql/bkup/stocks.bak' WITH FILE = 1, NOUNLOAD, REPLACE, STATS = 5"
echo "Database restore complete."