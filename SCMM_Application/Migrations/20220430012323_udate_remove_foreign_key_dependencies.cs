using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SCMM_Application.Migrations
{
    public partial class udate_remove_foreign_key_dependencies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Performance_User_CreatedUserId",
                table: "Performance");

            migrationBuilder.DropForeignKey(
                name: "FK_Performance_User_ModifiedUserId",
                table: "Performance");

            migrationBuilder.DropForeignKey(
                name: "FK_Race_User_CreatedUserId",
                table: "Race");

            migrationBuilder.DropForeignKey(
                name: "FK_Race_User_ModifiedUserId",
                table: "Race");

            migrationBuilder.DropForeignKey(
                name: "FK_Squad_User_CreatedUserId",
                table: "Squad");

            migrationBuilder.DropForeignKey(
                name: "FK_Squad_User_ModifiedUserId",
                table: "Squad");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRace_User_CreatedUserId",
                table: "UserRace");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRace_User_ModifiedUserId",
                table: "UserRace");

            migrationBuilder.DropIndex(
                name: "IX_UserRace_CreatedUserId",
                table: "UserRace");

            migrationBuilder.DropIndex(
                name: "IX_UserRace_ModifiedUserId",
                table: "UserRace");

            migrationBuilder.DropIndex(
                name: "IX_Squad_CreatedUserId",
                table: "Squad");

            migrationBuilder.DropIndex(
                name: "IX_Squad_ModifiedUserId",
                table: "Squad");

            migrationBuilder.DropIndex(
                name: "IX_Race_CreatedUserId",
                table: "Race");

            migrationBuilder.DropIndex(
                name: "IX_Race_ModifiedUserId",
                table: "Race");

            migrationBuilder.DropIndex(
                name: "IX_Performance_CreatedUserId",
                table: "Performance");

            migrationBuilder.DropIndex(
                name: "IX_Performance_ModifiedUserId",
                table: "Performance");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "UserRace",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "UserRace",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "Squad",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Squad",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "Race",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Race",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "Performance",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Performance",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "UserRace",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "UserRace",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "Squad",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Squad",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "Race",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Race",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "Performance",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Performance",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRace_CreatedUserId",
                table: "UserRace",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRace_ModifiedUserId",
                table: "UserRace",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Squad_CreatedUserId",
                table: "Squad",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Squad_ModifiedUserId",
                table: "Squad",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Race_CreatedUserId",
                table: "Race",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Race_ModifiedUserId",
                table: "Race",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Performance_CreatedUserId",
                table: "Performance",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Performance_ModifiedUserId",
                table: "Performance",
                column: "ModifiedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Performance_User_CreatedUserId",
                table: "Performance",
                column: "CreatedUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Performance_User_ModifiedUserId",
                table: "Performance",
                column: "ModifiedUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Race_User_CreatedUserId",
                table: "Race",
                column: "CreatedUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Race_User_ModifiedUserId",
                table: "Race",
                column: "ModifiedUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Squad_User_CreatedUserId",
                table: "Squad",
                column: "CreatedUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Squad_User_ModifiedUserId",
                table: "Squad",
                column: "ModifiedUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRace_User_CreatedUserId",
                table: "UserRace",
                column: "CreatedUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRace_User_ModifiedUserId",
                table: "UserRace",
                column: "ModifiedUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
