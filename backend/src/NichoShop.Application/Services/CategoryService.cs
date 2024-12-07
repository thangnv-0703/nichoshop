﻿using NichoShop.Application.Interfaces;
using NichoShop.Application.CommonService.Interface;
using NichoShop.Application.Queries;
using NichoShop.Application.Models.ViewModels;

namespace NichoShop.Application.Services;

public class CategoryService(IUserContext userContext, IQueryService queryService) : ICategoryService
{
    private readonly IQueryService _queryService = queryService;
    private readonly IUserContext _userContext = userContext;

    public async Task<List<CategoryViewModel>> GetCategoryAsync()
    {
        var user = _userContext.UserId;
        return await queryService.GetCategoryViewModelsAsync();
    }
}
