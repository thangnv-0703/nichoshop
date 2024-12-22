using NichoShop.Domain.Enums;
using NichoShop.Domain.SeedWork;
using NichoShop.Domain.Shared;

namespace NichoShop.Domain.AggergateModels.SkuAggregate;
public class Sku : AggregateRoot<int>
{
    public string SkuNo { get; private set; }

    public int ProductId { get; private set; }

    private readonly List<SkuVariant> _skuVariants = [];

    public IReadOnlyCollection<SkuVariant> SkuVariants => _skuVariants.AsReadOnly();

    public int Quantity { get; private set; }

    public bool InActive { get; private set; }

    public Money Price { get; private set; }

    private Sku()
    {
    }

    public Sku(string skuNo, int productId, List<SkuVariant> skuVariants, int quantity, bool inActive, double amount, Currency currency)
    {
        SkuNo = skuNo;
        ProductId = productId;
        _skuVariants = skuVariants;
        Quantity = quantity;
        InActive = inActive;
        Price = new Money(amount, currency);

        if (IsInvalid())
        {
            throw new Exception("Invalid sku");
        }
    }

    private bool IsInvalid()
    {
        return Quantity < 0;
    }
}
