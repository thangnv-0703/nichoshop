using Microsoft.EntityFrameworkCore;
using NichoShop.Domain.Seedwork;
using NichoShop.Domain.SeedWork;

namespace NichoShop.Infrastructure.Repositories;
public abstract class BaseRepository<TEntity, TKey>(NichoShopDbContext context) : IRepository<TEntity>
    where TEntity : AggregateRoot<TKey>
    where TKey : struct, IEquatable<TKey>
{
    protected readonly NichoShopDbContext _context = context;

    public void Add(TEntity entity)
    {
        _context.Set<TEntity>().AddAsync(entity);
    }

    public async Task<List<TEntity>> GetAll()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity?> GetById(object id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}
