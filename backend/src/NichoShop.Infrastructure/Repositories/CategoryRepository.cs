using Microsoft.EntityFrameworkCore;
using NichoShop.Domain.DTO;
using NichoShop.Domain.Repositories;

namespace NichoShop.Infrastructure.Repositories;

public class CategoryRepository(NichoShopDbContext context) : BaseRepository<Category, int>(context), ICategoryRepository
{
    public async Task<List<CategoryHome>> GetCategoryAsync()
    {
        return await _context.Category
                .Select(c => new CategoryHome
                {
                    Id = c.Id,
                    DisplayName = c.DisplayName
                }).ToListAsync();
    }
}
