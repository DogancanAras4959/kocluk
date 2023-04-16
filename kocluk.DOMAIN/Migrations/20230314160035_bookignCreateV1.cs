using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kocluk.DOMAIN.Migrations
{
    public partial class bookignCreateV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudyId",
                table: "booking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_booking_StudyId",
                table: "booking",
                column: "StudyId");

            migrationBuilder.AddForeignKey(
                name: "FK_booking_studies_StudyId",
                table: "booking",
                column: "StudyId",
                principalTable: "studies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_booking_studies_StudyId",
                table: "booking");

            migrationBuilder.DropIndex(
                name: "IX_booking_StudyId",
                table: "booking");

            migrationBuilder.DropColumn(
                name: "StudyId",
                table: "booking");
        }
    }
}
