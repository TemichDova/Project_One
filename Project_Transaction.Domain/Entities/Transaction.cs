
using Project_Transaction.Domain.Entities.Abstractions;

namespace Project_Transaction.Domain.Entities
{
    public sealed class Transaction : BaseEntity
    {
        public Guid TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
    }
}
