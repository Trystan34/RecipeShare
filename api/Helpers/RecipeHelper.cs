using System;
using System.Linq;
using api.Interfaces;
using api.Models;
using GraphQL;
using Microsoft.EntityFrameworkCore;

namespace api.Helpers
{
    public class RecipeHelper : IRecipeHelper
    {
        private readonly IGenericRepository<Recipe> _recipeRepository;
        public RecipeHelper(IGenericRepository<Recipe> recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }
        public Recipe CreateRecipe(string recipeName)
        {
            var newRecipe = new Recipe
            {
                Id = new Guid(),
                Name = recipeName,
                CategoryId = new Guid("c32cc263-a7af-4fbd-99a0-aceb57c91f6b")
            };
            Recipe createdRecipe = null;
            try
            {
                createdRecipe = _recipeRepository.Insert(newRecipe);
            }
            catch (DbUpdateException dbException)
            {
                if (dbException.InnerException.Message.Contains("duplicate key value"))
                {
                    throw new ExecutionError("duplicate_recipe_not_allowed", dbException.InnerException);
                }
                else
                {
                    throw dbException;
                }
            }
            return createdRecipe;
        }

        public Recipe QueryRecipe(string recipeName)
        {
            return _recipeRepository.GetAll().FirstOrDefault(c => c.Name == recipeName);
        }
    }
}
