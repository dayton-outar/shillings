using System;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using HotChocolate;
using HotChocolate.Data;
using Microsoft.EntityFrameworkCore;
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
            string sql = "EXEC [dbo].[CreateFinancialReport] @report, @no OUTPUT";
            
            string financialReportXml = SerializationHelper.Serialize<FinancialReport>(financialReport);
            List<SqlParameter> parms = new List<SqlParameter>
            { 
                // Create parameters
                new SqlParameter { ParameterName = "@report", Value = financialReportXml },
                new SqlParameter { ParameterName = "@no", SqlDbType = SqlDbType.BigInt, Direction = ParameterDirection.Output }
            };
            
            sq.Database.ExecuteSqlRaw(sql, parms.ToArray());

            var param = parms.Where(p => p.ParameterName == "@no").First();
            if (param.Value != null)
            {
                financialReport.No =  Convert.ToInt32(param.Value);
            }            
            financialReport.Analytes = sq.StatementAnalytes.Where(a => a.Report.No == financialReport.No).ToList();

            return financialReport;
        }

        [UseDbContext(typeof(StocksQuery))]
        public FinancialReport UpdateFinancialReport([ScopedService]StocksQuery sq, FinancialReport financialReport)
        {
            // Adapted from https://www.codemag.com/Article/2101031/Calling-Stored-Procedures-with-the-Entity-Framework-in-.NET-5
            string sql = "EXEC [dbo].[UpdateFinancialReport] @report";
            
            string financialReportXml = SerializationHelper.Serialize<FinancialReport>(financialReport);
            List<SqlParameter> parms = new List<SqlParameter>
            { 
                // Update parameters
                new SqlParameter { ParameterName = "@report", Value = financialReportXml }  
            };

            sq.Database.ExecuteSqlRaw(sql, parms.ToArray());
            financialReport.Analytes = sq.StatementAnalytes.Where(a => a.Report.No == financialReport.No).ToList();

            return financialReport;
        }

        [UseDbContext(typeof(StocksQuery))]
        public Company CreateCompany([ScopedService]StocksQuery sq, Company company, HotChocolate.Types.IFile file)
        {
            using (var ms = new System.IO.MemoryStream()) 
            {
                file.CopyToAsync(ms);
                var bytes = ms.ToArray();

                company.Files.Add(new FileContent{
                    Type = FileContent.FileType.Logo,
                    FileName = file.Name,
                    Created = DateTime.Now,
                    Content = bytes,
                    ContentSize = bytes.Length
                });
            }

            string sql = "EXEC [dbo].[CreateCompany] @company";
            
            string companyXml = SerializationHelper.Serialize<Company>(company);
            List<SqlParameter> parms = new List<SqlParameter>
            { 
                // Update parameters
                new SqlParameter { ParameterName = "@company", Value = companyXml }  
            };

            sq.Database.ExecuteSqlRaw(sql, parms.ToArray());

            return company;
        }

        [UseDbContext(typeof(StocksQuery))]
        public Company UpdateCompany([ScopedService]StocksQuery sq, Company company, HotChocolate.Types.IFile file)
        {
            using (var ms = new System.IO.MemoryStream()) 
            {
                file.CopyToAsync(ms);
                var bytes = ms.ToArray();

                company.Files = new List<FileContent>();
                company.Files.Add(new FileContent{
                    Type = FileContent.FileType.Logo,
                    FileName = file.Name,
                    Created = DateTime.Now,
                    Content = bytes,
                    ContentSize = bytes.Length
                });
            }

            //string sql = "EXEC [dbo].[UpdateCompany] @company";
            
            string companyXml = SerializationHelper.Serialize<Company>(company);
            // List<SqlParameter> parms = new List<SqlParameter>
            // { 
            //     // Update parameters
            //     new SqlParameter { ParameterName = "@company", Value = companyXml }  
            // };

            // sq.Database.ExecuteSqlRaw(sql, parms.ToArray());
            
            return company;
        }
    }
}