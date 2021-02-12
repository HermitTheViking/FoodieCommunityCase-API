namespace FoodieCommunityCase.Domain.Commands
{
    public class CreateNutrientCommand
    {
        public CreateNutrientInfoCommand ProteinInfo { get; set; }
        public CreateNutrientInfoCommand EnergyInfo { get; set; }
        public CreateNutrientInfoCommand EnergyKcalInfo { get; set; }
        public CreateNutrientInfoCommand FatInfo { get; set; }
        public CreateNutrientInfoCommand SodiumInfo { get; set; }
        public CreateNutrientInfoCommand FiberInfo { get; set; }
        public CreateNutrientInfoCommand CarbohydratesInfo { get; set; }
        public CreateNutrientInfoCommand SugarsInfo { get; set; }
        public CreateNutrientInfoCommand SaturatedFatInfo { get; set; }
        public CreateNutrientInfoCommand SaltInfo { get; set; }
    }
}
