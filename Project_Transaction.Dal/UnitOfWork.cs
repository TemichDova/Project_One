using Project_Transaction.Dal.Repositories;

namespace Project_Transaction.Dal;

public class UnitOfWork(DataContext dbContext) : IUnitOfWork
{
    /// <summary>
    /// Контекст БД.
    /// </summary>
    private readonly DataContext dbContext = dbContext;

    /// <inheritdoc />
    public async Task SaveChangesAsync()
    {
        await dbContext.SaveChangesAsync();
    }

    /// <inheritdoc />
    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
