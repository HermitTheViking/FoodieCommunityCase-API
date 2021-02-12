namespace FoodieCommunityCase.WebApi.Models
{
    public class NutrientInfoDto
    {
        public int DbId { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public float? PerHundred { get; set; }
        public float? PerPortion { get; set; }
        public float? PerDay { get; set; }
    }
}
