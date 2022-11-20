using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Harpoon.Migrations
{
    public partial class AddInterestRateDateAndLogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "InterestRates",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "LogNo",
                table: "InterestRates",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_InterestRates_LogNo",
                table: "InterestRates",
                column: "LogNo");

            migrationBuilder.AddForeignKey(
                name: "FK_InterestRates_Logs_LogNo",
                table: "InterestRates",
                column: "LogNo",
                principalTable: "Logs",
                principalColumn: "No",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterestRates_Logs_LogNo",
                table: "InterestRates");

            migrationBuilder.DropIndex(
                name: "IX_InterestRates_LogNo",
                table: "InterestRates");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "InterestRates");

            migrationBuilder.DropColumn(
                name: "LogNo",
                table: "InterestRates");
        }
    }
}
