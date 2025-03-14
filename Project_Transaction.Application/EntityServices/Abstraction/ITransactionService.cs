
using Project_Transaction.Application.Models.Transaction;
using Project_Transaction.Application.Models.Transaction.Abstractions;

namespace Project_Transaction.Application.EntityServices.Abstraction;

public interface ITransactionService
{
    public Task<CreateTransactionResponce> CreateTransaction(CreateTransactionRequest model);
    public Task<GetTransactionResponce> GetTransaction(Guid id);
}

