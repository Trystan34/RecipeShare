using System;
using api.Interfaces;
using api.Models;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Hosting;

namespace api.GraphQL.Mutation
{
    public class DeleteRecipeMutation : IFieldMutationServiceItem
    {
        public void Activate(ObjectGraphType objectGraph, IWebHostEnvironment env, IServiceProvider sp)
        {
            objectGraph.Field<StringGraphType>("deleteRecipe",
            arguments: new QueryArguments(
               new QueryArgument<NonNullGraphType<GuidGraphType>> { Name = "id" }
            ),
            resolve: context =>
            {
                var recipeId = context.GetArgument<Guid>("id");
                var recipeRepository = (IGenericRepository<Recipe>)sp.GetService(typeof(IGenericRepository<Recipe>));
                recipeRepository.Delete(recipeId);
                return $"recipeId:{recipeId} deleted";
            });
        }
    }
}
