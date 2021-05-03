using System.Linq;
using HotChocolate;

using O8Query.Models;
using O8Query.Data;
using HotChocolate.Data;
using HotChocolate.Types;

namespace Harpoon
{
    public class Query
    {
        [UseDbContext(typeof(StocksQuery))]
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<StockTrading> GetStockTradings([ScopedService]StocksQuery sq) => sq.StockTradings;

        [UseDbContext(typeof(StocksQuery))]
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Company> GetCompanies([ScopedService]StocksQuery sq) => sq.Companies;
    }
}