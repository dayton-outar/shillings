using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Harpoon.Migrations
{
    public partial class AddInterestRates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InterestRates",
                columns: table => new
                {
                    No = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(5,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestRates", x => x.No);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterestRates");
        }
    }
}
