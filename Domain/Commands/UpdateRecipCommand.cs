namespace FoodieCommunityCase.Domain.Commands
{
    public class UpdateRecipCommand
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string Name { get; set; }
        public string IngredientName { get; set; }
        public string OriginName { get; set; }
        public float Quantity { get; set; }
        public string Unit { get; set; }
        public string HundredUnit { get; set; }
        public float PortionQuantity { get; set; }
        public string PortionUnit { get; set; }
        public float AlcoholByVolume { get; set; }
        public UpdateNutrientCommand Nutrient { get; set; }
    }
}
