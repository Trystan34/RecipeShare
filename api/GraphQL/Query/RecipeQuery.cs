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
                new QueryArgument<StringGraphType> { Name = "name" }
            ),
            resolve: context =>
            {
                var recipeName = context.GetArgument<string>("name");

                var recipeRepository = (IGenericRepository<Recipe>)sp.GetService(typeof(IGenericRepository<Recipe>));
                var baseQuery = recipeRepository.GetAll();
                var name = context.GetArgument<string>("name");
                if (name != default(string))
                {
                    return baseQuery.Where(w => w.Name.Contains(name));
                }
                return baseQuery.ToList();
            });
        }
    }
}
