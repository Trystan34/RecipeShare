using System;
using api.Interfaces;

namespace api.Services
{
    public class SubscriptionServices : ISubscriptionServices
    {
        public SubscriptionServices()
        {
            this.RecipeAddedService = new RecipeAddedService();
        }
        public RecipeAddedService RecipeAddedService { get; }
    }
}
