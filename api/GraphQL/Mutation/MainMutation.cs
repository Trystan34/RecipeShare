using System;
using api.Interfaces;
using GraphQL.Types;
using Microsoft.AspNetCore.Hosting;

namespace api.GraphQL.Mutation
{
    /// <summary>
    /// MainMutation is a top level entity (like MainQuery and MainSubscription) to be added to GraphQL schema. 
    /// Normally it includes all mutation definitions in it. i.e., you may have tens of mutations defined here. 
    /// For a trivial project, that would be quiet alright. 
    /// However, as the project gets larger and the number of mutations & queries increase, this becomes a problem. 
    /// Let's say you have a large developers team. Everybody will be updating the same file when they update a mutation. 
    /// The same is valid for query development. This would lead to merge conflicts when developments are to push to GIT. 
    /// It's not actually very good in terms of transparency. You'll not be able to see all the mutations and queries at a glance. 
    /// It's much leaner to create separate files for each schema items.
    /// </summary>
    public class MainMutation : ObjectGraphType
    {
        public MainMutation(IServiceProvider provider, IWebHostEnvironment env, IFieldService fieldService)
        {
            Name = "MainMutation";
            fieldService.ActivateFields(this, FieldServiceType.Mutation, env, provider);

            // Empty field to avoid 'MainMutation' must define one or more fields error
            Field<StringGraphType>("mainMutation",
            resolve: context =>
            {
                return "";
            });
        }
    }
}
