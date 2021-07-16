using System;
using api.Interfaces;
using api.Models;
using GraphQL.Types;

namespace api.GraphQL.Types
{
    public class RecipeType : ObjectGraphType<Recipe>
    {
        public IServiceProvider Provider { get; set; }
        public RecipeType(IServiceProvider provider)
        {
            Field(x => x.Id, type: typeof(GuidGraphType));
            Field(x => x.Name, type: typeof(StringGraphType));
            Field(x => x.CategoryId, type: typeof(GuidGraphType));
            // The category that this recipe belongs to.
            Field<RecipeCategoryType>("category", resolve: context =>
            {
                IGenericRepository<RecipeCategory> recipeCategoryRepository = (IGenericRepository<RecipeCategory>)provider.GetService(typeof(IGenericRepository<RecipeCategory>));
                Guid categoryId = context.Source.CategoryId;
                return recipeCategoryRepository.GetById(categoryId);
            });
        }
    }
}
