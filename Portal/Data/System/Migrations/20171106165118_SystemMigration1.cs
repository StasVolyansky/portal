using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.Data.System.Migrations
{
    public partial class SystemMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Users_UserId",
                schema: "system",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_UserId",
                schema: "system",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "UserName",
                schema: "system",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "system",
                table: "Roles");

            migrationBuilder.CreateTable(
                name: "RoleEnrolments",
                schema: "system",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleEnrolments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleEnrolments_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "system",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleEnrolments_UserId",
                schema: "system",
                table: "RoleEnrolments",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleEnrolments",
                schema: "system");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                schema: "system",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                schema: "system",
                table: "Roles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_UserId",
                schema: "system",
                table: "Roles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Users_UserId",
                schema: "system",
                table: "Roles",
                column: "UserId",
                principalSchema: "system",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
