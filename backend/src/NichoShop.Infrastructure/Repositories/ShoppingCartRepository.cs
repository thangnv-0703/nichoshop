using Microsoft.EntityFrameworkCore;
using NichoShop.Domain.AggergateModels.ShoppingCartAggregate;
using NichoShop.Domain.Repositories;

namespace NichoShop.Infrastructure.Repositories;

public class ShoppingCartRepository(NichoShopDbContext context) : BaseRepository<ShoppingCart, Guid>(context), IShoppingCartRepository
{
    public async Task<ShoppingCart?> GetShoppingCartByUserIdAsync(Guid userId)
    {
        return await _context.ShoppingCart.Where(x => x.CustomerId == userId)
            .Include(x => x.Items)
            .FirstOrDefaultAsync();
    }
}
