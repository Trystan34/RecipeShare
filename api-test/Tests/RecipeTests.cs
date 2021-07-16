using System;
using api.Interfaces;
using api.Models;
using api_test.Helpers;
using GraphQL;
using Xunit;

namespace api_test.Tests
{
    public class RecipeTests : IClassFixture<TestClassFixture>
    {
        private readonly TestClassFixture _fixture;
        private readonly IRecipeHelper _recipeHelper;
        public RecipeTests(TestClassFixture fixture)
        {
            _fixture = fixture;
            _recipeHelper = (IRecipeHelper)_fixture.Server.Host.Services.GetService(typeof(IRecipeHelper));
        }

        [Theory]
        [InlineData("Roast Chicken")]
        public void Creates_Recipe(string recipeName)
        {
            var newRecipe = _recipeHelper.CreateRecipe(recipeName);

            Assert.True(newRecipe != default(Recipe));
        }

        [Theory]
        [InlineData("Roast Pork")]
        public void Dont_Create_Dublicate_Recipe(string recipeName)
        {
            var uniqRecipeName = $"{recipeName}{TestClassFixture.RandomString(5)}";

            // First create the recipe
            var newRecipe = _recipeHelper.CreateRecipe(uniqRecipeName);
            Assert.True(newRecipe != default(Recipe));

            // Try to create the same recipe!
            ExecutionError testException = Assert.Throws<ExecutionError>(() =>
            {
                _recipeHelper.CreateRecipe(uniqRecipeName);
            });
            Assert.True(testException.Message == "duplicate_recipe_not_allowed");
        }
    }
}
