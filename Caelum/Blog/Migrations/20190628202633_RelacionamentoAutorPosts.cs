using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Blog.Migrations
{
    public partial class RelacionamentoAutorPosts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AutorId",
                table: "Posts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AutorId",
                table: "Posts",
                column: "AutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Usuarios_AutorId",
                table: "Posts",
                column: "AutorId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Usuarios_AutorId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_AutorId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "AutorId",
                table: "Posts");
        }
    }
}
