using FoodieCommunityCase.Domain.Commands;
using FoodieCommunityCase.Domain.Entities.Food;
using FoodieCommunityCase.Domain.Mappers;
using FoodieCommunityCase.Domain.Messaging;
using FoodieCommunityCase.Domain.Repository;
using FoodieCommunityCase.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodieCommunityCase.WebApi.Controllers
{
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IMessageBus _messageBus;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<FoodController> _logger;
        private readonly IMapper<Recip, RecipDto> _mapper;

        public FoodController(
            IMessageBus messageBus,
            IUnitOfWork unitOfWork,
            IMapper<Recip, RecipDto> mapper,
            ILogger<FoodController> logger
            )
        {
            _messageBus = messageBus ?? throw new ArgumentNullException(nameof(messageBus));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [Route("api/food/recipes")]
        [Authorize]
        public IActionResult GetAll()
        {
            List<Recip> listOfRecipes = _unitOfWork.Foodrepos.GetAllAsyncRecip().Result;
            if (listOfRecipes == null) { return BadRequest("Didn't get any results back from database!"); }
            return Ok(from item in listOfRecipes select _mapper.Map(item));
        }

        [HttpGet("api/food/recipes/{country}")]
        [Authorize]
        public IActionResult GetAllByRecipCountry(string country)
        {
            if (string.IsNullOrEmpty(country)) { return BadRequest("Country was not filled out!"); }
            List<Recip> tmp = _unitOfWork.Foodrepos.GetAllAsyncRecipByCountry(country).Result;
            return tmp.Count <= 0 ? BadRequest("Didn't get a result back from database!") : Ok(tmp);
        }

        [HttpGet("api/food/recip/{id}")]
        [Authorize]
        public IActionResult GetByRecipDbId(int id)
        {
            if (id < 0) { return BadRequest("Id isn't filled out correctly!"); }
            Recip tmp = _unitOfWork.Foodrepos.GetAsyncRecipById(id).Result;
            return tmp == null ? BadRequest("Didn't get a result back from database!") : Ok(tmp);
        }

        [HttpPost("api/food/recip")]
        [Authorize]
        public async Task<IActionResult> CreateRecipAsync(CreateRecipDto model)
        {
            if (model == null) { return BadRequest("Body was not filled out"); }
            if (model.Nutrient == null) { return BadRequest("Body nutrient was not filled out"); }

            await _messageBus.SendAsync(new CreateRecipCommand
            {
                Country = model.Country,
                Name = model.Name,
                OriginName = model.OriginName,
                IngredientName = model.IngredientName,
                Quantity = model.Quantity,
                Unit = model.Unit,
                HundredUnit = model.HundredUnit,
                PortionQuantity = model.PortionQuantity,
                PortionUnit = model.PortionUnit,
                AlcoholByVolume = model.AlcoholByVolume,
                Nutrient = new CreateNutrientCommand
                {
                    ProteinInfo = model.Nutrient.ProteinInfo == null ? null : new CreateNutrientInfoCommand
                    {
                        Name = model.Nutrient.ProteinInfo.Name,
                        PerDay = model.Nutrient.ProteinInfo.PerDay,
                        PerHundred = model.Nutrient.ProteinInfo.PerHundred,
                        PerPortion = model.Nutrient.ProteinInfo.PerPortion,
                        Unit = model.Nutrient.ProteinInfo.Unit
                    },
                    EnergyInfo = model.Nutrient.EnergyInfo == null ? null : new CreateNutrientInfoCommand
                    {
                        Name = model.Nutrient.EnergyInfo.Name,
                        PerDay = model.Nutrient.EnergyInfo.PerDay,
                        PerHundred = model.Nutrient.EnergyInfo.PerHundred,
                        PerPortion = model.Nutrient.EnergyInfo.PerPortion,
                        Unit = model.Nutrient.EnergyInfo.Unit
                    },
                    EnergyKcalInfo = model.Nutrient.EnergyKcalInfo == null ? null : new CreateNutrientInfoCommand
                    {
                        Name = model.Nutrient.EnergyKcalInfo.Name,
                        PerDay = model.Nutrient.EnergyKcalInfo.PerDay,
                        PerHundred = model.Nutrient.EnergyKcalInfo.PerHundred,
                        PerPortion = model.Nutrient.EnergyKcalInfo.PerPortion,
                        Unit = model.Nutrient.EnergyKcalInfo.Unit
                    },
                    FatInfo = model.Nutrient.FatInfo == null ? null : new CreateNutrientInfoCommand
                    {
                        Name = model.Nutrient.FatInfo.Name,
                        PerDay = model.Nutrient.FatInfo.PerDay,
                        PerHundred = model.Nutrient.FatInfo.PerHundred,
                        PerPortion = model.Nutrient.FatInfo.PerPortion,
                        Unit = model.Nutrient.FatInfo.Unit
                    },
                    SodiumInfo = model.Nutrient.SodiumInfo == null ? null : new CreateNutrientInfoCommand
                    {
                        Name = model.Nutrient.SodiumInfo.Name,
                        PerDay = model.Nutrient.SodiumInfo.PerDay,
                        PerHundred = model.Nutrient.SodiumInfo.PerHundred,
                        PerPortion = model.Nutrient.SodiumInfo.PerPortion,
                        Unit = model.Nutrient.SodiumInfo.Unit
                    },
                    FiberInfo = model.Nutrient.FiberInfo == null ? null : new CreateNutrientInfoCommand
                    {
                        Name = model.Nutrient.FiberInfo.Name,
                        PerDay = model.Nutrient.FiberInfo.PerDay,
                        PerHundred = model.Nutrient.FiberInfo.PerHundred,
                        PerPortion = model.Nutrient.FiberInfo.PerPortion,
                        Unit = model.Nutrient.FiberInfo.Unit
                    },
                    CarbohydratesInfo = model.Nutrient.CarbohydratesInfo == null ? null : new CreateNutrientInfoCommand
                    {
                        Name = model.Nutrient.CarbohydratesInfo.Name,
                        PerDay = model.Nutrient.CarbohydratesInfo.PerDay,
                        PerHundred = model.Nutrient.CarbohydratesInfo.PerHundred,
                        PerPortion = model.Nutrient.CarbohydratesInfo.PerPortion,
                        Unit = model.Nutrient.CarbohydratesInfo.Unit
                    },
                    SugarsInfo = model.Nutrient.SugarsInfo == null ? null : new CreateNutrientInfoCommand
                    {
                        Name = model.Nutrient.SugarsInfo.Name,
                        PerDay = model.Nutrient.SugarsInfo.PerDay,
                        PerHundred = model.Nutrient.SugarsInfo.PerHundred,
                        PerPortion = model.Nutrient.SugarsInfo.PerPortion,
                        Unit = model.Nutrient.SugarsInfo.Unit
                    },
                    SaturatedFatInfo = model.Nutrient.SaturatedFatInfo == null ? null : new CreateNutrientInfoCommand
                    {
                        Name = model.Nutrient.SaturatedFatInfo.Name,
                        PerDay = model.Nutrient.SaturatedFatInfo.PerDay,
                        PerHundred = model.Nutrient.SaturatedFatInfo.PerHundred,
                        PerPortion = model.Nutrient.SaturatedFatInfo.PerPortion,
                        Unit = model.Nutrient.SaturatedFatInfo.Unit
                    },
                    SaltInfo = model.Nutrient.SaltInfo == null ? null : new CreateNutrientInfoCommand
                    {
                        Name = model.Nutrient.SaltInfo.Name,
                        PerDay = model.Nutrient.SaltInfo.PerDay,
                        PerHundred = model.Nutrient.SaltInfo.PerHundred,
                        PerPortion = model.Nutrient.SaltInfo.PerPortion,
                        Unit = model.Nutrient.SaltInfo.Unit
                    }
                }
            });
            return Ok("Recip was created");
        }

        [HttpPut("api/food/recip/{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateRecipAsync(int id, UpdateRecipDto model)
        {
            if (model == null) { return BadRequest("Body was not filled out"); }

            var tmpNutrient = model.Nutrient;
            var tmpNutrientProteinInfo = tmpNutrient.ProteinInfo;
            var tmpNutrientEnergyInfo = tmpNutrient.EnergyInfo;
            var tmpNutrientEnergyKcalInfo = tmpNutrient.EnergyKcalInfo;
            var tmpNutrientFatInfo = tmpNutrient.FatInfo;
            var tmpNutrientSodiumInfo = tmpNutrient.SodiumInfo;
            var tmpNutrientFiberInfo = tmpNutrient.FiberInfo;
            var tmpNutrientCarbohydratesInfo = tmpNutrient.CarbohydratesInfo;
            var tmpNutrientSugarsInfo = tmpNutrient.SugarsInfo;
            var tmpNutrientSaturatedFatInfo = tmpNutrient.SaturatedFatInfo;
            var tmpNutrientSaltInfo = tmpNutrient.SaltInfo;

            await _messageBus.SendAsync(new UpdateRecipCommand
            {
                Id = id,
                Country = model.Country,
                Name = model.Name,
                OriginName = model.OriginName,
                IngredientName = model.IngredientName,
                Quantity = model.Quantity,
                Unit = model.Unit,
                HundredUnit = model.HundredUnit,
                PortionQuantity = model.PortionQuantity,
                PortionUnit = model.PortionUnit,
                AlcoholByVolume = model.AlcoholByVolume,
                Nutrient = new UpdateNutrientCommand
                {
                    ProteinInfo = tmpNutrientProteinInfo == null ? null : new UpdateNutrientInfoCommand
                    {
                        Name = tmpNutrientProteinInfo.Name,
                        PerDay = tmpNutrientProteinInfo.PerDay,
                        PerHundred = tmpNutrientProteinInfo.PerHundred,
                        PerPortion = tmpNutrientProteinInfo.PerPortion,
                        Unit = tmpNutrientProteinInfo.Unit
                    },
                    EnergyInfo = tmpNutrientEnergyInfo == null ? null : new UpdateNutrientInfoCommand
                    {
                        Name = tmpNutrientEnergyInfo.Name,
                        PerDay = tmpNutrientEnergyInfo.PerDay,
                        PerHundred = tmpNutrientEnergyInfo.PerHundred,
                        PerPortion = tmpNutrientEnergyInfo.PerPortion,
                        Unit = tmpNutrientEnergyInfo.Unit
                    },
                    EnergyKcalInfo = tmpNutrientEnergyKcalInfo == null ? null : new UpdateNutrientInfoCommand
                    {
                        Name = tmpNutrientEnergyKcalInfo.Name,
                        PerDay = tmpNutrientEnergyKcalInfo.PerDay,
                        PerHundred = tmpNutrientEnergyKcalInfo.PerHundred,
                        PerPortion = tmpNutrientEnergyKcalInfo.PerPortion,
                        Unit = tmpNutrientEnergyKcalInfo.Unit
                    },
                    FatInfo = tmpNutrientFatInfo == null ? null : new UpdateNutrientInfoCommand
                    {
                        Name = tmpNutrientFatInfo.Name,
                        PerDay = tmpNutrientFatInfo.PerDay,
                        PerHundred = tmpNutrientFatInfo.PerHundred,
                        PerPortion = tmpNutrientFatInfo.PerPortion,
                        Unit = tmpNutrientFatInfo.Unit
                    },
                    SodiumInfo = tmpNutrientSodiumInfo == null ? null : new UpdateNutrientInfoCommand
                    {
                        Name = tmpNutrientSodiumInfo.Name,
                        PerDay = tmpNutrientSodiumInfo.PerDay,
                        PerHundred = tmpNutrientSodiumInfo.PerHundred,
                        PerPortion = tmpNutrientSodiumInfo.PerPortion,
                        Unit = tmpNutrientSodiumInfo.Unit
                    },
                    FiberInfo = tmpNutrientFiberInfo == null ? null : new UpdateNutrientInfoCommand
                    {
                        Name = tmpNutrientFiberInfo.Name,
                        PerDay = tmpNutrientFiberInfo.PerDay,
                        PerHundred = tmpNutrientFiberInfo.PerHundred,
                        PerPortion = tmpNutrientFiberInfo.PerPortion,
                        Unit = tmpNutrientFiberInfo.Unit
                    },
                    CarbohydratesInfo = tmpNutrientCarbohydratesInfo == null ? null : new UpdateNutrientInfoCommand
                    {
                        Name = tmpNutrientCarbohydratesInfo.Name,
                        PerDay = tmpNutrientCarbohydratesInfo.PerDay,
                        PerHundred = tmpNutrientCarbohydratesInfo.PerHundred,
                        PerPortion = tmpNutrientCarbohydratesInfo.PerPortion,
                        Unit = tmpNutrientCarbohydratesInfo.Unit
                    },
                    SugarsInfo = tmpNutrientSugarsInfo == null ? null : new UpdateNutrientInfoCommand
                    {
                        Name = tmpNutrientSugarsInfo.Name,
                        PerDay = tmpNutrientSugarsInfo.PerDay,
                        PerHundred = tmpNutrientSugarsInfo.PerHundred,
                        PerPortion = tmpNutrientSugarsInfo.PerPortion,
                        Unit = tmpNutrientSugarsInfo.Unit
                    },
                    SaturatedFatInfo = tmpNutrientSaturatedFatInfo == null ? null : new UpdateNutrientInfoCommand
                    {
                        Name = tmpNutrientSaturatedFatInfo.Name,
                        PerDay = tmpNutrientSaturatedFatInfo.PerDay,
                        PerHundred = tmpNutrientSaturatedFatInfo.PerHundred,
                        PerPortion = tmpNutrientSaturatedFatInfo.PerPortion,
                        Unit = tmpNutrientSaturatedFatInfo.Unit
                    },
                    SaltInfo = tmpNutrientSaltInfo == null ? null : new UpdateNutrientInfoCommand
                    {
                        Name = tmpNutrientSaltInfo.Name,
                        PerDay = tmpNutrientSaltInfo.PerDay,
                        PerHundred = tmpNutrientSaltInfo.PerHundred,
                        PerPortion = tmpNutrientSaltInfo.PerPortion,
                        Unit = tmpNutrientSaltInfo.Unit
                    }
                }
            });
            return Ok("Recip was updated");
        }

        [HttpDelete("api/food/recip/{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteByRecipDbIdAsync(int id)
        {
            if (id < 0) { return BadRequest("Id isn't filled out correctly!"); }
            Recip tmp = _unitOfWork.Foodrepos.GetAsyncRecipById(id).Result;
            if (tmp == null) { return BadRequest("Didn't get a result back from database!"); }
            _unitOfWork.Foodrepos.RemoveRecip(tmp);
            await _unitOfWork.SaveAsync();
            return Ok($"Recip with { id } was removed");
        }
    }
}
