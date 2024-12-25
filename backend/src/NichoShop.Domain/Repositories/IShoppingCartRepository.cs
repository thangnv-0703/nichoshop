using NichoShop.Domain.AggergateModels.ShoppingCartAggregate;

namespace NichoShop.Domain.Repositories;

public interface IShoppingCartRepository
{
    Task<ShoppingCart?> GetShoppingCartByUserIdAsync(Guid userId);
}
