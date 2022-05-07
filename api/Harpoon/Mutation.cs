
using O8Query.Models;
using O8Query.Data;

namespace Harpoon
{
    public class Mutation
    {
        private StocksQuery _sq;
        
        public Mutation(StocksQuery stocksQuery)
        {
            _sq = stocksQuery;
        }

        public bool CreateFinancialReport(FinancialReport financialReport)
        {
            // _sq.FinancialReports.Add(financialReport.);
            // _sq.SaveChanges();

            return true;
        }

        // public FinancialReport UpdateFinancialReport(string report, DateTime statementDate)
        // {
        //     // _sq.FinancialReports.Update(financialReport);
        //     // _sq.SaveChanges();

        //     return new FinancialReport();
        // }
    }
}