using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamSystem.Data.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleClames_Roles_RoleId",
                schema: "security",
                table: "RoleClames");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleClames",
                schema: "security",
                table: "RoleClames");

            migrationBuilder.RenameTable(
                name: "RoleClames",
                schema: "security",
                newName: "RoleClaims",
                newSchema: "security");

            migrationBuilder.RenameIndex(
                name: "IX_RoleClames_RoleId",
                schema: "security",
                table: "RoleClaims",
                newName: "IX_RoleClaims_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleClaims",
                schema: "security",
                table: "RoleClaims",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleClaims_Roles_RoleId",
                schema: "security",
                table: "RoleClaims",
                column: "RoleId",
                principalSchema: "security",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleClaims_Roles_RoleId",
                schema: "security",
                table: "RoleClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleClaims",
                schema: "security",
                table: "RoleClaims");

            migrationBuilder.RenameTable(
                name: "RoleClaims",
                schema: "security",
                newName: "RoleClames",
                newSchema: "security");

            migrationBuilder.RenameIndex(
                name: "IX_RoleClaims_RoleId",
                schema: "security",
                table: "RoleClames",
                newName: "IX_RoleClames_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleClames",
                schema: "security",
                table: "RoleClames",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleClames_Roles_RoleId",
                schema: "security",
                table: "RoleClames",
                column: "RoleId",
                principalSchema: "security",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
