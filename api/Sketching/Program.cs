using System;
using System.Linq;
using System.Collections.Generic;
using O8Query.Models;

namespace Sketching
{
    class Program
    {
        static void Main(string[] args)
        {
            var reportAnalytes = new List<StatementAnalyte>();
            //--
            reportAnalytes.Add(new StatementAnalyte{
                Sequence = 1,
                Description = "Revenue from products and services",
                Type = StatementAnalyte.StatementType.IncomeExpense,
                Section = StatementAnalyte.Sectional.Income,
                Analyte = StatementAnalyte.Assay.Revenue,
                Amount = 111064222.00m
            });
            
            reportAnalytes.Add(new StatementAnalyte{
                Sequence = 2,
                Description = "Interest revenue",
                Type = StatementAnalyte.StatementType.IncomeExpense,
                Section = StatementAnalyte.Sectional.Income,
                Analyte = StatementAnalyte.Assay.Interest | StatementAnalyte.Assay.Revenue,
                Amount = 4373119.00m
            });

            reportAnalytes.Add(new StatementAnalyte{
                Sequence = 3,
                Description = "Total Revenue",
                Type = StatementAnalyte.StatementType.IncomeExpense,
                Section = StatementAnalyte.Sectional.Income,
                Analyte = StatementAnalyte.Assay.Total | StatementAnalyte.Assay.Revenue,
                Amount = 115437341000.00m
            });

            reportAnalytes.Add(new StatementAnalyte{
                Sequence = 4,
                Description = "Direct and operating expenses",
                Type = StatementAnalyte.StatementType.IncomeExpense,
                Section = StatementAnalyte.Sectional.Income,
                Analyte = StatementAnalyte.Assay.DirectExpense | StatementAnalyte.Assay.OperatingExpense,
                Amount = 108109929000.00m
            });

            reportAnalytes.Add(new StatementAnalyte{
                Sequence = 5,
                Description = "Net impairment losses on financial assets",
                Type = StatementAnalyte.StatementType.IncomeExpense,
                Section = StatementAnalyte.Sectional.Income,
                Analyte = StatementAnalyte.Assay.Expense,
                Amount = 523486000.00m
            });

            reportAnalytes.Add(new StatementAnalyte{
                Sequence = 6,
                Description = "Expenses",
                Type = StatementAnalyte.StatementType.IncomeExpense,
                Section = StatementAnalyte.Sectional.Income,
                Analyte = StatementAnalyte.Assay.Expense,
                Amount = 108633415000.00m
            });

            reportAnalytes.Add(new StatementAnalyte{
                Sequence = 7,
                Description = "Profit before Other income",
                Type = StatementAnalyte.StatementType.IncomeExpense,
                Section = StatementAnalyte.Sectional.Income,
                Analyte = StatementAnalyte.Assay.GrossProfit,
                Amount = 6803926000.00m
            });

            reportAnalytes.Add(new StatementAnalyte{
                Sequence = 8,
                Description = "Other income",
                Type = StatementAnalyte.StatementType.IncomeExpense,
                Section = StatementAnalyte.Sectional.Income,
                Analyte = StatementAnalyte.Assay.Income,
                Amount = 3024608000.00m
            });

            reportAnalytes.Add(new StatementAnalyte{
                Sequence = 9,
                Description = "Interest income - non-financial services",
                Type = StatementAnalyte.StatementType.IncomeExpense,
                Section = StatementAnalyte.Sectional.Income,
                Analyte = StatementAnalyte.Assay.Income,
                Amount = 467866000.00m
            });

            reportAnalytes.Add(new StatementAnalyte{
                Sequence = 10,
                Description = "Interest expense - non-financial services",
                Type = StatementAnalyte.StatementType.IncomeExpense,
                Section = StatementAnalyte.Sectional.Income,
                Analyte = StatementAnalyte.Assay.Expense,
                Amount = 467866000.00m
            });

            reportAnalytes.Add(new StatementAnalyte{
                Sequence = 11,
                Description = "Share of results of associates and joint ventures",
                Type = StatementAnalyte.StatementType.IncomeExpense,
                Section = StatementAnalyte.Sectional.Income,
                Analyte = StatementAnalyte.Assay.Income,
                Amount = 543532000.00m
            });

            reportAnalytes.Add(new StatementAnalyte{
                Sequence = 12,
                Description = "Profit before Tax",
                Type = StatementAnalyte.StatementType.IncomeExpense,
                Section = StatementAnalyte.Sectional.Income,
                Analyte = StatementAnalyte.Assay.ProfitBeforeTaxes,
                Amount = 543532000.00m
            });

            reportAnalytes.Add(new StatementAnalyte{
                Sequence = 13,
                Description = "Tax",
                Type = StatementAnalyte.StatementType.IncomeExpense,
                Section = StatementAnalyte.Sectional.Income,
                Analyte = StatementAnalyte.Assay.Expense | StatementAnalyte.Assay.Tax,
                Amount = 2852049000.00m
            });

            reportAnalytes.Add(new StatementAnalyte{
                Sequence = 14,
                Description = "Net Profit",
                Type = StatementAnalyte.StatementType.IncomeExpense,
                Section = StatementAnalyte.Sectional.Income,
                Analyte = StatementAnalyte.Assay.NetProfit,
                Amount = 6856926000.00m
            });

            reportAnalytes.Add(new StatementAnalyte{
                Sequence = 15,
                Description = "Owners of GraceKennedy Limited",
                Type = StatementAnalyte.StatementType.IncomeExpense,
                Section = StatementAnalyte.Sectional.ProfitAttributable,
                Analyte = StatementAnalyte.Assay.ShareholdersProfit,
                Amount = 6218055000.00m
            });

            reportAnalytes.Add(new StatementAnalyte{
                Sequence = 16,
                Description = "Non-controlling interests",
                Type = StatementAnalyte.StatementType.IncomeExpense,
                Section = StatementAnalyte.Sectional.ProfitAttributable,
                Analyte = StatementAnalyte.Assay.NonControllingInterestProfit,
                Amount = 638871000.00m
            });

            reportAnalytes.Add(new StatementAnalyte{
                Sequence = 17,
                Description = "Basic Earnings per Stock Unit",
                Type = StatementAnalyte.StatementType.IncomeExpense,
                Section = StatementAnalyte.Sectional.EarningsPerStock,
                Analyte = StatementAnalyte.Assay.BasicEarningsPerStock,
                Amount = 6.28m
            });
            //--

            reportAnalytes.Add(new StatementAnalyte{
                Sequence = 1,
                Description = "Cash and deposits",
                Type = StatementAnalyte.StatementType.FinancialPosition,
                Section = StatementAnalyte.Sectional.Assets,
                Analyte = StatementAnalyte.Assay.Assets | StatementAnalyte.Assay.CurrentAssets,
                Amount = 24331106000.00m
            });

            reportAnalytes.Add(new StatementAnalyte{
                Sequence = 2,
                Description = "Investment securities",
                Type = StatementAnalyte.StatementType.FinancialPosition,
                Section = StatementAnalyte.Sectional.Assets,
                Analyte = StatementAnalyte.Assay.Assets | StatementAnalyte.Assay.CurrentAssets,
                Amount = 33513948000.00m
            });

            reportAnalytes.Add(new StatementAnalyte{
                Sequence = 3,
                Description = "Pledged assets",
                Type = StatementAnalyte.StatementType.FinancialPosition,
                Section = StatementAnalyte.Sectional.Assets,
                Analyte = StatementAnalyte.Assay.Assets | StatementAnalyte.Assay.CurrentAssets,
                Amount = 7610387000.00m
            });

            reportAnalytes.Add(new StatementAnalyte{
                Sequence = 4,
                Description = "Receivales",
                Type = StatementAnalyte.StatementType.FinancialPosition,
                Section = StatementAnalyte.Sectional.Assets,
                Analyte = StatementAnalyte.Assay.Assets | StatementAnalyte.Assay.CurrentAssets,
                Amount = 16871439000.00m
            });

            reportAnalytes.Add(new StatementAnalyte{
                Sequence = 5,
                Description = "Inventories",
                Type = StatementAnalyte.StatementType.FinancialPosition,
                Section = StatementAnalyte.Sectional.Assets,
                Analyte = StatementAnalyte.Assay.Assets | StatementAnalyte.Assay.Inventories,
                Amount = 14433135000.00m
            });

            reportAnalytes.Add(new StatementAnalyte{
                Sequence = 6,
                Description = "Loans receivables",
                Type = StatementAnalyte.StatementType.FinancialPosition,
                Section = StatementAnalyte.Sectional.Assets,
                Analyte = StatementAnalyte.Assay.Assets | StatementAnalyte.Assay.FixedAssets,
                Amount = 31250331000.00m
            });

            reportAnalytes.Add(new StatementAnalyte{
                Sequence = 7,
                Description = "Tax recoverables",
                Type = StatementAnalyte.StatementType.FinancialPosition,
                Section = StatementAnalyte.Sectional.Assets,
                Analyte = StatementAnalyte.Assay.Assets | StatementAnalyte.Assay.FixedAssets,
                Amount = 767669000.00m
            });

            reportAnalytes.Add(new StatementAnalyte{
                Sequence = 8,
                Description = "Investments in associates and joint ventures",
                Type = StatementAnalyte.StatementType.FinancialPosition,
                Section = StatementAnalyte.Sectional.Assets,
                Analyte = StatementAnalyte.Assay.Assets | StatementAnalyte.Assay.FixedAssets,
                Amount = 4118824000.00m
            });

            reportAnalytes.Add(new StatementAnalyte{
                Sequence = 9,
                Description = "Investments properties",
                Type = StatementAnalyte.StatementType.FinancialPosition,
                Section = StatementAnalyte.Sectional.Assets,
                Analyte = StatementAnalyte.Assay.Assets | StatementAnalyte.Assay.FixedAssets,
                Amount = 925734000.00m
            });

            reportAnalytes.Add(new StatementAnalyte{
                Sequence = 10,
                Description = "Intangible assets",
                Type = StatementAnalyte.StatementType.FinancialPosition,
                Section = StatementAnalyte.Sectional.Assets,
                Analyte = StatementAnalyte.Assay.Assets | StatementAnalyte.Assay.Intagible,
                Amount = 4411466000.00m
            });

            reportAnalytes.Add(new StatementAnalyte{
                Sequence = 11,
                Description = "Fixed assets",
                Type = StatementAnalyte.StatementType.FinancialPosition,
                Section = StatementAnalyte.Sectional.Assets,
                Analyte = StatementAnalyte.Assay.Assets | StatementAnalyte.Assay.FixedAssets,
                Amount = 25560044000.00m
            });

            reportAnalytes.Add(new StatementAnalyte{
                Sequence = 12,
                Description = "Deferred tax assets",
                Type = StatementAnalyte.StatementType.FinancialPosition,
                Section = StatementAnalyte.Sectional.Assets,
                Analyte = StatementAnalyte.Assay.Assets | StatementAnalyte.Assay.FixedAssets,
                Amount = 1060528000.00m
            });

            reportAnalytes.Add(new StatementAnalyte{
                Sequence = 13,
                Description = "Penstion plan assets",
                Type = StatementAnalyte.StatementType.FinancialPosition,
                Section = StatementAnalyte.Sectional.Assets,
                Analyte = StatementAnalyte.Assay.Assets | StatementAnalyte.Assay.FixedAssets,
                Amount = 6841372000.00m
            });

            reportAnalytes.Add(new StatementAnalyte{
                Sequence = 14,
                Description = "Assets classified as held for sale",
                Type = StatementAnalyte.StatementType.FinancialPosition,
                Section = StatementAnalyte.Sectional.Assets,
                Analyte = StatementAnalyte.Assay.Assets | StatementAnalyte.Assay.FixedAssets,
                Amount = 0.00m
            });

            reportAnalytes.Add(new StatementAnalyte{
                Sequence = 15,
                Description = "Total Assets",
                Type = StatementAnalyte.StatementType.FinancialPosition,
                Section = StatementAnalyte.Sectional.Assets,
                Analyte = StatementAnalyte.Assay.Total | StatementAnalyte.Assay.Assets,
                Amount = 171695983000.00m
            });

            reportAnalytes.Add(new StatementAnalyte{
                Sequence = 16,
                Description = "Deposits",
                Type = StatementAnalyte.StatementType.FinancialPosition,
                Section = StatementAnalyte.Sectional.Liabilities,
                Analyte = StatementAnalyte.Assay.Liabilities | StatementAnalyte.Assay.CurrentLiabilities,
                Amount = 41611220000.00m
            });

            reportAnalytes.Add(new StatementAnalyte{
                Sequence = 17,
                Description = "Securities sold under agreements to repurchase",
                Type = StatementAnalyte.StatementType.FinancialPosition,
                Section = StatementAnalyte.Sectional.Liabilities,
                Analyte = StatementAnalyte.Assay.Liabilities | StatementAnalyte.Assay.CurrentLiabilities,
                Amount = 4968483000.00m
            });

            reportAnalytes.Add(new StatementAnalyte{
                Sequence = 18,
                Description = "Bank and other loans",
                Type = StatementAnalyte.StatementType.FinancialPosition,
                Section = StatementAnalyte.Sectional.Liabilities,
                Analyte = StatementAnalyte.Assay.Liabilities | StatementAnalyte.Assay.FixedLiabilities,
                Amount = 25233708000.00m
            });

            reportAnalytes.Add(new StatementAnalyte{
                Sequence = 19,
                Description = "Payables",
                Type = StatementAnalyte.StatementType.FinancialPosition,
                Section = StatementAnalyte.Sectional.Liabilities,
                Analyte = StatementAnalyte.Assay.Liabilities | StatementAnalyte.Assay.CurrentLiabilities,
                Amount = 28211841000.00m
            });

            reportAnalytes.Add(new StatementAnalyte{
                Sequence = 20,
                Description = "Tax",
                Type = StatementAnalyte.StatementType.FinancialPosition,
                Section = StatementAnalyte.Sectional.Liabilities,
                Analyte = StatementAnalyte.Assay.Liabilities | StatementAnalyte.Assay.CurrentLiabilities,
                Amount = 1077285000.00m
            });

            reportAnalytes.Add(new StatementAnalyte{
                Sequence = 21,
                Description = "Provisions",
                Type = StatementAnalyte.StatementType.FinancialPosition,
                Section = StatementAnalyte.Sectional.Liabilities,
                Analyte = StatementAnalyte.Assay.Liabilities | StatementAnalyte.Assay.CurrentLiabilities,
                Amount = 42602000.00m
            });

            reportAnalytes.Add(new StatementAnalyte{
                Sequence = 22,
                Description = "Deferred tax liabilities",
                Type = StatementAnalyte.StatementType.FinancialPosition,
                Section = StatementAnalyte.Sectional.Liabilities,
                Analyte = StatementAnalyte.Assay.Liabilities | StatementAnalyte.Assay.CurrentLiabilities,
                Amount = 1822238000.00m
            });

            reportAnalytes.Add(new StatementAnalyte{
                Sequence = 23,
                Description = "Other post-employment obligations",
                Type = StatementAnalyte.StatementType.FinancialPosition,
                Section = StatementAnalyte.Sectional.Liabilities,
                Analyte = StatementAnalyte.Assay.Liabilities | StatementAnalyte.Assay.CurrentLiabilities,
                Amount = 5949279000.00m
            });

            reportAnalytes.Add(new StatementAnalyte{
                Sequence = 24,
                Description = "Total Liabilities",
                Type = StatementAnalyte.StatementType.FinancialPosition,
                Section = StatementAnalyte.Sectional.Liabilities,
                Analyte = StatementAnalyte.Assay.Total | StatementAnalyte.Assay.Liabilities,
                Amount = 108916656000.00m
            });

            reportAnalytes.Add(new StatementAnalyte{
                Sequence = 25,
                Description = "Share capital",
                Type = StatementAnalyte.StatementType.FinancialPosition,
                Section = StatementAnalyte.Sectional.Equity,
                Analyte = StatementAnalyte.Assay.Equity,
                Amount = 305493000.00m
            });

            reportAnalytes.Add(new StatementAnalyte{
                Sequence = 26,
                Description = "Capital and fair value reserves",
                Type = StatementAnalyte.StatementType.FinancialPosition,
                Section = StatementAnalyte.Sectional.Equity,
                Analyte = StatementAnalyte.Assay.Equity,
                Amount = 7789066000.00m
            });

            reportAnalytes.Add(new StatementAnalyte{
                Sequence = 27,
                Description = "Retained earnings",
                Type = StatementAnalyte.StatementType.FinancialPosition,
                Section = StatementAnalyte.Sectional.Equity,
                Analyte = StatementAnalyte.Assay.Equity,
                Amount = 44096867000.00m
            });

            reportAnalytes.Add(new StatementAnalyte{
                Sequence = 28,
                Description = "Banking reserves",
                Type = StatementAnalyte.StatementType.FinancialPosition,
                Section = StatementAnalyte.Sectional.Equity,
                Analyte = StatementAnalyte.Assay.Equity,
                Amount = 3620711000.00m
            });

            reportAnalytes.Add(new StatementAnalyte{
                Sequence = 29,
                Description = "Other reserves",
                Type = StatementAnalyte.StatementType.FinancialPosition,
                Section = StatementAnalyte.Sectional.Equity,
                Analyte = StatementAnalyte.Assay.Equity,
                Amount = 4098122000.00m
            });

            reportAnalytes.Add(new StatementAnalyte{
                Sequence = 30,
                Description = "Non-Controlling interests",
                Type = StatementAnalyte.StatementType.FinancialPosition,
                Section = StatementAnalyte.Sectional.Equity,
                Analyte = StatementAnalyte.Assay.Equity | StatementAnalyte.Assay.NonControllingEquity,
                Amount = 2869068000.00m
            });

            reportAnalytes.Add(new StatementAnalyte{
                Sequence = 31,
                Description = "Total Equity",
                Type = StatementAnalyte.StatementType.FinancialPosition,
                Section = StatementAnalyte.Sectional.Equity,
                Analyte = StatementAnalyte.Assay.Total | StatementAnalyte.Assay.Equity,
                Amount = 62779327000.00m
            });

            //--
            var qr2021 = new FinancialReport
            {
                CompanyCode = "GK",
                Period = FinancialReport.Periodical.Annual,
                StatementDate = new DateTime(2020, 12, 30),
                IsAudited = false,
                Analytes = reportAnalytes,
            };


            Console.WriteLine("{0} {1} {2:dd MMMM, yyyy}{3}", qr2021.CompanyCode, qr2021.Period, qr2021.StatementDate, qr2021.IsAudited ? "" : " (Unaudited)");
            int padding = 80;
            Console.WriteLine(string.Empty.PadLeft(padding, '='));

            foreach(var item in qr2021.Analytes) 
            {
                if (item.Sequence == 1) {
                    Console.WriteLine();

                    switch (item.Type) 
                    {
                        case StatementAnalyte.StatementType.IncomeExpense:
                            Console.WriteLine("Statement of Income");
                            break;
                        case StatementAnalyte.StatementType.FinancialPosition:
                            Console.WriteLine("Statement of Financial Position");
                            break;
                    }

                    Console.WriteLine(string.Empty.PadLeft(padding, '-'));
                }
                
                Console.WriteLine("{0,2}. {1,-50} {2,20:c}", item.Sequence, item.Description, item.Amount);
            }

            Console.WriteLine(string.Empty.PadLeft(padding, '='));

            // Console.WriteLine();

            // var totalAssets = qr2021.Analytes.Where(a => a.Analyte.HasFlag(StatementAnalyte.Assay.Assets)).Sum(a => a.Amount);
            // Console.WriteLine("{0}: {1:c}", "Total Assets", totalAssets);

            // var totalLiabilities = qr2021.Analytes.Where(a => a.Analyte.HasFlag(StatementAnalyte.Assay.Liabilities)).Sum(a => a.Amount);
            // Console.WriteLine("{0}: {1:c}", "Total Liabilities", totalLiabilities);

            // var totalEquity = qr2021.Analytes.Where(a => a.Analyte.HasFlag(StatementAnalyte.Assay.Equity)).Sum(a => a.Amount);
            // Console.WriteLine("{0}: {1:c}", "Total Equity", totalEquity);

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine();
            Console.WriteLine("Financial Ratios");
            Console.WriteLine(string.Empty.PadLeft(padding, '='));

            // -- Profit Ratios

            // Gross Profit Margin
            var grossProfit = qr2021.Analytes.Where(a => a.Analyte.HasFlag(StatementAnalyte.Assay.GrossProfit)).Sum(a => a.Amount);
            var revenue = qr2021.Analytes.Where(a => a.Analyte.HasFlag(StatementAnalyte.Assay.Total | StatementAnalyte.Assay.Revenue)).First().Amount;
            var grossMargin = grossProfit / revenue;

            Console.WriteLine("{0,-20} {1,3:p}", "Gross Profit Margin:", grossMargin);
            Console.WriteLine();

            // Net Profit Margin
            var netProfit = qr2021.Analytes.Where(a => a.Analyte.HasFlag(StatementAnalyte.Assay.NetProfit)).Sum(a => a.Amount);
            var netMargin = netProfit / revenue;

            Console.WriteLine("{0,-20} {1,3:p}", "Net Profit Margin:", netMargin);
            Console.WriteLine();

            // Return on Equity: ROE
            var totalEquity = qr2021.Analytes.Where(a => a.Analyte.HasFlag(StatementAnalyte.Assay.Total | StatementAnalyte.Assay.Equity)).Sum(a => a.Amount);
            var roe = netProfit / totalEquity;
            Console.WriteLine("{0,-20} {1,3:p}", "Return on Equity:", roe);
            Console.WriteLine();

            // Return on Assets: ROA
            /// <summary>
            /// Since all assets are either funded by equity
            /// or debt, some investors try to disregard the
            /// costs of acquiring the assets in the return
            /// calculation by adding back interest ex-
            /// pense in the formula.
            /// </summary>
            /// <remarks>
            /// Credit: Financial Ratio Cheatsheet - MyAccountingCourse.com
            /// </remarks>
            var totalAssets = qr2021.Analytes.Where(a => a.Analyte.HasFlag(StatementAnalyte.Assay.Total | StatementAnalyte.Assay.Assets)).Sum(a => a.Amount);
            var roa = grossProfit / totalAssets;
            Console.WriteLine("{0,-20} {1,3:p}", "Return on Assets:", roa);
            Console.WriteLine();

            // Return on Capital Employed:ROCE
            // Capital employed = Total assets − Current liabilities = Equity + Fixed Liabilities = Fixed Assets
            // First, find the net value of all fixed assets on the company's balance sheet. 
            // You'll see this value listed as property, plant, and equipment (PP&E). 
            // To this number, add the value of all capital investments and current assets. 
            // From this number, subtract all current liabilities. These include all financial obligations due in a year or less. 
            // Examples of current liabilities listed on a company's balance sheet include accounts payable, short-term debt, and dividends payable.
            var totalFixedAssets = qr2021.Analytes.Where(a => a.Analyte.HasFlag(StatementAnalyte.Assay.Total | StatementAnalyte.Assay.FixedAssets)).Sum(a => a.Amount);
            var roce = grossProfit / totalFixedAssets;

            // Total Asset Turnover
            var tat = revenue / totalAssets;
            Console.WriteLine("{0,-20} {1,3:p}", "Total Asset Turnover:", tat);
            Console.WriteLine();
        }
    }
}
