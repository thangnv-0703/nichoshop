using NichoShop.Domain.DTO;

namespace NichoShop.Application.Interfaces;

public interface ICategoryService
{
    Task<List<CategoryHome>> GetCategoryAsync();
}
