using NichoShop.Domain.AggergateModels.SkuAggregate;
using NichoShop.Domain.Repositories;

namespace NichoShop.Infrastructure.Repositories;

public class SkuRepository(NichoShopDbContext context) : BaseRepository<Sku, int>(context), ISkuRepository
{
}
