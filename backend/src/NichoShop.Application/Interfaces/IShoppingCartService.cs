﻿using NichoShop.Application.Models.Dtos.Request.ShoppingCart;
using NichoShop.Application.Models.Dtos.Request.CartItem;
using NichoShop.Application.Models.ViewModels;

namespace NichoShop.Application.Interfaces;

public interface IShoppingCartService
{
    Task<CartViewModel> GetShoppingCartByUserIdAsync();
    Task<bool> AddItemToCartAsync(AddItemToCartRequestDto param);
    Task<bool> UpdateCartItem(UpdateCartItemRequestDto updateCartItemRequestDto);
    Task<bool> DeleteCartItem(Guid cartItemId);
}
