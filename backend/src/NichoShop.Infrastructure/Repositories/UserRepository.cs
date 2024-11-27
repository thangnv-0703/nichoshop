using NichoShop.Domain.AggergateModels.UserAggregate;
using NichoShop.Domain.Repositories;

namespace NichoShop.Infrastructure.Repositories;
public class UserRepository : IUserRepository 
{
    protected readonly NichoShopDbContext _context;

    public UserRepository(NichoShopDbContext context)
    {
        _context = context;
    }

    public async Task<User> FindUserByPhoneNumberOrEmail(string phoneNumber, string email)
    {
        return await _context.User.Where(x => x.PhoneNumber == phoneNumber || x.Email == email);
    }
}
