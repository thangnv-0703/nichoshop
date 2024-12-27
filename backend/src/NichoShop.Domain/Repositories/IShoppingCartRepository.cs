using NichoShop.Domain.AggergateModels.ShoppingCartAggregate;
using NichoShop.Domain.Seedwork;

namespace NichoShop.Domain.Repositories;

public interface IShoppingCartRepository : IRepository<ShoppingCart>
{
    Task<ShoppingCart?> GetShoppingCartByUserIdAsync(Guid userId);
}
