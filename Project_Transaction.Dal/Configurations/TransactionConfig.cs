
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_Transaction.Dal.Configurations.Abstractions;
using Project_Transaction.Domain.Entities;

namespace Project_Transaction.Dal.Configurations;

public class TransactionConfig : BaseEntityConfig<Transaction>
{
    public override void Configure(EntityTypeBuilder<Transaction> builder)
    {
        base.Configure(builder);

        builder.HasIndex(x => x.TransactionId).IsUnique();
    }
}
