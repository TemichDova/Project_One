using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Project_Transaction.Domain.Entities.Abstractions;

namespace Project_Transaction.Dal.Configurations.Abstractions
{
    public abstract class BaseEntityConfig<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {


            builder.HasQueryFilter(x => !x.Deleted.HasValue);
        }
    }
}