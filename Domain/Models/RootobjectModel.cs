using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FoodieCommunityCase.Domain.Models
{
    public class RootobjectModel
    {
        [JsonInclude]
        [JsonPropertyName("data")]
        public List<RecipModel> Data { get; set; } = new List<RecipModel>();
        [JsonInclude]
        [JsonPropertyName("links")]
        public LinksModel Links { get; set; }
        [JsonInclude]
        [JsonPropertyName("meta")]
        public MetaModel Meta { get; set; }
    }
}