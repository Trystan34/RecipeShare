using System;
using System.Linq;
using api.GraphQL.Types;
using api.Interfaces;
using api.Models;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Hosting;

namespace api.GraphQL.Query
{
    public class RecipeQuery : IFieldQueryServiceItem
    {
        public void Activate(ObjectGraphType objectGraph, IWebHostEnvironment env, IServiceProvider sp)
        {
            objectGraph.Field<ListGraphType<RecipeType>>("recipes",
            arguments: new QueryArguments(
                new QueryArgument<GuidGraphType> { Name = "id" },
                new QueryArgument<StringGraphType> { Name = "name" }
            ),
            resolve: context =>
            {
                var recipeId = context.GetArgument<Guid>("id");
                var recipeName = context.GetArgument<string>("name");

                var recipeRepository = (IGenericRepository<Recipe>)sp.GetService(typeof(IGenericRepository<Recipe>));
                var baseQuery = recipeRepository.GetAll();

                if (recipeId != default(Guid) && recipeName != default(string))
                {
                    return baseQuery.Where(r => r.Id.Equals(recipeId) && r.Name.Contains(recipeName));
                }

                if (recipeId != default(Guid))
                {
                    return baseQuery.Where(r => r.Id.Equals(recipeId));
                }

                if (recipeName != default(string))
                {
                    return baseQuery.Where(r => r.Name.Contains(recipeName));
                }
                return baseQuery.ToList();
            });
        }
    }
}
