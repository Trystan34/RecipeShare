using System;
using api.GraphQL.Types;
using api.Interfaces;
using api.Models;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Hosting;

namespace api.GraphQL.Mutation
{
    public class RecipeCategoryMutation : IFieldMutationServiceItem
    {
        public void Activate(ObjectGraphType objectGraph, IWebHostEnvironment env, IServiceProvider sp)
        {
            objectGraph.Field<RecipeCategoryType>("addCategory",
            arguments: new QueryArguments(
            new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "name" },
            new QueryArgument<StringGraphType> { Name = "description" }
            ),
            resolve: context =>
            {
                var categoryName = context.GetArgument<string>("name");
                var description = context.GetArgument<string>("description");
                var recipeCategoryRepository = (IGenericRepository<RecipeCategory>)sp.GetService(typeof(IGenericRepository<RecipeCategory>));

                var newCategory = new RecipeCategory
                {
                    Id = new Guid(),
                    Name = categoryName,
                    Description = description
                };

                return recipeCategoryRepository.Insert(newCategory);
            });
        }
    }
}
