using System;
using api.Dto;
using api.GraphQL.Types;
using api.Interfaces;
using GraphQL;
using GraphQL.Resolvers;
using GraphQL.Types;
using Microsoft.AspNetCore.Hosting;

namespace api.GraphQL.Subscription
{
    public class RecipeAddedSubscription : IFieldSubscriptionServiceItem
    {
        public void Activate(ObjectGraphType objectGraph, IWebHostEnvironment env, IServiceProvider sp)
        {
            objectGraph.AddField(new EventStreamFieldType
            {
                Name = "recipeAdded",
                Type = typeof(RecipeAddedMessageType),
                Resolver = new FuncFieldResolver<RecipeAddedMessage>(context => context.Source as RecipeAddedMessage),
                Arguments = new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "name" }
                ),
                Subscriber = new EventStreamResolver<RecipeAddedMessage>(context =>
                    {
                        var subscriptionServices = (ISubscriptionServices)sp.GetService(typeof(ISubscriptionServices));
                        var recipeName = context.GetArgument<string>("name");
                        return subscriptionServices.RecipeAddedService.GetMessages(recipeName);
                    })
            });
        }
    }
}
