using System;
using api.Dto;
using GraphQL.Types;

namespace api.GraphQL.Types
{
    public class RecipeAddedMessageType : ObjectGraphType<RecipeAddedMessage>
    {
        public RecipeAddedMessageType()
        {
            Field(x => x.Id, type: typeof(GuidGraphType));
            Field(x => x.Message, type: typeof(StringGraphType));
            Field(x => x.RecipeName, type: typeof(StringGraphType));
            Field(x => x.CategoryName, type: typeof(StringGraphType));
        }
    }
}
