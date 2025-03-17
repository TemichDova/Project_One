
using Project_Transaction.Application.Models.Transaction;

namespace Project_Transaction.Application.EntityServices.Abstraction;

public interface ITransactionService
{
    public Task<CreateTransactionResponse> CreateTransaction(CreateTransactionRequest model);
    public Task<GetTransactionResponce> GetTransaction(Guid id);
}

