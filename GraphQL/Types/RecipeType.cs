using System;
using System.Linq;
using HotChocolate;
using HotChocolate.Types;
using RecipeShare.Models;

namespace RecipeShare.GraphQL.Types
{
    public class RecipeType : ObjectType<Recipe>
    {
        public record AddRecipePayload(Recipe recipe);
        // The object used to interact with adding a recipe.
        public record AddRecipeInput(string name, Guid categoryId);

        protected override void Configure(IObjectTypeDescriptor<Recipe> descriptor)
        {
            descriptor.Description("A recipe for food.");

            // Resolve a foreign key
            descriptor.Field(x => x.CategoryId)
                      .ResolveWith<Resolvers>(p => p.GetCategory(default!, default!))
                      .UseDbContext<AppDbContext>()
                      .Description("This is the category that the recipe belongs to.");
        }

        private class Resolvers
        {
            public RecipeCategory GetCategory(Recipe recipe, [ScopedService] AppDbContext context)
            {
                return context.RecipeCategories.FirstOrDefault(x => x.CategoryId == recipe.CategoryId);
            }
        }
    }
}
