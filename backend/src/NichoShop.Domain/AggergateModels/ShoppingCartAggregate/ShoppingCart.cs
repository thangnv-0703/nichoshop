using NichoShop.Domain.SeedWork;

namespace NichoShop.Domain.AggergateModels.ShoppingCartAggregate;

public class ShoppingCart(Guid customerId) : AggregateRoot<Guid>
{
    public Guid CustomerId { get; private set; } = customerId;

    private readonly List<CartItem> _items = [];
    public IReadOnlyCollection<CartItem> Items => _items.AsReadOnly();

    public void AddItem(int quantity, int skuId)
    {
        CartItem? item = _items.FirstOrDefault(x => x.SkuId == skuId);
        if (item is null)
        {
            item = new CartItem(skuId, quantity);
            _items.Add(item);
        }
        item.SetQuantity(quantity);
    }

    public void RemoveItem(int skuId)
    {
        var deletedItemIndex = _items.FindIndex(x => x.SkuId == skuId);
        if (deletedItemIndex == -1) throw new Exception("Item not found");
        _items.RemoveAt(deletedItemIndex);
    }
}