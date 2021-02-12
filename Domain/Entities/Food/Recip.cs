using System.Collections.Generic;

namespace FoodieCommunityCase.Domain.Entities.Food
{
    public class Recip
    {
        public int Id { get; set; }
        public int RepoId { get; set; }
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
        public virtual Nutrient Nutrient { get; set; }

        public virtual ICollection<Image> Images { get; set; }
    }
}
