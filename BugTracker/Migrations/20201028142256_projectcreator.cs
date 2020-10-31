using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTracker.Migrations
{
    public partial class projectcreator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Creator",
                table: "Project");

            migrationBuilder.AddColumn<string>(
                name: "Creator",
                table: "Project",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Creator",
                table: "Project");

            migrationBuilder.AddColumn<string>(
                name: "Creator",
                table: "Project",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
