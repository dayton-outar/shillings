using Microsoft.EntityFrameworkCore.Migrations;

namespace Harpoon.Migrations
{
    public partial class ModifyStockTradingReference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockTradings_Companies_SecurityCode",
                table: "StockTradings");

            migrationBuilder.AddForeignKey(
                name: "FK_StockTradings_Stocks_SecurityCode",
                table: "StockTradings",
                column: "SecurityCode",
                principalTable: "Stocks",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockTradings_Stocks_SecurityCode",
                table: "StockTradings");

            migrationBuilder.AddForeignKey(
                name: "FK_StockTradings_Companies_SecurityCode",
                table: "StockTradings",
                column: "SecurityCode",
                principalTable: "Companies",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
