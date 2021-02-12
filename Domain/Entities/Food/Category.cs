namespace FoodieCommunityCase.Domain.Entities.Food
{
    public class Category
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public virtual Image Image { get; set; }
    }
}
