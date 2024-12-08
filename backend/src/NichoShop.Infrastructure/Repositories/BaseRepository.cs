using Microsoft.EntityFrameworkCore;
using NichoShop.Domain.Seedwork;
using NichoShop.Domain.SeedWork;
using System.Linq.Expressions;

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

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
    }

    protected virtual IQueryable<TEntity> ApplyIncludeDetail(IQueryable<TEntity> query)
    {
        return query; // Default implementation returns query without includes
    }

    public async Task<TEntity?> GetByIdAsync(object id, bool includeDetail = false)
    {
        IQueryable<TEntity> query = _context.Set<TEntity>();
        if (includeDetail)
        {
            query = ApplyIncludeDetail(query);
        }

        return await query.FirstOrDefaultAsync(entity => EF.Property<object>(entity, "Id") == id);
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}
