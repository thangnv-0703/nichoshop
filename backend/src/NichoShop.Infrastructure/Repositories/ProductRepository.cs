using Microsoft.EntityFrameworkCore;
using NichoShop.Domain.AggergateModels.ProductAggregate;
using NichoShop.Domain.Repositories;

namespace NichoShop.Infrastructure.Repositories
{
    public class ProductRepository(NichoShopDbContext context) : BaseRepository<Product, int>(context), IProductRepository
    {
        protected override IQueryable<Product> ApplyIncludeDetail(IQueryable<Product> query)
        {
            return query
                .Include(x => x.Categories)
                .Include(x => x.Skus)
                .Include(x => x.Variants);
        }
    }
}
