using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChefsAndDishes.Migrations
{
    public partial class ChangedDateToAge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Chefs");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Chefs",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Chefs");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Chefs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
