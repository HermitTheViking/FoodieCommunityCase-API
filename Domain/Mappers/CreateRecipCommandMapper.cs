using FoodieCommunityCase.Domain.Commands;
using FoodieCommunityCase.Domain.Entities.Food;
using System;

namespace FoodieCommunityCase.Domain.Mappers
{
    public class CreateRecipCommandMapper : IMapper<CreateRecipCommand, Recip>
    {
        private readonly IMapper<CreateNutrientCommand, Nutrient> _nutrientCreateCommandMapper;

        public CreateRecipCommandMapper(IMapper<CreateNutrientCommand, Nutrient> nutrientCreateCommandMapper)
        {
            _nutrientCreateCommandMapper = nutrientCreateCommandMapper ?? throw new ArgumentNullException(nameof(nutrientCreateCommandMapper));
        }

        public Recip Map(CreateRecipCommand source)
        {
            if (source == null) { return null; }
            return new Recip
            {
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
                Nutrient = _nutrientCreateCommandMapper.Map(source.Nutrient)
            };
        }
    }
}
