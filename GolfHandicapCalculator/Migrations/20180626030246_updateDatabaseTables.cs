using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GolfHandicapCalculator.Migrations
{
    public partial class updateDatabaseTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_GolfCourses_GolfCourseID",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Rounds_RoundID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_GolfCourseID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoundID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "GolfCourseID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RoundID",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Rounds",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "GolfCourses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Rounds");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "GolfCourses");

            migrationBuilder.AddColumn<int>(
                name: "GolfCourseID",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoundID",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_GolfCourseID",
                table: "Users",
                column: "GolfCourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoundID",
                table: "Users",
                column: "RoundID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_GolfCourses_GolfCourseID",
                table: "Users",
                column: "GolfCourseID",
                principalTable: "GolfCourses",
                principalColumn: "GolfCourseID",
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
