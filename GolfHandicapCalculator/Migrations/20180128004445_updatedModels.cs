using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GolfHandicapCalculator.Migrations
{
    public partial class updatedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_HandiCaps_HandiCapID",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Rounds_RoundID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_HandiCapID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoundID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "HandiCapID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RoundID",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HandiCapID",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoundID",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_HandiCapID",
                table: "Users",
                column: "HandiCapID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoundID",
                table: "Users",
                column: "RoundID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_HandiCaps_HandiCapID",
                table: "Users",
                column: "HandiCapID",
                principalTable: "HandiCaps",
                principalColumn: "HandiCapID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Rounds_RoundID",
                table: "Users",
                column: "RoundID",
                principalTable: "Rounds",
                principalColumn: "RoundID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
