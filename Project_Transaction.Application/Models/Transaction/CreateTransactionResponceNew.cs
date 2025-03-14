
using Project_Transaction.Application.Models.Transaction.Abstractions;

namespace Project_Transaction.Application.Models.Transaction;

public sealed record CreateTransactionResponceNew : CreateTransactionResponce
{
    public required DateTime InsertDateTime { get; init; }
}

