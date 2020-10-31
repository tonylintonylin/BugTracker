using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTracker.Migrations
{
    public partial class revertdeveloperid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "DeveloperID",
                table: "Ticket",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_DeveloperID",
                table: "Ticket",
                column: "DeveloperID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_AspNetUsers_DeveloperID",
                table: "Ticket",
                column: "DeveloperID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_AspNetUsers_DeveloperID",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_DeveloperID",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "DeveloperID",
                table: "Ticket");

            migrationBuilder.AddColumn<int>(
                name: "TicketID",
                table: "AspNetUsers",
                type: "int",
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
    }
}
