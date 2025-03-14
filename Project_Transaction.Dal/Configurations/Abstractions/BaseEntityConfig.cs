using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Project_Transaction.Domain.Entities.Abstractions;

namespace Project_Transaction.Dal.Configurations.Abstractions
{
    public abstract class BaseEntityConfig<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            /*if (typeof(TEntity).IsAssignableTo(typeof(IManualIdGenerator)))
                builder.Property(x => x.Id).ValueGeneratedNever();
            else
                builder.Property(x => x.Id).HasValueGenerator(typeof(EntityIdUuidV7Generator))
                    .ValueGeneratedOnAdd();*/


            /*if (typeof(TEntity).IsAssignableTo(typeof(INumberable)))
            {
                builder.Property(x => ((INumberable)x).Number).IsRequired().UseIdentityColumn();
            }*/

            builder.HasQueryFilter(x => !x.Deleted.HasValue);
        }
    }
}