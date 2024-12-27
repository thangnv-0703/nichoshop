using NichoShop.Application.Interfaces;
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

    public async Task AddItemToCartAsync()
    {
        // bước 1: kiểm tra xem user đó có giỏ hàng chưa
        var userId = _userContext.UserId;
        var cartById = await _shoppingCartRepository.GetShoppingCartByUserIdAsync(userId);
        
        // bước 2.1: nếu có rồi thì get giỏ hàng đó
        // bước 2.2: nếu chưa có thì tạo ShoppingCart theo UserId đó
        if (cart is not null)
        {
            
        }
        else
        {
            ShoppingCart newCart = new ShoppingCart()
            {
                Id = Guid.NewGuid(),
                CustomerId = userId,
            }
        }
            

        // bước 3: check xem item đó trong giỏ chưa
        // bước 4.1: nếu chưa thì add
        // bước 4.2: nếu có thì add thêm số lượng

        // bước 5: save db
    }
}
