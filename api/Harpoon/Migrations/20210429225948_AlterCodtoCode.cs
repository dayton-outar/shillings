using Microsoft.EntityFrameworkCore.Migrations;

namespace Harpoon.Migrations
{
    public partial class AlterCodtoCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockTradings_Companies_SecurityCod",
                table: "StockTradings");

            migrationBuilder.RenameColumn(
                name: "SecurityCod",
                table: "StockTradings",
                newName: "SecurityCode");

            migrationBuilder.RenameIndex(
                name: "IX_StockTradings_SecurityCod",
                table: "StockTradings",
                newName: "IX_StockTradings_SecurityCode");

            migrationBuilder.RenameColumn(
                name: "Cod",
                table: "Companies",
                newName: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_StockTradings_Companies_SecurityCode",
                table: "StockTradings",
                column: "SecurityCode",
                principalTable: "Companies",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockTradings_Companies_SecurityCode",
                table: "StockTradings");

            migrationBuilder.RenameColumn(
                name: "SecurityCode",
                table: "StockTradings",
                newName: "SecurityCod");

            migrationBuilder.RenameIndex(
                name: "IX_StockTradings_SecurityCode",
                table: "StockTradings",
                newName: "IX_StockTradings_SecurityCod");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Companies",
                newName: "Cod");

            migrationBuilder.AddForeignKey(
                name: "FK_StockTradings_Companies_SecurityCod",
                table: "StockTradings",
                column: "SecurityCod",
                principalTable: "Companies",
                principalColumn: "Cod",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
