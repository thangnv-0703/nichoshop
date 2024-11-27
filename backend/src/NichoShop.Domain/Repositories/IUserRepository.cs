using NichoShop.Domain.AggergateModels.UserAggregate;

namespace NichoShop.Domain.Repositories;
public interface IUserRepository 
{
    Task<User> FindUserByPhoneNumberOrEmail(string phoneNumber, string email);
}
