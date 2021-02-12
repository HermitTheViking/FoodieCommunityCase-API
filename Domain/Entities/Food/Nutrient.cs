#nullable enable

namespace FoodieCommunityCase.Domain.Entities.Food
{
    public class Nutrient
    {
        public int Id { get; set; }
        public virtual NutrientInfo? ProteinInfo { get; set; }
        public virtual NutrientInfo? CarbohydratesInfo { get; set; }
        public virtual NutrientInfo? EnergyInfo { get; set; }
        public virtual NutrientInfo? EnergyKcalInfo { get; set; }
        public virtual NutrientInfo? FatInfo { get; set; }
        public virtual NutrientInfo? FiberInfo { get; set; }
        public virtual NutrientInfo? SodiumInfo { get; set; }
        public virtual NutrientInfo? SugarsInfo { get; set; }
        public virtual NutrientInfo? SaturatedFatInfo { get; set; }
        public virtual NutrientInfo? SaltInfo { get; set; }
    }
}
