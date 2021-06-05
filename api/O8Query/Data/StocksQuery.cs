﻿using Microsoft.EntityFrameworkCore;

using O8Query.Models;

namespace O8Query.Data
{
    public class StocksQuery: DbContext
    {
        public StocksQuery(DbContextOptions<StocksQuery> baseContext) : base(baseContext) { }

        public DbSet<Company> Companies { get; set; }

        public DbSet<StockTrading> StockTradings { get; set; }

        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //new StocksQuerySeeder(modelBuilder).Seed();
        }
    }
}
