using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HearthStone_Backend.Migrations
{
    public partial class CardsBackAndInfosAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CardBacks",
                columns: table => new
                {
                    CardBackId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Source = table.Column<string>(nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    Img = table.Column<string>(nullable: true),
                    ImgAnimated = table.Column<string>(nullable: true),
                    SortCategory = table.Column<string>(nullable: true),
                    SortOrder = table.Column<string>(nullable: true),
                    Locale = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardBacks", x => x.CardBackId);
                });

            migrationBuilder.CreateTable(
                name: "Infos",
                columns: table => new
                {
                    Classes = table.Column<List<string>>(nullable: true),
                    Sets = table.Column<List<string>>(nullable: true),
                    Standard = table.Column<List<string>>(nullable: true),
                    Wild = table.Column<List<string>>(nullable: true),
                    Types = table.Column<List<string>>(nullable: true),
                    Factions = table.Column<List<string>>(nullable: true),
                    Qualities = table.Column<List<string>>(nullable: true),
                    Races = table.Column<List<string>>(nullable: true),
                    Locales = table.Column<List<string>>(nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardBacks");

            migrationBuilder.DropTable(
                name: "Infos");
        }
    }
}
