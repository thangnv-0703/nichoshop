using NichoShop.Application.Models.ViewModels;

namespace NichoShop.Application.Interfaces;

public interface IShoppingCartService
{
    Task<CartViewModel> GetShoppingCartByUserIdAsync();
}
