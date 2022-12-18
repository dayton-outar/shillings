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
        public IQueryable<StockTrading> GetStockTradings([ScopedService]StocksQuery sq) => sq.StockTradings.Include(t => t.Stock);

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
        public IQueryable<Company> GetCompanies([ScopedService]StocksQuery sq) => sq.Companies.Include(c => c.Files);

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

        [UseDbContext(typeof(StocksQuery))]
        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<InterestRate> GetInterestRates([ScopedService]StocksQuery sq) => sq.InterestRates;

        [UseDbContext(typeof(StocksQuery))]
        [UseProjection]
        [UseSorting]
        public IQueryable<ReportedEarnings> GetReportedEarnings(FinancialReport.Periodical period, System.DateTime begin, System.DateTime end, [ScopedService]StocksQuery sq) => sq.Earnings.FromSqlInterpolated($"SELECT * FROM [dbo].[Earnings]({period}, {begin.Date}, {end.Date})").AsQueryable();

        [UseDbContext(typeof(StocksQuery))]
        [UseProjection]
        [UseSorting]
        public IQueryable<Solvency> GetSolvencies(FinancialReport.Periodical period, System.DateTime begin, System.DateTime end, [ScopedService]StocksQuery sq) => sq.Solvencies.FromSqlInterpolated($"SELECT * FROM [dbo].[Solvency]({period}, {begin.Date}, {end.Date})").AsQueryable();

        public Dependencies GetDependencies() {
            var dependencies = new Dependencies();

            dependencies.Sectionals = new List<StatementSectional> {
                new StatementSectional {
                    Type = StatementAnalyte.StatementType.Income,
                    Sections = new List<StatementAnalyte.Sectional> { 
                            StatementAnalyte.Sectional.Revenues,
                            StatementAnalyte.Sectional.Expenses,
                            StatementAnalyte.Sectional.Gains,
                            StatementAnalyte.Sectional.Losses,
                            StatementAnalyte.Sectional.ProfitShare,
                            StatementAnalyte.Sectional.EarningsPerStock,
                            StatementAnalyte.Sectional.SharesOutstanding
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
                            StatementAnalyte.Sectional.None
                        }
                }
            };

            dependencies.Assays = new List<SectionalAnalytes> {
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
                // Inspired by Coca-Cola financial statements
                new SectionalAnalytes {
                    Sectional = StatementAnalyte.Sectional.SharesOutstanding,
                    Assay = new List<StatementAnalyte.Assay> {
                            StatementAnalyte.Assay.Note
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
                            StatementAnalyte.Assay.Intangible
                        }
                },
                new SectionalAnalytes {
                    Sectional = StatementAnalyte.Sectional.Liabilities,
                    Assay = new List<StatementAnalyte.Assay> {
                            StatementAnalyte.Assay.Current,
                            StatementAnalyte.Assay.Loan,
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
                // Credit(s): https://www.investopedia.com/investing/what-is-a-cash-flow-statement/
                // The operating activities on the CFS include any sources and uses of cash from business activities.
                new SectionalAnalytes {
                    Sectional = StatementAnalyte.Sectional.OperatingActivities,
                    Assay = new List<StatementAnalyte.Assay> {
                            StatementAnalyte.Assay.Operating,
                            StatementAnalyte.Assay.Adjustments,
                            StatementAnalyte.Assay.Receivables,
                            StatementAnalyte.Assay.Inventories,
                            StatementAnalyte.Assay.Depreciation,
                            StatementAnalyte.Assay.Impairment,
                            StatementAnalyte.Assay.Payables,
                            StatementAnalyte.Assay.Interest,
                            StatementAnalyte.Assay.Wages,
                            StatementAnalyte.Assay.Tax
                        }
                },                
                // Cash from financing activities includes the sources of cash from investors and banks, as well as the way cash is paid to shareholders.
                // How is the business financed?
                new SectionalAnalytes {
                    Sectional = StatementAnalyte.Sectional.FinancingActivities,
                    Assay = new List<StatementAnalyte.Assay> {
                            StatementAnalyte.Assay.Loan,
                            StatementAnalyte.Assay.Shares,
                            StatementAnalyte.Assay.Dividends,
                            // Classifies treasury shares from common shares
                            StatementAnalyte.Assay.Treasury,
                            // Classifies dividends pay out
                            StatementAnalyte.Assay.Shareholders,
                            // Classifies dividends pay out
                            StatementAnalyte.Assay.NonControlling,
                            // Classifies loans that are non-financial
                            // StatementAnalyte.Assay.Bondholders
                        }
                },
                // Investing activities include any sources and uses of cash from a company’s investments.
                // What does the business invest it's money?
                new SectionalAnalytes {
                    Sectional = StatementAnalyte.Sectional.InvestingActivities,
                    Assay = new List<StatementAnalyte.Assay> {
                            StatementAnalyte.Assay.Capital,
                            StatementAnalyte.Assay.Intangible,
                            StatementAnalyte.Assay.Interest
                        }
                },
                new SectionalAnalytes {
                    Sectional = StatementAnalyte.Sectional.None,
                    Assay = new List<StatementAnalyte.Assay> {
                            StatementAnalyte.Assay.ExchangeRateChanges
                        }
                }
            };

            return dependencies;
        }
    }
}