using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using api.Interfaces;
using api.Models;
using api_test.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace api_test.Tests
{
    public class QueryTests : IClassFixture<TestClassFixture>
    {
        private readonly TestClassFixture _fixture;
        private readonly IRecipeHelper _recipeHelper;
        public QueryTests(TestClassFixture fixture)
        {
            _fixture = fixture;
            _recipeHelper = (IRecipeHelper)_fixture.Server.Host.Services.GetService(typeof(IRecipeHelper));
        }

        [Fact]
        public async Task Queries_Existing_Recipes_By_Name()
        {
            var recipeName = TestClassFixture.RandomString(5);

            var newCountry1 = _recipeHelper.CreateRecipe($"{recipeName}{TestClassFixture.RandomString(5)}");
            Assert.True(newCountry1 != default(Recipe));

            var newCountry2 = _recipeHelper.CreateRecipe($"{recipeName}{TestClassFixture.RandomString(5)}");
            Assert.True(newCountry2 != default(Recipe));

            var newCountry3 = _recipeHelper.CreateRecipe($"{recipeName}{TestClassFixture.RandomString(5)}");
            Assert.True(newCountry3 != default(Recipe));

            var param = new JObject();
            param["query"] = @"query recipes($name:String!){
                                  recipes(name:$name){
                                    id
                                    name
                                  }}";

            dynamic variables = new JObject();
            variables.name = recipeName;

            param["variables"] = variables;
            var content = new StringContent(JsonConvert.SerializeObject(param), UTF8Encoding.UTF8, "application/json");
            var response = await _fixture.Client.PostAsync("graphql", content);
            var serviceResultJson = await response.Content.ReadAsStringAsync();

            var gqlResult = new GqlResultList<Recipe>(serviceResultJson, "recipes");

            Assert.True(gqlResult.GraphQLError == null);
            Assert.True(gqlResult.Data != null);
            Assert.True(gqlResult.Data.Count == 3);
        }
    }
}
