using FoodieCommunityCase.Domain.Entities.Food;
using FoodieCommunityCase.Domain.Mappers;
using FoodieCommunityCase.WebApi.Models;

namespace FoodieCommunityCase.WebApi.Mappers
{
    public class NutrientInfoMapper : IMapper<NutrientInfo, NutrientInfoDto>
    {
        public NutrientInfoDto Map(NutrientInfo source)
        {
            if (source == null) { return null; }
            return new NutrientInfoDto
            {
                DbId = source.Id,
                Name = source.Name,
                Unit = source.Unit,
                PerHundred = source.PerHundred,
                PerPortion = source.PerPortion,
                PerDay = source.PerDay
            };
        }
    }
}
