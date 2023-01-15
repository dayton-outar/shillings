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
        public string GetToken([Service] IdentityService ids, string email, string password) => ids.Authenticate(email, password);

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
                financialReport.No =  Convert.ToInt64(param.Value);
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
        public bool DeleteFinancialReport([ScopedService]StocksQuery sq, long no)
        {
            bool result = false;

            try
            {
                string sql = "EXEC [dbo].[DeleteFinancialReport] @no";
                
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

        #region Manage Interest Rates

        [UseDbContext(typeof(StocksQuery))]
        public InterestRate CreateInterestRate([ScopedService]StocksQuery sq, InterestRate rate)
        {
            string sql = "EXEC [dbo].[CreateInterestRate] @rate, @no OUTPUT";
            
            string rateXml = SerializationHelper.Serialize<InterestRate>(rate);
            List<SqlParameter> parms = new List<SqlParameter>
            { 
                // Update parameters
                new SqlParameter { ParameterName = "@rate", Value = rateXml },
                new SqlParameter { ParameterName = "@no", SqlDbType = SqlDbType.BigInt, Direction = ParameterDirection.Output }
            };

            sq.Database.ExecuteSqlRaw(sql, parms.ToArray());

            var param = parms.Where(p => p.ParameterName == "@no").First();
            if (param.Value != null)
            {
                rate.No =  Convert.ToInt64(param.Value);
            }

            return rate;
        }

        [UseDbContext(typeof(StocksQuery))]
        public InterestRate UpdateInterestRate([ScopedService]StocksQuery sq, InterestRate rate)
        {
            string sql = "EXEC [dbo].[UpdateInterestRate] @rate";
            
            string rateXml = SerializationHelper.Serialize<InterestRate>(rate);
            List<SqlParameter> parms = new List<SqlParameter>
            { 
                // Update parameters
                new SqlParameter { ParameterName = "@rate", Value = rateXml }  
            };

            sq.Database.ExecuteSqlRaw(sql, parms.ToArray());

            return rate;
        }

        [UseDbContext(typeof(StocksQuery))]
        public bool DeleteInterestRate([ScopedService]StocksQuery sq, long no)
        {
            bool result = false;

            try
            {
                string sql = "EXEC [dbo].[DeleteInterestRate] @no";
                
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

        #region Manage Dividends

        [UseDbContext(typeof(StocksQuery))]
        public Dividend CreateDividends([ScopedService]StocksQuery sq, Dividend dividend)
        {
            string sql = "EXEC [dbo].[CreateDividends] @dividends, @no OUTPUT";
            
            string dividendsXml = SerializationHelper.Serialize<Dividend>(dividend);
            List<SqlParameter> parms = new List<SqlParameter>
            { 
                // Update parameters
                new SqlParameter { ParameterName = "@dividends", Value = dividendsXml },
                new SqlParameter { ParameterName = "@no", SqlDbType = SqlDbType.BigInt, Direction = ParameterDirection.Output }
            };

            sq.Database.ExecuteSqlRaw(sql, parms.ToArray());

            var param = parms.Where(p => p.ParameterName == "@no").First();
            if (param.Value != null)
            {
                dividend.No =  Convert.ToInt64(param.Value);
            }

            return dividend;
        }

        [UseDbContext(typeof(StocksQuery))]
        public Dividend UpdateDividends([ScopedService]StocksQuery sq, Dividend dividend)
        {
            string sql = "EXEC [dbo].[UpdateDividends] @dividends";
            
            string dividendsXml = SerializationHelper.Serialize<Dividend>(dividend);
            List<SqlParameter> parms = new List<SqlParameter>
            { 
                // Update parameters
                new SqlParameter { ParameterName = "@dividends", Value = dividendsXml }  
            };

            sq.Database.ExecuteSqlRaw(sql, parms.ToArray());

            return dividend;
        }

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
                        Content = bytes,
                        ContentSize = bytes.Length,
                        ContentType = GetContentType(file.Name),
                        Created = DateTime.Now
                    });
                }
            }

            string sql = "EXEC [dbo].[CreateCompany] @company";
            
            string companyXml = SerializationHelper.Serialize<Company>(company);
            List<SqlParameter> parms = new List<SqlParameter>
            { 
                // Create parameters
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
            string sql = "EXEC [dbo].[CreateStock] @stock, @no OUTPUT";
            
            string stockXml = SerializationHelper.Serialize<Stock>(stock);
            List<SqlParameter> parms = new List<SqlParameter>
            { 
                // Create parameters
                new SqlParameter { ParameterName = "@stock", Value = stockXml },
                new SqlParameter { ParameterName = "@no", SqlDbType = SqlDbType.BigInt, Direction = ParameterDirection.Output }
            };

            sq.Database.ExecuteSqlRaw(sql, parms.ToArray());

            var param = parms.Where(p => p.ParameterName == "@no").First();
            if (param.Value != null)
            {
                stock.No =  Convert.ToInt64(param.Value);
            }

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
        public bool DeleteStock([ScopedService]StocksQuery sq, long stockNo)
        {
            bool result = false;

            try
            {
                string sql = "EXEC [dbo].[DeleteStock] @stockNo";
                
                List<SqlParameter> parms = new List<SqlParameter>
                { 
                    // Update parameters
                    new SqlParameter { ParameterName = "@stockNo", Value = stockNo }  
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
            string sql = "EXEC [dbo].[CreateMarket] @market, @no OUTPUT";
            
            string marketXml = SerializationHelper.Serialize<Market>(market);
            List<SqlParameter> parms = new List<SqlParameter>
            { 
                // Create parameters
                new SqlParameter { ParameterName = "@market", Value = marketXml },
                new SqlParameter { ParameterName = "@no", SqlDbType = SqlDbType.BigInt, Direction = ParameterDirection.Output }
            };

            sq.Database.ExecuteSqlRaw(sql, parms.ToArray());

            var param = parms.Where(p => p.ParameterName == "@no").First();
            if (param.Value != null)
            {
                market.No =  Convert.ToInt64(param.Value);
            }

            return market;
        }

        [UseDbContext(typeof(StocksQuery))]
        public Market UpdateMarket([ScopedService]StocksQuery sq, Market market)
        {
            string sql = "EXEC [dbo].[UpdateMarket] @market";
            
            string marketXml = SerializationHelper.Serialize<Market>(market);
            List<SqlParameter> parms = new List<SqlParameter>
            { 
                // Update parameters
                new SqlParameter { ParameterName = "@market", Value = marketXml }  
            };

            sq.Database.ExecuteSqlRaw(sql, parms.ToArray());

            return market;
        }

        [UseDbContext(typeof(StocksQuery))]
        public bool DeleteMarket([ScopedService]StocksQuery sq, long marketNo)
        {
            bool result = false;

            try
            {
                string sql = "EXEC [dbo].[DeleteMarket] @marketNo";
                
                List<SqlParameter> parms = new List<SqlParameter>
                { 
                    // Update parameters
                    new SqlParameter { ParameterName = "@marketNo", Value = marketNo }  
                };

                sq.Database.ExecuteSqlRaw(sql, parms.ToArray());

                result = true;
            } catch {}

            return result;
        }

        #endregion

        #region Manage Market Index

        [UseDbContext(typeof(StocksQuery))]
        public MarketIndex CreateMarketIndex([ScopedService]StocksQuery sq, MarketIndex marketIndex)
        {
            string sql = "EXEC [dbo].[CreateMarketIndex] @marketIndex, @no OUTPUT";
            
            string marketIndexXml = SerializationHelper.Serialize<MarketIndex>(marketIndex);
            List<SqlParameter> parms = new List<SqlParameter>
            { 
                // Create parameters
                new SqlParameter { ParameterName = "@marketIndex", Value = marketIndexXml },
                new SqlParameter { ParameterName = "@no", SqlDbType = SqlDbType.BigInt, Direction = ParameterDirection.Output }
            };

            sq.Database.ExecuteSqlRaw(sql, parms.ToArray());

            var param = parms.Where(p => p.ParameterName == "@no").First();
            if (param.Value != null)
            {
                marketIndex.No =  Convert.ToInt64(param.Value);
            }

            return marketIndex;
        }

        [UseDbContext(typeof(StocksQuery))]
        public MarketIndex UpdateMarketIndex([ScopedService]StocksQuery sq, MarketIndex marketIndex)
        {
            string sql = "EXEC [dbo].[UpdateMarketIndex] @marketIndex";
            
            string marketIndexXml = SerializationHelper.Serialize<MarketIndex>(marketIndex);
            List<SqlParameter> parms = new List<SqlParameter>
            { 
                // Update parameters
                new SqlParameter { ParameterName = "@marketIndex", Value = marketIndexXml }  
            };

            sq.Database.ExecuteSqlRaw(sql, parms.ToArray());

            return marketIndex;
        }

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

        #region Manage Stock Index

        [UseDbContext(typeof(StocksQuery))]
        public StockIndex CreateStockIndex([ScopedService]StocksQuery sq, StockIndex stockIndex)
        {
            string sql = "EXEC [dbo].[CreateStockIndex] @stockIndex, @no OUTPUT";
            
            string stockIndexXml = SerializationHelper.Serialize<StockIndex>(stockIndex);
            List<SqlParameter> parms = new List<SqlParameter>
            { 
                // Create parameters
                new SqlParameter { ParameterName = "@stockIndex", Value = stockIndexXml },
                new SqlParameter { ParameterName = "@no", SqlDbType = SqlDbType.BigInt, Direction = ParameterDirection.Output }
            };

            sq.Database.ExecuteSqlRaw(sql, parms.ToArray());

            var param = parms.Where(p => p.ParameterName == "@no").First();
            if (param.Value != null)
            {
                stockIndex.No =  Convert.ToInt64(param.Value);
            }

            return stockIndex;
        }

        [UseDbContext(typeof(StocksQuery))]
        public StockIndex UpdateStockIndex([ScopedService]StocksQuery sq, StockIndex stockIndex)
        {
            string sql = "EXEC [dbo].[UpdateStockIndex] @stockIndex";
            
            string marketIndexXml = SerializationHelper.Serialize<StockIndex>(stockIndex);
            List<SqlParameter> parms = new List<SqlParameter>
            { 
                // Update parameters
                new SqlParameter { ParameterName = "@stockIndex", Value = marketIndexXml }  
            };

            sq.Database.ExecuteSqlRaw(sql, parms.ToArray());

            return stockIndex;
        }

        [UseDbContext(typeof(StocksQuery))]
        public bool DeleteStockIndex([ScopedService]StocksQuery sq, long no)
        {
            bool result = false;

            try
            {
                string sql = "EXEC [dbo].[DeleteStockIndex] @no";
                
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

        #region Manage Industries

        [UseDbContext(typeof(StocksQuery))]
        public Industry CreateIndustry([ScopedService]StocksQuery sq, Industry industry)
        {
            string sql = "EXEC [dbo].[CreateIndustry] @industry, @no OUTPUT";
            
            string industryXml = SerializationHelper.Serialize<Industry>(industry);
            List<SqlParameter> parms = new List<SqlParameter>
            { 
                // Create parameters
                new SqlParameter { ParameterName = "@industry", Value = industryXml },
                new SqlParameter { ParameterName = "@no", SqlDbType = SqlDbType.BigInt, Direction = ParameterDirection.Output }
            };

            sq.Database.ExecuteSqlRaw(sql, parms.ToArray());

            var param = parms.Where(p => p.ParameterName == "@no").First();
            if (param.Value != null)
            {
                industry.No =  Convert.ToInt64(param.Value);
            }

            return industry;
        }

        [UseDbContext(typeof(StocksQuery))]
        public Industry UpdateIndustry([ScopedService]StocksQuery sq, Industry industry)
        {
            string sql = "EXEC [dbo].[UpdateIndustry] @industry";
            
            string industryXml = SerializationHelper.Serialize<Industry>(industry);
            List<SqlParameter> parms = new List<SqlParameter>
            { 
                // Update parameters
                new SqlParameter { ParameterName = "@industry", Value = industryXml }  
            };

            sq.Database.ExecuteSqlRaw(sql, parms.ToArray());

            return industry;
        }

        [UseDbContext(typeof(StocksQuery))]
        public bool DeleteIndustry([ScopedService]StocksQuery sq, long no)
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

        #region Helpers

        // Credit: https://stackoverflow.com/questions/34131326/using-mimemapping-in-asp-net-core
        // See also https://www.garykessler.net/library/file_sigs.html
        private string GetContentType(string fileName)
        {
            string contentType;
            new Microsoft.AspNetCore.StaticFiles.FileExtensionContentTypeProvider().TryGetContentType(fileName, out contentType);
            return contentType ?? "application/octet-stream";
        }

        #endregion
    }
}