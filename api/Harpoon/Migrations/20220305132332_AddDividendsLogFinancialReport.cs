using Microsoft.EntityFrameworkCore.Migrations;

namespace Harpoon.Migrations
{
    public partial class AddDividendsLogFinancialReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "LogNo",
                table: "FinancialReports",
                type: "bigint",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FinancialReports_LogNo",
                table: "FinancialReports",
                column: "LogNo");

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialReports_Logs_LogNo",
                table: "FinancialReports",
                column: "LogNo",
                principalTable: "Logs",
                principalColumn: "No",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinancialReports_Logs_LogNo",
                table: "FinancialReports");

            migrationBuilder.DropIndex(
                name: "IX_FinancialReports_LogNo",
                table: "FinancialReports");

            migrationBuilder.DropColumn(
                name: "LogNo",
                table: "FinancialReports");
        }
    }
}
