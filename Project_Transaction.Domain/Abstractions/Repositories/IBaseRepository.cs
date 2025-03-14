using System.Collections.Generic;
using System.Linq.Expressions;
using Project_Transaction.Domain.Entities.Abstractions;
using Project_Transaction.Domain.Exceptions;

namespace Project_Transaction.Domain.Abstractions.Repositories
{
    public partial interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> Get(Guid id);

        Task<TEntity> Create(TEntity entity);

        Task<TEntity?> GetEntity(Expression<Func<TEntity, bool>> predicate);

        Task Delete(Guid id);
    }
}
