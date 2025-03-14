namespace Project_Transaction.Application.Models.Transaction;

    public sealed record CreateTransactionResponce
    {
        public required DateTime InsertDateTime { get; init; }
    }

