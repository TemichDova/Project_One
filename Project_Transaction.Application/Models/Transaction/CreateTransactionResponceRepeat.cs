

using Project_Transaction.Application.Models.Transaction.Abstractions;

namespace Project_Transaction.Application.Models.Transaction;

public record CreateTransactionResponceRepeat : CreateTransactionResponce
{
    public Guid Id { get; init; }
}
