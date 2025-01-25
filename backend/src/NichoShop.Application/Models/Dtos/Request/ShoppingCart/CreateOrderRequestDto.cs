using NichoShop.Domain.Enums;

namespace NichoShop.Application.Models.Dtos.Request.ShoppingCart
{
    public class CreateOrderRequestDto
    {
        public PaymentMethod PaymentMethod { get; set; }
        public Guid UserAddressID { get; set; }
        public List<Guid> Items { get; set; }
    }
}
