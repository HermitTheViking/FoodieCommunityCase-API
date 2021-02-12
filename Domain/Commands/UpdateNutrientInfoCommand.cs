namespace FoodieCommunityCase.Domain.Commands
{
    public class UpdateNutrientInfoCommand
    {
        public string Name { get; set; }
        public string Unit { get; set; }
        public float? PerHundred { get; set; }
        public float? PerPortion { get; set; }
        public float? PerDay { get; set; }
    }
}
