using NichoShop.Application.Interfaces;
using NichoShop.Application.Models.ViewModels;
using NichoShop.Application.Queries;
using NichoShop.Common.Interface;

namespace NichoShop.Application.Services;

public class CategoryService(IUserContext userContext, IQueryService queryService) : ICategoryService
{
    private readonly IQueryService _queryService = queryService;
    private readonly IUserContext _userContext = userContext;

    public async Task<List<CategoryViewModel>> GetCategoryAsync()
    {
        var user = _userContext.UserId;
        return await _queryService.GetCategoryViewModelsAsync();
    }
}
