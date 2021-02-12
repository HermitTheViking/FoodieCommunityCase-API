using FoodieCommunityCase.Domain.Entities.Food;
using FoodieCommunityCase.Domain.Mappers;
using FoodieCommunityCase.WebApi.Models;
using System;

namespace FoodieCommunityCase.WebApi.Mappers
{
    public class RecipMapper : IMapper<Recip, RecipDto>
    {
        private readonly IMapper<Nutrient, NutrientDto> _nutrientMapper;

        public RecipMapper(IMapper<Nutrient, NutrientDto> nutrientMapper)
        {
            _nutrientMapper = nutrientMapper ?? throw new ArgumentNullException(nameof(nutrientMapper));
        }

        public RecipDto Map(Recip source)
        {
            if (source == null) { return null; }
            return new RecipDto
            {
                DbId = source.Id,
                Country = source.Country,
                Name = source.Name,
                IngredientName = source.IngredientName,
                OriginName = source.OriginName,
                Quantity = source.Quantity,
                Unit = source.Unit,
                HundredUnit = source.HundredUnit,
                PortionQuantity = source.PortionQuantity,
                PortionUnit = source.PortionUnit,
                AlcoholByVolume = source.AlcoholByVolume,
                Nutrient = _nutrientMapper.Map(source.Nutrient)
            };
        }
    }
}
