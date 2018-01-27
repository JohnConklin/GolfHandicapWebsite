using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GolfHandicapCalculator.Migrations
{
    public partial class updatedHandicap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HandiCapID",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_HandiCapID",
                table: "Users",
                column: "HandiCapID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_HandiCaps_HandiCapID",
                table: "Users",
                column: "HandiCapID",
                principalTable: "HandiCaps",
                principalColumn: "HandiCapID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_HandiCaps_HandiCapID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_HandiCapID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "HandiCapID",
                table: "Users");
        }
    }
}
