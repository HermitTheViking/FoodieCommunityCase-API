namespace FoodieCommunityCase.WebApi.Models
{
    public class CreateNutrientInfoDto
    {
        public string Name { get; set; }
        public string Unit { get; set; }
        public float? PerHundred { get; set; }
        public float? PerPortion { get; set; }
        public float? PerDay { get; set; }
    }
}
