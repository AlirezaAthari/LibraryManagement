using Microsoft.EntityFrameworkCore.Migrations;

namespace wpf_start.Migrations
{
    public partial class Librarian : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LibraryPart",
                table: "Users",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LibraryPart",
                table: "Users");
        }
    }
}
