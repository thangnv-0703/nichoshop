using NichoShop.Domain.AggergateModels.UserAggregate;

namespace NichoShop.Application.CommonService.Interface;

public interface IJwtProvider
{
    string GenerateToken(User user);
}
