namespace FoodieCommunityCase.WebApi.Models
{
    public class NutrientDto
    {
        public int DbId { get; set; }
        public virtual NutrientInfoDto ProteinInfo { get; set; }
        public virtual NutrientInfoDto CarbohydratesInfo { get; set; }
        public virtual NutrientInfoDto EnergyInfo { get; set; }
        public virtual NutrientInfoDto EnergyKcalInfo { get; set; }
        public virtual NutrientInfoDto FatInfo { get; set; }
        public virtual NutrientInfoDto FiberInfo { get; set; }
        public virtual NutrientInfoDto SodiumInfo { get; set; }
        public virtual NutrientInfoDto SugarsInfo { get; set; }
        public virtual NutrientInfoDto SaturatedFatInfo { get; set; }
        public virtual NutrientInfoDto SaltInfo { get; set; }
    }
}
