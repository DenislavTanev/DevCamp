using Microsoft.EntityFrameworkCore.Migrations;

namespace DevCamp.Data.Migrations
{
    public partial class ChangesToListing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeliveryTime",
                table: "Packages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Revisions",
                table: "Packages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsComplete",
                table: "Listings",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryTime",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "Revisions",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "IsComplete",
                table: "Listings");
        }
    }
}
