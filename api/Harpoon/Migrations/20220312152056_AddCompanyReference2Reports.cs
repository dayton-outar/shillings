using Microsoft.EntityFrameworkCore.Migrations;

namespace Harpoon.Migrations
{
    public partial class AddCompanyReference2Reports : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CompanyCode",
                table: "FinancialReports",
                type: "nvarchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.CreateIndex(
                name: "IX_FinancialReports_CompanyCode",
                table: "FinancialReports",
                column: "CompanyCode");

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialReports_Companies_CompanyCode",
                table: "FinancialReports",
                column: "CompanyCode",
                principalTable: "Companies",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinancialReports_Companies_CompanyCode",
                table: "FinancialReports");

            migrationBuilder.DropIndex(
                name: "IX_FinancialReports_CompanyCode",
                table: "FinancialReports");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyCode",
                table: "FinancialReports",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldNullable: true);
        }
    }
}
