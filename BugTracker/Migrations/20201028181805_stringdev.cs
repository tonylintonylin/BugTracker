using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTracker.Migrations
{
    public partial class stringdev : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_AspNetUsers_DeveloperID",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_DeveloperID",
                table: "Ticket");

            migrationBuilder.AlterColumn<string>(
                name: "DeveloperID",
                table: "Ticket",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Developer",
                table: "Ticket",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Developer",
                table: "Ticket");

            migrationBuilder.AlterColumn<string>(
                name: "DeveloperID",
                table: "Ticket",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

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
    }
}
