using NichoShop.Domain.AggergateModels.SkuAggregate;

namespace NichoShop.Application.Interfaces
{
    public interface ISkuService
    {
        Task<List<Sku>> GetByFitlers(Dictionary<string, (object Value, string Comparison)> filters);
        Task<bool> UpdateSkus(List<Sku> sku);
    }
}
