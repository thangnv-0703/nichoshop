using NichoShop.Domain.AggergateModels;
using NichoShop.Domain.Repositories;

namespace NichoShop.Infrastructure.Repositories;

public class CategoryRepository(NichoShopDbContext context) : BaseRepository<Category, int>(context), ICategoryRepository
{
}
