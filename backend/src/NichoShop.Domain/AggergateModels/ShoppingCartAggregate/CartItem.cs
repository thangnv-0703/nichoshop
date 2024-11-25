using NichoShop.Domain.Seedwork;

namespace NichoShop.Domain.AggergateModels.ShoppingCartAggregate;
public class CartItem : Entity<Guid>
{
    public int Quantity { get; private set; }

    public int SkuId { get; private set; }

    public CartItem(int skuId, int quantity)
    {  
        SkuId = skuId;
        Quantity = quantity;
        if (IsInvalid())
        {
            throw new Exception("Invalid cart item");
        }
    }

    private bool IsInvalid()
    {
        return Quantity <= 0 || SkuId <= 0;
    }
}
