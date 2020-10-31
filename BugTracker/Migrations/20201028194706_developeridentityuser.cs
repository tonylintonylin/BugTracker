using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTracker.Migrations
{
    public partial class developeridentityuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Developer",
                table: "Ticket");

            migrationBuilder.AlterColumn<string>(
                name: "DeveloperID",
                table: "Ticket",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Developer",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
