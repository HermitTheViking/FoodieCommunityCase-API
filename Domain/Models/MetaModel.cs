using System.Text.Json.Serialization;

namespace FoodieCommunityCase.Domain.Models
{
    public class MetaModel
    {
        [JsonInclude]
        [JsonPropertyName("api_version")]
        public string Api_version { get; set; }
        [JsonInclude]
        [JsonPropertyName("generated_in")]
        public int Generated_in { get; set; }
    }
}
