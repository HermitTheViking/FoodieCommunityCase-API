namespace FoodieCommunityCase.Domain.Events.Foodrepo
{
    internal class FoodrepoRecipUpdatedEvent : IEvent
    {
        public int Count { get; set; }
        public int FirstRepoId { get; set; }
        public int LastRepoId { get; set; }
    }
}
