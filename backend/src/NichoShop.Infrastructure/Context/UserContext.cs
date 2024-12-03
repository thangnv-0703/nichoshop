using Microsoft.AspNetCore.Http;
using NichoShop.Infrastructure.CommonService;
using NichoShop.Infrastructure.Context;

public sealed class UserContext(IHttpContextAccessor httpContextAccessor)
    : IUserContext
{
    public Guid UserId =>
        httpContextAccessor
            .HttpContext?
            .User
            .GetUserId() ??
        throw new UnauthorizedAccessException();

    public string PhoneNumber =>
        httpContextAccessor
            .HttpContext?
            .User
            .GetPhoneNumber() ??
        throw new UnauthorizedAccessException();

    public bool IsAuthenticated =>
        httpContextAccessor
            .HttpContext?
            .User
            .Identity?
            .IsAuthenticated ??
        throw new ApplicationException("User context is unavailable");
}