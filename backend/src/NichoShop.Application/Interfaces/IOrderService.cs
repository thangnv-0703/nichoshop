using NichoShop.Application.Models.Dtos.Request.Paging;
using NichoShop.Application.Models.Dtos.Request.ShoppingCart;
using NichoShop.Domain.AggergateModels.OrderAggregate;

namespace NichoShop.Application.Interfaces
{
    public interface IOrderService
    {
        Task<Guid> CreateOrder(CreateOrderRequestDto param);
        Task<List<Order>> GetPaging(PagingRequestDto param);
    }
}
