using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GolfHandicapCalculator.Migrations
{
    public partial class updatedRound : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoundID",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoundID",
                table: "Users",
                column: "RoundID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Rounds_RoundID",
                table: "Users",
                column: "RoundID",
                principalTable: "Rounds",
                principalColumn: "RoundID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Rounds_RoundID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoundID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RoundID",
                table: "Users");
        }
    }
}
