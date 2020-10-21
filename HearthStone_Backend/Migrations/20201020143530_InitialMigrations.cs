using Microsoft.EntityFrameworkCore.Migrations;

namespace HearthStone_Backend.Migrations
{
    public partial class InitialMigrations : Migration
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
                name: "Cards",
                columns: table => new
                {
                    CardId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CardSet = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Faction = table.Column<string>(nullable: true),
                    Rarity = table.Column<string>(nullable: true),
                    Cost = table.Column<string>(nullable: true),
                    Attack = table.Column<string>(nullable: true),
                    Health = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    Flavor = table.Column<string>(nullable: true),
                    Artist = table.Column<string>(nullable: true),
                    Collectable = table.Column<bool>(nullable: false),
                    Elite = table.Column<bool>(nullable: false),
                    Race = table.Column<string>(nullable: true),
                    img = table.Column<string>(nullable: true),
                    imgGold = table.Column<string>(nullable: true),
                    Locale = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.CardId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardBacks");

            migrationBuilder.DropTable(
                name: "Cards");
        }
    }
}
