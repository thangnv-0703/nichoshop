using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NichoShop.Application.Interfaces;
using NichoShop.Application.Models.Dtos.Request.ShoppingCart;
using System.Net;

namespace NichoShop.Application.Controllers;

[Route("api/v1/cart")]
[ApiController]
[Authorize]
public class ShoppingCartController : Controller
{
    private readonly IShoppingCartService _shoppingCartService;

    public ShoppingCartController(IShoppingCartService shoppingCartService)
    {
        _shoppingCartService = shoppingCartService;
    }

    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetShoppingCartByUserId()
    {
        var result = await _shoppingCartService.GetShoppingCartByUserIdAsync();
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType((int)HttpStatusCode.UnprocessableContent)]
    public async Task<IActionResult> AddItemToCart([FromBody] AddItemToCartRequestDto param)
    {
        var result = await _shoppingCartService.AddItemToCartAsync(param);
        return Ok(result);
    }
}
