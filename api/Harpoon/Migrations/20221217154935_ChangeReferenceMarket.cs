using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Harpoon.Migrations
{
    public partial class ChangeReferenceMarket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MarketIndices_Markets_MarketCode",
                table: "MarketIndices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Markets",
                table: "Markets");

            migrationBuilder.DropIndex(
                name: "IX_MarketIndices_MarketCode",
                table: "MarketIndices");

            migrationBuilder.DropColumn(
                name: "MarketCode",
                table: "MarketIndices");

            migrationBuilder.AddColumn<long>(
                name: "MarketNo",
                table: "MarketIndices",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Markets",
                table: "Markets",
                column: "No");

            migrationBuilder.CreateIndex(
                name: "IX_MarketIndices_MarketNo",
                table: "MarketIndices",
                column: "MarketNo");

            migrationBuilder.AddForeignKey(
                name: "FK_MarketIndices_Markets_MarketNo",
                table: "MarketIndices",
                column: "MarketNo",
                principalTable: "Markets",
                principalColumn: "No",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MarketIndices_Markets_MarketNo",
                table: "MarketIndices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Markets",
                table: "Markets");

            migrationBuilder.DropIndex(
                name: "IX_MarketIndices_MarketNo",
                table: "MarketIndices");

            migrationBuilder.DropColumn(
                name: "MarketNo",
                table: "MarketIndices");

            migrationBuilder.AddColumn<string>(
                name: "MarketCode",
                table: "MarketIndices",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Markets",
                table: "Markets",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_MarketIndices_MarketCode",
                table: "MarketIndices",
                column: "MarketCode");

            migrationBuilder.AddForeignKey(
                name: "FK_MarketIndices_Markets_MarketCode",
                table: "MarketIndices",
                column: "MarketCode",
                principalTable: "Markets",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
