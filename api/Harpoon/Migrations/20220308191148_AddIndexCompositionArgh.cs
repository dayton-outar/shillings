using Microsoft.EntityFrameworkCore.Migrations;

namespace Harpoon.Migrations
{
    public partial class AddIndexCompositionArgh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MarketIndices_Companies_CompanyCode",
                table: "MarketIndices");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_MarketIndices_MarketIndexNo",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_MarketIndexNo",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_MarketIndices_CompanyCode",
                table: "MarketIndices");

            migrationBuilder.DropColumn(
                name: "MarketIndexNo",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "CompanyCode",
                table: "MarketIndices");

            migrationBuilder.CreateTable(
                name: "MarketIndexStock",
                columns: table => new
                {
                    IndicesNo = table.Column<long>(type: "bigint", nullable: false),
                    StocksCode = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketIndexStock", x => new { x.IndicesNo, x.StocksCode });
                    table.ForeignKey(
                        name: "FK_MarketIndexStock_MarketIndices_IndicesNo",
                        column: x => x.IndicesNo,
                        principalTable: "MarketIndices",
                        principalColumn: "No",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarketIndexStock_Stocks_StocksCode",
                        column: x => x.StocksCode,
                        principalTable: "Stocks",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MarketIndexStock_StocksCode",
                table: "MarketIndexStock",
                column: "StocksCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarketIndexStock");

            migrationBuilder.AddColumn<long>(
                name: "MarketIndexNo",
                table: "Stocks",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyCode",
                table: "MarketIndices",
                type: "nvarchar(20)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_MarketIndexNo",
                table: "Stocks",
                column: "MarketIndexNo");

            migrationBuilder.CreateIndex(
                name: "IX_MarketIndices_CompanyCode",
                table: "MarketIndices",
                column: "CompanyCode");

            migrationBuilder.AddForeignKey(
                name: "FK_MarketIndices_Companies_CompanyCode",
                table: "MarketIndices",
                column: "CompanyCode",
                principalTable: "Companies",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_MarketIndices_MarketIndexNo",
                table: "Stocks",
                column: "MarketIndexNo",
                principalTable: "MarketIndices",
                principalColumn: "No",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
