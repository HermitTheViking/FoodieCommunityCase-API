namespace FoodieCommunityCase.Domain.Events.Food
{
    internal class FoodCreatedEvent : IEvent
    {
        public string RecepiName { get; set; }
    }
}
