using System.Text.Json.Serialization;

namespace FoodieCommunityCase.Domain.Models
{
    public class TranslationModel
    {
        [JsonInclude]
        [JsonPropertyName("de")]
        public string De { get; set; }
        [JsonInclude]
        [JsonPropertyName("en")]
        public string En { get; set; }
        [JsonInclude]
        [JsonPropertyName("fr")]
        public string Fr { get; set; }
        [JsonInclude]
        [JsonPropertyName("it")]
        public string It { get; set; }
    }
}
