namespace DevCamp.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class Da : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Flag",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "Icon",
                table: "Achievements");

            migrationBuilder.DropColumn(
                name: "Partners",
                table: "AboutUs");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Flag",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "Achievements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Partners",
                table: "AboutUs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
