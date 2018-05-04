using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GolfHandicapCalculator.Migrations
{
    public partial class updateCourseAndRounds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GolfCourseID",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_GolfCourseID",
                table: "Users",
                column: "GolfCourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_GolfCourses_GolfCourseID",
                table: "Users",
                column: "GolfCourseID",
                principalTable: "GolfCourses",
                principalColumn: "GolfCourseID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_GolfCourses_GolfCourseID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_GolfCourseID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "GolfCourseID",
                table: "Users");
        }
    }
}
