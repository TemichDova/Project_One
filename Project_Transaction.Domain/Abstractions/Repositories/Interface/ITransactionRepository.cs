
using Project_Transaction.Domain.Entities;

namespace Project_Transaction.Domain.Abstractions.Repositories.Interface;

public interface ITransactionRepository : IBaseRepository<Transaction>
{
    public Task<int> Count();
    /// <summary>
    /// Получить TransactionId последний из списка Transactions.
    /// </summary>
    /// <returns>TransactionId.</returns>
    public Task<Guid> GetOldTransactionId();
}
