namespace DevCamp.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class RemoveSkillsFromListing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListingSkills");

            migrationBuilder.AddColumn<double>(
                name: "StartingPrice",
                table: "Listings",
                type: "float",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartingPrice",
                table: "Listings");

            migrationBuilder.CreateTable(
                name: "ListingSkills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListingId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListingSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListingSkills_Listings_ListingId",
                        column: x => x.ListingId,
                        principalTable: "Listings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListingSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListingSkills_ListingId",
                table: "ListingSkills",
                column: "ListingId");

            migrationBuilder.CreateIndex(
                name: "IX_ListingSkills_SkillId",
                table: "ListingSkills",
                column: "SkillId");
        }
    }
}
