namespace FoodieCommunityCase.Domain.Entities.Food
{
    public class NutrientInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public float? PerHundred { get; set; }
        public float? PerPortion { get; set; }
        public float? PerDay { get; set; }
    }
}
