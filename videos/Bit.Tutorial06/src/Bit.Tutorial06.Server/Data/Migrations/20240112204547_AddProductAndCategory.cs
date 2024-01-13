using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bit.Tutorial06.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddProductAndCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Color = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 512, nullable: true),
                    CreatedOn = table.Column<long>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Color", "Name" },
                values: new object[,]
                {
                    { 1, "#FFCD56", "Ford" },
                    { 2, "#FF6384", "Nissan" },
                    { 3, "#4BC0C0", "Benz" },
                    { 4, "#FF9124", "BMW" },
                    { 5, "#2B88D8", "Tesla" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, 1306466648064000120L, "The Ford Mustang is ranked #1 in Sports Cars", "Mustang", 27155m },
                    { 2, 1, 1306457800704000120L, "The Ford GT is a mid-engine two-seater sports car manufactured and marketed by American automobile manufacturer", "GT", 500000m },
                    { 3, 1, 1306440105984000120L, "Ford Ranger is a nameplate that has been used on multiple model lines of pickup trucks sold by Ford worldwide.", "Ranger", 25000m },
                    { 4, 1, 1306431258624000120L, "Raptor is a SCORE off-road trophy truck living in a asphalt world", "Raptor", 53205m },
                    { 5, 1, 1306422411264000120L, "The Ford Maverick is a compact pickup truck produced by Ford Motor Company.", "Maverick", 22470m },
                    { 6, 2, 1306466648064000120L, "A powerful convertible sports car", "Roadster", 42800m },
                    { 7, 2, 1306457800704000120L, "A perfectly adequate family sedan with sharp looks", "Altima", 24550m },
                    { 8, 2, 1306440105984000120L, "Legendary supercar with AWD, 4 seats, a powerful V6 engine and the latest tech", "GT-R", 113540m },
                    { 9, 2, 1306422411264000120L, "A new smart SUV", "Juke", 28100m },
                    { 10, 3, 1306466648064000120L, "", "H247", 54950m },
                    { 11, 3, 1306457800704000120L, "", "V297", 103360m },
                    { 12, 3, 1306422411264000120L, "", "R50", 2000000m },
                    { 13, 4, 1306466648064000120L, "", "M550i", 77790m },
                    { 14, 4, 1306457800704000120L, "", "540i", 60945m },
                    { 15, 4, 1306448953344000120L, "", "530e", 56545m },
                    { 16, 4, 1306440105984000120L, "", "530i", 55195m },
                    { 17, 4, 1306431258624000120L, "", "M850i", 100045m },
                    { 18, 4, 1306422411264000120L, "", "X7", 77980m },
                    { 19, 4, 1306413563904000120L, "", "IX", 87000m },
                    { 20, 5, 1306466648064000120L, "rapid acceleration and dynamic handling", "Model 3", 61990m },
                    { 21, 5, 1306457800704000120L, "finishes near the top of our luxury electric car rankings.", "Model S", 135000m },
                    { 22, 5, 1306448953344000120L, "Heart-pumping acceleration, long drive range", "Model X", 138890m },
                    { 23, 5, 1306422411264000120L, "extensive driving range, lots of standard safety features", "Model Y", 67790m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                table: "Products",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
