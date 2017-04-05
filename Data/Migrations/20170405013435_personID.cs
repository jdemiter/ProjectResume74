using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjectResume.Data.Migrations
{
    public partial class personID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobDuty_Person_PersonID",
                table: "JobDuty");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkExperience_Person_PersonID",
                table: "WorkExperience");

            migrationBuilder.DropIndex(
                name: "IX_WorkExperience_PersonID",
                table: "WorkExperience");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Person",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Person");

            migrationBuilder.AddColumn<int>(
                name: "PersonID",
                table: "Person",
                nullable: false
                )
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "WorkExperience",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperience_ID",
                table: "WorkExperience",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Person",
                table: "Person",
                column: "PersonID");

            migrationBuilder.AddForeignKey(
                name: "FK_JobDuty_Person_PersonID",
                table: "JobDuty",
                column: "PersonID",
                principalTable: "Person",
                principalColumn: "PersonID",
                onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_WorkExperience_Person_ID",
            //    table: "WorkExperience",
            //    column: "PersonID",
            //    principalTable: "Person",
            //    principalColumn: "PersonID",
            //    onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobDuty_Person_PersonID",
                table: "JobDuty");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkExperience_Person_ID",
                table: "WorkExperience");

            migrationBuilder.DropIndex(
                name: "IX_WorkExperience_ID",
                table: "WorkExperience");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Person",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "PersonID",
                table: "Person");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Person",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "WorkExperience",
                nullable: false)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperience_PersonID",
                table: "WorkExperience",
                column: "PersonID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Person",
                table: "Person",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_JobDuty_Person_PersonID",
                table: "JobDuty",
                column: "PersonID",
                principalTable: "Person",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkExperience_Person_PersonID",
                table: "WorkExperience",
                column: "PersonID",
                principalTable: "Person",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
