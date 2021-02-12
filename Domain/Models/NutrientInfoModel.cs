using System.Text.Json.Serialization;

namespace FoodieCommunityCase.Domain.Models
{
    public class NutrientInfoModel
    {
        [JsonInclude]
        [JsonPropertyName("name_translations")]
        public TranslationModel Name_translations { get; set; }
        [JsonInclude]
        [JsonPropertyName("unit")]
        public string Unit { get; set; }
        [JsonInclude]
        [JsonPropertyName("per_hundred")]
        public float? Per_hundred { get; set; }
        [JsonInclude]
        [JsonPropertyName("per_portion")]
        public float? Per_portion { get; set; }
        [JsonInclude]
        [JsonPropertyName("per_day")]
        public float? Per_day { get; set; }
    }
}
