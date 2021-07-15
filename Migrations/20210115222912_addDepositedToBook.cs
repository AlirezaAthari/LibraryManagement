using Microsoft.EntityFrameworkCore.Migrations;

namespace wpf_start.Migrations
{
    public partial class addDepositedToBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Deposited",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deposited",
                table: "Books");
        }
    }
}
