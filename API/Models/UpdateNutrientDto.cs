namespace FoodieCommunityCase.WebApi.Models
{
    public class UpdateNutrientDto
    {
        public UpdateNutrientInfoDto ProteinInfo { get; set; }
        public UpdateNutrientInfoDto EnergyInfo { get; set; }
        public UpdateNutrientInfoDto EnergyKcalInfo { get; set; }
        public UpdateNutrientInfoDto FatInfo { get; set; }
        public UpdateNutrientInfoDto SodiumInfo { get; set; }
        public UpdateNutrientInfoDto FiberInfo { get; set; }
        public UpdateNutrientInfoDto CarbohydratesInfo { get; set; }
        public UpdateNutrientInfoDto SugarsInfo { get; set; }
        public UpdateNutrientInfoDto SaturatedFatInfo { get; set; }
        public UpdateNutrientInfoDto SaltInfo { get; set; }
    }
}
