using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FoodieCommunityCase.Domain.Models
{
    public class RecipModel
    {
        [JsonInclude]
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonInclude]
        [JsonPropertyName("country")]
        public string Country { get; set; }
        [JsonInclude]
        [JsonPropertyName("barcode")]
        public string Barcode { get; set; }
        [JsonInclude]
        [JsonPropertyName("name_translations")]
        public TranslationModel Name_translations { get; set; }
        [JsonInclude]
        [JsonPropertyName("display_name_translations")]
        public TranslationModel Display_name_translations { get; set; }
        [JsonInclude]
        [JsonPropertyName("ingredients_translations")]
        public TranslationModel Ingredients_translations { get; set; }
        [JsonInclude]
        [JsonPropertyName("origin_translations")]
        public TranslationModel Origin_translations { get; set; }
        [JsonInclude]
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonInclude]
        [JsonPropertyName("quantity")]
        public float Quantity { get; set; }
        [JsonInclude]
        [JsonPropertyName("unit")]
        public string Unit { get; set; }
        [JsonInclude]
        [JsonPropertyName("hundred_unit")]
        public string Hundred_unit { get; set; }
        [JsonInclude]
        [JsonPropertyName("portion_quantity")]
        public float Portion_quantity { get; set; }
        [JsonInclude]
        [JsonPropertyName("portion_unit")]
        public string Portion_unit { get; set; }
        [JsonInclude]
        [JsonPropertyName("alcohol_by_volume")]
        public float Alcohol_by_volume { get; set; }
        [JsonInclude]
        [JsonPropertyName("nutrients")]
        public NutrientModel Nutrients { get; set; }
        [JsonInclude]
        [JsonPropertyName("created_at")]
        public DateTime Created_at { get; set; }
        [JsonInclude]
        [JsonPropertyName("updated_at")]
        public DateTime Updated_at { get; set; }

        [JsonInclude]
        [JsonPropertyName("images")]
        public List<ImageModel> Images { get; set; } = new List<ImageModel>();
    }
}
