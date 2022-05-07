using HotChocolate;
using HotChocolate.Data;

using O8Query.Models;
using O8Query.Data;

namespace Harpoon
{
    public class Mutation
    {

        [UseDbContext(typeof(StocksQuery))]
        public FinancialReport CreateFinancialReport([ScopedService]StocksQuery sq, FinancialReport financialReport)
        {
            // _sq.FinancialReports.Add(financialReport.);
            // _sq.SaveChanges();

            return new FinancialReport{
                No = 1,
                Company = new Company{
                    Code = string.Empty,
                    Name = string.Empty
                },
                Period = FinancialReport.Periodical.Quarterly,
                IsAudited = true,
                StatementDate = new System.DateTime(2022, 8, 8)                
            };
        }

        [UseDbContext(typeof(StocksQuery))]
        public FinancialReport UpdateFinancialReport([ScopedService]StocksQuery sq, FinancialReport financialReport)
        {
            // _sq.FinancialReports.Update(financialReport);
            // _sq.SaveChanges();

            return new FinancialReport();
        }
    }
}