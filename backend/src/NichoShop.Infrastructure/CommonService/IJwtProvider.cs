using NichoShop.Domain.AggergateModels.UserAggregate;

namespace NichoShop.Infrastructure.CommonService;

public interface IJwtProvider
{
    string GenerateToken(User user);
}
