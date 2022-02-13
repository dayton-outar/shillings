using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Harpoon.Migrations
{
    public partial class ModifyFinancialReports : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StatementAnalytes_FinancialStatements_No",
                table: "StatementAnalytes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FinancialStatements",
                table: "FinancialStatements");

            migrationBuilder.DropTable(
                name: "FinancialStatements");

            migrationBuilder.DropColumn(
                name: "CompanyCode",
                table: "FinancialStatements");

            migrationBuilder.DropColumn(
                name: "IsAudited",
                table: "FinancialStatements");

            migrationBuilder.DropColumn(
                name: "Period",
                table: "FinancialStatements");

            migrationBuilder.DropColumn(
                name: "StatementDate",
                table: "FinancialStatements");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "FinancialStatements");

            migrationBuilder.RenameTable(
                name: "FinancialStatements",
                newName: "FinancialStatement");

            migrationBuilder.AddColumn<long>(
                name: "FinancialReportNo",
                table: "StatementAnalytes",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "StatementAnalytes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FinancialStatement",
                table: "FinancialStatement",
                column: "No");

            migrationBuilder.CreateTable(
                name: "FinancialReports",
                columns: table => new
                {
                    No = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Period = table.Column<int>(type: "int", nullable: false),
                    StatementDate = table.Column<DateTime>(type: "date", nullable: false),
                    IsAudited = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialReports", x => x.No);
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StatementAnalytes_FinancialReports_FinancialReportNo",
                table: "StatementAnalytes");

            migrationBuilder.DropForeignKey(
                name: "FK_StatementAnalytes_FinancialStatement_No",
                table: "StatementAnalytes");

            migrationBuilder.DropTable(
                name: "FinancialReports");

            migrationBuilder.DropIndex(
                name: "IX_StatementAnalytes_FinancialReportNo",
                table: "StatementAnalytes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FinancialStatement",
                table: "FinancialStatement");

            migrationBuilder.DropColumn(
                name: "FinancialReportNo",
                table: "StatementAnalytes");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "StatementAnalytes");

            migrationBuilder.RenameTable(
                name: "FinancialStatement",
                newName: "FinancialStatements");

            migrationBuilder.AddColumn<string>(
                name: "CompanyCode",
                table: "FinancialStatements",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsAudited",
                table: "FinancialStatements",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "FinancialStatements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "StatementDate",
                table: "FinancialStatements",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "FinancialStatements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FinancialStatements",
                table: "FinancialStatements",
                column: "No");

            migrationBuilder.AddForeignKey(
                name: "FK_StatementAnalytes_FinancialStatements_No",
                table: "StatementAnalytes",
                column: "No",
                principalTable: "FinancialStatements",
                principalColumn: "No",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
