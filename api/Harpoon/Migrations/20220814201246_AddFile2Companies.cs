using Microsoft.EntityFrameworkCore.Migrations;

namespace Harpoon.Migrations
{
    public partial class AddFile2Companies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyFileContent",
                columns: table => new
                {
                    CompaniesCode = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    FilesNo = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyFileContent", x => new { x.CompaniesCode, x.FilesNo });
                    table.ForeignKey(
                        name: "FK_CompanyFileContent_Companies_CompaniesCode",
                        column: x => x.CompaniesCode,
                        principalTable: "Companies",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyFileContent_Files_FilesNo",
                        column: x => x.FilesNo,
                        principalTable: "Files",
                        principalColumn: "No",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyFileContent_FilesNo",
                table: "CompanyFileContent",
                column: "FilesNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyFileContent");
        }
    }
}
