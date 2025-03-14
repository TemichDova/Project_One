
using Microsoft.EntityFrameworkCore;
using Project_Transaction.Dal.Repositories.Abstractions;
using Project_Transaction.Domain.Abstractions.Repositories.Interface;
using Project_Transaction.Domain.Entities;
using Project_Transaction.Domain.Exceptions;

namespace Project_Transaction.Dal.Repositories
{
    public sealed class TransactionRepository(DataContext dbcontext) : BaseRepository<Transaction>(dbcontext),  ITransactionRepository
    {

        public override async Task<Transaction> Get(Guid id)
        {
            var dbSet = DbSet.AsNoTracking();
            return await dbSet.FirstOrDefaultAsync(entity => entity.TransactionId == id) ?? throw new NotFoundException();
        }

        public async Task<int> Count()
        {
            return await DbSet.CountAsync();
        }

        public async Task<Guid> GetOldTransactionId()
        {
            return await DbSet
                 .OrderBy(t => t.Created).Select(s => s.Id).FirstAsync();
        }
    }
}
