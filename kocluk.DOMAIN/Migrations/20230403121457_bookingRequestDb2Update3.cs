using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kocluk.DOMAIN.Migrations
{
    public partial class bookingRequestDb2Update3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BookingProcess",
                table: "bookingRequest",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookingProcess",
                table: "bookingRequest");
        }
    }
}
