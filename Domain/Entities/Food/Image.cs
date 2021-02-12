using System.Collections.Generic;

namespace FoodieCommunityCase.Domain.Entities.Food
{
    public class Image
    {
        public int Id { get; set; }
        public string Thumb { get; set; }
        public string Medium { get; set; }
        public string Large { get; set; }
        public string Xlarge { get; set; }
        public virtual Recip Recip { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}
