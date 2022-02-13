using Microsoft.EntityFrameworkCore.Migrations;

namespace Harpoon.Migrations
{
    public partial class ModifyFinancialReportsReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StatementAnalytes_FinancialReports_FinancialReportNo",
                table: "StatementAnalytes");

            migrationBuilder.DropIndex(
                name: "IX_StatementAnalytes_FinancialReportNo",
                table: "StatementAnalytes");

            migrationBuilder.DropColumn(
                name: "FinancialReportNo",
                table: "StatementAnalytes");

            migrationBuilder.AddForeignKey(
                name: "FK_StatementAnalytes_FinancialReports_No",
                table: "StatementAnalytes",
                column: "No",
                principalTable: "FinancialReports",
                principalColumn: "No",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StatementAnalytes_FinancialReports_No",
                table: "StatementAnalytes");

            migrationBuilder.AddColumn<long>(
                name: "FinancialReportNo",
                table: "StatementAnalytes",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FinancialStatement",
                columns: table => new
                {
                    No = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialStatement", x => x.No);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StatementAnalytes_FinancialReportNo",
                table: "StatementAnalytes",
                column: "FinancialReportNo");

            migrationBuilder.AddForeignKey(
                name: "FK_StatementAnalytes_FinancialReports_FinancialReportNo",
                table: "StatementAnalytes",
                column: "FinancialReportNo",
                principalTable: "FinancialReports",
                principalColumn: "No",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StatementAnalytes_FinancialStatement_No",
                table: "StatementAnalytes",
                column: "No",
                principalTable: "FinancialStatement",
                principalColumn: "No",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
