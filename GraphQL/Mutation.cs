using System;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;
using RecipeShare.Models;
using static RecipeShare.GraphQL.Types.RecipeType;

namespace RecipeShare.GraphQL
{
    public class Mutation
    {
        // This attribute will help us utilise the multi threaded api db context
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddRecipePayload> AddRecipeAsync(
            AddRecipeInput input,
            [ScopedService] AppDbContext context,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken)
        {
            var recipe = new Recipe
            {
                RecipeId = new Guid(),
                Name = input.name,
                CategoryId = input.categoryId
            };

            context.Recipes.Add(recipe);
            await context.SaveChangesAsync(cancellationToken);

            // Emit subscription.
            await eventSender.SendAsync(nameof(Subscription.OnRecipeAdded), recipe, cancellationToken);

            return new AddRecipePayload(recipe);
        }
    }
}
