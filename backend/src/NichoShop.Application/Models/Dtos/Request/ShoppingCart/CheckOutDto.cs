using NichoShop.Application.Models.Dtos.Request.UserAddress;
using NichoShop.Application.Models.ViewModels;

namespace NichoShop.Application.Models.Dtos.Request.ShoppingCart;

public class CheckOutDto
{
    public UserAddressDto? Address { get; set; }
    public List<CartItemViewModel> Products { get; set; }
}
