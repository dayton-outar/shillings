using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Harpoon.Migrations
{
    public partial class AddCode2MarketIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "MarketIndices",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "MarketIndices");
        }
    }
}
