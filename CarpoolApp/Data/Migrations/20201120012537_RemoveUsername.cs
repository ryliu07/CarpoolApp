using Microsoft.EntityFrameworkCore.Migrations;

namespace CarpoolApp.Data.Migrations
{
    public partial class RemoveUsername : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "AppUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "AppUser",
                type: "text",
                nullable: true);
        }
    }
}
