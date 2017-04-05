using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjectResume.Data.Migrations
{
    public partial class morepeopleseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkExperience_Person_ID",
                table: "WorkExperience");

            migrationBuilder.DropIndex(
                name: "IX_WorkExperience_ID",
                table: "WorkExperience");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "WorkExperience",
                nullable: false)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperience_PersonID",
                table: "WorkExperience",
                column: "PersonID");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkExperience_Person_PersonID",
                table: "WorkExperience",
                column: "PersonID",
                principalTable: "Person",
                principalColumn: "PersonID",
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

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "WorkExperience",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperience_ID",
                table: "WorkExperience",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkExperience_Person_ID",
                table: "WorkExperience",
                column: "ID",
                principalTable: "Person",
                principalColumn: "PersonID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
