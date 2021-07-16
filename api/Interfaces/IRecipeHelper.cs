using System;
using api.Models;

namespace api.Interfaces
{
    public interface IRecipeHelper
    {
        Recipe CreateRecipe(string recipeName);
    }
}
