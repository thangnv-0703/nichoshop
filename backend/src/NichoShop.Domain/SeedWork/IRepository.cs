using NichoShop.Domain.Enums;

namespace NichoShop.Domain.Seedwork;

public interface IRepository<TEntity> where TEntity : IAggregateRoot
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    void Add(TEntity entity);
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(object id, bool includeDetail = false);
    Task<List<TEntity>> GetPaging(int pageNumber, int pageSize, Dictionary<string, (object Value, SqlOperator Comparison)> filters, bool includeDetail);
    Task<List<TEntity>> GetByFilters(Dictionary<string, (object Value, SqlOperator Comparison)> filters);
}
