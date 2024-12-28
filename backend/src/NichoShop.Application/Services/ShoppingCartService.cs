﻿using NichoShop.Application.Interfaces;
using NichoShop.Application.Models.Dtos.Request.ShoppingCart;
using NichoShop.Application.Models.ViewModels;
using NichoShop.Application.Queries;
using NichoShop.Common.Interface;
using NichoShop.Domain.AggergateModels.ShoppingCartAggregate;
using NichoShop.Domain.Repositories;

namespace NichoShop.Application.Services;

public class ShoppingCartService(IUserContext userContext, IQueryService queryService, IShoppingCartRepository shoppingCartRepository, ISkuRepository skuRepository) : IShoppingCartService
{
    private readonly IQueryService _queryService = queryService;
    private readonly IUserContext _userContext = userContext;
    private readonly IShoppingCartRepository _shoppingCartRepository = shoppingCartRepository;
    private readonly ISkuRepository _skuRepository = skuRepository;

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

    public async Task<bool> AddItemToCartAsync(AddItemToCartRequestDto param)
    {
        var userId = _userContext.UserId;
        var cart = await _shoppingCartRepository.GetShoppingCartByUserIdAsync(userId);

        if (cart is null)
        {
            cart = new ShoppingCart(userId);
            _shoppingCartRepository.Add(cart);
        }

        if (await IsValidQuantitySkuAsync(param.Quantity, param.SkuId))
        {
            cart.AddItem(param.Quantity, param.SkuId);
            await _shoppingCartRepository.SaveChangesAsync();
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="quantity"></param>
    /// <param name="skuId"></param>
    /// <returns></returns>
    private async Task<bool> IsValidQuantitySkuAsync(int quantity, int skuId)
    {
        var sku = await _skuRepository.GetByIdAsync(skuId);
        if (sku is not null)
        {
            return sku.Quantity >= quantity;
        }
        return false;
    }
}
