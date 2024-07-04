using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamSystem.Data.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentNationalId",
                table: "Answers",
                newName: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Answers",
                newName: "StudentNationalId");
        }
    }
}
