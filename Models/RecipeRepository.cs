using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RecipeShare.Models
{
    /// <summary>
    /// Interacts with the database.
    /// </summary>
    public class RecipeRepository : IRecipeRepository
    {
        private readonly AppDbContext _appDbContext;
        public RecipeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Recipe> AllRecipes
        {
            get
            {
                return _appDbContext.Recipes;
            }

        }

        public Recipe GetRecipeById(Guid recipeId)
        {
            return _appDbContext.Recipes.FirstOrDefault(p => p.RecipeId == recipeId);
        }
    }
}
