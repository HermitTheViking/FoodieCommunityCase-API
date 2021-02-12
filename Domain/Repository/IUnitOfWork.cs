using System.Threading.Tasks;

namespace FoodieCommunityCase.Domain.Repository
{
    public interface IUnitOfWork
    {
        void Save();
        Task SaveAsync();
        ITransactionRepository Transactions { get; }
        IFoodrepoRepository Foodrepos { get; }
    }
}
