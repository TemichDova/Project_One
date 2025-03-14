namespace Project_Transaction.Application.Models.Transaction;

    public sealed record CreateTransactionRequest
    {
        public required Guid Id { get; init; }
        public required DateTime TransactionDate { get; init; }
        public required decimal Amount { get; init; }
    }

