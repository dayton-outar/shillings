﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using O8Query.Data;

namespace Harpoon.Migrations
{
    [DbContext(typeof(StocksQuery))]
    partial class StocksQueryModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<DateTime>("Founded")
                        .HasColumnType("date");

                    b.Property<string>("Industry")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<long>("OutstandingShares")
                        .HasColumnType("bigint");

                    b.Property<string>("Security")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StockType")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

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

                    b.Property<bool>("isListed")
                        .HasColumnType("bit");

                    b.HasKey("Code");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("O8Query.Models.Dividend", b =>
                {
                    b.Property<long>("No")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<long?>("LogNo")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("RecordDate")
                        .HasColumnType("date");

                    b.Property<string>("SecurityCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("No");

                    b.HasIndex("LogNo");

                    b.ToTable("Dividends");
                });

            modelBuilder.Entity("O8Query.Models.FinancialReport", b =>
                {
                    b.Property<long>("No")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("IsAudited")
                        .HasColumnType("bit");

                    b.Property<long?>("LogNo")
                        .HasColumnType("bigint");

                    b.Property<int>("Period")
                        .HasColumnType("int");

                    b.Property<DateTime>("StatementDate")
                        .HasColumnType("date");

                    b.HasKey("No");

                    b.HasIndex("LogNo");

                    b.ToTable("FinancialReports");
                });

            modelBuilder.Entity("O8Query.Models.Log", b =>
                {
                    b.Property<long>("No")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                    b.Property<string>("Code")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("CompanyCode")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Code");

                    b.HasIndex("CompanyCode");

                    b.ToTable("Markets");
                });

            modelBuilder.Entity("O8Query.Models.StatementAnalyte", b =>
                {
                    b.Property<long>("No")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                    b.Property<string>("Code")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("CompanyCode")
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<long>("IssuedShares")
                        .HasColumnType("bigint");

                    b.Property<long>("OutstandingShares")
                        .HasColumnType("bigint");

                    b.Property<string>("StockType")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("isListed")
                        .HasColumnType("bit");

                    b.HasKey("Code");

                    b.HasIndex("CompanyCode");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("O8Query.Models.StockIndex", b =>
                {
                    b.Property<long>("No")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Index")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<long?>("LogNo")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValueChange")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("No");

                    b.HasIndex("Index");

                    b.HasIndex("LogNo");

                    b.ToTable("StockIndices");
                });

            modelBuilder.Entity("O8Query.Models.StockTrading", b =>
                {
                    b.Property<long>("No")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.Property<string>("SecurityCode")
                        .HasColumnType("nvarchar(20)");

                    b.Property<long>("Volume")
                        .HasColumnType("bigint");

                    b.HasKey("No");

                    b.HasIndex("LogNo");

                    b.HasIndex("SecurityCode");

                    b.ToTable("StockTradings");
                });

            modelBuilder.Entity("O8Query.Models.TotalStockTrades", b =>
                {
                    b.Property<DateTime>("ClosingDate")
                        .HasColumnType("date");

                    b.Property<decimal>("ClosingPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<string>("Security")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Volume")
                        .HasColumnType("bigint");

                    b.ToTable("TotalTrades");
                });

            modelBuilder.Entity("O8Query.Models.Dividend", b =>
                {
                    b.HasOne("O8Query.Models.Log", "Log")
                        .WithMany()
                        .HasForeignKey("LogNo");

                    b.Navigation("Log");
                });

            modelBuilder.Entity("O8Query.Models.FinancialReport", b =>
                {
                    b.HasOne("O8Query.Models.Log", "Log")
                        .WithMany()
                        .HasForeignKey("LogNo");

                    b.Navigation("Log");
                });

            modelBuilder.Entity("O8Query.Models.Market", b =>
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
                        .WithMany()
                        .HasForeignKey("CompanyCode");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("O8Query.Models.StockIndex", b =>
                {
                    b.HasOne("O8Query.Models.Market", "Market")
                        .WithMany()
                        .HasForeignKey("Index")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("O8Query.Models.Log", "Log")
                        .WithMany()
                        .HasForeignKey("LogNo");

                    b.Navigation("Log");

                    b.Navigation("Market");
                });

            modelBuilder.Entity("O8Query.Models.StockTrading", b =>
                {
                    b.HasOne("O8Query.Models.Log", "Log")
                        .WithMany()
                        .HasForeignKey("LogNo");

                    b.HasOne("O8Query.Models.Company", "Security")
                        .WithMany()
                        .HasForeignKey("SecurityCode");

                    b.Navigation("Log");

                    b.Navigation("Security");
                });

            modelBuilder.Entity("O8Query.Models.FinancialReport", b =>
                {
                    b.Navigation("Analytes");
                });
#pragma warning restore 612, 618
        }
    }
}
