using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Harpoon.Migrations
{
    public partial class AddFinancialStatements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FinancialStatements",
                columns: table => new
                {
                    No = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Period = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    StatementDate = table.Column<DateTime>(type: "date", nullable: false),
                    IsAudited = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialStatements", x => x.No);
                });

            migrationBuilder.CreateTable(
                name: "StatementAnalytes",
                columns: table => new
                {
                    No = table.Column<long>(type: "bigint", nullable: false),
                    Sequence = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Section = table.Column<int>(type: "int", nullable: false),
                    Analyte = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatementAnalytes", x => x.No);
                    table.ForeignKey(
                        name: "FK_StatementAnalytes_FinancialStatements_No",
                        column: x => x.No,
                        principalTable: "FinancialStatements",
                        principalColumn: "No",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StatementAnalytes");

            migrationBuilder.DropTable(
                name: "FinancialStatements");
        }
    }
}
