namespace FoodieCommunityCase.WebApi.Models
{
    public class CreateNutrientDto
    {
        public CreateNutrientInfoDto ProteinInfo { get; set; }
        public CreateNutrientInfoDto EnergyInfo { get; set; }
        public CreateNutrientInfoDto EnergyKcalInfo { get; set; }
        public CreateNutrientInfoDto FatInfo { get; set; }
        public CreateNutrientInfoDto SodiumInfo { get; set; }
        public CreateNutrientInfoDto FiberInfo { get; set; }
        public CreateNutrientInfoDto CarbohydratesInfo { get; set; }
        public CreateNutrientInfoDto SugarsInfo { get; set; }
        public CreateNutrientInfoDto SaturatedFatInfo { get; set; }
        public CreateNutrientInfoDto SaltInfo { get; set; }
    }
}
