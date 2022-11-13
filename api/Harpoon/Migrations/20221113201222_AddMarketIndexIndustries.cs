using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Harpoon.Migrations
{
    public partial class AddMarketIndexIndustries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IndustryMarketIndex",
                columns: table => new
                {
                    IndustriesNo = table.Column<long>(type: "bigint", nullable: false),
                    MarketIndicesNo = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndustryMarketIndex", x => new { x.IndustriesNo, x.MarketIndicesNo });
                    table.ForeignKey(
                        name: "FK_IndustryMarketIndex_Industries_IndustriesNo",
                        column: x => x.IndustriesNo,
                        principalTable: "Industries",
                        principalColumn: "No",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IndustryMarketIndex_MarketIndices_MarketIndicesNo",
                        column: x => x.MarketIndicesNo,
                        principalTable: "MarketIndices",
                        principalColumn: "No",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IndustryMarketIndex_MarketIndicesNo",
                table: "IndustryMarketIndex",
                column: "MarketIndicesNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IndustryMarketIndex");
        }
    }
}
