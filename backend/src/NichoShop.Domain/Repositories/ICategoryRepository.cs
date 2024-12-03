using NichoShop.Domain.DTO;
using NichoShop.Domain.Seedwork;

namespace NichoShop.Domain.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<List<CategoryHome>> GetCategoryAsync();
    }
}
