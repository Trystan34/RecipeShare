using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RecipeShare.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RecipeCategories",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeCategories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    RecipeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    LongDescription = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
                    AllergyInformation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    PreparationTime = table.Column<int>(type: "int", nullable: false),
                    CookTime = table.Column<int>(type: "int", nullable: false),
                    Serves = table.Column<double>(type: "float", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageThumbnailUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoThumbnailUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.RecipeId);
                    table.ForeignKey(
                        name: "FK_Recipes_RecipeCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "RecipeCategories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "RecipeCategories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[] { new Guid("c32cc263-a7af-4fbd-99a0-aceb57c91f6b"), "Roast", null });

            migrationBuilder.InsertData(
                table: "RecipeCategories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[] { new Guid("8223c37b-4ca4-4d14-8e9f-027e147e9642"), "Pies", null });

            migrationBuilder.InsertData(
                table: "RecipeCategories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[] { new Guid("6bc96ff6-a14c-41d9-b3d6-47c51f2e5198"), "Stir fry", null });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "RecipeId", "AllergyInformation", "CategoryId", "CookTime", "ImageThumbnailUrl", "ImageUrl", "LongDescription", "Name", "Notes", "PreparationTime", "Rating", "Serves", "ShortDescription", "VideoThumbnailUrl", "VideoUrl" },
                values: new object[] { new Guid("e7448fc2-1cbe-48ad-a69e-deda6ca38ddb"), "None", new Guid("c32cc263-a7af-4fbd-99a0-aceb57c91f6b"), 60, null, null, "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.", "Roast duck with duck fat potatoes", null, 10, 5.0, 6.0, "The duck fat makes the potatoes extra crispy.", null, null });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "RecipeId", "AllergyInformation", "CategoryId", "CookTime", "ImageThumbnailUrl", "ImageUrl", "LongDescription", "Name", "Notes", "PreparationTime", "Rating", "Serves", "ShortDescription", "VideoThumbnailUrl", "VideoUrl" },
                values: new object[] { new Guid("78edd685-1b1e-4105-a95f-bfafa2ef05a6"), "Gluten", new Guid("8223c37b-4ca4-4d14-8e9f-027e147e9642"), 40, "https://gillcleerenpluralsight.blob.core.windows.net/files/applepiesmall.jpg", "https://gillcleerenpluralsight.blob.core.windows.net/files/applepie.jpg", "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.", "Apple Pie", "My grandma made this.", 20, 4.0, 4.0, "Delicious like grandma made!", null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_CategoryId",
                table: "Recipes",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "RecipeCategories");
        }
    }
}
