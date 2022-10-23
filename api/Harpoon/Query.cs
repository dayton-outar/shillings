using System.Linq;
using System.Collections.Generic;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;

using O8Query.Models;
using O8Query.Data;

namespace Harpoon
{
    public class Query
    {
        [UseDbContext(typeof(StocksQuery))]
        [UsePaging(DefaultPageSize = 50)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<StockTrading> GetStockTradings([ScopedService]StocksQuery sq) => sq.StockTradings.Include(t => t.Security);

        [UseDbContext(typeof(StocksQuery))]
        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Dividend> GetDividends([ScopedService]StocksQuery sq) => sq.Dividends;

        [UseDbContext(typeof(StocksQuery))]
        [UseProjection]
        [UseSorting]
        public IQueryable<TotalStockTrades> GetTotalTrades(string companyCode, System.DateTime begin, System.DateTime end, [ScopedService]StocksQuery sq) => sq.TotalTrades.FromSqlInterpolated($"SELECT * FROM [dbo].[TotalStocksTraded]({companyCode}, {begin.Date}, {end.Date})").AsQueryable();

        [UseDbContext(typeof(StocksQuery))]
        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Market> GetMarkets([ScopedService]StocksQuery sq) => sq.Markets;

        [UseDbContext(typeof(StocksQuery))]
        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<MarketIndex> GetMarketIndices([ScopedService]StocksQuery sq) => sq.MarketIndices;

        [UseDbContext(typeof(StocksQuery))]
        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<StockIndex> GetStockIndices([ScopedService]StocksQuery sq) => sq.StockIndices;

        [UseDbContext(typeof(StocksQuery))]
        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Company> GetCompanies([ScopedService]StocksQuery sq) => sq.Companies.Include(c => c.Files).Include(c => c.Stocks);

        [UseDbContext(typeof(StocksQuery))]
        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Industry> GetIndustries([ScopedService]StocksQuery sq) => sq.Industries;

        [UseDbContext(typeof(StocksQuery))]
        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Stock> GetStocks([ScopedService]StocksQuery sq) => sq.Stocks.Include(s => s.Indices);

        [UseDbContext(typeof(StocksQuery))]
        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<FinancialReport> GetFinancialReports([ScopedService]StocksQuery sq) => sq.FinancialReports;

        public List<StatementSectional> GetSectionals() {
            return new List<StatementSectional> {
                new StatementSectional {
                    Type = StatementAnalyte.StatementType.Income,
                    Sections = new List<StatementAnalyte.Sectional> { 
                            StatementAnalyte.Sectional.Revenues,
                            StatementAnalyte.Sectional.Expenses,
                            StatementAnalyte.Sectional.Gains,
                            StatementAnalyte.Sectional.Losses,
                            StatementAnalyte.Sectional.ProfitShare,
                            StatementAnalyte.Sectional.EarningsPerStock
                        }
                },
                new StatementSectional {
                    Type = StatementAnalyte.StatementType.FinancialPosition,
                    Sections = new List<StatementAnalyte.Sectional> { 
                            StatementAnalyte.Sectional.Assets,
                            StatementAnalyte.Sectional.Liabilities,
                            StatementAnalyte.Sectional.Equity
                        }
                },
                new StatementSectional {
                    Type = StatementAnalyte.StatementType.CashFlow,
                    Sections = new List<StatementAnalyte.Sectional> { 
                            StatementAnalyte.Sectional.OperatingActivities,
                            StatementAnalyte.Sectional.FinancingActivities,
                            StatementAnalyte.Sectional.InvestingActivities,
                        }
                }
            };
        }

        public List<SectionalAnalytes> GetAssays() {
            return new List<SectionalAnalytes> {
                new SectionalAnalytes {
                    Sectional = StatementAnalyte.Sectional.Revenues,
                    Assay = new List<StatementAnalyte.Assay> { 
                            StatementAnalyte.Assay.Operating,
                            StatementAnalyte.Assay.Interest
                        }
                },
                new SectionalAnalytes {
                    Sectional = StatementAnalyte.Sectional.Expenses,
                    Assay = new List<StatementAnalyte.Assay> { 
                            StatementAnalyte.Assay.Direct,
                            StatementAnalyte.Assay.Operating,
                            StatementAnalyte.Assay.Interest,
                            StatementAnalyte.Assay.Tax
                        }
                },
                new SectionalAnalytes {
                    Sectional = StatementAnalyte.Sectional.Gains,
                    Assay = new List<StatementAnalyte.Assay> { 
                            StatementAnalyte.Assay.Interest,
                            StatementAnalyte.Assay.Investment,
                            StatementAnalyte.Assay.Other
                        }
                },
                new SectionalAnalytes {
                    Sectional = StatementAnalyte.Sectional.Losses,
                    Assay = new List<StatementAnalyte.Assay> {
                            StatementAnalyte.Assay.Interest,
                            StatementAnalyte.Assay.Impairment
                        }
                },
                new SectionalAnalytes {
                    Sectional = StatementAnalyte.Sectional.ProfitShare,
                    Assay = new List<StatementAnalyte.Assay> {
                            StatementAnalyte.Assay.Shareholders,
                            StatementAnalyte.Assay.NonControlling
                        }
                },
                new SectionalAnalytes {
                    Sectional = StatementAnalyte.Sectional.EarningsPerStock,
                    Assay = new List<StatementAnalyte.Assay> {
                            StatementAnalyte.Assay.Basic,
                            StatementAnalyte.Assay.Diluted
                        }
                },
                new SectionalAnalytes {
                    Sectional = StatementAnalyte.Sectional.Assets,
                    Assay = new List<StatementAnalyte.Assay> {
                            StatementAnalyte.Assay.Current,
                            StatementAnalyte.Assay.Cash,
                            StatementAnalyte.Assay.Inventories,
                            StatementAnalyte.Assay.Fixed,
                            StatementAnalyte.Assay.Receivables,
                            StatementAnalyte.Assay.Intagible
                        }
                },
                new SectionalAnalytes {
                    Sectional = StatementAnalyte.Sectional.Liabilities,
                    Assay = new List<StatementAnalyte.Assay> {
                            StatementAnalyte.Assay.Current,
                            StatementAnalyte.Assay.Debt,
                            StatementAnalyte.Assay.Fixed,
                            StatementAnalyte.Assay.Payables
                        }
                },
                new SectionalAnalytes {
                    Sectional = StatementAnalyte.Sectional.Equity,
                    Assay = new List<StatementAnalyte.Assay> {
                            StatementAnalyte.Assay.Capital,
                            StatementAnalyte.Assay.Reserves,
                            StatementAnalyte.Assay.Retained,
                            StatementAnalyte.Assay.NonControlling
                        }
                },
                new SectionalAnalytes {
                    Sectional = StatementAnalyte.Sectional.OperatingActivities,
                    Assay = new List<StatementAnalyte.Assay> {
                            StatementAnalyte.Assay.Operating
                        }
                },
                new SectionalAnalytes {
                    Sectional = StatementAnalyte.Sectional.FinancingActivities,
                    Assay = new List<StatementAnalyte.Assay> {
                            StatementAnalyte.Assay.Capital
                        }
                },
                new SectionalAnalytes {
                    Sectional = StatementAnalyte.Sectional.InvestingActivities,
                    Assay = new List<StatementAnalyte.Assay> {
                            StatementAnalyte.Assay.Investment
                        }
                }
            };
        }
    }
}