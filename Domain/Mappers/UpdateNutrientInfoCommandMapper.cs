using FoodieCommunityCase.Domain.Commands;
using FoodieCommunityCase.Domain.Entities.Food;

namespace FoodieCommunityCase.Domain.Mappers
{
    public class UpdateNutrientInfoCommandMapper : IMapper<UpdateNutrientInfoCommand, NutrientInfo>
    {
        public NutrientInfo Map(UpdateNutrientInfoCommand source)
        {
            if (source == null) { return null; }
            return new NutrientInfo
            {
                Name = source.Name,
                Unit = source.Unit,
                PerHundred = source.PerHundred,
                PerPortion = source.PerPortion,
                PerDay = source.PerDay
            };
        }
    }
}
