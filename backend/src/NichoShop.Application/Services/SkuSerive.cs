using NichoShop.Application.Interfaces;
using NichoShop.Domain.AggergateModels.SkuAggregate;
using NichoShop.Domain.Enums;
using NichoShop.Domain.Exceptions;
using NichoShop.Domain.Repositories;

namespace NichoShop.Application.Services
{
    public class SkuSerive : ISkuService
    {
        private readonly ISkuRepository _skuRepository;
        public SkuSerive(ISkuRepository skuRepository)
        {
            _skuRepository = skuRepository;
        }

        public async Task<List<Sku>> GetByFitlers(Dictionary<string, (object Value, SqlOperator Comparison)> filters)
        {
            return await _skuRepository.GetByFilters(filters);
        }

        public async Task<bool> UpdateSkus(List<Sku> skus)
        {
            var filtersWithComparison = new Dictionary<string, (object Value, SqlOperator Comparison)>
            {
                { "Id", (skus.Select(x=>x.Id), SqlOperator.In) }
            };
            List<Sku> foundSkus = await _skuRepository.GetByFilters(filtersWithComparison);

            foundSkus = foundSkus.Select(
                foundSku =>
                {
                    var skuUpdate = skus.Find(x => foundSku.Id == x.Id) ?? throw new NotFoundException("i18nSku.messages.notFoundSku");
                    return skuUpdate;
                }
            ).ToList();

            return await _skuRepository.SaveChangesAsync() > 0;
        }
    }
}
