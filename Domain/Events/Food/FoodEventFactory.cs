using FoodieCommunityCase.Domain.Entities.Food;

namespace FoodieCommunityCase.Domain.Events.Food
{
    public class FoodEventFactory
    {
        public IEvent GetFoodUpdatedEvent(Recip model)
        {
            return new FoodUpdatedEvent()
            {
                Id = model.Id,
                RecepiName = model.Name
            };
        }

        public IEvent GetFoodCreatedEvent(Recip model)
        {
            return new FoodCreatedEvent()
            {
                RecepiName = model.Name
            };
        }
    }
}
