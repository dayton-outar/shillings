using Microsoft.EntityFrameworkCore.Migrations;

namespace Harpoon.Migrations
{
    public partial class AdjustIndexReference2Market : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockIndices_Markets_Index",
                table: "StockIndices");

            migrationBuilder.DropIndex(
                name: "IX_StockIndices_Index",
                table: "StockIndices");
        }
    }
}
