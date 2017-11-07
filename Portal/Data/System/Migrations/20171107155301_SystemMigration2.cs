using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Portal.Data.System.Migrations
{
    public partial class SystemMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                schema: "system",
                table: "RoleEnrolments");

            migrationBuilder.DropColumn(
                name: "User",
                schema: "system",
                table: "RoleEnrolments");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                schema: "system",
                table: "RoleEnrolments",
                type: "int",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleEnrolments_Roles_RoleId",
                schema: "system",
                table: "RoleEnrolments");

            migrationBuilder.DropIndex(
                name: "IX_RoleEnrolments_RoleId",
                schema: "system",
                table: "RoleEnrolments");

            migrationBuilder.DropColumn(
                name: "RoleId",
                schema: "system",
                table: "RoleEnrolments");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                schema: "system",
                table: "RoleEnrolments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "User",
                schema: "system",
                table: "RoleEnrolments",
                nullable: true);
        }
    }
}
