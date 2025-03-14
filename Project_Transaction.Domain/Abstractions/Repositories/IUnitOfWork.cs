namespace Project_Transaction.Dal.Repositories;

/// <summary>
/// Интерфейс единичной работы.
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Сохранить изменения.
    /// </summary>
    /// <returns></returns>
    public Task SaveChangesAsync();

    /// <summary>
    /// Сохранить изменения.
    /// </summary>
    /// <returns></returns>
    public Task SaveChangesAsync(CancellationToken cancellationToken);
}
