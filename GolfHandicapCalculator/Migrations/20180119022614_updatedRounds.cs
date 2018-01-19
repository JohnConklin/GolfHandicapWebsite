using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GolfHandicapCalculator.Migrations
{
    public partial class updatedRounds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GolfCourses_Rounds_RoundID",
                table: "GolfCourses");

            migrationBuilder.DropIndex(
                name: "IX_GolfCourses_RoundID",
                table: "GolfCourses");

            migrationBuilder.DropColumn(
                name: "RoundID",
                table: "GolfCourses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoundID",
                table: "GolfCourses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GolfCourses_RoundID",
                table: "GolfCourses",
                column: "RoundID");

            migrationBuilder.AddForeignKey(
                name: "FK_GolfCourses_Rounds_RoundID",
                table: "GolfCourses",
                column: "RoundID",
                principalTable: "Rounds",
                principalColumn: "RoundID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
