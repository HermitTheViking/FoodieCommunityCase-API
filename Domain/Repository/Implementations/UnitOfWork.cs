using FoodieCommunityCase.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace FoodieCommunityCase.Domain.Repository.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FoodEntities _entities;
        private readonly ILogger<UnitOfWork> _logger;

        public UnitOfWork(
            FoodEntities entities,
            ITransactionRepository transactions,
            IFoodrepoRepository foodrepos,
            ILogger<UnitOfWork> logger
            )
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _entities = entities ?? throw new ArgumentNullException(nameof(entities));
            Transactions = transactions ?? throw new ArgumentNullException(nameof(transactions));
            Foodrepos = foodrepos ?? throw new ArgumentNullException(nameof(foodrepos));
        }

        internal FoodEntities FoodEntities => _entities;

        public async Task SaveAsync()
        {
            try
            {
                var count = await _entities.SaveChangesAsync().ConfigureAwait(false);
                _logger.LogDebug($"{count} state entries written to database");
            }
            catch (Exception ex)
            {
                _logger.LogError("Error when saving to database", ex);
                throw;
            }
        }

        public void Save()
        {
            try
            {
                var count = _entities.SaveChanges();
                _logger.LogDebug($"{count} state entries written to database");
            }
            catch (Exception ex)
            {
                _logger.LogError("Error when saving to database", ex);
                throw;
            }
        }

        public ITransactionRepository Transactions { get; private set; }
        public IFoodrepoRepository Foodrepos { get; private set; }
    }
}
