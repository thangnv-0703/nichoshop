using NichoShop.Domain.AggergateModels.SkuAggregate;
using NichoShop.Domain.Enums;
using NichoShop.Domain.Shared;

namespace NichoShop.Application.Interfaces
{
    public interface ISkuService
    {
        Task<List<Sku>> GetByFitlers(Dictionary<string,FilterItem> filters);
        Task<bool> UpdateSkus(List<Sku> sku);
    }
}
