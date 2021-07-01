using System;
using System.Collections.Generic;

namespace RecipeShare.Models
{
    public interface IRecipeCategoryRepository
    {
        IEnumerable<RecipeCategory> AllCategories { get; }
    }
}
