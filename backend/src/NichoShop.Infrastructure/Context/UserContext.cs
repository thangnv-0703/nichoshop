﻿using Microsoft.AspNetCore.Http;
using NichoShop.Infrastructure.CommonService;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace NichoShop.Infrastructure.Context;

public sealed class UserContext
    : IUserContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public UserContext(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
    }

    private ClaimsPrincipal User => _httpContextAccessor.HttpContext?.User
        ?? throw new UnauthorizedAccessException("HttpContext is unavailable.");

    public Guid UserId =>
        Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out Guid userId)
        ? userId
        : throw new UnauthorizedAccessException("User ID is missing or invalid.");

    public string PhoneNumber => User.FindFirstValue(JwtRegisteredClaimNames.PhoneNumber) ??
        throw new UnauthorizedAccessException();

    public bool IsAuthenticated => User.Identity?.IsAuthenticated ??
        throw new ApplicationException("User context is unavailable");
}