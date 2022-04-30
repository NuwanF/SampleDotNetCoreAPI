using Microsoft.EntityFrameworkCore.Migrations;

namespace SCMM_Application.Migrations
{
    public partial class _20220429000001_udate_Race : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "RaceType");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Race");

            migrationBuilder.AddColumn<string>(
                name: "Age",
                table: "RaceType",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Distance",
                table: "RaceType",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "RaceType",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "RaceType");

            migrationBuilder.DropColumn(
                name: "Distance",
                table: "RaceType");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "RaceType");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "RaceType",
                type: "nvarchar(250)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Race",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
