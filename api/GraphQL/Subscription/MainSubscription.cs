using System;
using api.Interfaces;
using GraphQL.Types;
using Microsoft.AspNetCore.Hosting;

namespace api.GraphQL.Subscription
{
    public class MainSubscription : ObjectGraphType
    {
        public MainSubscription(IServiceProvider provider, IWebHostEnvironment env, IFieldService fieldService)
        {
            Name = "MainSubscription";
            fieldService.ActivateFields(this, FieldServiceType.Subscription, env, provider);

            // Empty field to avoid 'MainSubscription' must define one or more fields error
            Field<StringGraphType>("mainSubscription",
            resolve: context =>
            {
                return "";
            });
        }
    }
}
