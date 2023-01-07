using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Harpoon.Migrations
{
    public partial class ChangeReferenceStock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dividends_Stocks_StockCode",
                table: "Dividends");

            migrationBuilder.DropForeignKey(
                name: "FK_MarketIndexStock_Stocks_StocksCode",
                table: "MarketIndexStock");

            migrationBuilder.DropForeignKey(
                name: "FK_StockTradings_Stocks_SecurityCode",
                table: "StockTradings");
            
            migrationBuilder.DropForeignKey(
                name: "FK_OutstandingSharesLog_Stocks_Code",
                table: "OutstandingSharesLog");

            migrationBuilder.DropIndex(
                name: "IX_StockTradings_SecurityCode",
                table: "StockTradings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stocks",
                table: "Stocks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MarketIndexStock",
                table: "MarketIndexStock");

            migrationBuilder.DropIndex(
                name: "IX_MarketIndexStock_StocksCode",
                table: "MarketIndexStock");

            migrationBuilder.DropIndex(
                name: "IX_Dividends_StockCode",
                table: "Dividends");

            migrationBuilder.DropColumn(
                name: "SecurityCode",
                table: "StockTradings");

            migrationBuilder.DropColumn(
                name: "StocksCode",
                table: "MarketIndexStock");

            migrationBuilder.DropColumn(
                name: "StockCode",
                table: "Dividends");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "OutstandingSharesLog");

            migrationBuilder.AddColumn<long>(
                name: "StockNo",
                table: "StockTradings",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "StocksNo",
                table: "MarketIndexStock",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "StockNo",
                table: "Dividends",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
            
            migrationBuilder.AddColumn<long>(
                name: "StockNo",
                table: "OutstandingSharesLog",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stocks",
                table: "Stocks",
                column: "No");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MarketIndexStock",
                table: "MarketIndexStock",
                columns: new[] { "IndicesNo", "StocksNo" });

            migrationBuilder.CreateIndex(
                name: "IX_StockTradings_StockNo",
                table: "StockTradings",
                column: "StockNo");

            migrationBuilder.CreateIndex(
                name: "IX_MarketIndexStock_StocksNo",
                table: "MarketIndexStock",
                column: "StocksNo");

            migrationBuilder.CreateIndex(
                name: "IX_Dividends_StockNo",
                table: "Dividends",
                column: "StockNo");
            
            migrationBuilder.CreateIndex(
                name: "IX_OutstandingSharesLog_StockNo",
                table: "OutstandingSharesLog",
                column: "StockNo");

            migrationBuilder.AddForeignKey(
                name: "FK_OutstandingSharesLog_Stocks_StockNo",
                table: "OutstandingSharesLog",
                column: "StockNo",
                principalTable: "Stocks",
                principalColumn: "No",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dividends_Stocks_StockNo",
                table: "Dividends",
                column: "StockNo",
                principalTable: "Stocks",
                principalColumn: "No",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MarketIndexStock_Stocks_StocksNo",
                table: "MarketIndexStock",
                column: "StocksNo",
                principalTable: "Stocks",
                principalColumn: "No",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StockTradings_Stocks_StockNo",
                table: "StockTradings",
                column: "StockNo",
                principalTable: "Stocks",
                principalColumn: "No",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dividends_Stocks_StockNo",
                table: "Dividends");

            migrationBuilder.DropForeignKey(
                name: "FK_MarketIndexStock_Stocks_StocksNo",
                table: "MarketIndexStock");

            migrationBuilder.DropForeignKey(
                name: "FK_StockTradings_Stocks_StockNo",
                table: "StockTradings");

            migrationBuilder.DropForeignKey(
                name: "FK_TotalTrades_Stocks_StockCode",
                table: "TotalTrades");

            migrationBuilder.DropIndex(
                name: "IX_StockTradings_StockNo",
                table: "StockTradings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stocks",
                table: "Stocks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MarketIndexStock",
                table: "MarketIndexStock");

            migrationBuilder.DropIndex(
                name: "IX_MarketIndexStock_StocksNo",
                table: "MarketIndexStock");

            migrationBuilder.DropIndex(
                name: "IX_Dividends_StockNo",
                table: "Dividends");

            migrationBuilder.DropColumn(
                name: "StockNo",
                table: "StockTradings");

            migrationBuilder.DropColumn(
                name: "StocksNo",
                table: "MarketIndexStock");

            migrationBuilder.DropColumn(
                name: "StockNo",
                table: "Dividends");

            migrationBuilder.AlterColumn<string>(
                name: "StockCode",
                table: "TotalTrades",
                type: "nvarchar(20)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecurityCode",
                table: "StockTradings",
                type: "nvarchar(20)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StocksCode",
                table: "MarketIndexStock",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StockCode",
                table: "Dividends",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stocks",
                table: "Stocks",
                column: "Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MarketIndexStock",
                table: "MarketIndexStock",
                columns: new[] { "IndicesNo", "StocksCode" });

            migrationBuilder.CreateIndex(
                name: "IX_StockTradings_SecurityCode",
                table: "StockTradings",
                column: "SecurityCode");

            migrationBuilder.CreateIndex(
                name: "IX_MarketIndexStock_StocksCode",
                table: "MarketIndexStock",
                column: "StocksCode");

            migrationBuilder.CreateIndex(
                name: "IX_Dividends_StockCode",
                table: "Dividends",
                column: "StockCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Dividends_Stocks_StockCode",
                table: "Dividends",
                column: "StockCode",
                principalTable: "Stocks",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MarketIndexStock_Stocks_StocksCode",
                table: "MarketIndexStock",
                column: "StocksCode",
                principalTable: "Stocks",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockTradings_Stocks_SecurityCode",
                table: "StockTradings",
                column: "SecurityCode",
                principalTable: "Stocks",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_TotalTrades_Stocks_StockCode",
                table: "TotalTrades",
                column: "StockCode",
                principalTable: "Stocks",
                principalColumn: "Code");
        }
    }
}
