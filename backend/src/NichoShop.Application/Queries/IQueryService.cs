using NichoShop.Application.Models.ViewModels;

namespace NichoShop.Application.Queries;

public interface IQueryService
{
    Task<List<CategoryViewModel>> GetCategoryViewModelsAsync();
}
