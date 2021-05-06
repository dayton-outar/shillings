using System.Linq;
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
        public IQueryable<Company> GetCompanies([ScopedService]StocksQuery sq) => sq.Companies;
    }
}