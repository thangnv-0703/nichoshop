using NichoShop.Domain.Enums;
using NichoShop.Domain.Exceptions;
using NichoShop.Domain.Seedwork;
using NichoShop.Domain.Shared;

namespace NichoShop.Domain.AggergateModels.OrderAggregate;

public class OrderItem : Entity<Guid>
{
    public int SkuId { get; private set; }

    public string ProductName { get; private set; }

    public string VariantName { get; private set; }

    public string Thumbnail { get; private set; }

    public int Quantity { get; private set; }

    public Money Price { get; private set; }

    private OrderItem()
    {
    }

    public OrderItem(int skuId, string productName, string variantName, string thumbnail, int quantity, double amount, Currency currency)
    {
        SkuId = skuId;
        ProductName = productName;
        VariantName = variantName;
        Thumbnail = thumbnail;
        Quantity = quantity;
        Price = new Money(amount, currency);

        if (IsInvalid())
        {
            throw new DomainException
            {
                MessageCode = "i18nOrder.messages.invalidOrderItem"
            };
        }
    }

    private bool IsInvalid()
    {
        return Quantity <= 0 || string.IsNullOrEmpty(ProductName) || string.IsNullOrEmpty(VariantName) || string.IsNullOrEmpty(Thumbnail);
    }
}

public class OrderItemProps
{
    public int SkuId { get; set; }
    public string ProductName { get; set; } = default!;
    public string VariantName { get; set; } = default!;
    public string Thumbnail { get; set; } = default!;
    public int Quantity { get; set; }
    public double Amount { get; set; }
    public Currency Currency { get; set; }
}