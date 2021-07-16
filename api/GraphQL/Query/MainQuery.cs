using System;
using api.Interfaces;
using GraphQL.Types;
using Microsoft.AspNetCore.Hosting;

namespace api.GraphQL.Query
{
    public class MainQuery : ObjectGraphType
    {
        public MainQuery(IServiceProvider provider, IWebHostEnvironment env, IFieldService fieldService)
        {
            Name = "MainQuery";
            fieldService.ActivateFields(this, FieldServiceType.Query, env, provider);

            // Empty field to avoid 'MainQuery' must define one or more fields error
            Field<StringGraphType>("mainQuery",
            resolve: context =>
            {
                return "";
            });
        }
    }
}
