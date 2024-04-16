using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DogApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSign = table.Column<bool>(type: "bit", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Height = table.Column<int>(type: "int", nullable: true),
                    Width = table.Column<int>(type: "int", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrackItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Itemid = table.Column<int>(type: "int", nullable: false),
                    Trackid = table.Column<int>(type: "int", nullable: false),
                    X = table.Column<float>(type: "real", nullable: true),
                    Y = table.Column<float>(type: "real", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrackItems_Items_Itemid",
                        column: x => x.Itemid,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrackItems_Tracks_Trackid",
                        column: x => x.Trackid,
                        principalTable: "Tracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Category", "Description", "Image", "IsSign", "Name" },
                values: new object[,]
                {
                    { 1, "Open", "", "/images/hojresving", true, "højre sving" },
                    { 2, "Open", "", "/images/venstresving", true, "venstre sving" },
                    { 3, "Open", "", "/images/hojrerundt", true, "højre rundt" },
                    { 4, "Open", "", "/images/venstrerundt", true, "venstre rundt" },
                    { 5, "Open", "", "/images/diagonalthojre", true, "diagonalt højre" },
                    { 6, null, "Description of Extra 1", "hest", false, "Extra 1" },
                    { 7, null, "Description of Extra 2", "hest", false, "Extra 2" },
                    { 8, null, "Description of Extra 3", "hest", false, "Extra 3" },
                    { 9, null, "Description of Extra 4", "hest", false, "Extra 4" },
                    { 10, null, "Description of Extra 5", "hest", false, "Extra 5" }
                });

            migrationBuilder.InsertData(
                table: "Tracks",
                columns: new[] { "Id", "Category", "Height", "Name", "Width" },
                values: new object[,]
                {
                    { 1, " Champion", 100, "Rallybane 1", 200 },
                    { 2, "Open ", 150, "Rallybane 2", 250 },
                    { 3, "Beginder", 120, "Rallybane 3", 180 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrackItems_Itemid",
                table: "TrackItems",
                column: "Itemid");

            migrationBuilder.CreateIndex(
                name: "IX_TrackItems_Trackid",
                table: "TrackItems",
                column: "Trackid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrackItems");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Tracks");
        }
    }
}
