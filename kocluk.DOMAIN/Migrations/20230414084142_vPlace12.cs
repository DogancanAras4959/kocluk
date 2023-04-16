using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kocluk.DOMAIN.Migrations
{
    public partial class vPlace12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlaceId",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlaceId",
                table: "students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Place",
                table: "bookingRequest",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tip",
                table: "bookingRequest",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PlaceId",
                table: "booking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "place",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_place", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_PlaceId",
                table: "users",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_students_PlaceId",
                table: "students",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_booking_PlaceId",
                table: "booking",
                column: "PlaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_booking_place_PlaceId",
                table: "booking",
                column: "PlaceId",
                principalTable: "place",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_students_place_PlaceId",
                table: "students",
                column: "PlaceId",
                principalTable: "place",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_users_place_PlaceId",
                table: "users",
                column: "PlaceId",
                principalTable: "place",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_booking_place_PlaceId",
                table: "booking");

            migrationBuilder.DropForeignKey(
                name: "FK_students_place_PlaceId",
                table: "students");

            migrationBuilder.DropForeignKey(
                name: "FK_users_place_PlaceId",
                table: "users");

            migrationBuilder.DropTable(
                name: "place");

            migrationBuilder.DropIndex(
                name: "IX_users_PlaceId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_students_PlaceId",
                table: "students");

            migrationBuilder.DropIndex(
                name: "IX_booking_PlaceId",
                table: "booking");

            migrationBuilder.DropColumn(
                name: "PlaceId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "PlaceId",
                table: "students");

            migrationBuilder.DropColumn(
                name: "Place",
                table: "bookingRequest");

            migrationBuilder.DropColumn(
                name: "Tip",
                table: "bookingRequest");

            migrationBuilder.DropColumn(
                name: "PlaceId",
                table: "booking");
        }
    }
}
