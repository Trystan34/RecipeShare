using System;
using System.Linq;
using HotChocolate;
using HotChocolate.Types;
using RecipeShare.Models;

namespace RecipeShare.GraphQL.Types
{
    public class RecipeCategoryType : ObjectType<RecipeCategory>
    {
        public record AddRecipeCategoryPayload(RecipeCategory recipeCategory);
        public record AddRecipeCategoryInput(string name, string description = "");
        // Since we are inheriting from ObjectType we need to override the functionality
        protected override void Configure(IObjectTypeDescriptor<RecipeCategory> descriptor)
        {
            descriptor.Description("Get all the recipes for a category.");

            // descriptor.Field(x => x.Recipes).Ignore();

            descriptor.Field(x => x.Recipes)
                        .ResolveWith<Resolvers>(p => p.GetRecipes(default!, default!))
                        .UseDbContext<AppDbContext>()
                        .Description("These are all the recipes available for this category.");
        }

        private class Resolvers
        {
            public IQueryable<Recipe> GetRecipes(RecipeCategory recipeCategory, [ScopedService] AppDbContext context)
            {
                return context.Recipes.Where(x => x.CategoryId == recipeCategory.CategoryId);
            }
        }
    }
}
