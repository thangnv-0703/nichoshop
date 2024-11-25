using NichoShop.Domain.SeedWork;

namespace NichoShop.Domain.AggergateModels.ProductAggregate;
public class ProductVariantOption(string value) : ValueObject
{
    public string Value { get; private set; } = value;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
