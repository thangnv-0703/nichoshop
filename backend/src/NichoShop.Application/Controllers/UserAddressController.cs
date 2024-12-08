using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NichoShop.Application.Interfaces;
using NichoShop.Application.Models.Dtos.Request.UserAddress;
using System.Net;

namespace NichoShop.Application.Controllers;

[Route("api/v1/users/address")]
[ApiController]
[Authorize]
public class UserAddressController : Controller
{
    private readonly IUserAddressService _userAddressService;

    public UserAddressController(IUserAddressService userAddressService)
    {
        _userAddressService = userAddressService;
    }

    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> CreateUserAddress()
    {
        var result = await _userAddressService.GetUserAddressAsync();
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> CreateUserAddress(CreateUserAddressRequestDto param)
    {
        var result = await _userAddressService.CreateUserAddressAsync(param);
        return Ok(result);
    }

    [HttpPut("{userAddressId}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> UpdateUserAddress(Guid userAddressId, [FromBody] UpdateUserAddressResquestDto param)
    {
        var result = await _userAddressService.UpdateUserAddressAsync(param, userAddressId);
        return Ok(result);
    }

    [HttpPut("{userAddressId}/default")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> SetDefaultUserAddress(Guid userAddressId)
    {
        var result = await _userAddressService.SetDefaultUserAddressAsync(userAddressId);
        return Ok(result);
    }

    [HttpDelete("userAddressId")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> DeleteUserAddress(Guid userAddressId)
    {
        var result = await _userAddressService.DeleteUserAddressAsync(userAddressId);
        return Ok(result);
    }
}
