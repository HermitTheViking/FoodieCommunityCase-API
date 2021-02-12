namespace FoodieCommunityCase.Domain.Commands
{
    public class UpdateNutrientCommand
    {
        public UpdateNutrientInfoCommand ProteinInfo { get; set; }
        public UpdateNutrientInfoCommand EnergyInfo { get; set; }
        public UpdateNutrientInfoCommand EnergyKcalInfo { get; set; }
        public UpdateNutrientInfoCommand FatInfo { get; set; }
        public UpdateNutrientInfoCommand SodiumInfo { get; set; }
        public UpdateNutrientInfoCommand FiberInfo { get; set; }
        public UpdateNutrientInfoCommand CarbohydratesInfo { get; set; }
        public UpdateNutrientInfoCommand SugarsInfo { get; set; }
        public UpdateNutrientInfoCommand SaturatedFatInfo { get; set; }
        public UpdateNutrientInfoCommand SaltInfo { get; set; }
    }
}
