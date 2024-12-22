using NichoShop.Domain.SeedWork;

namespace NichoShop.Domain.AggergateModels.SkuAggregate;

public class SkuVariant(string name, string value) : ValueObject
{
    public string Name { get; private set; } = name;
    public string Value { get; private set; } = value;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
        yield return Value;
    }
}
