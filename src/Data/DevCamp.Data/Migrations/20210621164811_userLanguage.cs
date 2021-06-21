namespace DevCamp.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class userLanguage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAchievements_Achievements_AchievementId",
                table: "UserAchievements");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAchievements_AspNetUsers_UserId",
                table: "UserAchievements");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSkills_AspNetUsers_UserId",
                table: "UserSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSkills_Skills_SkillId",
                table: "UserSkills");

            migrationBuilder.DropTable(
                name: "ApplicationUserLanguage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSkills",
                table: "UserSkills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAchievements",
                table: "UserAchievements");

            migrationBuilder.RenameTable(
                name: "UserSkills",
                newName: "UsersSkills");

            migrationBuilder.RenameTable(
                name: "UserAchievements",
                newName: "UsersAchievements");

            migrationBuilder.RenameIndex(
                name: "IX_UserSkills_UserId",
                table: "UsersSkills",
                newName: "IX_UsersSkills_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserSkills_SkillId",
                table: "UsersSkills",
                newName: "IX_UsersSkills_SkillId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAchievements_UserId",
                table: "UsersAchievements",
                newName: "IX_UsersAchievements_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAchievements_AchievementId",
                table: "UsersAchievements",
                newName: "IX_UsersAchievements_AchievementId");

            migrationBuilder.DropColumn(
                name: "ProfilePic",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePic",
                table: "AspNetUsers",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDelivery",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Profession",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "ResponseTime",
                table: "AspNetUsers",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersSkills",
                table: "UsersSkills",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersAchievements",
                table: "UsersAchievements",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UsersLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersLanguages_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersLanguages_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersLanguages_IsDeleted",
                table: "UsersLanguages",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_UsersLanguages_LanguageId",
                table: "UsersLanguages",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersLanguages_UserId",
                table: "UsersLanguages",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersAchievements_Achievements_AchievementId",
                table: "UsersAchievements",
                column: "AchievementId",
                principalTable: "Achievements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersAchievements_AspNetUsers_UserId",
                table: "UsersAchievements",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersSkills_AspNetUsers_UserId",
                table: "UsersSkills",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersSkills_Skills_SkillId",
                table: "UsersSkills",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersAchievements_Achievements_AchievementId",
                table: "UsersAchievements");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersAchievements_AspNetUsers_UserId",
                table: "UsersAchievements");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersSkills_AspNetUsers_UserId",
                table: "UsersSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersSkills_Skills_SkillId",
                table: "UsersSkills");

            migrationBuilder.DropTable(
                name: "UsersLanguages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersSkills",
                table: "UsersSkills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersAchievements",
                table: "UsersAchievements");

            migrationBuilder.DropColumn(
                name: "LastDelivery",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Profession",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ResponseTime",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "UsersSkills",
                newName: "UserSkills");

            migrationBuilder.RenameTable(
                name: "UsersAchievements",
                newName: "UserAchievements");

            migrationBuilder.RenameIndex(
                name: "IX_UsersSkills_UserId",
                table: "UserSkills",
                newName: "IX_UserSkills_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersSkills_SkillId",
                table: "UserSkills",
                newName: "IX_UserSkills_SkillId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersAchievements_UserId",
                table: "UserAchievements",
                newName: "IX_UserAchievements_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersAchievements_AchievementId",
                table: "UserAchievements",
                newName: "IX_UserAchievements_AchievementId");

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePic",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSkills",
                table: "UserSkills",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAchievements",
                table: "UserAchievements",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ApplicationUserLanguage",
                columns: table => new
                {
                    SpokenLanguagesId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserLanguage", x => new { x.SpokenLanguagesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserLanguage_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApplicationUserLanguage_Languages_SpokenLanguagesId",
                        column: x => x.SpokenLanguagesId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserLanguage_UsersId",
                table: "ApplicationUserLanguage",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAchievements_Achievements_AchievementId",
                table: "UserAchievements",
                column: "AchievementId",
                principalTable: "Achievements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAchievements_AspNetUsers_UserId",
                table: "UserAchievements",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSkills_AspNetUsers_UserId",
                table: "UserSkills",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSkills_Skills_SkillId",
                table: "UserSkills",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
