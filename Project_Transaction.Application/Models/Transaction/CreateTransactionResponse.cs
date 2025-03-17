namespace Project_Transaction.Application.Models.Transaction;

    public sealed record CreateTransactionResponse
    {
        public required DateTime InsertDateTime { get; init; }
    }

