using NichoShop.Application.Interfaces;
using NichoShop.Application.Models.Dtos.Request.CartItem;
using NichoShop.Application.Models.ViewModels;
using NichoShop.Application.Queries;
using NichoShop.Common.Interface;
using NichoShop.Domain.AggergateModels.ShoppingCartAggregate;
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

    public async Task<bool> UpdateCartItem(UpdateCartItemRequestDto updateCartItemRequestDto)
    {
        var cart = await _shoppingCartRepository.GetByIdAsync(updateCartItemRequestDto.CartId, includeDetail: true) ?? throw new Exception("Shopping cart is undefined");
        cart.UpdateCartItem(new CartItem(updateCartItemRequestDto.Id, updateCartItemRequestDto.Quantity));
        return await _shoppingCartRepository.SaveChangesAsync() > 0;
    }


    public async Task<bool> DeleteCartItem(Guid cartItemId)
    {
        var userId = _userContext.UserId;
        var shoppingCart = await _shoppingCartRepository.GetShoppingCartByUserIdAsync(userId);

        if (shoppingCart is null)
        {
            throw new Exception("Shopping cart is undefined");
        }

        shoppingCart.RemoveItem(cartItemId);
        return await _shoppingCartRepository.SaveChangesAsync() > 0;

    }
}
