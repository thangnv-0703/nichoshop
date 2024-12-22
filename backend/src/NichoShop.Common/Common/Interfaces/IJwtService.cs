using NichoShop.Common.Models;

namespace NichoShop.Common.Interface;

public interface IJwtService
{
    string GenerateToken(Identity user);
}
