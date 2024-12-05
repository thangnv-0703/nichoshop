using NichoShop.Application.Models.ViewModels;

namespace NichoShop.Application.Interfaces;

public interface ICategoryService
{
    Task<List<CategoryViewModel>> GetCategoryAsync();
}
