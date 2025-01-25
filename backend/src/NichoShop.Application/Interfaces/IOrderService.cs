using NichoShop.Application.Models.Dtos.Request.ShoppingCart;

namespace NichoShop.Application.Interfaces
{
    public interface IOrderService
    {
        Task<Guid> CreateOrder(CreateOrderRequestDto param);
    }
}
