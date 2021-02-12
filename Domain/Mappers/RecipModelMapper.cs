using FoodieCommunityCase.Domain.Entities.Food;
using FoodieCommunityCase.Domain.Models;
using System;

namespace FoodieCommunityCase.Domain.Mappers
{
    public class RecipModelMapper : IMapper<RecipModel, Recip>
    {
        private readonly IMapper<NutrientModel, Nutrient> _nutrientModelMapper;

        public RecipModelMapper(IMapper<NutrientModel, Nutrient> nutrientModelMapper)
        {
            _nutrientModelMapper = nutrientModelMapper ?? throw new ArgumentNullException(nameof(nutrientModelMapper));
        }

        public Recip Map(RecipModel source)
        {
            if (source == null) { return null; }
            return new Recip
            {
                RepoId = source.Id,
                Country = source.Country,
                Name = source.Name_translations.En ?? source.Name_translations.De ?? source.Name_translations.Fr ?? source.Name_translations.It,
                IngredientName = source.Name_translations.En ?? source.Name_translations.De ?? source.Name_translations.Fr ?? source.Name_translations.It,
                OriginName = source.Name_translations.En ?? source.Name_translations.De ?? source.Name_translations.Fr ?? source.Name_translations.It,
                Quantity = source.Quantity,
                Unit = source.Unit,
                HundredUnit = source.Hundred_unit,
                PortionQuantity = source.Portion_quantity,
                PortionUnit = source.Portion_unit,
                AlcoholByVolume = source.Alcohol_by_volume,
                Nutrient = _nutrientModelMapper.Map(source.Nutrients)
            };
        }
    }
}
