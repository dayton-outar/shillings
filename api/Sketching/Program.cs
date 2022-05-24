using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using O8Query.Models;
using O8Query.Data;

namespace Sketching
{
    class Program
    {
        static void Main(string[] args)
        {
            // var reportAnalytes = new List<StatementAnalyte>();
            // //--
            // reportAnalytes.Add(new StatementAnalyte{
            //     Sequence = 1,
            //     Description = "Revenue from products and services",
            //     Type = StatementAnalyte.StatementType.Income,
            //     Section = StatementAnalyte.Sectional.Revenues,
            //     Analyte = StatementAnalyte.Assay.Operating,
            //     Amount = 111064222000.00m
            // });
            
            // reportAnalytes.Add(new StatementAnalyte{
            //     Sequence = 2,
            //     Description = "Interest revenue",
            //     Type = StatementAnalyte.StatementType.Income,
            //     Section = StatementAnalyte.Sectional.Revenues,
            //     Analyte = StatementAnalyte.Assay.Interest,
            //     Amount = 4373119000.00m
            // });

            // reportAnalytes.Add(new StatementAnalyte{
            //     Sequence = 4,
            //     Description = "Direct expenses",
            //     Type = StatementAnalyte.StatementType.Income,
            //     Section = StatementAnalyte.Sectional.Expenses,
            //     Analyte = StatementAnalyte.Assay.Direct,
            //     Amount = 83903002000.00m
            // });

            // reportAnalytes.Add(new StatementAnalyte{
            //     Sequence = 4,
            //     Description = "Interest expenses",
            //     Type = StatementAnalyte.StatementType.Income,
            //     Section = StatementAnalyte.Sectional.Expenses,
            //     Analyte = StatementAnalyte.Assay.Interest | StatementAnalyte.Assay.Direct,
            //     Amount = 7015734000.00m
            // });

            // reportAnalytes.Add(new StatementAnalyte{
            //     Sequence = 4,
            //     Description = "Operating expenses",
            //     Type = StatementAnalyte.StatementType.Income,
            //     Section = StatementAnalyte.Sectional.Expenses,
            //     Analyte = StatementAnalyte.Assay.Operating,
            //     Amount = 17714679000.00m
            // });

            // reportAnalytes.Add(new StatementAnalyte{
            //     Sequence = 5,
            //     Description = "Net impairment losses on financial assets",
            //     Type = StatementAnalyte.StatementType.Income,
            //     Section = StatementAnalyte.Sectional.Losses,
            //     Analyte = StatementAnalyte.Assay.Impairment,
            //     Amount = 523486000.00m
            // });

            // reportAnalytes.Add(new StatementAnalyte{
            //     Sequence = 8,
            //     Description = "Other income",
            //     Type = StatementAnalyte.StatementType.Income,
            //     Section = StatementAnalyte.Sectional.Gains,
            //     Analyte = StatementAnalyte.Assay.Other,
            //     Amount = 3024608000.00m
            // });

            // reportAnalytes.Add(new StatementAnalyte{
            //     Sequence = 9,
            //     Description = "Interest income - non-financial services",
            //     Type = StatementAnalyte.StatementType.Income,
            //     Section = StatementAnalyte.Sectional.Gains,
            //     Analyte = StatementAnalyte.Assay.Interest,
            //     Amount = 467866000.00m
            // });

            // reportAnalytes.Add(new StatementAnalyte{
            //     Sequence = 10,
            //     Description = "Interest expense - non-financial services",
            //     Type = StatementAnalyte.StatementType.Income,
            //     Section = StatementAnalyte.Sectional.Losses,
            //     Analyte = StatementAnalyte.Assay.Interest,
            //     Amount = 1130957000.00m
            // });

            // reportAnalytes.Add(new StatementAnalyte{
            //     Sequence = 11,
            //     Description = "Share of results of associates and joint ventures",
            //     Type = StatementAnalyte.StatementType.Income,
            //     Section = StatementAnalyte.Sectional.Gains,
            //     Analyte = StatementAnalyte.Assay.Investment,
            //     Amount = 543532000.00m
            // });

            // reportAnalytes.Add(new StatementAnalyte{
            //     Sequence = 13,
            //     Description = "Tax",
            //     Type = StatementAnalyte.StatementType.Income,
            //     Section = StatementAnalyte.Sectional.Expenses,
            //     Analyte = StatementAnalyte.Assay.Tax,
            //     Amount = 2852049000.00m
            // });

            // reportAnalytes.Add(new StatementAnalyte{
            //     Sequence = 15,
            //     Description = "Owners of GraceKennedy Limited",
            //     Type = StatementAnalyte.StatementType.Income,
            //     Section = StatementAnalyte.Sectional.ProfitShare,
            //     Analyte = StatementAnalyte.Assay.Shareholders,
            //     Amount = 6218055000.00m
            // });

            // reportAnalytes.Add(new StatementAnalyte{
            //     Sequence = 16,
            //     Description = "Non-controlling interests",
            //     Type = StatementAnalyte.StatementType.Income,
            //     Section = StatementAnalyte.Sectional.ProfitShare,
            //     Analyte = StatementAnalyte.Assay.NonControlling,
            //     Amount = 638871000.00m
            // });

            // reportAnalytes.Add(new StatementAnalyte{
            //     Sequence = 17,
            //     Description = "Basic Earnings per Stock Unit",
            //     Type = StatementAnalyte.StatementType.Income,
            //     Section = StatementAnalyte.Sectional.EarningsPerStock,
            //     Analyte = StatementAnalyte.Assay.Basic,
            //     Amount = 6.28m
            // });
            // //--

            // reportAnalytes.Add(new StatementAnalyte{
            //     Sequence = 1,
            //     Description = "Cash and deposits",
            //     Type = StatementAnalyte.StatementType.FinancialPosition,
            //     Section = StatementAnalyte.Sectional.Assets,
            //     Analyte = StatementAnalyte.Assay.Current | StatementAnalyte.Assay.Cash,
            //     Amount = 24331106000.00m
            // });

            // reportAnalytes.Add(new StatementAnalyte{
            //     Sequence = 2,
            //     Description = "Investment securities",
            //     Type = StatementAnalyte.StatementType.FinancialPosition,
            //     Section = StatementAnalyte.Sectional.Assets,
            //     Analyte = StatementAnalyte.Assay.Current | StatementAnalyte.Assay.Cash,
            //     Amount = 33513948000.00m
            // });

            // reportAnalytes.Add(new StatementAnalyte{
            //     Sequence = 3,
            //     Description = "Pledged assets",
            //     Type = StatementAnalyte.StatementType.FinancialPosition,
            //     Section = StatementAnalyte.Sectional.Assets,
            //     Analyte = StatementAnalyte.Assay.Current | StatementAnalyte.Assay.Cash,
            //     Amount = 7610387000.00m
            // });

            // reportAnalytes.Add(new StatementAnalyte{
            //     Sequence = 4,
            //     Description = "Receivables",
            //     Type = StatementAnalyte.StatementType.FinancialPosition,
            //     Section = StatementAnalyte.Sectional.Assets,
            //     Analyte = StatementAnalyte.Assay.Current | StatementAnalyte.Assay.Receivables,
            //     Amount = 16871439000.00m
            // });

            // reportAnalytes.Add(new StatementAnalyte{
            //     Sequence = 5,
            //     Description = "Inventories",
            //     Type = StatementAnalyte.StatementType.FinancialPosition,
            //     Section = StatementAnalyte.Sectional.Assets,
            //     Analyte = StatementAnalyte.Assay.Inventories,
            //     Amount = 14433135000.00m
            // });

            // reportAnalytes.Add(new StatementAnalyte{
            //     Sequence = 6,
            //     Description = "Loans receivables",
            //     Type = StatementAnalyte.StatementType.FinancialPosition,
            //     Section = StatementAnalyte.Sectional.Assets,
            //     Analyte = StatementAnalyte.Assay.Fixed,
            //     Amount = 31250331000.00m
            // });

            // reportAnalytes.Add(new StatementAnalyte{
            //     Sequence = 7,
            //     Description = "Tax recoverables",
            //     Type = StatementAnalyte.StatementType.FinancialPosition,
            //     Section = StatementAnalyte.Sectional.Assets,
            //     Analyte = StatementAnalyte.Assay.Fixed,
            //     Amount = 767669000.00m
            // });

            // reportAnalytes.Add(new StatementAnalyte{
            //     Sequence = 8,
            //     Description = "Investments in associates and joint ventures",
            //     Type = StatementAnalyte.StatementType.FinancialPosition,
            //     Section = StatementAnalyte.Sectional.Assets,
            //     Analyte = StatementAnalyte.Assay.Current,
            //     Amount = 4118824000.00m
            // });

            // reportAnalytes.Add(new StatementAnalyte{
            //     Sequence = 9,
            //     Description = "Investments properties",
            //     Type = StatementAnalyte.StatementType.FinancialPosition,
            //     Section = StatementAnalyte.Sectional.Assets,
            //     Analyte = StatementAnalyte.Assay.Fixed,
            //     Amount = 925734000.00m
            // });

            // reportAnalytes.Add(new StatementAnalyte{
            //     Sequence = 10,
            //     Description = "Intangible assets",
            //     Type = StatementAnalyte.StatementType.FinancialPosition,
            //     Section = StatementAnalyte.Sectional.Assets,
            //     Analyte = StatementAnalyte.Assay.Intagible,
            //     Amount = 4411466000.00m
            // });

            // reportAnalytes.Add(new StatementAnalyte{
            //     Sequence = 11,
            //     Description = "Fixed assets",
            //     Type = StatementAnalyte.StatementType.FinancialPosition,
            //     Section = StatementAnalyte.Sectional.Assets,
            //     Analyte = StatementAnalyte.Assay.Fixed,
            //     Amount = 25560044000.00m
            // });

            // reportAnalytes.Add(new StatementAnalyte{
            //     Sequence = 12,
            //     Description = "Deferred tax assets",
            //     Type = StatementAnalyte.StatementType.FinancialPosition,
            //     Section = StatementAnalyte.Sectional.Assets,
            //     Analyte = StatementAnalyte.Assay.Fixed,
            //     Amount = 1060528000.00m
            // });

            // reportAnalytes.Add(new StatementAnalyte{
            //     Sequence = 13,
            //     Description = "Pension plan assets",
            //     Type = StatementAnalyte.StatementType.FinancialPosition,
            //     Section = StatementAnalyte.Sectional.Assets,
            //     Analyte = StatementAnalyte.Assay.Fixed,
            //     Amount = 6841372000.00m
            // });

            // reportAnalytes.Add(new StatementAnalyte{
            //     Sequence = 14,
            //     Description = "Assets classified as held for sale",
            //     Type = StatementAnalyte.StatementType.FinancialPosition,
            //     Section = StatementAnalyte.Sectional.Assets,
            //     Analyte = StatementAnalyte.Assay.Fixed,
            //     Amount = 0.00m
            // });

            // reportAnalytes.Add(new StatementAnalyte{
            //     Sequence = 16,
            //     Description = "Deposits",
            //     Type = StatementAnalyte.StatementType.FinancialPosition,
            //     Section = StatementAnalyte.Sectional.Liabilities,
            //     Analyte = StatementAnalyte.Assay.Current,
            //     Amount = 41611220000.00m
            // });

            // reportAnalytes.Add(new StatementAnalyte{
            //     Sequence = 17,
            //     Description = "Securities sold under agreements to repurchase",
            //     Type = StatementAnalyte.StatementType.FinancialPosition,
            //     Section = StatementAnalyte.Sectional.Liabilities,
            //     Analyte = StatementAnalyte.Assay.Current,
            //     Amount = 4968483000.00m
            // });

            // reportAnalytes.Add(new StatementAnalyte{
            //     Sequence = 18,
            //     Description = "Bank and other loans",
            //     Type = StatementAnalyte.StatementType.FinancialPosition,
            //     Section = StatementAnalyte.Sectional.Liabilities,
            //     Analyte = StatementAnalyte.Assay.Fixed | StatementAnalyte.Assay.Debt,
            //     Amount = 25233708000.00m
            // });

            // reportAnalytes.Add(new StatementAnalyte{
            //     Sequence = 19,
            //     Description = "Payables",
            //     Type = StatementAnalyte.StatementType.FinancialPosition,
            //     Section = StatementAnalyte.Sectional.Liabilities,
            //     Analyte = StatementAnalyte.Assay.Current | StatementAnalyte.Assay.Payables,
            //     Amount = 28211841000.00m
            // });

            // reportAnalytes.Add(new StatementAnalyte{
            //     Sequence = 20,
            //     Description = "Tax",
            //     Type = StatementAnalyte.StatementType.FinancialPosition,
            //     Section = StatementAnalyte.Sectional.Liabilities,
            //     Analyte = StatementAnalyte.Assay.Current,
            //     Amount = 1077285000.00m
            // });

            // reportAnalytes.Add(new StatementAnalyte{
            //     Sequence = 21,
            //     Description = "Provisions",
            //     Type = StatementAnalyte.StatementType.FinancialPosition,
            //     Section = StatementAnalyte.Sectional.Liabilities,
            //     Analyte = StatementAnalyte.Assay.Current,
            //     Amount = 42602000.00m
            // });

            // reportAnalytes.Add(new StatementAnalyte{
            //     Sequence = 22,
            //     Description = "Deferred tax liabilities",
            //     Type = StatementAnalyte.StatementType.FinancialPosition,
            //     Section = StatementAnalyte.Sectional.Liabilities,
            //     Analyte = StatementAnalyte.Assay.Current,
            //     Amount = 1822238000.00m
            // });

            // reportAnalytes.Add(new StatementAnalyte{
            //     Sequence = 23,
            //     Description = "Other post-employment obligations",
            //     Type = StatementAnalyte.StatementType.FinancialPosition,
            //     Section = StatementAnalyte.Sectional.Liabilities,
            //     Analyte = StatementAnalyte.Assay.Current,
            //     Amount = 5949279000.00m
            // });

            // reportAnalytes.Add(new StatementAnalyte{
            //     Sequence = 25,
            //     Description = "Share capital",
            //     Type = StatementAnalyte.StatementType.FinancialPosition,
            //     Section = StatementAnalyte.Sectional.Equity,
            //     Analyte = StatementAnalyte.Assay.Capital,
            //     Amount = 305493000.00m
            // });

            // reportAnalytes.Add(new StatementAnalyte{
            //     Sequence = 26,
            //     Description = "Capital and fair value reserves",
            //     Type = StatementAnalyte.StatementType.FinancialPosition,
            //     Section = StatementAnalyte.Sectional.Equity,
            //     Analyte = StatementAnalyte.Assay.Capital | StatementAnalyte.Assay.Reserves,
            //     Amount = 7789066000.00m
            // });

            // reportAnalytes.Add(new StatementAnalyte{
            //     Sequence = 27,
            //     Description = "Retained earnings",
            //     Type = StatementAnalyte.StatementType.FinancialPosition,
            //     Section = StatementAnalyte.Sectional.Equity,
            //     Analyte = StatementAnalyte.Assay.Retained,
            //     Amount = 44096867000.00m
            // });

            // reportAnalytes.Add(new StatementAnalyte{
            //     Sequence = 28,
            //     Description = "Banking reserves",
            //     Type = StatementAnalyte.StatementType.FinancialPosition,
            //     Section = StatementAnalyte.Sectional.Equity,
            //     Analyte = StatementAnalyte.Assay.Reserves,
            //     Amount = 3620711000.00m
            // });

            // reportAnalytes.Add(new StatementAnalyte{
            //     Sequence = 29,
            //     Description = "Other reserves",
            //     Type = StatementAnalyte.StatementType.FinancialPosition,
            //     Section = StatementAnalyte.Sectional.Equity,
            //     Analyte = StatementAnalyte.Assay.Reserves,
            //     Amount = 4098122000.00m
            // });

            // reportAnalytes.Add(new StatementAnalyte{
            //     Sequence = 30,
            //     Description = "Non-Controlling interests",
            //     Type = StatementAnalyte.StatementType.FinancialPosition,
            //     Section = StatementAnalyte.Sectional.Equity,
            //     Analyte = StatementAnalyte.Assay.NonControlling,
            //     Amount = 2869068000.00m
            // });

            //--
            var contextOptions = new DbContextOptionsBuilder<StocksQuery>()
                                    .UseSqlServer(@"Server=localhost,1401;Database=stocks;Persist Security Info=True;User ID=sa;Password=Password44;")
                                    .Options;

            var sq = new StocksQuery(contextOptions);
            var qr2021 = sq.FinancialReports.Include(r => r.Analytes).Include(r => r.Company).First(f => f.No == 4);
            // var qr2021 = new FinancialReport
            // {
            //     Company = new Company {
            //         Code = "GK"
            //     },
            //     Period = FinancialReport.Periodical.Annual,
            //     StatementDate = new DateTime(2020, 12, 30),
            //     IsAudited = false,
            //     Analytes = reportAnalytes,
            // };


            Console.WriteLine("{0} {1} {2:dd MMMM, yyyy}{3}", qr2021.Company.Name, qr2021.Period, qr2021.StatementDate, qr2021.IsAudited ? "" : " (Unaudited)");
            int padding = 120;
            // Console.WriteLine(string.Empty.PadLeft(padding, '='));

            foreach(var item in qr2021.Analytes) 
            {
                if (item.Sequence == 1) {
                    Console.WriteLine();

                    switch (item.Type) 
                    {
                        case StatementAnalyte.StatementType.Income:
                            Console.WriteLine("Statement of Income");
                            break;
                        case StatementAnalyte.StatementType.FinancialPosition:
                            Console.WriteLine("Statement of Financial Position");
                            break;
                    }

                    Console.WriteLine(string.Empty.PadLeft(padding, '-'));
                }
                
                Console.WriteLine("{0,2}. {1,-50} {2,-30} {3,20:c}", item.Sequence, item.Description, item.Analyte, item.Amount);
            }

            Console.WriteLine(string.Empty.PadLeft(padding, '='));

            Console.WriteLine();

            var asl = new List<StatementAnalyte.Assay>();
            asl.Add(StatementAnalyte.Assay.Direct);
            asl.Add(StatementAnalyte.Assay.Operating);
            var ast = EnumExtension.ToCombined<StatementAnalyte.Assay>(asl);

            Console.WriteLine("{0}", ast);

            // var revenue = qr2021.Analytes.Where(a => a.Section == StatementAnalyte.Sectional.Revenues).Sum(a => a.Amount);
            // Console.WriteLine("{0,-50} {1,20:c}", "Revenues", revenue);
            // Console.WriteLine();

            // var directExpenses = qr2021.Analytes.Where(a => a.Section == StatementAnalyte.Sectional.Expenses && a.Analyte.HasFlag(StatementAnalyte.Assay.Direct)).Sum(a => a.Amount);
            // var netImpairment = qr2021.Analytes.Where(a => a.Section == StatementAnalyte.Sectional.Losses && a.Analyte.HasFlag(StatementAnalyte.Assay.Impairment)).Sum(a => a.Amount);
            // directExpenses = directExpenses - netImpairment;
            // Console.WriteLine("{0,-50} {1,20:c}", "Direct Expenses", directExpenses);
            // Console.WriteLine();

            // var operatingExpenses = qr2021.Analytes.Where(a => a.Section == StatementAnalyte.Sectional.Expenses && a.Analyte.HasFlag(StatementAnalyte.Assay.Operating)).Sum(a => a.Amount);
            // Console.WriteLine("{0,-50} {1,20:c}", "Operating Expenses", operatingExpenses);
            // Console.WriteLine();

            // var tax = qr2021.Analytes.Where(a => a.Section == StatementAnalyte.Sectional.Expenses && a.Analyte.HasFlag(StatementAnalyte.Assay.Tax)).Sum(a => a.Amount);
            // Console.WriteLine("{0,-50} {1,20:c}", "Tax", tax);
            // Console.WriteLine();

            // Console.ForegroundColor = ConsoleColor.Green;

            // Console.WriteLine();
            // Console.WriteLine("Financial Ratios");
            // Console.WriteLine(string.Empty.PadLeft(padding, '='));

            // // -- Profit Ratios

            // // Gross Profit Margin            
            // var grossProfit = (revenue - (directExpenses + operatingExpenses));
            // var grossMargin = grossProfit / revenue;

            // Console.WriteLine("{0,-30} {1,3:p}", "Gross Profit Margin:", grossMargin);
            // Console.WriteLine();

            // // Net Profit Margin
            // var totalGains = qr2021.Analytes.Where(a => a.Section == StatementAnalyte.Sectional.Gains).Sum(a => a.Amount);
            // var totalLosses = qr2021.Analytes.Where(a => a.Section == StatementAnalyte.Sectional.Losses).Sum(a => a.Amount);

            // var netProfit = (revenue + totalGains) - (directExpenses + operatingExpenses + totalLosses + tax);
            // var netMargin = netProfit / revenue;

            // Console.WriteLine("{0,-30} {1,3:p}", "Net Profit Margin:", netMargin);
            // Console.WriteLine();

            // // Return on Equity: ROE
            // var totalEquity = qr2021.Analytes.Where(a => a.Section == StatementAnalyte.Sectional.Equity).Sum(a => a.Amount);
            // var roe = netProfit / totalEquity;
            // Console.WriteLine("{0,-30} {1,3:p}", "Return on Equity:", roe);
            // Console.WriteLine();

            // // Return on Assets: ROA
            // /// <summary>
            // /// Since all assets are either funded by equity
            // /// or debt, some investors try to disregard the
            // /// costs of acquiring the assets in the return
            // /// calculation by adding back interest ex-
            // /// pense in the formula.
            // /// </summary>
            // /// <remarks>
            // /// Credit: Financial Ratio Cheatsheet - MyAccountingCourse.com
            // /// </remarks>
            // var totalAssets = qr2021.Analytes.Where(a => a.Section == StatementAnalyte.Sectional.Assets).Sum(a => a.Amount);
            // var roa = grossProfit / totalAssets;
            // Console.WriteLine("{0,-30} {1,3:p}", "Return on Assets:", roa);
            // Console.WriteLine();

            // // Return on Capital Employed:ROCE
            // // Capital employed = Total assets − Current liabilities = Equity + Fixed Liabilities = Fixed Assets
            // // First, find the net value of all fixed assets on the company's balance sheet. 
            // // You'll see this value listed as property, plant, and equipment (PP&E). 
            // // To this number, add the value of all capital investments and current assets. 
            // // From this number, subtract all current liabilities. These include all financial obligations due in a year or less. 
            // // Examples of current liabilities listed on a company's balance sheet include accounts payable, short-term debt, and dividends payable.
            // var totalFixedAssets = qr2021.Analytes.Where(a => a.Section == StatementAnalyte.Sectional.Assets && a.Analyte.HasFlag(StatementAnalyte.Assay.Fixed)).Sum(a => a.Amount);
            // var roce = grossProfit / totalFixedAssets;
            // Console.WriteLine("{0,-30} {1,3:p}", "ROCE:", roce);
            // Console.WriteLine();

            // // -- Liquidity Ratios

            // // Quick Ratio
            // var totalCash = qr2021.Analytes.Where(a => a.Analyte.HasFlag(StatementAnalyte.Assay.Cash)).Sum(a => a.Amount);
            // var totalCurrentLiabilities = qr2021.Analytes.Where(a => a.Section == StatementAnalyte.Sectional.Liabilities && a.Analyte.HasFlag(StatementAnalyte.Assay.Current)).Sum(a => a.Amount);
            // var qr = totalCash / totalCurrentLiabilities;
            // Console.WriteLine("{0,-30} {1,3:p}", "Quick Ratio:", qr);
            // Console.WriteLine();

            // // Current Ratio / Working Capital Ratio
            // var totalCurrentAssets = qr2021.Analytes.Where(a => a.Section == StatementAnalyte.Sectional.Assets && a.Analyte.HasFlag(StatementAnalyte.Assay.Current)).Sum(a => a.Amount);
            // var cr = totalCurrentAssets / totalCurrentLiabilities;
            // Console.WriteLine("{0,-30} {1,3:p}", "Current Ratio:", cr);
            // var wc = totalCurrentAssets - totalCurrentLiabilities;
            // Console.WriteLine("{0,-30} {1,3:c}", "Working Capital:", wc);
            // Console.WriteLine();

            // // -- Solvency Ratios

            // // Debt to Equity
            // var totalLiabilities = qr2021.Analytes.Where(a => a.Section == StatementAnalyte.Sectional.Liabilities).Sum(a => a.Amount);
            // // Some companies use a specific line item for debt not the total list of liabilities
            // var dte = totalLiabilities / totalEquity;
            // Console.WriteLine("{0,-30} {1,3:p}", "Debt-to-Equity Ratio:", dte);
            // Console.WriteLine();

            // // Debt to Equity ... Specific item except total liabilities
            // var totalDebt = qr2021.Analytes.Where(a => a.Section == StatementAnalyte.Sectional.Liabilities && a.Analyte.HasFlag(StatementAnalyte.Assay.Debt)).Sum(a => a.Amount);
            // var sdr = totalDebt / totalEquity;
            // Console.WriteLine("{0,-30} {1,3:p}", "Debt Ratio (Bank Loan):", sdr);
            // Console.WriteLine();

            // // Equity Ratio
            // var eqr = totalEquity / totalAssets;
            // Console.WriteLine("{0,-30} {1,3:p}", "Equity Ratio:", eqr);
            // Console.WriteLine();

            // // Debt Ratio = 1 - Equity Ratio
            // var dr = totalLiabilities / totalAssets;
            // Console.WriteLine("{0,-30} {1,3:p}", "Debt Ratio:", dr);
            // Console.WriteLine();

            // // -- Activity Ratios

            // // Total Asset Turnover
            // var tat = revenue / totalAssets;
            // Console.WriteLine("{0,-30} {1,3:p}", "Total Asset Turnover:", tat);
            // Console.WriteLine();

            // // Inventory Turnover
            // var totalInventories = qr2021.Analytes.Where(a => a.Analyte.HasFlag(StatementAnalyte.Assay.Inventories)).Sum(a => a.Amount);
            // var totalDirectExpense = qr2021.Analytes.Where(a => a.Section == StatementAnalyte.Sectional.Expenses && a.Analyte.HasFlag(StatementAnalyte.Assay.Direct)).Sum(a => a.Amount);
            // var ivt = totalDirectExpense / totalInventories; // Skewed because operating expense is bundled in this
            // Console.WriteLine("{0,-30} {1,3}", "Inventory Turnover:", Math.Round(ivt, 2));
            // // Credit: https://www.wallstreetprep.com/knowledge/inventory-turnover-days-inventory-outstanding/
            // var dio = 365 / ivt;
            // Console.WriteLine("{0,-30} {1} days", "Days Inventory Outstanding:", Math.Ceiling(dio));
            // Console.WriteLine();

            // // Accounts Receivables Turnover
            // var totalReceivables = qr2021.Analytes.Where(a => a.Analyte.HasFlag(StatementAnalyte.Assay.Receivables)).Sum(a => a.Amount);
            // var rtr = totalCash / totalReceivables; // Could use revenue instead of cash? Average receivables (across periodicals)?
            // Console.WriteLine("{0,-30} {1,3}", "Receivable Turnover:", Math.Round(rtr, 2));
            // Console.WriteLine();

            // // Day Sales Outstanding
            // var dso = 365 / rtr;
            // Console.WriteLine("{0,-30} {1} days", "Day Sales Outstanding:", Math.Ceiling(dso));
            // Console.WriteLine();

            // // Day Payable Outstanding
            // // Credit: https://www.wallstreetprep.com/knowledge/days-payable-outstanding-dpo/
            // var totalPayables = qr2021.Analytes.Where(a => a.Analyte.HasFlag(StatementAnalyte.Assay.Payables)).Sum(a => a.Amount);
            // var dpo = (totalPayables / totalDirectExpense) * 365;
            // Console.WriteLine("{0,-30} {1} days", "Day Payable Outstanding:", Math.Ceiling(dpo));
            // Console.WriteLine();

            // // Cash Cycle
            // // Measures how fast a company can convert cash on hand into even more cash on hand
            // // Credit: https://www.investopedia.com/terms/c/cashconversioncycle.asp#:~:text=Cash%20Conversion%20Cycle%20%3D%20days%20inventory,sales%20outstanding%20%2D%20days%20payables%20outstanding.
            // var ccc = dio + dso - dpo;
            // Console.WriteLine("{0,-30} {1} days", "Cash Cycle:", Math.Ceiling(ccc));
            // Console.WriteLine();

            // // -- Market Prospects Ratios
            // var marketCap = 989655000m; // Weighed average number of stock units outstanding
            // var eps = qr2021.Analytes.Where(a => a.Section == StatementAnalyte.Sectional.EarningsPerStock && a.Analyte.HasFlag(StatementAnalyte.Assay.Basic)).First().Amount;
            // Console.WriteLine("{0,-30} {1,3:c}", "EPS:", eps);
            // Console.WriteLine();

            // // P/E Ratio = Stock Price / Earnings per Stock
            // var stockPrice = 62.68m;
            // var p2e = stockPrice / eps;
            // Console.WriteLine("{0,-30} {1,3}", "P/E:", Math.Round(p2e, 2));
            // Console.WriteLine();

            // // P/B Ratio = Shareholder's Equity / Market Capitalization
            // var nonControlling = qr2021.Analytes.Where(a => a.Section == StatementAnalyte.Sectional.Equity && a.Analyte.HasFlag(StatementAnalyte.Assay.NonControlling)).First().Amount;
            // var shareholdersEquity = totalEquity - nonControlling;
            // var bookValuePerStock = shareholdersEquity / marketCap;

            // var p2b = stockPrice / bookValuePerStock;
            // Console.WriteLine("{0,-30} {1,3}", "P/B:", Math.Round(p2b, 2));
            // Console.WriteLine();

            // // Dividends Payout Ratio = Total Dividends Paid / Shareholder's Net Income; Total Dividends per Stock / Earnings per Stock
            // var dividends = new List<Dividend>();

            // dividends.Add(new Dividend{
            //     Stock = new Stock {
            //         Code = "GK"
            //     },
            //     Amount = 0.45m,
            //     PaymentDate = new DateTime(2021, 4, 6),
            //     Log = new Log{
            //         Event = Log.EventType.Information,
            //         Logged = new DateTime(2021, 3, 15)
            //     }
            // });

            // dividends.Add(new Dividend{
            //     Stock = new Stock {
            //         Code = "GK"
            //     },
            //     Amount = 0.45m,
            //     PaymentDate = new DateTime(2021, 6, 15),
            //     Log = new Log{
            //         Event = Log.EventType.Information,
            //         Logged = new DateTime(2021, 5, 28)
            //     }
            // });

            // dividends.Add(new Dividend{
            //     Stock = new Stock {
            //         Code = "GK"
            //     },
            //     Amount = 0.48m,
            //     PaymentDate = new DateTime(2021, 9, 24),
            //     Log = new Log{
            //         Event = Log.EventType.Information,
            //         Logged = new DateTime(2021, 9, 3)
            //     }
            // });

            // dividends.Add(new Dividend{
            //     Stock = new Stock {
            //         Code = "GK"
            //     },
            //     Amount = 0.55m,
            //     PaymentDate = new DateTime(2021, 12, 16),
            //     Log = new Log{
            //         Event = Log.EventType.Information,
            //         Logged = new DateTime(2021, 11, 26)
            //     }
            // });

            // var totalAnnualDividendsPerStock = dividends.Where(d => d.Stock.Code == "GK").Sum(a => a.Amount);
            // var dpr = totalAnnualDividendsPerStock / eps; // Since we're using an Annual Report. The Earnings per Stock is the Annual Earnings per Stock
            // Console.WriteLine("{0,-30} {1,3:p}", "Dividend Payout:", dpr);
            // Console.WriteLine();

            // // Dividend Yield = Annual Dividends per Stock / Stock Price
            // var dy = totalAnnualDividendsPerStock / stockPrice;
            // Console.WriteLine("{0,-30} {1,3:p}", "Dividend Yield:", dy);
            // Console.WriteLine();

            // // -- Coverage Ratios
            
            // // Times Interest Coverage Ratio
            // // Credit: https://www.investopedia.com/terms/t/tie.asp#:~:text=What%20Is%20the%20Times%20Interest,on%20bonds%20and%20other%20debt.
            // var totalInterestExpense = qr2021.Analytes.Where(a => a.Section == StatementAnalyte.Sectional.Expenses &&  a.Analyte.HasFlag(StatementAnalyte.Assay.Interest)).Sum(a => a.Amount);
            // var tier = grossProfit / totalInterestExpense;
            // Console.WriteLine("{0,-30} {1,3:p}", "Interest Coverage:", tier);
            // Console.WriteLine();

            // Beta | Calculate Volatility from years of stock price movemements of a stock

            // --- More Ratios
            // Economic Value Added
            // Credit: https://www.investopedia.com/terms/e/eva.asp#:~:text=EVA%20is%20the%20incremental%20difference,funds%20invested%20into%20the%20business.
            // EVA = Net Income - (Capital * WACC) | Capital = Debt + Leases + Shareholder's Equity
        }
    }
}
