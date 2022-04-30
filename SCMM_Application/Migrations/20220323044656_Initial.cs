using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SCMM_Application.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RaceType",
                columns: table => new
                {
                    RaceTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceType", x => x.RaceTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Stage",
                columns: table => new
                {
                    StageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stage", x => x.StageId);
                });

            migrationBuilder.CreateTable(
                name: "Stroke",
                columns: table => new
                {
                    StrokeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stroke", x => x.StrokeId);
                });

            migrationBuilder.CreateTable(
                name: "UserType",
                columns: table => new
                {
                    UserTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserType", x => x.UserTypeId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserTypeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    DOB = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_UserType_UserTypeId",
                        column: x => x.UserTypeId,
                        principalTable: "UserType",
                        principalColumn: "UserTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Performance",
                columns: table => new
                {
                    PerformanceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StrokeId = table.Column<int>(nullable: false),
                    StageId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    PersonalBestTime = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedUserId = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Performance", x => x.PerformanceId);
                    table.ForeignKey(
                        name: "FK_Performance_User_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Performance_User_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Performance_Stage_StageId",
                        column: x => x.StageId,
                        principalTable: "Stage",
                        principalColumn: "StageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Performance_Stroke_StrokeId",
                        column: x => x.StrokeId,
                        principalTable: "Stroke",
                        principalColumn: "StrokeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Performance_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Race",
                columns: table => new
                {
                    RaceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RaceTypeId = table.Column<int>(nullable: false),
                    StrokeId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Venue = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    RaceDate = table.Column<DateTime>(nullable: false),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedUserId = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Race", x => x.RaceId);
                    table.ForeignKey(
                        name: "FK_Race_User_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Race_User_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Race_RaceType_RaceTypeId",
                        column: x => x.RaceTypeId,
                        principalTable: "RaceType",
                        principalColumn: "RaceTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Race_Stage_StrokeId",
                        column: x => x.StrokeId,
                        principalTable: "Stage",
                        principalColumn: "StageId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Squad",
                columns: table => new
                {
                    SquadId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(nullable: false),
                    CoachId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedUserId = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Squad", x => x.SquadId);
                    table.ForeignKey(
                        name: "FK_Squad_User_CoachId",
                        column: x => x.CoachId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Squad_User_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Squad_User_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Squad_User_StudentId",
                        column: x => x.StudentId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRace",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RaceId = table.Column<int>(nullable: false),
                    Timing = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Place = table.Column<int>(nullable: false),
                    CreatedUserId = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedUserId = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRace", x => new { x.UserId, x.RaceId });
                    table.ForeignKey(
                        name: "FK_UserRace_User_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRace_User_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRace_Race_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Race",
                        principalColumn: "RaceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRace_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Performance_CreatedUserId",
                table: "Performance",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Performance_ModifiedUserId",
                table: "Performance",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Performance_StageId",
                table: "Performance",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_Performance_StrokeId",
                table: "Performance",
                column: "StrokeId");

            migrationBuilder.CreateIndex(
                name: "IX_Performance_UserId",
                table: "Performance",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Race_CreatedUserId",
                table: "Race",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Race_ModifiedUserId",
                table: "Race",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Race_RaceTypeId",
                table: "Race",
                column: "RaceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Race_StrokeId",
                table: "Race",
                column: "StrokeId");

            migrationBuilder.CreateIndex(
                name: "IX_Squad_CoachId",
                table: "Squad",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_Squad_CreatedUserId",
                table: "Squad",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Squad_ModifiedUserId",
                table: "Squad",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Squad_StudentId",
                table: "Squad",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserTypeId",
                table: "User",
                column: "UserTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRace_CreatedUserId",
                table: "UserRace",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRace_ModifiedUserId",
                table: "UserRace",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRace_RaceId",
                table: "UserRace",
                column: "RaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Performance");

            migrationBuilder.DropTable(
                name: "Squad");

            migrationBuilder.DropTable(
                name: "UserRace");

            migrationBuilder.DropTable(
                name: "Stroke");

            migrationBuilder.DropTable(
                name: "Race");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "RaceType");

            migrationBuilder.DropTable(
                name: "Stage");

            migrationBuilder.DropTable(
                name: "UserType");
        }
    }
}
