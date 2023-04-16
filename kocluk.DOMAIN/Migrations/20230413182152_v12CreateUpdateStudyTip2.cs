using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kocluk.DOMAIN.Migrations
{
    public partial class v12CreateUpdateStudyTip2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "studyTips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudyId = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studyTips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_studyTips_studies_StudyId",
                        column: x => x.StudyId,
                        principalTable: "studies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_studyTips_StudyId",
                table: "studyTips",
                column: "StudyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "studyTips");
        }
    }
}
