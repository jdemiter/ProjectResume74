using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectResume.Data.Migrations
{
    public partial class moremodelandviewedits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VolunteerDate",
                table: "VolunteerExperience");

            migrationBuilder.AddColumn<DateTime>(
                name: "VolunteerEndDate",
                table: "VolunteerExperience",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "VolunteerStartDate",
                table: "VolunteerExperience",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "References",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VolunteerEndDate",
                table: "VolunteerExperience");

            migrationBuilder.DropColumn(
                name: "VolunteerStartDate",
                table: "VolunteerExperience");

            migrationBuilder.AddColumn<DateTime>(
                name: "VolunteerDate",
                table: "VolunteerExperience",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "References",
                nullable: true);
        }
    }
}
