using NichoShop.Application.Interfaces;
using NichoShop.Domain.DTO;
using NichoShop.Domain.Repositories;

namespace NichoShop.Application.Services;

public class CategoryService(ICategoryRepository categoriesRepository) : ICategoryService
{
    private readonly ICategoryRepository _categoriesRepository = categoriesRepository;

    public async Task<List<CategoryHome>> GetCategoryAsync()
    {
        return await _categoriesRepository.GetCategoryAsync();
    }
}
