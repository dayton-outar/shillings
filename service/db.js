const sql = require('mssql');

const config = {
    user: process.env.MSSQLUSER,
    password: process.env.MSSQLPWD,
    server: 'localhost,1401',
    database: 'stocks',
}

function runQuery(query) {
    // sql.connect() will return the existing global pool if it exists or create a new one if it doesn't
    return sql.connect().then((pool) => {
      return pool.query(query)
    })
}