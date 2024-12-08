using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NichoShop.Application.Interfaces;
using NichoShop.Application.Models.Dtos.Request.User;
using System.Net;

namespace NichoShop.Application.Controllers;

[Route("api/v1/users")]
[ApiController]
public class UserController : Controller
{
    private readonly IUserService _userService;
    private readonly IValidator<CreateUserRequestDto> _createUserValidator;
    private readonly IValidator<LoginRequestDto> _loginValidator;

    public UserController(IUserService userService, IValidator<CreateUserRequestDto> createUserValidator, IValidator<LoginRequestDto> loginValidator)
    {
        _userService = userService;
        _createUserValidator = createUserValidator;
        _loginValidator = loginValidator;
    }

    [HttpPost("signup")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Signup([FromBody] CreateUserRequestDto requestDto)
    {
        var result = _createUserValidator.Validate(requestDto);
        await _userService.CreateUserAsync(requestDto);
        return Ok(true);
    }

    [HttpPost("login")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto requestDto)
    {
        _loginValidator.Validate(requestDto);
        var result = await _userService.LoginAsync(requestDto);
        return Ok(result);
    }
}
