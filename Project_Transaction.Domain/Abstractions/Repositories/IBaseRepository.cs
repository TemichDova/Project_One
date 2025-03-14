using System.Collections.Generic;
using System.Linq.Expressions;
using Project_Transaction.Domain.Entities.Abstractions;
using Project_Transaction.Domain.Exceptions;

namespace Project_Transaction.Domain.Abstractions.Repositories;

/// <summary>
/// Базовый интерфейс репозитории.
/// </summary>
public partial interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    /// <summary>
    /// Получить сущность по Id.
    /// </summary>
    /// <param name="id">ID получаемой сущности.</param>
    /// <returns>Сущность.</returns>
    Task<TEntity> Get(Guid id);

    /// <summary>
    /// Изменить сущность.
    /// </summary>
    /// <returns>Сущность.</returns>
    Task<TEntity> Create(TEntity entity);

    /// <summary>
    /// Метод получения сущности по условию.
    /// </summary>
    /// <returns>Сущность.</returns>
    Task<TEntity?> GetEntity(Expression<Func<TEntity, bool>> predicate);

    /// <summary>
    /// Удалить сущность по Id.
    /// </summary>
    /// <param name="id">ID удаляемой сущности.</param>
    Task Delete(Guid id);
}
