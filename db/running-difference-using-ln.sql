-- Completes 456 rows in 117ms
SELECT  m.[Name],
        i.[Value],
        LAG(i.[Value], 1, i.[Value]) OVER (ORDER BY l.[Logged]) [Prev], -- Credit: https://learn.microsoft.com/en-us/sql/t-sql/functions/lag-transact-sql?view=sql-server-ver15
        LOG( ( i.[Value] / LAG(i.[Value], 1, i.[Value]) OVER (ORDER BY l.[Logged]) )) AS Diff,
        i.[ValueChange],
        l.[Logged]
FROM [stocks].[dbo].[StockIndices] i
    INNER JOIN [dbo].[Logs] l ON i.[LogNo] = l.[No]
    INNER JOIN [dbo].[MarketIndices] m ON m.[No] = i.[MarketIndexNo]
ORDER BY l.[Logged] DESC