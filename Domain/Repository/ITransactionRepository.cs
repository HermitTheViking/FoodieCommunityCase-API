using FoodieCommunityCase.Domain.Entities.Transactions;
using FoodieCommunityCase.Domain.Pagination;
using System.Collections.Generic;

namespace FoodieCommunityCase.Domain.Repository
{
    public interface ITransactionRepository
    {
        void Add(Transaction entity);
        PaginationResult<Transaction> GetByFilter(PaginationQuery paginationQuery);
        IEnumerable<Transaction> GetAllAsync();
    }
}
