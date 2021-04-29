using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Harpoon.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Cod = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Security = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Cod);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    No = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Event = table.Column<int>(type: "int", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logged = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.No);
                });

            migrationBuilder.CreateTable(
                name: "StockTradings",
                columns: table => new
                {
                    No = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SecurityCod = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Volume = table.Column<long>(type: "bigint", nullable: false),
                    ClosingPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceChange = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Percentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockTradings", x => x.No);
                    table.ForeignKey(
                        name: "FK_StockTradings_Companies_SecurityCod",
                        column: x => x.SecurityCod,
                        principalTable: "Companies",
                        principalColumn: "Cod",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StockTradings_SecurityCod",
                table: "StockTradings",
                column: "SecurityCod");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "StockTradings");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
