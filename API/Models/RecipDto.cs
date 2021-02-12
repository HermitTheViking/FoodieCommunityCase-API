namespace FoodieCommunityCase.WebApi.Models
{
    public class RecipDto
    {
        public string Country { get; set; }
        public string Name { get; set; }
        public string IngredientName { get; set; }
        public string OriginName { get; set; }
        public string Unit { get; set; }
        public string HundredUnit { get; set; }
        public string PortionUnit { get; set; }

        public int DbId { get; set; }
        public NutrientDto Nutrient { get; set; }

        public float Quantity { get; set; }
        public float PortionQuantity { get; set; }
        public float AlcoholByVolume { get; set; }
    }
}
