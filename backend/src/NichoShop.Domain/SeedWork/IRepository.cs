namespace NichoShop.Domain.Seedwork;

public interface IRepository<T> where T : IAggregateRoot
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default);
}
