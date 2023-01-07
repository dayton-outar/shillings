﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using O8Query.Data;

#nullable disable

namespace Harpoon.Migrations
{
    [DbContext(typeof(StocksQuery))]
    partial class StocksQueryModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AnnouncementCompany", b =>
                {
                    b.Property<long>("AnnouncementsNo")
                        .HasColumnType("bigint");

                    b.Property<string>("CompaniesCode")
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("AnnouncementsNo", "CompaniesCode");

                    b.HasIndex("CompaniesCode");

                    b.ToTable("AnnouncementCompany");
                });

            modelBuilder.Entity("CompanyFileContent", b =>
                {
                    b.Property<string>("CompaniesCode")
                        .HasColumnType("nvarchar(20)");

                    b.Property<long>("FilesNo")
                        .HasColumnType("bigint");

                    b.HasKey("CompaniesCode", "FilesNo");

                    b.HasIndex("FilesNo");

                    b.ToTable("CompanyFileContent");
                });

            modelBuilder.Entity("CompanyIndustry", b =>
                {
                    b.Property<string>("CompaniesCode")
                        .HasColumnType("nvarchar(20)");

                    b.Property<long>("IndustriesNo")
                        .HasColumnType("bigint");

                    b.HasKey("CompaniesCode", "IndustriesNo");

                    b.HasIndex("IndustriesNo");

                    b.ToTable("CompanyIndustry");
                });

            modelBuilder.Entity("DataSource", b =>
                {
                    b.Property<long>("No")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("No"), 1L, 1);

                    b.Property<string>("Endpoint")
                        .IsRequired()
                        .HasMaxLength(2100)
                        .HasColumnType("nvarchar(2100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Reader")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SourceType")
                        .HasColumnType("int");

                    b.HasKey("No");

                    b.ToTable("DataSources");
                });

            modelBuilder.Entity("IndustryMarketIndex", b =>
                {
                    b.Property<long>("IndustriesNo")
                        .HasColumnType("bigint");

                    b.Property<long>("MarketIndicesNo")
                        .HasColumnType("bigint");

                    b.HasKey("IndustriesNo", "MarketIndicesNo");

                    b.HasIndex("MarketIndicesNo");

                    b.ToTable("IndustryMarketIndex");
                });

            modelBuilder.Entity("MarketIndexStock", b =>
                {
                    b.Property<long>("IndicesNo")
                        .HasColumnType("bigint");

                    b.Property<long>("StocksNo")
                        .HasColumnType("bigint");

                    b.HasKey("IndicesNo", "StocksNo");

                    b.HasIndex("StocksNo");

                    b.ToTable("MarketIndexStock");
                });

            modelBuilder.Entity("O8Query.Models.Announcement", b =>
                {
                    b.Property<long>("No")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("No"), 1L, 1);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("LogNo")
                        .HasColumnType("bigint");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("No");

                    b.HasIndex("LogNo");

                    b.ToTable("Announcements");
                });

            modelBuilder.Entity("O8Query.Models.Company", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("About")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Founded")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalEmployed")
                        .HasColumnType("int");

                    b.Property<string>("WebSite")
                        .IsRequired()
                        .HasMaxLength(2100)
                        .HasColumnType("nvarchar(2100)");

                    b.Property<string>("Wiki")
                        .IsRequired()
                        .HasMaxLength(2100)
                        .HasColumnType("nvarchar(2100)");

                    b.HasKey("Code");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("O8Query.Models.Dividend", b =>
                {
                    b.Property<long>("No")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("No"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<long>("LogNo")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("RecordDate")
                        .HasColumnType("date");

                    b.Property<long>("StockNo")
                        .HasColumnType("bigint");

                    b.HasKey("No");

                    b.HasIndex("LogNo");

                    b.HasIndex("StockNo");

                    b.ToTable("Dividends");
                });

            modelBuilder.Entity("O8Query.Models.FileContent", b =>
                {
                    b.Property<long>("No")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("No"), 1L, 1);

                    b.Property<byte[]>("Content")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("ContentSize")
                        .HasColumnType("int");

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("No");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("O8Query.Models.FinancialReport", b =>
                {
                    b.Property<long>("No")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("No"), 1L, 1);

                    b.Property<string>("CompanyCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("IsAudited")
                        .HasColumnType("bit");

                    b.Property<long>("LogNo")
                        .HasColumnType("bigint");

                    b.Property<int>("Period")
                        .HasColumnType("int");

                    b.Property<DateTime>("StatementDate")
                        .HasColumnType("date");

                    b.HasKey("No");

                    b.HasIndex("CompanyCode");

                    b.HasIndex("LogNo");

                    b.ToTable("FinancialReports");
                });

            modelBuilder.Entity("O8Query.Models.Industry", b =>
                {
                    b.Property<long>("No")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("No"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Wiki")
                        .IsRequired()
                        .HasMaxLength(2100)
                        .HasColumnType("nvarchar(2100)");

                    b.HasKey("No");

                    b.ToTable("Industries");
                });

            modelBuilder.Entity("O8Query.Models.InterestRate", b =>
                {
                    b.Property<long>("No")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("No"), 1L, 1);

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<long>("LogNo")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(5,4)");

                    b.Property<int>("Term")
                        .HasColumnType("int");

                    b.HasKey("No");

                    b.HasIndex("LogNo");

                    b.ToTable("InterestRates");
                });

            modelBuilder.Entity("O8Query.Models.Log", b =>
                {
                    b.Property<long>("No")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("No"), 1L, 1);

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Event")
                        .HasColumnType("int");

                    b.Property<DateTime>("Logged")
                        .HasColumnType("datetime2");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("No");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("O8Query.Models.Market", b =>
                {
                    b.Property<long>("No")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("No"), 1L, 1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("CompanyCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("SourceNo")
                        .HasColumnType("bigint");

                    b.HasKey("No");

                    b.HasIndex("CompanyCode");

                    b.HasIndex("SourceNo");

                    b.ToTable("Markets");
                });

            modelBuilder.Entity("O8Query.Models.MarketIndex", b =>
                {
                    b.Property<long>("No")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("No"), 1L, 1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<long>("MarketNo")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("No");

                    b.HasIndex("MarketNo");

                    b.ToTable("MarketIndices");
                });

            modelBuilder.Entity("O8Query.Models.ReportedEarnings", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("StatementDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CompanyCode")
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal>("Earnings")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Margin")
                        .HasColumnType("decimal(5,4)");

                    b.Property<decimal>("Revenues")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Code", "StatementDate");

                    b.HasIndex("CompanyCode");

                    b.ToTable("Earnings");
                });

            modelBuilder.Entity("O8Query.Models.Solvency", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("StatementDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Assets")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CompanyCode")
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal>("Current")
                        .HasColumnType("decimal(5,4)");

                    b.Property<decimal>("Debt")
                        .HasColumnType("decimal(5,4)");

                    b.HasKey("Code", "StatementDate");

                    b.HasIndex("CompanyCode");

                    b.ToTable("Solvencies");
                });

            modelBuilder.Entity("O8Query.Models.StatementAnalyte", b =>
                {
                    b.Property<long>("No")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("No"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Analyte")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<long?>("ReportNo")
                        .HasColumnType("bigint");

                    b.Property<int>("Section")
                        .HasColumnType("int");

                    b.Property<int>("Sequence")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("No");

                    b.HasIndex("ReportNo");

                    b.ToTable("StatementAnalytes");
                });

            modelBuilder.Entity("O8Query.Models.Stock", b =>
                {
                    b.Property<long>("No")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("No"), 1L, 1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("CompanyCode")
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Currency")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<long?>("IssuedShares")
                        .HasColumnType("bigint");

                    b.Property<long?>("MarketNo")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("OutstandingShares")
                        .HasColumnType("bigint");

                    b.Property<int>("StockType")
                        .HasColumnType("int");

                    b.Property<bool>("isListed")
                        .HasColumnType("bit");

                    b.HasKey("No");

                    b.HasIndex("CompanyCode");

                    b.HasIndex("MarketNo");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("O8Query.Models.StockIndex", b =>
                {
                    b.Property<long>("No")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("No"), 1L, 1);

                    b.Property<long?>("LogNo")
                        .HasColumnType("bigint");

                    b.Property<long>("MarketIndexNo")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValueChange")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("No");

                    b.HasIndex("LogNo");

                    b.HasIndex("MarketIndexNo");

                    b.ToTable("StockIndices");
                });

            modelBuilder.Entity("O8Query.Models.StockTrading", b =>
                {
                    b.Property<long>("No")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("No"), 1L, 1);

                    b.Property<decimal>("ClosingPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<long?>("LogNo")
                        .HasColumnType("bigint");

                    b.Property<decimal>("MarketCapitalization")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Percentage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PriceChange")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("StockNo")
                        .HasColumnType("bigint");

                    b.Property<long>("Volume")
                        .HasColumnType("bigint");

                    b.HasKey("No");

                    b.HasIndex("LogNo");

                    b.HasIndex("StockNo");

                    b.ToTable("StockTradings");
                });

            modelBuilder.Entity("O8Query.Models.TotalStockTrades", b =>
                {
                    b.Property<long>("No")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("ClosingDate")
                        .HasColumnType("date");

                    b.Property<decimal>("ClosingPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("HighestPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("LowestPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("OpeningDate")
                        .HasColumnType("date");

                    b.Property<decimal>("OpeningPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Percentage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Prices")
                        .HasColumnType("xml");

                    b.Property<long?>("StockNo")
                        .HasColumnType("bigint");

                    b.Property<long>("Volume")
                        .HasColumnType("bigint");

                    b.HasKey("No", "ClosingDate");

                    b.HasIndex("StockNo");

                    b.ToTable("TotalTrades");
                });

            modelBuilder.Entity("AnnouncementCompany", b =>
                {
                    b.HasOne("O8Query.Models.Announcement", null)
                        .WithMany()
                        .HasForeignKey("AnnouncementsNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("O8Query.Models.Company", null)
                        .WithMany()
                        .HasForeignKey("CompaniesCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CompanyFileContent", b =>
                {
                    b.HasOne("O8Query.Models.Company", null)
                        .WithMany()
                        .HasForeignKey("CompaniesCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("O8Query.Models.FileContent", null)
                        .WithMany()
                        .HasForeignKey("FilesNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CompanyIndustry", b =>
                {
                    b.HasOne("O8Query.Models.Company", null)
                        .WithMany()
                        .HasForeignKey("CompaniesCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("O8Query.Models.Industry", null)
                        .WithMany()
                        .HasForeignKey("IndustriesNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IndustryMarketIndex", b =>
                {
                    b.HasOne("O8Query.Models.Industry", null)
                        .WithMany()
                        .HasForeignKey("IndustriesNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("O8Query.Models.MarketIndex", null)
                        .WithMany()
                        .HasForeignKey("MarketIndicesNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MarketIndexStock", b =>
                {
                    b.HasOne("O8Query.Models.MarketIndex", null)
                        .WithMany()
                        .HasForeignKey("IndicesNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("O8Query.Models.Stock", null)
                        .WithMany()
                        .HasForeignKey("StocksNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("O8Query.Models.Announcement", b =>
                {
                    b.HasOne("O8Query.Models.Log", "Log")
                        .WithMany()
                        .HasForeignKey("LogNo");

                    b.Navigation("Log");
                });

            modelBuilder.Entity("O8Query.Models.Dividend", b =>
                {
                    b.HasOne("O8Query.Models.Log", "Log")
                        .WithMany()
                        .HasForeignKey("LogNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("O8Query.Models.Stock", "Stock")
                        .WithMany()
                        .HasForeignKey("StockNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Log");

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("O8Query.Models.FinancialReport", b =>
                {
                    b.HasOne("O8Query.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("O8Query.Models.Log", "Log")
                        .WithMany()
                        .HasForeignKey("LogNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Log");
                });

            modelBuilder.Entity("O8Query.Models.InterestRate", b =>
                {
                    b.HasOne("O8Query.Models.Log", "Log")
                        .WithMany()
                        .HasForeignKey("LogNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Log");
                });

            modelBuilder.Entity("O8Query.Models.Market", b =>
                {
                    b.HasOne("O8Query.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataSource", "Source")
                        .WithMany()
                        .HasForeignKey("SourceNo");

                    b.Navigation("Company");

                    b.Navigation("Source");
                });

            modelBuilder.Entity("O8Query.Models.MarketIndex", b =>
                {
                    b.HasOne("O8Query.Models.Market", "Market")
                        .WithMany()
                        .HasForeignKey("MarketNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Market");
                });

            modelBuilder.Entity("O8Query.Models.ReportedEarnings", b =>
                {
                    b.HasOne("O8Query.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyCode");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("O8Query.Models.Solvency", b =>
                {
                    b.HasOne("O8Query.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyCode");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("O8Query.Models.StatementAnalyte", b =>
                {
                    b.HasOne("O8Query.Models.FinancialReport", "Report")
                        .WithMany("Analytes")
                        .HasForeignKey("ReportNo");

                    b.Navigation("Report");
                });

            modelBuilder.Entity("O8Query.Models.Stock", b =>
                {
                    b.HasOne("O8Query.Models.Company", "Company")
                        .WithMany("Stocks")
                        .HasForeignKey("CompanyCode");

                    b.HasOne("O8Query.Models.Market", "Market")
                        .WithMany()
                        .HasForeignKey("MarketNo");

                    b.Navigation("Company");

                    b.Navigation("Market");
                });

            modelBuilder.Entity("O8Query.Models.StockIndex", b =>
                {
                    b.HasOne("O8Query.Models.Log", "Log")
                        .WithMany()
                        .HasForeignKey("LogNo");

                    b.HasOne("O8Query.Models.MarketIndex", "MarketIndex")
                        .WithMany()
                        .HasForeignKey("MarketIndexNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Log");

                    b.Navigation("MarketIndex");
                });

            modelBuilder.Entity("O8Query.Models.StockTrading", b =>
                {
                    b.HasOne("O8Query.Models.Log", "Log")
                        .WithMany()
                        .HasForeignKey("LogNo");

                    b.HasOne("O8Query.Models.Stock", "Stock")
                        .WithMany()
                        .HasForeignKey("StockNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Log");

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("O8Query.Models.TotalStockTrades", b =>
                {
                    b.HasOne("O8Query.Models.Stock", "Stock")
                        .WithMany()
                        .HasForeignKey("StockNo");

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("O8Query.Models.Company", b =>
                {
                    b.Navigation("Stocks");
                });

            modelBuilder.Entity("O8Query.Models.FinancialReport", b =>
                {
                    b.Navigation("Analytes");
                });
#pragma warning restore 612, 618
        }
    }
}
