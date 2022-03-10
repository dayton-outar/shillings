using Microsoft.EntityFrameworkCore.Migrations;

namespace Harpoon.Migrations
{
    public partial class AddCompanyAnnouncements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Announcements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AnnouncementCompany",
                columns: table => new
                {
                    AnnouncementsNo = table.Column<long>(type: "bigint", nullable: false),
                    CompaniesCode = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnouncementCompany", x => new { x.AnnouncementsNo, x.CompaniesCode });
                    table.ForeignKey(
                        name: "FK_AnnouncementCompany_Announcements_AnnouncementsNo",
                        column: x => x.AnnouncementsNo,
                        principalTable: "Announcements",
                        principalColumn: "No",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnnouncementCompany_Companies_CompaniesCode",
                        column: x => x.CompaniesCode,
                        principalTable: "Companies",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementCompany_CompaniesCode",
                table: "AnnouncementCompany",
                column: "CompaniesCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnnouncementCompany");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Announcements");
        }
    }
}
