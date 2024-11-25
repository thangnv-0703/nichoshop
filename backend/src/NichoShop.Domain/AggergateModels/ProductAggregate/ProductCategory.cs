using NichoShop.Domain.SeedWork;

namespace NichoShop.Domain.AggergateModels.ProductAggregate;
public class ProductCategory(int productId, int categoryId) : ValueObject
{
    public int ProductId { get; private set; } = productId;

    public int CategoryId { get; private set; } = categoryId;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return ProductId;
        yield return CategoryId;
    }
}
