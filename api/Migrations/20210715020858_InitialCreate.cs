using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "business");

            migrationBuilder.CreateTable(
                name: "recipe_category",
                schema: "business",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "(now())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recipe_category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "recipe",
                schema: "business",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    ShortDescription = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    LongDescription = table.Column<string>(type: "character varying(1500)", maxLength: 1500, nullable: true),
                    AllergyInformation = table.Column<string>(type: "text", nullable: true),
                    Rating = table.Column<double>(type: "double precision", nullable: false),
                    PreparationTime = table.Column<int>(type: "integer", nullable: false),
                    CookTime = table.Column<int>(type: "integer", nullable: false),
                    Serves = table.Column<double>(type: "double precision", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    ImageThumbnailUrl = table.Column<string>(type: "text", nullable: true),
                    VideoUrl = table.Column<string>(type: "text", nullable: true),
                    VideoThumbnailUrl = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "(now())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recipe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_recipe_recipe_category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "business",
                        principalTable: "recipe_category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "business",
                table: "recipe_category",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("c32cc263-a7af-4fbd-99a0-aceb57c91f6b"), null, "Roast" },
                    { new Guid("8223c37b-4ca4-4d14-8e9f-027e147e9642"), null, "Pies" },
                    { new Guid("6bc96ff6-a14c-41d9-b3d6-47c51f2e5198"), null, "Stir fry" }
                });

            migrationBuilder.InsertData(
                schema: "business",
                table: "recipe",
                columns: new[] { "Id", "AllergyInformation", "CategoryId", "CookTime", "ImageThumbnailUrl", "ImageUrl", "LongDescription", "Name", "Notes", "PreparationTime", "Rating", "Serves", "ShortDescription", "VideoThumbnailUrl", "VideoUrl" },
                values: new object[,]
                {
                    { new Guid("e7448fc2-1cbe-48ad-a69e-deda6ca38ddb"), "None", new Guid("c32cc263-a7af-4fbd-99a0-aceb57c91f6b"), 60, null, null, "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.", "Roast duck with duck fat potatoes", null, 10, 5.0, 6.0, "The duck fat makes the potatoes extra crispy.", null, null },
                    { new Guid("78edd685-1b1e-4105-a95f-bfafa2ef05a6"), "Gluten", new Guid("8223c37b-4ca4-4d14-8e9f-027e147e9642"), 40, "https://gillcleerenpluralsight.blob.core.windows.net/files/applepiesmall.jpg", "https://gillcleerenpluralsight.blob.core.windows.net/files/applepie.jpg", "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.", "Apple Pie", "My grandma made this.", 20, 4.0, 4.0, "Delicious like grandma made!", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_recipe_CategoryId",
                schema: "business",
                table: "recipe",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_recipe_Name",
                schema: "business",
                table: "recipe",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_recipe_category_Name",
                schema: "business",
                table: "recipe_category",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "recipe",
                schema: "business");

            migrationBuilder.DropTable(
                name: "recipe_category",
                schema: "business");
        }
    }
}
