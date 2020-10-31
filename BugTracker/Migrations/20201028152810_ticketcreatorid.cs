using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTracker.Migrations
{
    public partial class ticketcreatorid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatorID",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeveloperID",
                table: "Ticket",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatorID",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "DeveloperID",
                table: "Ticket");
        }
    }
}
