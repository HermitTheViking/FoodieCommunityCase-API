namespace FoodieCommunityCase.Domain.Events.Food
{
    internal class FoodUpdatedEvent : IEvent
    {
        public int Id { get; set; }
        public string RecepiName { get; set; }
    }
}
