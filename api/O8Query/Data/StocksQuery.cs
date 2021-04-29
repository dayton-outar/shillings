using System;
using Microsoft.EntityFrameworkCore;

using O8Query.Models;

namespace O8Query.Data
{
    public class StocksQuery: DbContext
    {
        public StocksQuery(DbContextOptions<StocksQuery> baseContext) : base(baseContext) { }

        public DbSet<Company> Companies { get; set; }

        public DbSet<StockTrading> StockTradings { get; set; }
    }
}
