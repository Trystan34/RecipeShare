using System;
using System.Collections.Generic;

namespace RecipeShare.Models
{
    public class RecipeCategoryRepository : IRecipeCategoryRepository
    {
        private readonly AppDbContext _appDbContext;

        public RecipeCategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<RecipeCategory> AllCategories => _appDbContext.RecipeCategories;
    }
}
