using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace NichoShop.Infrastructure.Context;

public static class ClaimsPrincipalExtensions
{
    public static Guid? GetUserId(this ClaimsPrincipal? principal)
    {
        string? userId = principal?.FindFirstValue(JwtRegisteredClaimNames.Sub);

        return Guid.TryParse(userId, out Guid parsedUserId) ?
            parsedUserId : null;
    }

    public static string? GetPhoneNumber(this ClaimsPrincipal? principal)
    {
        return principal?.FindFirstValue(JwtRegisteredClaimNames.PhoneNumber);
    }
}