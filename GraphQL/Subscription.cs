using System;
using HotChocolate;
using HotChocolate.Types;
using RecipeShare.Models;

namespace RecipeShare.GraphQL
{
    public class Subscription
    {
        [Subscribe]
        [Topic]
        public Recipe OnRecipeAdded([EventMessage] Recipe recipe)
        {
            Console.WriteLine($"Recipe added: {recipe.Name}");
            return recipe;
        }
    }
}
