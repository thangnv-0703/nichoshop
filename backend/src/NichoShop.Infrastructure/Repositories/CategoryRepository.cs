using Microsoft.EntityFrameworkCore;
using NichoShop.Domain.Repositories;

namespace NichoShop.Infrastructure.Repositories;

public class CategoryRepository(NichoShopDbContext context) : BaseRepository<Category, int>(context), ICategoryRepository
{
}
