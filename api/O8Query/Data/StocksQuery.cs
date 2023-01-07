using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

using O8Query.Models;

namespace O8Query.Data
{
    public class StocksQuery: DbContext
    {
        public StocksQuery(DbContextOptions<StocksQuery> baseContext) : base(baseContext) { }

        public DbSet<Market> Markets { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Stock> Stocks { get; set; }

        public DbSet<MarketIndex> MarketIndices { get; set; }

        public DbSet<StockTrading> StockTradings { get; set; }

        public DbSet<StockIndex> StockIndices { get; set; }

        public DbSet<Log> Logs { get; set; }

        public DbSet<FinancialReport> FinancialReports { get; set; }

        public DbSet<StatementAnalyte> StatementAnalytes { get; set; }

        public DbSet<Dividend> Dividends { get; set; }

        public DbSet<Announcement> Announcements { get; set; }

        public DbSet<Industry> Industries { get; set; }

        public DbSet<FileContent> Files { get; set; }

        [NotMapped]
        public DbSet<TotalStockTrades> TotalTrades { get; set; }

        public DbSet<InterestRate> InterestRates { get; set; }

        [NotMapped]
        public DbSet<ReportedEarnings> Earnings { get; set; }

        [NotMapped]
        public DbSet<Solvency> Solvencies { get; set; }

        public DbSet<DataSource> DataSources { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //new StocksQuerySeeder(modelBuilder).Seed();
            modelBuilder.Entity<TotalStockTrades>().HasKey(t => new { t.No, t.ClosingDate });
            modelBuilder.Entity<ReportedEarnings>().HasKey(e => new { e.Code, e.StatementDate });
            modelBuilder.Entity<Solvency>().HasKey(s => new { s.Code, s.StatementDate });
        }
    }
}
