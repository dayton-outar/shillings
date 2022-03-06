using Microsoft.EntityFrameworkCore.Migrations;

namespace Harpoon.Migrations
{
    public partial class AddStockforDividend : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StockCode",
                table: "Dividends",
                type: "nvarchar(20)",
                nullable: true);

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
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dividends_Stocks_StockCode",
                table: "Dividends");

            migrationBuilder.DropIndex(
                name: "IX_Dividends_StockCode",
                table: "Dividends");

            migrationBuilder.DropColumn(
                name: "StockCode",
                table: "Dividends");
        }
    }
}
