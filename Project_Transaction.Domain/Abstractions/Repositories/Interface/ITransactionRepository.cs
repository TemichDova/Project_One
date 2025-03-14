

using Project_Transaction.Domain.Entities;

namespace Project_Transaction.Domain.Abstractions.Repositories.Interface
{
    public interface ITransactionRepository : IBaseRepository<Transaction>
    {
        public Task<int> Count();
        public Task<Guid> GetOldTransactionId();
    }
}
