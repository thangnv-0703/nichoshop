namespace NichoShop.Application.Interfaces;

public interface ICategoryService
{
    Task<List<Category>> GetCategoryAsync();
}
