using FoodieCommunityCase.Domain.Commands;
using FoodieCommunityCase.Domain.Entities.Food;
using FoodieCommunityCase.Domain.ErrorHandling;
using FoodieCommunityCase.Domain.Events;
using FoodieCommunityCase.Domain.Events.Food;
using FoodieCommunityCase.Domain.Mappers;
using FoodieCommunityCase.Domain.Messaging;
using FoodieCommunityCase.Domain.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace FoodieCommunityCase.Domain.CommandHandlers
{
    public class FoodCommandHandler :
        ICommandHandler,
        IAsyncCommandHandler<CreateRecipCommand>,
        IAsyncCommandHandler<UpdateRecipCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventStore _eventStore;
        private readonly FoodEventFactory _foodEventFactory;
        private readonly ILogger<FoodCommandHandler> _logger;
        private readonly IMapper<CreateRecipCommand, Recip> _createMapper;
        private readonly IMapper<UpdateRecipCommand, Recip> _updateMapper;

        public FoodCommandHandler(
            IUnitOfWork unitOfWork,
            IEventStore eventStore,
            FoodEventFactory foodEventFactory,
            ILogger<FoodCommandHandler> logger,
            IMapper<CreateRecipCommand, Recip> createMapper,
            IMapper<UpdateRecipCommand, Recip> updateMapper
            )
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _eventStore = eventStore ?? throw new ArgumentNullException(nameof(eventStore));
            _foodEventFactory = foodEventFactory ?? throw new ArgumentNullException(nameof(foodEventFactory));
            _createMapper = createMapper ?? throw new ArgumentNullException(nameof(createMapper));
            _updateMapper = updateMapper ?? throw new ArgumentNullException(nameof(updateMapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task HandleAsync(CreateRecipCommand command)
        {
            if (command == null) { throw ExceptionFactory.CommandIsNull(); }

            var tmp = _createMapper.Map(command);
            if (tmp == null) { throw ExceptionFactory.MappingOfRecipeFailed(); }

            if (tmp.Nutrient.ProteinInfo != null && tmp.Nutrient.ProteinInfo.Name == null)
            {
                tmp.Nutrient.ProteinInfo = null;
            }
            if (tmp.Nutrient.CarbohydratesInfo != null && tmp.Nutrient.CarbohydratesInfo.Name == null)
            {
                tmp.Nutrient.CarbohydratesInfo = null;
            }
            if (tmp.Nutrient.EnergyInfo != null && tmp.Nutrient.EnergyInfo.Name == null)
            {
                tmp.Nutrient.EnergyInfo = null;
            }
            if (tmp.Nutrient.EnergyKcalInfo != null && tmp.Nutrient.EnergyKcalInfo.Name == null)
            {
                tmp.Nutrient.EnergyKcalInfo = null;
            }
            if (tmp.Nutrient.FatInfo != null && tmp.Nutrient.FatInfo.Name == null)
            {
                tmp.Nutrient.FatInfo = null;
            }
            if (tmp.Nutrient.FiberInfo != null && tmp.Nutrient.FiberInfo.Name == null)
            {
                tmp.Nutrient.FiberInfo = null;
            }
            if (tmp.Nutrient.SaltInfo != null && tmp.Nutrient.SaltInfo.Name == null)
            {
                tmp.Nutrient.SaltInfo = null;
            }
            if (tmp.Nutrient.SaturatedFatInfo != null && tmp.Nutrient.SaturatedFatInfo.Name == null)
            {
                tmp.Nutrient.SaturatedFatInfo = null;
            }
            if (tmp.Nutrient.SodiumInfo != null && tmp.Nutrient.SodiumInfo.Name == null)
            {
                tmp.Nutrient.SodiumInfo = null;
            }
            if (tmp.Nutrient.SugarsInfo != null && tmp.Nutrient.SugarsInfo.Name == null)
            {
                tmp.Nutrient.SugarsInfo = null;
            }

            _unitOfWork.Foodrepos.AddRecip(tmp);
            _eventStore.AddEvents(_foodEventFactory.GetFoodCreatedEvent(tmp));
            await _unitOfWork.SaveAsync();
        }

        public async Task HandleAsync(UpdateRecipCommand command)
        {
            if (command == null) { throw ExceptionFactory.CommandIsNull(); }
            var tmp = _updateMapper.Map(command);

            if (tmp == null) { throw ExceptionFactory.MappingOfRecipeFailed(); }

            var recip = _unitOfWork.Foodrepos.GetAsyncRecipById(command.Id).Result;
            if (recip == null) { return; }

            tmp.Nutrient.Id = recip.Nutrient.Id;
            if (recip.Nutrient.ProteinInfo != null)
            {
                tmp.Nutrient.ProteinInfo.Id = recip.Nutrient.ProteinInfo.Id;
            }
            if (recip.Nutrient.CarbohydratesInfo != null)
            {
                tmp.Nutrient.CarbohydratesInfo.Id = recip.Nutrient.CarbohydratesInfo.Id;
            }
            if (recip.Nutrient.EnergyInfo != null)
            {
                tmp.Nutrient.EnergyInfo.Id = recip.Nutrient.EnergyInfo.Id;
            }
            if (recip.Nutrient.EnergyKcalInfo != null)
            {
                tmp.Nutrient.EnergyKcalInfo.Id = recip.Nutrient.EnergyKcalInfo.Id;
            }
            if (recip.Nutrient.FatInfo != null)
            {
                tmp.Nutrient.FatInfo.Id = recip.Nutrient.FatInfo.Id;
            }
            if (recip.Nutrient.FiberInfo != null)
            {
                tmp.Nutrient.FiberInfo.Id = recip.Nutrient.FiberInfo.Id;
            }
            if (recip.Nutrient.SaltInfo != null)
            {
                tmp.Nutrient.SaltInfo.Id = recip.Nutrient.SaltInfo.Id;
            }
            if (recip.Nutrient.SaturatedFatInfo != null)
            {
                tmp.Nutrient.SaturatedFatInfo.Id = recip.Nutrient.SaturatedFatInfo.Id;
            }
            if (recip.Nutrient.SodiumInfo != null)
            {
                tmp.Nutrient.SodiumInfo.Id = recip.Nutrient.SodiumInfo.Id;
            }
            if (recip.Nutrient.SugarsInfo != null)
            {
                tmp.Nutrient.SugarsInfo.Id = recip.Nutrient.SugarsInfo.Id;
            }

            _unitOfWork.Foodrepos.UpdateRecip(tmp);
            _eventStore.AddEvents(_foodEventFactory.GetFoodUpdatedEvent(tmp));
            await _unitOfWork.SaveAsync();
        }
    }
}
