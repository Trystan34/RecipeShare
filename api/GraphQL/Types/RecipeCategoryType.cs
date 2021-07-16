using System;
using System.Linq;
using api.Interfaces;
using api.Models;
using GraphQL.Types;

namespace api.GraphQL.Types
{
    public class RecipeCategoryType : ObjectGraphType<RecipeCategory>
    {
        public IServiceProvider Provider { get; set; }
        public RecipeCategoryType(IServiceProvider provider)
        {
            Field(x => x.Id, type: typeof(GuidGraphType));
            Field(x => x.Name, type: typeof(StringGraphType));
            Field(x => x.Description, type: typeof(StringGraphType));
            // The recipes that belong to this category.
            Field<ListGraphType<RecipeType>>("recipes", resolve: context =>
            {
                IGenericRepository<Recipe> recipeRepository = (IGenericRepository<Recipe>)provider.GetService(typeof(IGenericRepository<Recipe>));
                Guid currentCategoryId = context.Source.Id;
                return recipeRepository.GetAll().Where(r => r.CategoryId == currentCategoryId);
            });
        }
    }
}
