using System;
using System.Collections.Generic;

namespace RecipeShare.Models
{
    /// <summary>
    /// The repository interface - enforces functions on anything that accesses recipe repository.
    /// </summary>
    public interface IRecipeRepository
    {
        IEnumerable<Recipe> AllRecipes { get; }
        Recipe GetRecipeById(Guid recipeId);
    }
}
