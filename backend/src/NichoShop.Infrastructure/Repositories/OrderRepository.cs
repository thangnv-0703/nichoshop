using Microsoft.EntityFrameworkCore;
using NichoShop.Domain.AggergateModels.OrderAggregate;
using NichoShop.Domain.AggergateModels.ProductAggregate;
using NichoShop.Domain.Repositories;

namespace NichoShop.Infrastructure.Repositories
{
    public class OrderRepository(NichoShopDbContext context) : BaseRepository<Order, Guid>(context), IOrderRepository
    {
        protected override IQueryable<Order> ApplyIncludeDetail(IQueryable<Order> query)
        {
            return query
                .Include(x => x.Items);
        }
    }
}
