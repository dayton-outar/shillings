using Microsoft.EntityFrameworkCore.Migrations;

namespace Harpoon.Migrations
{
    public partial class AddMarketIndicesReference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "MarketIndexNo",
                table: "StockIndices",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockIndices_MarketIndexNo",
                table: "StockIndices",
                column: "MarketIndexNo");

            migrationBuilder.AddForeignKey(
                name: "FK_StockIndices_MarketIndices_MarketIndexNo",
                table: "StockIndices",
                column: "MarketIndexNo",
                principalTable: "MarketIndices",
                principalColumn: "No",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockIndices_MarketIndices_MarketIndexNo",
                table: "StockIndices");

            migrationBuilder.DropIndex(
                name: "IX_StockIndices_MarketIndexNo",
                table: "StockIndices");

            migrationBuilder.DropColumn(
                name: "MarketIndexNo",
                table: "StockIndices");
        }
    }
}
