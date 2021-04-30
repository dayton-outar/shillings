using Microsoft.EntityFrameworkCore.Migrations;

namespace Harpoon.Migrations
{
    public partial class AddLogToStockTradings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "LogNo",
                table: "StockTradings",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockTradings_LogNo",
                table: "StockTradings",
                column: "LogNo");

            migrationBuilder.AddForeignKey(
                name: "FK_StockTradings_Logs_LogNo",
                table: "StockTradings",
                column: "LogNo",
                principalTable: "Logs",
                principalColumn: "No",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockTradings_Logs_LogNo",
                table: "StockTradings");

            migrationBuilder.DropIndex(
                name: "IX_StockTradings_LogNo",
                table: "StockTradings");

            migrationBuilder.DropColumn(
                name: "LogNo",
                table: "StockTradings");
        }
    }
}
