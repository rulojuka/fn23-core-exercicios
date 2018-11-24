using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Blog.Migrations
{
    public partial class AddInfoPublicacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataPublicacao",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Publicado",
                table: "Posts",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataPublicacao",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Publicado",
                table: "Posts");
        }
    }
}
