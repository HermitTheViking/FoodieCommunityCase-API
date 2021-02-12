using FoodieCommunityCase.Domain.Commands;
using FoodieCommunityCase.Domain.Entities.Food;
using System;

namespace FoodieCommunityCase.Domain.Mappers
{
    public class UpdateNutrientCommandMapper : IMapper<UpdateNutrientCommand, Nutrient>
    {
        private readonly IMapper<UpdateNutrientInfoCommand, NutrientInfo> _nutrientInfoUpdateCommandMapper;

        public UpdateNutrientCommandMapper(IMapper<UpdateNutrientInfoCommand, NutrientInfo> nutrientInfoUpdateCommandMapper)
        {
            _nutrientInfoUpdateCommandMapper = nutrientInfoUpdateCommandMapper ?? throw new ArgumentNullException(nameof(nutrientInfoUpdateCommandMapper));
        }

        public Nutrient Map(UpdateNutrientCommand source)
        {
            if (source == null) { return null; }
            return new Nutrient
            {
                ProteinInfo = _nutrientInfoUpdateCommandMapper.Map(source.ProteinInfo),
                EnergyInfo = _nutrientInfoUpdateCommandMapper.Map(source.EnergyInfo),
                EnergyKcalInfo = _nutrientInfoUpdateCommandMapper.Map(source.EnergyKcalInfo),
                FatInfo = _nutrientInfoUpdateCommandMapper.Map(source.FatInfo),
                SodiumInfo = _nutrientInfoUpdateCommandMapper.Map(source.SodiumInfo),
                FiberInfo = _nutrientInfoUpdateCommandMapper.Map(source.FiberInfo),
                CarbohydratesInfo = _nutrientInfoUpdateCommandMapper.Map(source.CarbohydratesInfo),
                SugarsInfo = _nutrientInfoUpdateCommandMapper.Map(source.SugarsInfo),
                SaturatedFatInfo = _nutrientInfoUpdateCommandMapper.Map(source.SaturatedFatInfo),
                SaltInfo = _nutrientInfoUpdateCommandMapper.Map(source.SaltInfo)
            };
        }
    }
}
