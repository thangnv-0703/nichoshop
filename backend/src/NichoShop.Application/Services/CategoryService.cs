using NichoShop.Application.Interfaces;
using NichoShop.Domain.Repositories;
using NichoShop.Infrastructure.CommonService;

namespace NichoShop.Application.Services;

public class CategoryService(ICategoryRepository categoriesRepository, IUserContext userContext) : ICategoryService
{
    private readonly ICategoryRepository _categoriesRepository = categoriesRepository;
    private readonly IUserContext _userContext = userContext;

    public async Task<List<Category>> GetCategoryAsync()
    {
        var user = _userContext.UserId;
        return await _categoriesRepository.GetAll();
    }
}
