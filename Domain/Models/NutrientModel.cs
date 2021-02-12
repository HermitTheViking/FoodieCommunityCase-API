using System.Text.Json.Serialization;

namespace FoodieCommunityCase.Domain.Models
{
    public class NutrientModel
    {
        [JsonInclude]
        [JsonPropertyName("protein")]
        public NutrientInfoModel Protein { get; set; }
        [JsonInclude]
        [JsonPropertyName("energy")]
        public NutrientInfoModel Energy { get; set; }
        [JsonInclude]
        [JsonPropertyName("energy_kcal")]
        public NutrientInfoModel Energy_kcal { get; set; }
        [JsonInclude]
        [JsonPropertyName("fat")]
        public NutrientInfoModel Fat { get; set; }
        [JsonInclude]
        [JsonPropertyName("sodium")]
        public NutrientInfoModel Sodium { get; set; }
        [JsonInclude]
        [JsonPropertyName("fiber")]
        public NutrientInfoModel Fiber { get; set; }
        [JsonInclude]
        [JsonPropertyName("carbohydrates")]
        public NutrientInfoModel Carbohydrates { get; set; }
        [JsonInclude]
        [JsonPropertyName("sugars")]
        public NutrientInfoModel Sugars { get; set; }
        [JsonInclude]
        [JsonPropertyName("saturated_fat")]
        public NutrientInfoModel Saturated_fat { get; set; }
        [JsonInclude]
        [JsonPropertyName("salt")]
        public NutrientInfoModel Salt { get; set; }
    }
}
