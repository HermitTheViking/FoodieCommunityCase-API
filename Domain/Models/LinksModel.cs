using System.Text.Json.Serialization;

namespace FoodieCommunityCase.Domain.Models
{
    public class LinksModel
    {
        [JsonInclude]
        [JsonPropertyName("self")]
        public string Self { get; set; }
        [JsonInclude]
        [JsonPropertyName("next")]
        public string Next { get; set; }
        [JsonInclude]
        [JsonPropertyName("last")]
        public string Last { get; set; }
    }
}
