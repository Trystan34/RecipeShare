using System;
using System.Linq;
using HotChocolate;
using HotChocolate.Data;
using RecipeShare.Models;

namespace RecipeShare.GraphQL
{
    public class Query
    {
        // UseDbContext attribute is pulling a db context from a pool then returning the db context to the pool
        [UseDbContext(typeof(AppDbContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Recipe> GetRecipe([ScopedService] AppDbContext context)
        {
            return context.Recipes;
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<RecipeCategory> GetRecipeCategories([ScopedService] AppDbContext context)
        {
            return context.RecipeCategories;
        }
    }
}
