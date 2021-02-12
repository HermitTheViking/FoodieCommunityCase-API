using FoodieCommunityCase.Domain.Commands;
using FoodieCommunityCase.Domain.Entities.Food;
using System;

namespace FoodieCommunityCase.Domain.Mappers
{
    public class UpdateRecipCommandMapper : IMapper<UpdateRecipCommand, Recip>
    {
        private readonly IMapper<UpdateNutrientCommand, Nutrient> _nutrientUpdateCommandMapper;

        public UpdateRecipCommandMapper(IMapper<UpdateNutrientCommand, Nutrient> nutrientUpdateCommandMapper)
        {
            _nutrientUpdateCommandMapper = nutrientUpdateCommandMapper ?? throw new ArgumentNullException(nameof(nutrientUpdateCommandMapper));
        }

        public Recip Map(UpdateRecipCommand source)
        {
            if (source == null) { return null; }
            return new Recip
            {
                Id = source.Id,
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
                Nutrient = _nutrientUpdateCommandMapper.Map(source.Nutrient)
            };
        }
    }
}
