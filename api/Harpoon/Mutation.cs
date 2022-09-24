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
        #region Manage Financial Reports

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

        #endregion

        #region Manage Dividends

        [UseDbContext(typeof(StocksQuery))]
        public bool DeleteDividends([ScopedService]StocksQuery sq, long no)
        {
            bool result = false;

            try
            {
                string sql = "EXEC [dbo].[DeleteDividends] @no";
                
                List<SqlParameter> parms = new List<SqlParameter>
                { 
                    // Update parameters
                    new SqlParameter { ParameterName = "@no", Value = no }  
                };

                sq.Database.ExecuteSqlRaw(sql, parms.ToArray());

                result = true;
            } catch {}

            return result;
        }

        #endregion

        #region Manage Companies

        [UseDbContext(typeof(StocksQuery))]
        public Company CreateCompany([ScopedService]StocksQuery sq, Company company, HotChocolate.Types.IFile file)
        {
            if (file != null) 
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
            if (file != null) 
            {
                using (var ms = new System.IO.MemoryStream()) 
                {
                    file.CopyToAsync(ms);
                    var bytes = ms.ToArray();

                    if (company.Files != null && company.Files.Count() > 0) 
                    {
                        var logo = company.Files.Where(f => f.Type == FileContent.FileType.Logo).OrderByDescending(f => f.Created).First();

                        if (logo != null) 
                        {
                            logo.FileName = file.Name;
                            logo.Content = bytes;
                            logo.ContentSize= bytes.Length;
                            logo.ContentType = GetContentType(file.Name);
                            logo.Created = DateTime.Now;
                        }
                        else
                        {
                            logo = new FileContent {
                                Type = FileContent.FileType.Logo,
                                FileName = file.Name,
                                Created = DateTime.Now,
                                Content = bytes,
                                ContentSize = bytes.Length,
                                ContentType = GetContentType(file.Name)
                            };
                        }
                    } 
                    else 
                    {
                        company.Files = new List<FileContent>();
                        company.Files.Add(new FileContent {
                                Type = FileContent.FileType.Logo,
                                FileName = file.Name,
                                Created = DateTime.Now,
                                Content = bytes,
                                ContentSize = bytes.Length,
                                ContentType = GetContentType(file.Name)
                            });
                    }
                }
            }

            string sql = "EXEC [dbo].[UpdateCompany] @company";
            
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
        public bool DeleteCompany([ScopedService]StocksQuery sq, string companyCode)
        {
            bool result = false;

            try
            {
                string sql = "EXEC [dbo].[DeleteCompany] @companyCode";
                
                List<SqlParameter> parms = new List<SqlParameter>
                { 
                    // Update parameters
                    new SqlParameter { ParameterName = "@companyCode", Value = companyCode }  
                };

                sq.Database.ExecuteSqlRaw(sql, parms.ToArray());

                result = true;
            } catch {}

            return result;
        }

        #endregion

        #region Manage Stocks

        [UseDbContext(typeof(StocksQuery))]
        public Stock CreateStock([ScopedService]StocksQuery sq, Stock stock)
        {
            string sql = "EXEC [dbo].[CreateStock] @stock";
            
            string stockXml = SerializationHelper.Serialize<Stock>(stock);
            List<SqlParameter> parms = new List<SqlParameter>
            { 
                // Update parameters
                new SqlParameter { ParameterName = "@stock", Value = stockXml }  
            };

            sq.Database.ExecuteSqlRaw(sql, parms.ToArray());

            return stock;
        }

        [UseDbContext(typeof(StocksQuery))]
        public Stock UpdateStock([ScopedService]StocksQuery sq, Stock stock)
        {
            string sql = "EXEC [dbo].[UpdateStock] @stock";
            
            string stockXml = SerializationHelper.Serialize<Stock>(stock);
            List<SqlParameter> parms = new List<SqlParameter>
            { 
                // Update parameters
                new SqlParameter { ParameterName = "@stock", Value = stockXml }  
            };

            sq.Database.ExecuteSqlRaw(sql, parms.ToArray());

            return stock;
        }

        [UseDbContext(typeof(StocksQuery))]
        public bool DeleteStock([ScopedService]StocksQuery sq, string stockCode)
        {
            bool result = false;

            try
            {
                string sql = "EXEC [dbo].[DeleteStock] @stockCode";
                
                List<SqlParameter> parms = new List<SqlParameter>
                { 
                    // Update parameters
                    new SqlParameter { ParameterName = "@stockCode", Value = stockCode }  
                };

                sq.Database.ExecuteSqlRaw(sql, parms.ToArray());

                result = true;
            } catch {}

            return result;
        }

        #endregion

        #region Manage Markets

        [UseDbContext(typeof(StocksQuery))]
        public Market CreateMarket([ScopedService]StocksQuery sq, Market market)
        {
            string sql = "EXEC [dbo].[CreateMarket] @market";
            
            string stockXml = SerializationHelper.Serialize<Market>(market);
            List<SqlParameter> parms = new List<SqlParameter>
            { 
                // Update parameters
                new SqlParameter { ParameterName = "@market", Value = stockXml }  
            };

            sq.Database.ExecuteSqlRaw(sql, parms.ToArray());

            return market;
        }

        [UseDbContext(typeof(StocksQuery))]
        public Market UpdateMarket([ScopedService]StocksQuery sq, Market market)
        {
            string sql = "EXEC [dbo].[UpdateMarket] @market";
            
            string stockXml = SerializationHelper.Serialize<Market>(market);
            List<SqlParameter> parms = new List<SqlParameter>
            { 
                // Update parameters
                new SqlParameter { ParameterName = "@market", Value = stockXml }  
            };

            sq.Database.ExecuteSqlRaw(sql, parms.ToArray());

            return market;
        }

        [UseDbContext(typeof(StocksQuery))]
        public bool DeleteMarket([ScopedService]StocksQuery sq, string marketCode)
        {
            bool result = false;

            try
            {
                string sql = "EXEC [dbo].[DeleteMarket] @marketCode";
                
                List<SqlParameter> parms = new List<SqlParameter>
                { 
                    // Update parameters
                    new SqlParameter { ParameterName = "@marketCode", Value = marketCode }  
                };

                sq.Database.ExecuteSqlRaw(sql, parms.ToArray());

                result = true;
            } catch {}

            return result;
        }

        #endregion

        #region Market Index

        [UseDbContext(typeof(StocksQuery))]
        public bool DeleteMarketIndex([ScopedService]StocksQuery sq, long no)
        {
            bool result = false;

            try
            {
                string sql = "EXEC [dbo].[DeleteMarketIndex] @no";
                
                List<SqlParameter> parms = new List<SqlParameter>
                { 
                    // Update parameters
                    new SqlParameter { ParameterName = "@no", Value = no }  
                };

                sq.Database.ExecuteSqlRaw(sql, parms.ToArray());

                result = true;
            } catch {}

            return result;
        }

        #endregion

        #region Industries

        [UseDbContext(typeof(StocksQuery))]
        public bool DeleteIndustries([ScopedService]StocksQuery sq, long no)
        {
            bool result = false;

            try
            {
                string sql = "EXEC [dbo].[DeleteIndustry] @no";
                
                List<SqlParameter> parms = new List<SqlParameter>
                { 
                    // Update parameters
                    new SqlParameter { ParameterName = "@no", Value = no }  
                };

                sq.Database.ExecuteSqlRaw(sql, parms.ToArray());

                result = true;
            } catch {}

            return result;
        }

        #endregion

        // Credit: https://stackoverflow.com/questions/34131326/using-mimemapping-in-asp-net-core
        // See also https://www.garykessler.net/library/file_sigs.html
        private string GetContentType(string fileName)
        {
            string contentType;
            new Microsoft.AspNetCore.StaticFiles.FileExtensionContentTypeProvider().TryGetContentType(fileName, out contentType);
            return contentType ?? "application/octet-stream";
        }
    }
}