using Microsoft.EntityFrameworkCore.Migrations;

namespace Harpoon.Migrations
{
    public partial class MarketIndicesReferenceNotNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockIndices_Markets_Index",
                table: "StockIndices");

            migrationBuilder.DropIndex(
                name: "IX_StockIndices_Index",
                table: "StockIndices");

            migrationBuilder.DropColumn(
                name: "Index",
                table: "StockIndices");

            migrationBuilder.DropForeignKey(
                name: "FK_StockIndices_MarketIndices_MarketIndexNo",
                table: "StockIndices");

            migrationBuilder.DropIndex(
                name: "IX_StockIndices_MarketIndexNo",
                table: "StockIndices");
            
            migrationBuilder.AlterColumn<long>(
                name: "MarketIndexNo",
                table: "StockIndices",
                type: "bigint",
                nullable: false);

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
            migrationBuilder.AddColumn<string>(
                name: "Index",
                table: "StockIndices",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_StockIndices_Index",
                table: "StockIndices",
                column: "Index");

            migrationBuilder.AddForeignKey(
                name: "FK_StockIndices_Markets_Index",
                table: "StockIndices",
                column: "Index",
                principalTable: "Markets",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
