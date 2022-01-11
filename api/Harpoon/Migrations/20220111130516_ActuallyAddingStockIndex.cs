using Microsoft.EntityFrameworkCore.Migrations;

namespace Harpoon.Migrations
{
    public partial class ActuallyAddingStockIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StockIndices",
                columns: table => new
                {
                    No = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Index = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValueChange = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LogNo = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockIndices", x => x.No);
                    table.ForeignKey(
                        name: "FK_StockIndices_Logs_LogNo",
                        column: x => x.LogNo,
                        principalTable: "Logs",
                        principalColumn: "No",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StockIndices_LogNo",
                table: "StockIndices",
                column: "LogNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockIndices");
        }
    }
}
