using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NichoShop.Application.Interfaces;
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
}
