using Microsoft.EntityFrameworkCore.Migrations;

namespace Harpoon.Migrations
{
    public partial class AddIndustries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Industries",
                columns: table => new
                {
                    No = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Wiki = table.Column<string>(type: "nvarchar(2100)", maxLength: 2100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Industries", x => x.No);
                });

            migrationBuilder.CreateTable(
                name: "CompanyIndustry",
                columns: table => new
                {
                    CompaniesCode = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    IndustriesNo = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyIndustry", x => new { x.CompaniesCode, x.IndustriesNo });
                    table.ForeignKey(
                        name: "FK_CompanyIndustry_Companies_CompaniesCode",
                        column: x => x.CompaniesCode,
                        principalTable: "Companies",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyIndustry_Industries_IndustriesNo",
                        column: x => x.IndustriesNo,
                        principalTable: "Industries",
                        principalColumn: "No",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyIndustry_IndustriesNo",
                table: "CompanyIndustry",
                column: "IndustriesNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyIndustry");

            migrationBuilder.DropTable(
                name: "Industries");
        }
    }
}
