using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Harpoon.Migrations
{
    public partial class AddTermToInterestRates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Term",
                table: "InterestRates",
                type: "int",
                nullable: false,
                defaultValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Term",
                table: "InterestRates");
        }
    }
}
