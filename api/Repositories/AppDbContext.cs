using System;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(now())");
                entity.HasIndex(e => e.Name).IsUnique(true);
            });

            modelBuilder.Entity<RecipeCategory>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(now())");
                entity.HasIndex(e => e.Name).IsUnique(true);
            });

            // Seed categories.
            modelBuilder.Entity<RecipeCategory>().HasData(new RecipeCategory { Id = new Guid("c32cc263-a7af-4fbd-99a0-aceb57c91f6b"), Name = "Roast" });
            modelBuilder.Entity<RecipeCategory>().HasData(new RecipeCategory { Id = new Guid("8223c37b-4ca4-4d14-8e9f-027e147e9642"), Name = "Pies" });
            modelBuilder.Entity<RecipeCategory>().HasData(new RecipeCategory { Id = new Guid("6bc96ff6-a14c-41d9-b3d6-47c51f2e5198"), Name = "Stir fry" });

            // Seed Recipes.
            modelBuilder.Entity<Recipe>().HasData(new Recipe
            {
                Id = new Guid("e7448fc2-1cbe-48ad-a69e-deda6ca38ddb"),
                Name = "Roast duck with duck fat potatoes",
                ShortDescription = "The duck fat makes the potatoes extra crispy.",
                LongDescription =
                    "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
                CategoryId = new Guid("c32cc263-a7af-4fbd-99a0-aceb57c91f6b"),
                Rating = 5,
                AllergyInformation = "None",
                PreparationTime = 10,
                CookTime = 60,
                Serves = 6
            });

            modelBuilder.Entity<Recipe>().HasData(new Recipe
            {
                Id = new Guid("78edd685-1b1e-4105-a95f-bfafa2ef05a6"),
                Name = "Apple Pie",
                ShortDescription = "Delicious like grandma made!",
                LongDescription =
                    "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
                CategoryId = new Guid("8223c37b-4ca4-4d14-8e9f-027e147e9642"),
                Rating = 4,
                AllergyInformation = "Gluten",
                PreparationTime = 20,
                CookTime = 40,
                Serves = 4,
                ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/applepie.jpg",
                ImageThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/applepiesmall.jpg",
                Notes = "My grandma made this."
            });
        }
    }
}
