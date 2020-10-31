using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTracker.Migrations
{
    public partial class icollectiondevs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Developer",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "DeveloperID",
                table: "Ticket");

            migrationBuilder.AddColumn<int>(
                name: "TicketID",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TicketID",
                table: "AspNetUsers",
                column: "TicketID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Ticket_TicketID",
                table: "AspNetUsers",
                column: "TicketID",
                principalTable: "Ticket",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Ticket_TicketID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TicketID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TicketID",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Developer",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeveloperID",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
