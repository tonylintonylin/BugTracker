using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTracker.Migrations
{
    public partial class projectcreationdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerID",
                table: "Project");

            migrationBuilder.AddColumn<string>(
                name: "CreationDate",
                table: "Project",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Project");

            migrationBuilder.AddColumn<string>(
                name: "OwnerID",
                table: "Project",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
