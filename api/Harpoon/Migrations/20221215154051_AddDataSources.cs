using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Harpoon.Migrations
{
    public partial class AddDataSources : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "SourceNo",
                table: "Markets",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DataSources",
                columns: table => new
                {
                    No = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Endpoint = table.Column<string>(type: "nvarchar(2100)", maxLength: 2100, nullable: false),
                    Reader = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataSources", x => x.No);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Markets_SourceNo",
                table: "Markets",
                column: "SourceNo");

            migrationBuilder.AddForeignKey(
                name: "FK_Markets_DataSources_SourceNo",
                table: "Markets",
                column: "SourceNo",
                principalTable: "DataSources",
                principalColumn: "No");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Markets_DataSources_SourceNo",
                table: "Markets");

            migrationBuilder.DropTable(
                name: "DataSources");

            migrationBuilder.DropIndex(
                name: "IX_Markets_SourceNo",
                table: "Markets");

            migrationBuilder.DropColumn(
                name: "SourceNo",
                table: "Markets");
        }
    }
}
