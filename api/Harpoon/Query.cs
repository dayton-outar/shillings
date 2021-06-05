using System.Linq;
//using System.Collections.Generic;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
//using Microsoft.Data.SqlClient;

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

        // public IQueryable<StockTrading> GetTotalStocks([ScopedService]StocksQuery sq) {

        //     List<SqlParameter> parms = new List<SqlParameter> 
        //     {
        //         // Create parameter(s)    
        //         new SqlParameter { ParameterName = "@companyCode", Value = "" }
        //     };

        //     return sq.StockTradings.FromSqlRaw("exec [dbo].[GetTotalStocksTraded] @companyCode", parms).Include(t => t.Security);
        // }

        [UseDbContext(typeof(StocksQuery))]
        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Company> GetCompanies([ScopedService]StocksQuery sq) => sq.Companies;
    }
}