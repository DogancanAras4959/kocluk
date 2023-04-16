using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kocluk.DOMAIN.Migrations
{
    public partial class tableStudentUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BornTime",
                table: "students",
                newName: "School");

            migrationBuilder.AddColumn<string>(
                name: "Area",
                table: "students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Branch",
                table: "students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CountryId",
                table: "students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ParentAddress",
                table: "students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ParentName",
                table: "students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ParentPhone",
                table: "students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Area",
                table: "students");

            migrationBuilder.DropColumn(
                name: "Branch",
                table: "students");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "students");

            migrationBuilder.DropColumn(
                name: "ParentAddress",
                table: "students");

            migrationBuilder.DropColumn(
                name: "ParentName",
                table: "students");

            migrationBuilder.DropColumn(
                name: "ParentPhone",
                table: "students");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "students");

            migrationBuilder.RenameColumn(
                name: "School",
                table: "students",
                newName: "BornTime");
        }
    }
}
