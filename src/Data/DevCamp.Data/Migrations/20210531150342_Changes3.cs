namespace DevCamp.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class Changes3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Achievements_AspNetUsers_UserId",
                table: "Achievements");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_AspNetUsers_UserId",
                table: "Skills");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Listings_ListingId1",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_ListingId1",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_UserId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Achievements_UserId",
                table: "Achievements");

            migrationBuilder.DropColumn(
                name: "ListingId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "ListingId1",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Achievements");

            migrationBuilder.CreateTable(
                name: "AchievementApplicationUser",
                columns: table => new
                {
                    AchievementsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AchievementApplicationUser", x => new { x.AchievementsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_AchievementApplicationUser_Achievements_AchievementsId",
                        column: x => x.AchievementsId,
                        principalTable: "Achievements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AchievementApplicationUser_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserSkill",
                columns: table => new
                {
                    SkillsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserSkill", x => new { x.SkillsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserSkill_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApplicationUserSkill_Skills_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ListingSkill",
                columns: table => new
                {
                    ListingsId = table.Column<int>(type: "int", nullable: false),
                    SkillsId = table.Column<int>(type: "int", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListingSkill", x => new { x.ListingsId, x.SkillsId });
                    table.ForeignKey(
                        name: "FK_ListingSkill_Listings_ListingsId",
                        column: x => x.ListingsId,
                        principalTable: "Listings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListingSkill_Skills_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AchievementApplicationUser_UsersId",
                table: "AchievementApplicationUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserSkill_UsersId",
                table: "ApplicationUserSkill",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_ListingSkill_SkillsId",
                table: "ListingSkill",
                column: "SkillsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AchievementApplicationUser");

            migrationBuilder.DropTable(
                name: "ApplicationUserSkill");

            migrationBuilder.DropTable(
                name: "ListingSkill");

            migrationBuilder.AddColumn<string>(
                name: "ListingId",
                table: "Skills",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ListingId1",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Skills",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Achievements",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_ListingId1",
                table: "Skills",
                column: "ListingId1");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_UserId",
                table: "Skills",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Achievements_UserId",
                table: "Achievements",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Achievements_AspNetUsers_UserId",
                table: "Achievements",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_AspNetUsers_UserId",
                table: "Skills",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Listings_ListingId1",
                table: "Skills",
                column: "ListingId1",
                principalTable: "Listings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
