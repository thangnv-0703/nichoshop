using NichoShop.Application.Interfaces;
using NichoShop.Application.Queries;
using NichoShop.Application.Models.ViewModels;
using NichoShop.Common.Interface;
using NichoShop.Domain.Repositories;

namespace NichoShop.Application.Services;

public class ShoppingCartService(IUserContext userContext, IQueryService queryService, IShoppingCartRepository shoppingCartRepository) : IShoppingCartService
{
    private readonly IQueryService _queryService = queryService;
    private readonly IUserContext _userContext = userContext;
    private readonly IShoppingCartRepository _shoppingCartRepository = shoppingCartRepository;

    public async Task<CartViewModel> GetShoppingCartByUserIdAsync()
    {
        var userId = _userContext.UserId;
        var result = new CartViewModel();

        var shoppingCart = await _shoppingCartRepository.GetShoppingCartByUserIdAsync(userId);

        if (shoppingCart is not null)
        {
            var cartItems = await _queryService.GetCartItemViewModelsAsync(userId);
            result.Id = shoppingCart.Id;
            result.Items = cartItems;
        }

        return result;
    }
}
