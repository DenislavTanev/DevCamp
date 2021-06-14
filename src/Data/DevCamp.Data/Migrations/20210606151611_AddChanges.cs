namespace DevCamp.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BoostedDeliveryPeriod",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "BoostedDeliveryPrice",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "DeliveryPeriod",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "IsBoosted",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Packages");

            migrationBuilder.AlterColumn<bool>(
                name: "IsIncluded",
                table: "PackageItems",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "SubCategoryId",
                table: "Listings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Listings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BoostedDeliveryPeriod",
                table: "Packages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "BoostedDeliveryPrice",
                table: "Packages",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryPeriod",
                table: "Packages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsBoosted",
                table: "Packages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "TotalPrice",
                table: "Packages",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<bool>(
                name: "IsIncluded",
                table: "PackageItems",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SubCategoryId",
                table: "Listings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Listings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
