using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevCamp.Data.Migrations
{
    public partial class FixSkills : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "UsersSkills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "UsersSkills",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UsersSkills",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "UsersSkills",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersSkills_IsDeleted",
                table: "UsersSkills",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UsersSkills_IsDeleted",
                table: "UsersSkills");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "UsersSkills");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "UsersSkills");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UsersSkills");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "UsersSkills");
        }
    }
}
