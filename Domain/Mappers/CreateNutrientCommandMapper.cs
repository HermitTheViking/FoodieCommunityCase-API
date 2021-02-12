using FoodieCommunityCase.Domain.Commands;
using FoodieCommunityCase.Domain.Entities.Food;
using System;

namespace FoodieCommunityCase.Domain.Mappers
{
    public class CreateNutrientCommandMapper : IMapper<CreateNutrientCommand, Nutrient>
    {
        private readonly IMapper<CreateNutrientInfoCommand, NutrientInfo> _nutrientInfoCreateCommandMapper;

        public CreateNutrientCommandMapper(IMapper<CreateNutrientInfoCommand, NutrientInfo> nutrientInfoCreateCommandMapper)
        {
            _nutrientInfoCreateCommandMapper = nutrientInfoCreateCommandMapper ?? throw new ArgumentNullException(nameof(nutrientInfoCreateCommandMapper));
        }

        public Nutrient Map(CreateNutrientCommand source)
        {
            if (source == null) { return null; }
            return new Nutrient
            {
                ProteinInfo = _nutrientInfoCreateCommandMapper.Map(source.ProteinInfo),
                EnergyInfo = _nutrientInfoCreateCommandMapper.Map(source.EnergyInfo),
                EnergyKcalInfo = _nutrientInfoCreateCommandMapper.Map(source.EnergyKcalInfo),
                FatInfo = _nutrientInfoCreateCommandMapper.Map(source.FatInfo),
                SodiumInfo = _nutrientInfoCreateCommandMapper.Map(source.SodiumInfo),
                FiberInfo = _nutrientInfoCreateCommandMapper.Map(source.FiberInfo),
                CarbohydratesInfo = _nutrientInfoCreateCommandMapper.Map(source.CarbohydratesInfo),
                SugarsInfo = _nutrientInfoCreateCommandMapper.Map(source.SugarsInfo),
                SaturatedFatInfo = _nutrientInfoCreateCommandMapper.Map(source.SaturatedFatInfo),
                SaltInfo = _nutrientInfoCreateCommandMapper.Map(source.SaltInfo)
            };
        }
    }
}
