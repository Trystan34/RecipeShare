using System;
using api.Services;

namespace api.Interfaces
{
    public interface ISubscriptionServices
    {
        RecipeAddedService RecipeAddedService { get; }
    }
}
