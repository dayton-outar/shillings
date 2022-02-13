using Microsoft.EntityFrameworkCore.Migrations;

namespace Harpoon.Migrations
{
    public partial class ModifyFinancialReportsReportFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StatementAnalytes_FinancialReports_No",
                table: "StatementAnalytes");

            migrationBuilder.AddColumn<long>(
                name: "ReportNo",
                table: "StatementAnalytes",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StatementAnalytes_ReportNo",
                table: "StatementAnalytes",
                column: "ReportNo");

            migrationBuilder.AddForeignKey(
                name: "FK_StatementAnalytes_FinancialReports_ReportNo",
                table: "StatementAnalytes",
                column: "ReportNo",
                principalTable: "FinancialReports",
                principalColumn: "No",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StatementAnalytes_FinancialReports_ReportNo",
                table: "StatementAnalytes");

            migrationBuilder.DropIndex(
                name: "IX_StatementAnalytes_ReportNo",
                table: "StatementAnalytes");

            migrationBuilder.DropColumn(
                name: "ReportNo",
                table: "StatementAnalytes");

            migrationBuilder.AddForeignKey(
                name: "FK_StatementAnalytes_FinancialReports_No",
                table: "StatementAnalytes",
                column: "No",
                principalTable: "FinancialReports",
                principalColumn: "No",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
