namespace NichoShop.Domain.Seedwork;

public interface IRepository<TEntity> where TEntity : IAggregateRoot
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    void Add(TEntity entity); 
    Task<List<TEntity>> GetAll();
    Task<TEntity?> GetById(object id);
}
