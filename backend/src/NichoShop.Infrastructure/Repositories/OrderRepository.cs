using NichoShop.Domain.AggergateModels.OrderAggregate;
using NichoShop.Domain.Repositories;

namespace NichoShop.Infrastructure.Repositories
{
    public class OrderRepository(NichoShopDbContext context) : BaseRepository<Order, Guid>(context), IOrderRepository
    {
    }
}
