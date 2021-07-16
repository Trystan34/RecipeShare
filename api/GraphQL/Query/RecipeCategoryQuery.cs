using System;
using System.Linq;
using api.GraphQL.Types;
using api.Interfaces;
using api.Models;
using api.Repositories;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Hosting;

namespace api.GraphQL.Query
{
    public class RecipeCategoryQuery : IFieldQueryServiceItem
    {
        public void Activate(ObjectGraphType objectGraph, IWebHostEnvironment env, IServiceProvider sp)
        {
            objectGraph.Field<ListGraphType<RecipeCategoryType>>("recipeCategories",
            arguments: new QueryArguments(
                new QueryArgument<StringGraphType> { Name = "name" }
            ),
            resolve: context =>
            {
                var recipeCategoryRepository = (IGenericRepository<RecipeCategory>)sp.GetService(typeof(IGenericRepository<RecipeCategory>));
                var baseQuery = recipeCategoryRepository.GetAll();
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
