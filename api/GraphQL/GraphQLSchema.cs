using System;
using api.GraphQL.Mutation;
using api.GraphQL.Query;
using api.GraphQL.Subscription;
using api.Interfaces;
using api.Services;
using GraphQL.Types;
using Microsoft.AspNetCore.Hosting;

namespace api.GraphQL
{
    public class GraphQLSchema : Schema
    {
        /// <summary>
        /// In the constructor, first thing to do is to resolve IFieldService and call its RegisterFields() method. 
        /// What this does is, to collect all the classes which implements IFieldQueryServiceItem and keep them in 
        /// _fieldTable of the FieldService Then MainMutation, MainQuery and MainSubscription are resolved. 
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="environment"></param>
        /// <param name="fieldService"></param>
        /// <returns></returns>
        public GraphQLSchema(IServiceProvider provider, IWebHostEnvironment environment, IFieldService fieldService) : base(provider)
        {
            fieldService.RegisterFields();
            Query = new MainQuery(provider, environment, fieldService);
            Mutation = new MainMutation(provider, environment, fieldService);
            Subscription = new MainSubscription(provider, environment, fieldService);
        }
    }
}
