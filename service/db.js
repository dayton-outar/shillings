const sql = require('mssql');
const xml2json = require('xml-js');

const dotenv = require('dotenv');
dotenv.config();

const config = {
    user: process.env.MSSQLUSER,
    password: process.env.MSSQLPWD,
    server: process.env.O8DBHOST,
    port: parseInt(process.env.MSSQLPORT, 10),
    database: 'stocks',
    options: {
        enableArithAbort: true
    }
}

const O8Q = {
    updateStocks: async function ( tradings ) {
        let result = {
            success: false,
            message: 'Failed to update stocks',
            data: {}
        };

        try {

            if ( tradings.stocks.length === 0) {
                result.message = 'No data to update database';
                return result;
            }

            let pool = await sql.connect(config);

            let stocks = xml2json.json2xml(tradings, {
                compact: true,
                ignoreComment: true,
                spaces: 4
            });

            let dbr = await pool.request()
                .input('stocks', sql.Xml, stocks)
                .execute('UpdateStockTradings');
            
            console.log(dbr);

            result = {
                success: dbr.returnValue === 0,
                message: `Successfully updated ${tradings.stocks.length} stocks for ${tradings.stocks[0].date}`,
                data: {}
            };

        } catch(ex) {
            console.error( ex.message );
            result.message = ex.message;
        }

        return result;
    },
    updateCompany: async function ( listing ) {
        let result = {
            success: false,
            message: 'Failed to update company details',
            data: {}
        };

        try {

            if ( listing.companies.length === 0) {
                result.message = 'No data to update database';
                return result;
            }

            let pool = await sql.connect(config);

            let companies = xml2json.json2xml(listing, {
                compact: true,
                ignoreComment: true,
                spaces: 4
            });

            let dbr = await pool.request()
                .input('companies', sql.Xml, companies)
                .execute('UpdateCompaniesDetails');
            
            //console.log(dbr);

            result = {
                success: dbr.returnValue === 0,
                message: `Successfully updated ${listing.companies.length} companies`,
                data: {}
            };

        } catch(ex) {
            console.error( ex.message );
            result.message = ex.message;
        }

        return result;
    },
    updateIndices: async function ( logs ) {
        let result = {
            success: false,
            message: 'Failed to update stock indices',
            data: {}
        };

        try {

            if ( logs.indices.length === 0) {
                result.message = 'No data to update database';
                return result;
            }

            let pool = await sql.connect(config);

            let indices = xml2json.json2xml(logs, {
                compact: true,
                ignoreComment: true,
                spaces: 4
            });

            let dbr = await pool.request()
                .input('indices', sql.Xml, indices)
                .execute('UpdateStockIndices');
            
            //console.log(dbr);

            result = {
                success: dbr.returnValue === 0,
                message: `Successfully updated ${logs.indices.length} indices`,
                data: {}
            };

        } catch(ex) {
            console.error( ex.message );
            result.message = ex.message;
        }

        return result;
    },
    updateDividends: async function ( all ) {
        let result = {
            success: false,
            message: 'Failed to update stock dividends',
            data: {}
        };

        try {

            if ( all.dividends.length === 0) {
                result.message = 'No data to update database';
                return result;
            }

            let pool = await sql.connect(config);

            let stockDividends = xml2json.json2xml(all, {
                compact: true,
                ignoreComment: true,
                spaces: 4
            });

            let dbr = await pool.request()
                .input('dividends', sql.Xml, stockDividends)
                .execute('UpdateStockDividends');
            
            console.log(dbr);

            result = {
                success: dbr.returnValue === 0, // https://www.npmjs.com/package/mssql#execute-procedure-callback
                message: `Successfully updated ${dividends.dividends.length} dividends`,
                data: {}
            };

        } catch(ex) {
            console.error( ex.message );
            result.message = ex.message;
        }

        return result;
    }
}

sql.on('error', err => {

    console.log('Database error occurred\n');
    console.error( err );

})

module.exports = O8Q;