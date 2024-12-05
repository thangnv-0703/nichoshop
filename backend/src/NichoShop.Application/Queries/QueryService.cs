using Microsoft.EntityFrameworkCore;
using NichoShop.Application.Models.ViewModels;
using NichoShop.Infrastructure;

namespace NichoShop.Application.Queries;
public class QueryService(NichoShopDbContext dbContext) : IQueryService
{
    private readonly NichoShopDbContext _dbContext = dbContext;

    public async Task<List<CategoryViewModel>> GetCategoryViewModelsAsync()
    {
        return await _dbContext.Category
            .Select(c => new CategoryViewModel
            {
                Id = c.Id,
                Name = c.Name,
                DisplayName = c.DisplayName
            })
            .ToListAsync();
    }
}
