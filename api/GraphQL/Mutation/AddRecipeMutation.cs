using System;
using api.Dto;
using api.GraphQL.Types;
using api.Interfaces;
using api.Models;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Hosting;

namespace api.GraphQL.Mutation
{
    public class AddRecipeMutation : IFieldMutationServiceItem
    {
        public void Activate(ObjectGraphType objectGraph, IWebHostEnvironment env, IServiceProvider sp)
        {
            objectGraph.Field<RecipeType>("addRecipe",
            arguments: new QueryArguments(
               new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "recipeName" },
               new QueryArgument<NonNullGraphType<GuidGraphType>> { Name = "categoryId" }
            ),
            resolve: context =>
            {
                var recipeName = context.GetArgument<string>("recipeName");
                var categoryId = context.GetArgument<Guid>("categoryId");

                var subscriptionServices = (ISubscriptionServices)sp.GetService(typeof(ISubscriptionServices));
                var recipeCategoryRepository = (IGenericRepository<RecipeCategory>)sp.GetService(typeof(IGenericRepository<RecipeCategory>));
                var recipeRepository = (IGenericRepository<Recipe>)sp.GetService(typeof(IGenericRepository<Recipe>));

                var foundCategory = recipeCategoryRepository.GetById(categoryId);

                var newRecipe = new Recipe
                {
                    Id = new Guid(),
                    Name = recipeName,
                    Category = foundCategory
                };

                var addedRecipe = recipeRepository.Insert(newRecipe);

                subscriptionServices.RecipeAddedService.AddRecipeAddedMessage(new RecipeAddedMessage
                {
                    Id = addedRecipe.Id,
                    RecipeName = addedRecipe.Name,
                    CategoryName = foundCategory.Name,
                    Message = "A new recipe was added."
                });

                return addedRecipe;
            });
        }
    }
}
