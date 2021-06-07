using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevCamp.Data.Migrations
{
    public partial class ChangesToFAQ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FrequentlyAskedQuestions_AspNetUsers_UserId",
                table: "FrequentlyAskedQuestions");

            migrationBuilder.DropIndex(
                name: "IX_FrequentlyAskedQuestions_UserId",
                table: "FrequentlyAskedQuestions");

            migrationBuilder.DropIndex(
                name: "IX_Countries_IsDeleted",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "FrequentlyAskedQuestions");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Countries");

            migrationBuilder.AddColumn<int>(
                name: "ListingId",
                table: "FrequentlyAskedQuestions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FrequentlyAskedQuestions_ListingId",
                table: "FrequentlyAskedQuestions",
                column: "ListingId");

            migrationBuilder.AddForeignKey(
                name: "FK_FrequentlyAskedQuestions_Listings_ListingId",
                table: "FrequentlyAskedQuestions",
                column: "ListingId",
                principalTable: "Listings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FrequentlyAskedQuestions_Listings_ListingId",
                table: "FrequentlyAskedQuestions");

            migrationBuilder.DropIndex(
                name: "IX_FrequentlyAskedQuestions_ListingId",
                table: "FrequentlyAskedQuestions");

            migrationBuilder.DropColumn(
                name: "ListingId",
                table: "FrequentlyAskedQuestions");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "FrequentlyAskedQuestions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Countries",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Countries",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_FrequentlyAskedQuestions_UserId",
                table: "FrequentlyAskedQuestions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_IsDeleted",
                table: "Countries",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_FrequentlyAskedQuestions_AspNetUsers_UserId",
                table: "FrequentlyAskedQuestions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
