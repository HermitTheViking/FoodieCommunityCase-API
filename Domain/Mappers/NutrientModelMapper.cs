using FoodieCommunityCase.Domain.Entities.Food;
using FoodieCommunityCase.Domain.Models;
using System;

namespace FoodieCommunityCase.Domain.Mappers
{
    public class NutrientModelMapper : IMapper<NutrientModel, Nutrient>
    {
        private readonly IMapper<NutrientInfoModel, NutrientInfo> _nutrientInfoModelMapper;

        public NutrientModelMapper(IMapper<NutrientInfoModel, NutrientInfo> nutrientInfoModelMapper)
        {
            _nutrientInfoModelMapper = nutrientInfoModelMapper ?? throw new ArgumentNullException(nameof(nutrientInfoModelMapper));
        }

        public Nutrient Map(NutrientModel source)
        {
            if (source == null) { return null; }
            return new Nutrient
            {
                ProteinInfo = _nutrientInfoModelMapper.Map(source.Protein),
                EnergyInfo = _nutrientInfoModelMapper.Map(source.Energy),
                EnergyKcalInfo = _nutrientInfoModelMapper.Map(source.Energy_kcal),
                FatInfo = _nutrientInfoModelMapper.Map(source.Fat),
                SodiumInfo = _nutrientInfoModelMapper.Map(source.Sodium),
                FiberInfo = _nutrientInfoModelMapper.Map(source.Fiber),
                CarbohydratesInfo = _nutrientInfoModelMapper.Map(source.Carbohydrates),
                SugarsInfo = _nutrientInfoModelMapper.Map(source.Sugars),
                SaturatedFatInfo = _nutrientInfoModelMapper.Map(source.Saturated_fat),
                SaltInfo = _nutrientInfoModelMapper.Map(source.Salt)
            };
        }
    }
}
