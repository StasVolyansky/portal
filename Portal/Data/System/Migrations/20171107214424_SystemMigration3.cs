using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Portal.Data.System.Migrations
{
    public partial class SystemMigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleEnrolments_Roles_RoleId",
                schema: "system",
                table: "RoleEnrolments");

            migrationBuilder.DropIndex(
                name: "IX_RoleEnrolments_RoleId",
                schema: "system",
                table: "RoleEnrolments");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "system",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                schema: "system",
                table: "RoleEnrolments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                schema: "system",
                table: "Roles");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                schema: "system",
                table: "RoleEnrolments",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_RoleEnrolments_RoleId",
                schema: "system",
                table: "RoleEnrolments",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleEnrolments_Roles_RoleId",
                schema: "system",
                table: "RoleEnrolments",
                column: "RoleId",
                principalSchema: "system",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
