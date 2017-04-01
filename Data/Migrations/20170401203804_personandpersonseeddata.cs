using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjectResume.Data.Migrations
{
    public partial class personandpersonseeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: true),
                    StreetAddress = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "JobDuty",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PersonID = table.Column<int>(nullable: true),
                    Responsibilities = table.Column<string>(nullable: true),
                    WorkExperienceID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobDuty", x => x.ID);
                    table.ForeignKey(
                        name: "FK_JobDuty_Person_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobDuty_WorkExperience_WorkExperienceID",
                        column: x => x.WorkExperienceID,
                        principalTable: "WorkExperience",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.AddColumn<int>(
                name: "PersonID",
                table: "WorkExperience",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperience_PersonID",
                table: "WorkExperience",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_JobDuty_PersonID",
                table: "JobDuty",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_JobDuty_WorkExperienceID",
                table: "JobDuty",
                column: "WorkExperienceID");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkExperience_Person_PersonID",
                table: "WorkExperience",
                column: "PersonID",
                principalTable: "Person",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkExperience_Person_PersonID",
                table: "WorkExperience");

            migrationBuilder.DropIndex(
                name: "IX_WorkExperience_PersonID",
                table: "WorkExperience");

            migrationBuilder.DropColumn(
                name: "PersonID",
                table: "WorkExperience");

            migrationBuilder.DropTable(
                name: "JobDuty");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
