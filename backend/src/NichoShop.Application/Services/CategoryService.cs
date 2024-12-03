using NichoShop.Application.Interfaces;
using NichoShop.Domain.Repositories;
using NichoShop.Infrastructure.CommonService;

namespace NichoShop.Application.Services;

public class CategoryService(ICategoryRepository categoriesRepository) : ICategoryService
{
    private readonly ICategoryRepository _categoriesRepository = categoriesRepository;

    public async Task<List<Category>> GetCategoryAsync()
    {
        return await _categoriesRepository.GetAll();
    }
}
