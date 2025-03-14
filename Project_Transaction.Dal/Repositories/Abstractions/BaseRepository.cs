using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Project_Transaction.Domain.Abstractions.Repositories;
using Project_Transaction.Domain.Entities.Abstractions;
using Project_Transaction.Domain.Exceptions;

namespace Project_Transaction.Dal.Repositories.Abstractions
{
    /// <summary>
    /// Класс базового репозитория с общими методами.
    /// </summary>
    /// <typeparam name="TEntity">Доменная модель.</typeparam>
    /// <param name="dbContext">Контекст БД.</param>
    public abstract class BaseRepository<TEntity>(DataContext dbContext) : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected DataContext DbContext { get; init; } = dbContext;

        protected virtual DbSet<TEntity> DbSet { get; set; } = dbContext.Set<TEntity>();

        public virtual async Task<TEntity> Get(Guid id)
        {
            var dbSet = DbSet.AsNoTracking();
            return await dbSet.FirstOrDefaultAsync(entity => entity.Id == id) ??  throw new NotFoundException(); 
        }

        public virtual Task<TEntity> Create(TEntity entity)
        {
            DbSet.Add(entity);
            return Task.FromResult(entity);
        }

        public virtual async Task<TEntity?> GetEntity(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(predicate);
               
        }

        public virtual async Task Delete(Guid id)
        {
            var entity = await DbSet.FindAsync(id) ?? throw new NotFoundException();
            DbSet.Remove(entity);
        }
    }
}
