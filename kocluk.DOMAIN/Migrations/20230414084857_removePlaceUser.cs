using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kocluk.DOMAIN.Migrations
{
    public partial class removePlaceUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_place_PlaceId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_PlaceId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "PlaceId",
                table: "users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlaceId",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_users_PlaceId",
                table: "users",
                column: "PlaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_place_PlaceId",
                table: "users",
                column: "PlaceId",
                principalTable: "place",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
