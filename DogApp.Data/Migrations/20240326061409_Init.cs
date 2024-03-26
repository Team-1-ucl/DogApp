using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable



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
                    ItemCategory = table.Column<int>(type: "int", nullable: true),
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
                columns: new[] { "Id", "Description", "Image", "ItemCategory", "Name" },
                values: new object[,]
                {
                    { 1, "Description of Sign 1", "hest", 0, "Sign 1" },
                    { 2, "Description of Sign 2", "hest", 0, "Sign 2" },
                    { 3, "Description of Sign 3", "hest", 0, "Sign 3" },
                    { 4, "Description of Sign 4", "hest", 0, "Sign 4" },
                    { 5, "Description of Sign 5", "hest", 0, "Sign 5" },
                    { 6, "Description of Extra 1", "hest", 1, "Extra 1" },
                    { 7, "Description of Extra 2", "hest", 1, "Extra 2" },
                    { 8, "Description of Extra 3", "hest", 1, "Extra 3" },
                    { 9, "Description of Extra 4", "hest", 1, "Extra 4" },
                    { 10, "Description of Extra 5", "hest", 1, "Extra 5" }
                });

            migrationBuilder.InsertData(
                table: "Tracks",
                columns: new[] { "Id", "Category", "Height", "Name", "Width" },
                values: new object[,]
                {
                    { 1, "Category A", 100, "Rally 1", 200 },
                    { 2, "Category B", 150, "Rally 2", 250 },
                    { 3, "Category C", 120, "Rally 3", 180 }
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
