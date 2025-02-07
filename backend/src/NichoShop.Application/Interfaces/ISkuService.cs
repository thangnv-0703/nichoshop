using NichoShop.Domain.AggergateModels.SkuAggregate;
using NichoShop.Domain.Enums;

namespace NichoShop.Application.Interfaces
{
    public interface ISkuService
    {
        Task<List<Sku>> GetByFitlers(Dictionary<string, (object Value, SqlOperator Comparison)> filters);
        Task<bool> UpdateSkus(List<Sku> sku);
    }
}
