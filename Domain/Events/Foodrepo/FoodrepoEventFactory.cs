using FoodieCommunityCase.Domain.Entities.Food;
using System.Collections.Generic;

namespace FoodieCommunityCase.Domain.Events.Foodrepo
{
    public class FoodrepoEventFactory
    {
        public IEvent GetFoodrepoUpdatedEvent(List<Recip> model)
        {
            return new FoodrepoRecipUpdatedEvent()
            {
                Count = model.Count,
                FirstRepoId = model[0].RepoId,
                LastRepoId = model[^1].RepoId
            };
        }
    }
}
