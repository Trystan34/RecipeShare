using System;

namespace api.Dto
{
    public class RecipeAddedMessage
    {
        public Guid Id { get; set; }
        public string RecipeName { get; set; }
        public string CategoryName { get; set; }
        public string Message { get; set; }
    }
}
