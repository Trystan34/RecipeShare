using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RecipeShare.Models;

namespace RecipeShare.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly ILogger<RecipeController> _logger;
        private readonly IRecipeRepository _recipeRepository;
        private readonly IRecipeCategoryRepository _categoryRepository;

        public RecipeController(ILogger<RecipeController> logger, IRecipeRepository recipeRepository, IRecipeCategoryRepository categoryRepository)
        {
            _logger = logger;
            _recipeRepository = recipeRepository;
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public IEnumerable<Recipe> Get()
        {
            return _recipeRepository.AllRecipes.ToArray();
        }
    }
}
