using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectResume.Data.Migrations
{
    public partial class changepropertyname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmploymentDate",
                table: "WorkExperience");

            migrationBuilder.DropColumn(
                name: "JobDuties",
                table: "WorkExperience");

            migrationBuilder.AddColumn<DateTime>(
                name: "EmploymentStartDate",
                table: "WorkExperience",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmploymentStartDate",
                table: "WorkExperience");

            migrationBuilder.AddColumn<DateTime>(
                name: "EmploymentDate",
                table: "WorkExperience",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "JobDuties",
                table: "WorkExperience",
                nullable: true);
        }
    }
}
