using NichoShop.Domain.AggergateModels.UserAggregate;
using NichoShop.Domain.Seedwork;

namespace NichoShop.Domain.Repositories;
public interface IUserRepository : IRepository<User>
{
    Task<User?> FindUserByPhoneNumber(string phoneNumber);
}
