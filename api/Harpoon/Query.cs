using System.Linq;
using System.Collections.Generic;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

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
        [UseProjection]
        [UseSorting]
        public IQueryable<TotalStockTrades> GetTotalTrades(string companyCode, System.DateTime begin, System.DateTime end, [ScopedService]StocksQuery sq) 
        {
            return sq.TotalTrades.FromSqlInterpolated($"SELECT * FROM [dbo].[TotalStocksTraded]({companyCode}, {begin.Date}, {end.Date})").AsQueryable();
        }

        [UseDbContext(typeof(StocksQuery))]
        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Company> GetCompanies([ScopedService]StocksQuery sq) => sq.Companies;
    }
}