# Wait to be sure that SQL Server came up
sleep 90s

# Run the setup script to create the DB and the schema in the DB
# Note: make sure that your password matches what is in the Dockerfile
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P $MSSQL_SA_PASSWORD -q "RESTORE DATABASE [stocks] FROM DISK = N'/var/opt/mssql/bkup/stocks.bak' WITH MOVE 'stocks' TO '/var/opt/mssql/data/stocks.mdf', MOVE 'stocks_log' TO '/var/opt/mssql/data/stocks_log.ldf'"
