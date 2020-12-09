using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HearthStone_Backend.Migrations
{
    public partial class UserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Email = table.Column<string>(nullable: false),            
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Email);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.CreateTable(
                name: "Info",
                columns: table => new
                {
                    Classes = table.Column<string[]>(type: "text[]", nullable: true),
                    Factions = table.Column<string[]>(type: "text[]", nullable: true),
                    Locales = table.Column<string[]>(type: "text[]", nullable: true),
                    Qualities = table.Column<string[]>(type: "text[]", nullable: true),
                    Races = table.Column<string[]>(type: "text[]", nullable: true),
                    Sets = table.Column<string[]>(type: "text[]", nullable: true),
                    Standard = table.Column<string[]>(type: "text[]", nullable: true),
                    Types = table.Column<string[]>(type: "text[]", nullable: true),
                    Wild = table.Column<string[]>(type: "text[]", nullable: true)
                },
                constraints: table =>
                {
                });
        }
    }
}
