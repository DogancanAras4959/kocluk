using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kocluk.DOMAIN.Migrations
{
    public partial class v123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StudentName",
                table: "booking",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StudyName",
                table: "booking",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "booking",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentName",
                table: "booking");

            migrationBuilder.DropColumn(
                name: "StudyName",
                table: "booking");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "booking");
        }
    }
}
