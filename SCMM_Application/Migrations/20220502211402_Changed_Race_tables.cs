using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SCMM_Application.Migrations
{
    public partial class Changed_Race_tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Race_RaceType_RaceTypeId",
                table: "Race");

            migrationBuilder.DropForeignKey(
                name: "FK_Race_Stage_StrokeId",
                table: "Race");

            migrationBuilder.DropTable(
                name: "RaceType");

            migrationBuilder.DropIndex(
                name: "IX_Race_RaceTypeId",
                table: "Race");

            migrationBuilder.DropColumn(
                name: "RaceDate",
                table: "Race");

            migrationBuilder.DropColumn(
                name: "RaceTypeId",
                table: "Race");

            migrationBuilder.DropColumn(
                name: "Venue",
                table: "Race");

            migrationBuilder.AddColumn<string>(
                name: "Age",
                table: "Race",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ClubMeetId",
                table: "Race",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Distance",
                table: "Race",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Race",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ClubMeet",
                columns: table => new
                {
                    ClubMeetId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Venue = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    MeetDate = table.Column<DateTime>(nullable: false),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedUserId = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubMeet", x => x.ClubMeetId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Race_ClubMeetId",
                table: "Race",
                column: "ClubMeetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Race_ClubMeet_ClubMeetId",
                table: "Race",
                column: "ClubMeetId",
                principalTable: "ClubMeet",
                principalColumn: "ClubMeetId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Race_Stroke_StrokeId",
                table: "Race",
                column: "StrokeId",
                principalTable: "Stroke",
                principalColumn: "StrokeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Race_ClubMeet_ClubMeetId",
                table: "Race");

            migrationBuilder.DropForeignKey(
                name: "FK_Race_Stroke_StrokeId",
                table: "Race");

            migrationBuilder.DropTable(
                name: "ClubMeet");

            migrationBuilder.DropIndex(
                name: "IX_Race_ClubMeetId",
                table: "Race");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Race");

            migrationBuilder.DropColumn(
                name: "ClubMeetId",
                table: "Race");

            migrationBuilder.DropColumn(
                name: "Distance",
                table: "Race");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Race");

            migrationBuilder.AddColumn<DateTime>(
                name: "RaceDate",
                table: "Race",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "RaceTypeId",
                table: "Race",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Venue",
                table: "Race",
                type: "nvarchar(250)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "RaceType",
                columns: table => new
                {
                    RaceTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Age = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Distance = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceType", x => x.RaceTypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Race_RaceTypeId",
                table: "Race",
                column: "RaceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Race_RaceType_RaceTypeId",
                table: "Race",
                column: "RaceTypeId",
                principalTable: "RaceType",
                principalColumn: "RaceTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Race_Stage_StrokeId",
                table: "Race",
                column: "StrokeId",
                principalTable: "Stage",
                principalColumn: "StageId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
