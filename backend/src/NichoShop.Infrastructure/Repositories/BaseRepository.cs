using Microsoft.EntityFrameworkCore;
using NichoShop.Domain.Enums;
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

    public List<TEntity> GetByFilters(Dictionary<string, (object Value, SqlOperator Comparison)> filters)
    {
        var parameter = Expression.Parameter(typeof(TEntity), "x");
        IQueryable<TEntity> query = _context.Set<TEntity>();
        foreach (var filter in filters)
        {
            // Tạo Expression cho tên field và giá trị filter
            var property = Expression.Property(parameter, filter.Key);
            var constant = Expression.Constant(filter.Value.Value);

            Expression comparisonExpression = null;

            switch (filter.Value.Comparison)
            {
                case SqlOperator.Equal:
                    comparisonExpression = Expression.Equal(property, constant);
                    break;
                case SqlOperator.Notequal:
                    comparisonExpression = Expression.NotEqual(property, constant);
                    break;
                case SqlOperator.Greaterthan:
                    comparisonExpression = Expression.GreaterThan(property, constant);
                    break;
                case SqlOperator.Lessthan:
                    comparisonExpression = Expression.LessThan(property, constant);
                    break;
                case SqlOperator.In:
                    comparisonExpression = Expression.Call(
                        typeof(Enumerable),
                        "Contains",
                        new Type[] { property.Type },
                        constant,
                        property
                    );

                    break;
                default:
                    throw new ArgumentException($"Unsupported comparison: {filter.Value.Comparison}");
            }

            var lambda = Expression.Lambda<Func<TEntity, bool>>(comparisonExpression, parameter);
            query = query.Where(lambda);
        }

        return query.ToList();
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}
