using System;
using api.GraphQL.Types;
using api.Interfaces;
using api.Models;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Hosting;

namespace api.GraphQL.Mutation
{
    public class UpdateRecipeMutation : IFieldMutationServiceItem
    {
        public void Activate(ObjectGraphType objectGraph, IWebHostEnvironment env, IServiceProvider sp)
        {
            objectGraph.Field<RecipeType>("updateRecipe",
            arguments: new QueryArguments(
               new QueryArgument<NonNullGraphType<GuidGraphType>> { Name = "id" },
               new QueryArgument<StringGraphType> { Name = "name" },
               new QueryArgument<GuidGraphType> { Name = "categoryId" }
            ),
            resolve: context =>
            {
                var recipeId = context.GetArgument<Guid>("id");
                var recipeCategoryId = context.GetArgument<Guid?>("categoryId");
                var recipeName = context.GetArgument<string>("name");

                var recipeRepository = (IGenericRepository<Recipe>)sp.GetService(typeof(IGenericRepository<Recipe>));
                var foundRecipe = recipeRepository.GetById(recipeId);

                if (recipeCategoryId != null)
                {
                    foundRecipe.Category.Id = recipeCategoryId.Value;
                }
                if (!String.IsNullOrEmpty(recipeName))
                {
                    foundRecipe.Name = recipeName;
                }

                return recipeRepository.Update(foundRecipe);
            });
        }
    }
}
