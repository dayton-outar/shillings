using HotChocolate;
using HotChocolate.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

using O8Query.Models;
using O8Query.Data;

namespace Harpoon
{
    public class Mutation
    {

        [UseDbContext(typeof(StocksQuery))]
        public FinancialReport CreateFinancialReport([ScopedService]StocksQuery sq, FinancialReport financialReport)
        {
            // Adapted from https://www.codemag.com/Article/2101031/Calling-Stored-Procedures-with-the-Entity-Framework-in-.NET-5
            int rowsAffected;
            string sql = "EXEC [dbo].[CreateFinancialReport] @report";
            
            string financialReportXml = SerializationHelper.Serialize<FinancialReport>(financialReport);
            List<SqlParameter> parms = new List<SqlParameter>
            { 
                // Create parameters
                new SqlParameter { ParameterName = "@report", Value = financialReportXml }  
            };
            
            rowsAffected = sq.Database.ExecuteSqlRaw(sql, parms.ToArray());

            return financialReport;
        }

        [UseDbContext(typeof(StocksQuery))]
        public FinancialReport UpdateFinancialReport([ScopedService]StocksQuery sq, FinancialReport financialReport)
        {
            // Adapted from https://www.codemag.com/Article/2101031/Calling-Stored-Procedures-with-the-Entity-Framework-in-.NET-5
            int rowsAffected;
            string sql = "EXEC [dbo].[UpdateFinancialReport] @report";
            
            string financialReportXml = SerializationHelper.Serialize<FinancialReport>(financialReport);
            List<SqlParameter> parms = new List<SqlParameter>
            { 
                // Create parameters
                new SqlParameter { ParameterName = "@report", Value = financialReportXml }  
            };
            
            rowsAffected = sq.Database.ExecuteSqlRaw(sql, parms.ToArray());

            return financialReport;
        }
    }
}