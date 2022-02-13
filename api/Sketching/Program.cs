using System;
using System.Collections.Generic;
using O8Query.Models;

namespace Sketching
{
    class Program
    {
        static void Main(string[] args)
        {
            var incomeExpenseAnalytes = new List<StatementAnalyte>();
            //--
            incomeExpenseAnalytes.Add(new StatementAnalyte{
                Sequence = 1,
                Description = "Total Revenue",
                Type = StatementAnalyte.StatementType.IncomeExpense,
                Section = StatementAnalyte.Sectional.Income,
                Analyte = StatementAnalyte.Assay.Revenue,
                Amount = 115437341000.00m
            });

            incomeExpenseAnalytes.Add(new StatementAnalyte{
                Sequence = 2,
                Description = "Direct and operating expenses",
                Type = StatementAnalyte.StatementType.IncomeExpense,
                Section = StatementAnalyte.Sectional.Income,
                Analyte = StatementAnalyte.Assay.DirectExpense | StatementAnalyte.Assay.OperatingExpense,
                Amount = 108109929000.00m
            });

            incomeExpenseAnalytes.Add(new StatementAnalyte{
                Sequence = 3,
                Description = "Net impairment losses on financial assets",
                Type = StatementAnalyte.StatementType.IncomeExpense,
                Section = StatementAnalyte.Sectional.Income,
                Analyte = StatementAnalyte.Assay.Expense,
                Amount = 523486000.00m
            });

            incomeExpenseAnalytes.Add(new StatementAnalyte{
                Sequence = 4,
                Description = "Expenses",
                Type = StatementAnalyte.StatementType.IncomeExpense,
                Section = StatementAnalyte.Sectional.Income,
                Analyte = StatementAnalyte.Assay.Revenue,
                Amount = 108633415000.00m
            });

            incomeExpenseAnalytes.Add(new StatementAnalyte{
                Sequence = 5,
                Description = "Profit before Other income",
                Type = StatementAnalyte.StatementType.IncomeExpense,
                Section = StatementAnalyte.Sectional.Income,
                Analyte = StatementAnalyte.Assay.ProfitBeforeInterestAndTaxes,
                Amount = 6803926000.00m
            });

            incomeExpenseAnalytes.Add(new StatementAnalyte{
                Sequence = 6,
                Description = "Other income",
                Type = StatementAnalyte.StatementType.IncomeExpense,
                Section = StatementAnalyte.Sectional.Income,
                Analyte = StatementAnalyte.Assay.Income,
                Amount = 3024608000.00m
            });

            incomeExpenseAnalytes.Add(new StatementAnalyte{
                Sequence = 7,
                Description = "Interest income - non-financial services",
                Type = StatementAnalyte.StatementType.IncomeExpense,
                Section = StatementAnalyte.Sectional.Income,
                Analyte = StatementAnalyte.Assay.Income,
                Amount = 467866000.00m
            });

            incomeExpenseAnalytes.Add(new StatementAnalyte{
                Sequence = 8,
                Description = "Interest expense - non-financial services",
                Type = StatementAnalyte.StatementType.IncomeExpense,
                Section = StatementAnalyte.Sectional.Income,
                Analyte = StatementAnalyte.Assay.Expense,
                Amount = 467866000.00m
            });

            incomeExpenseAnalytes.Add(new StatementAnalyte{
                Sequence = 9,
                Description = "Share of results of associates and joint ventures",
                Type = StatementAnalyte.StatementType.IncomeExpense,
                Section = StatementAnalyte.Sectional.Income,
                Analyte = StatementAnalyte.Assay.Income,
                Amount = 543532000.00m
            });

            incomeExpenseAnalytes.Add(new StatementAnalyte{
                Sequence = 10,
                Description = "Profit before Tax",
                Type = StatementAnalyte.StatementType.IncomeExpense,
                Section = StatementAnalyte.Sectional.Income,
                Analyte = StatementAnalyte.Assay.ProfitBeforeTaxes,
                Amount = 543532000.00m
            });

            incomeExpenseAnalytes.Add(new StatementAnalyte{
                Sequence = 11,
                Description = "Tax",
                Type = StatementAnalyte.StatementType.IncomeExpense,
                Section = StatementAnalyte.Sectional.Income,
                Analyte = StatementAnalyte.Assay.Expense | StatementAnalyte.Assay.Tax,
                Amount = 2852049000.00m
            });

            incomeExpenseAnalytes.Add(new StatementAnalyte{
                Sequence = 12,
                Description = "Net Profit",
                Type = StatementAnalyte.StatementType.IncomeExpense,
                Section = StatementAnalyte.Sectional.Income,
                Analyte = StatementAnalyte.Assay.Income,
                Amount = 6856926000.00m
            });

            incomeExpenseAnalytes.Add(new StatementAnalyte{
                Sequence = 13,
                Description = "Owners of GraceKennedy Limited",
                Type = StatementAnalyte.StatementType.IncomeExpense,
                Section = StatementAnalyte.Sectional.ProfitAttributable,
                Analyte = StatementAnalyte.Assay.ShareholdersProfit,
                Amount = 6218055000.00m
            });

            incomeExpenseAnalytes.Add(new StatementAnalyte{
                Sequence = 14,
                Description = "Non-controlling interests",
                Type = StatementAnalyte.StatementType.IncomeExpense,
                Section = StatementAnalyte.Sectional.ProfitAttributable,
                Analyte = StatementAnalyte.Assay.NonControllingInterestProfit,
                Amount = 638871000.00m
            });

            incomeExpenseAnalytes.Add(new StatementAnalyte{
                Sequence = 15,
                Description = "Basic Earnings per Stock Unit",
                Type = StatementAnalyte.StatementType.IncomeExpense,
                Section = StatementAnalyte.Sectional.EarningsPerStock,
                Analyte = StatementAnalyte.Assay.BasicEarningsPerStock,
                Amount = 6.28m
            });
            //--
            var qr2021 = new FinancialReport
            {
                CompanyCode = "GK",
                Period = FinancialReport.Periodical.Annual,
                StatementDate = new DateTime(2020, 12, 30),
                IsAudited = false,
                Analytes = incomeExpenseAnalytes,
            };


            foreach(var item in qr2021.Analytes) 
            {
                Console.WriteLine("{0}. {1} ----------------- {2:c}", item.Sequence, item.Description, item.Amount);
            }
        }
    }
}
