﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace wpf_start.Migrations
{
    public partial class addPartToBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Part",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Part",
                table: "Books");
        }
    }
}
