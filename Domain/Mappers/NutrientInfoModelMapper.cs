using FoodieCommunityCase.Domain.Entities.Food;
using FoodieCommunityCase.Domain.Models;

namespace FoodieCommunityCase.Domain.Mappers
{
    public class NutrientInfoModelMapper : IMapper<NutrientInfoModel, NutrientInfo>
    {
        public NutrientInfo Map(NutrientInfoModel source)
        {
            if (source == null) { return null; }
            return new NutrientInfo
            {
                Name = source.Name_translations.En ?? source.Name_translations.De ?? source.Name_translations.Fr ?? source.Name_translations.It,
                Unit = source.Unit,
                PerHundred = source.Per_hundred,
                PerPortion = source.Per_portion,
                PerDay = source.Per_day
            };
        }
    }
}
