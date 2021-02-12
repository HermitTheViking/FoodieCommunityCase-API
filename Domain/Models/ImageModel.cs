using System.Text.Json.Serialization;

namespace FoodieCommunityCase.Domain.Models
{
    public class ImageModel
    {
        [JsonInclude]
        [JsonPropertyName("categories")]
        public string[] Categories { get; set; }
        [JsonInclude]
        [JsonPropertyName("thumb")]
        public string Thumb { get; set; }
        [JsonInclude]
        [JsonPropertyName("medium")]
        public string Medium { get; set; }
        [JsonInclude]
        [JsonPropertyName("large")]
        public string Large { get; set; }
        [JsonInclude]
        [JsonPropertyName("xlarge")]
        public string Xlarge { get; set; }
    }
}
