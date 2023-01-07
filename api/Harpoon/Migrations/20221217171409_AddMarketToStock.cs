using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Harpoon.Migrations
{
    public partial class AddMarketToStock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "MarketNo",
                table: "Stocks",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_MarketNo",
                table: "Stocks",
                column: "MarketNo");

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Markets_MarketNo",
                table: "Stocks",
                column: "MarketNo",
                principalTable: "Markets",
                principalColumn: "No");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Markets_MarketNo",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_MarketNo",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "MarketNo",
                table: "Stocks");
        }
    }
}
