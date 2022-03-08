using Microsoft.EntityFrameworkCore.Migrations;

namespace Harpoon.Migrations
{
    public partial class AddIndexComposition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "OutstandingShares",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "StockType",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "isListed",
                table: "Companies");

            migrationBuilder.RenameColumn(
                name: "Security",
                table: "Companies",
                newName: "Name");

            migrationBuilder.CreateTable(
                name: "CompanyMarketIndex",
                columns: table => new
                {
                    CompaniesCode = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    IndicesNo = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyMarketIndex", x => new { x.CompaniesCode, x.IndicesNo });
                    table.ForeignKey(
                        name: "FK_CompanyMarketIndex_Companies_CompaniesCode",
                        column: x => x.CompaniesCode,
                        principalTable: "Companies",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyMarketIndex_MarketIndices_IndicesNo",
                        column: x => x.IndicesNo,
                        principalTable: "MarketIndices",
                        principalColumn: "No",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyMarketIndex_IndicesNo",
                table: "CompanyMarketIndex",
                column: "IndicesNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyMarketIndex");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Companies",
                newName: "Security");

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "Companies",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "OutstandingShares",
                table: "Companies",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "StockType",
                table: "Companies",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isListed",
                table: "Companies",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
