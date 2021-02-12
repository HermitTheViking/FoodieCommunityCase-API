using FoodieCommunityCase.Domain.Entities;
using FoodieCommunityCase.Domain.Entities.Transactions;
using FoodieCommunityCase.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodieCommunityCase.Domain.Repository.Implementations
{
    public class TransactionRepository : BaseRepository, ITransactionRepository
    {
        private readonly FoodEntities _entities;

        public TransactionRepository(FoodEntities entities)
        {
            _entities = entities ?? throw new ArgumentNullException(nameof(entities));
        }

        public void Add(Transaction entity)
        {
            _entities.Transactions.Add(entity);
        }

        public IEnumerable<Transaction> GetAllAsync()
        {
            return _entities.Transactions.OrderBy(x => x.Id);
        }

        public PaginationResult<Transaction> GetByFilter(PaginationQuery paginationQuery)
        {
            var transactions = _entities.Transactions;

            return GetPaginatedResult(
                paginationQuery,
                transactions,
                (elements, filter) => elements.Where(x => x.EventType != null && x.EventType.Contains(paginationQuery.Filter)),
                elements => elements.OrderBy(x => x.Created));
        }
    }
}
