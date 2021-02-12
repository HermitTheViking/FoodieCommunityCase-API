using FoodieCommunityCase.Domain.Entities.Food;
using FoodieCommunityCase.Domain.Mappers;
using FoodieCommunityCase.WebApi.Models;
using System;

namespace FoodieCommunityCase.WebApi.Mappers
{
    public class NutrientMapper : IMapper<Nutrient, NutrientDto>
    {
        private readonly IMapper<NutrientInfo, NutrientInfoDto> _nutrientInfoMapper;

        public NutrientMapper(IMapper<NutrientInfo, NutrientInfoDto> nutrientInfoMapper)
        {
            _nutrientInfoMapper = nutrientInfoMapper ?? throw new ArgumentNullException(nameof(nutrientInfoMapper));
        }

        public NutrientDto Map(Nutrient source)
        {
            if (source == null) { return null; }
            return new NutrientDto
            {
                DbId = source.Id,
                ProteinInfo = _nutrientInfoMapper.Map(source.ProteinInfo),
                EnergyInfo = _nutrientInfoMapper.Map(source.EnergyInfo),
                EnergyKcalInfo = _nutrientInfoMapper.Map(source.EnergyKcalInfo),
                FatInfo = _nutrientInfoMapper.Map(source.FatInfo),
                SodiumInfo = _nutrientInfoMapper.Map(source.SodiumInfo),
                FiberInfo = _nutrientInfoMapper.Map(source.FiberInfo),
                CarbohydratesInfo = _nutrientInfoMapper.Map(source.CarbohydratesInfo),
                SugarsInfo = _nutrientInfoMapper.Map(source.SugarsInfo),
                SaturatedFatInfo = _nutrientInfoMapper.Map(source.SaturatedFatInfo),
                SaltInfo = _nutrientInfoMapper.Map(source.SaltInfo)
            };
        }
    }
}
