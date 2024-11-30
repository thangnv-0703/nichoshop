using Microsoft.EntityFrameworkCore;
using NichoShop.Domain.AggergateModels.UserAggregate;
using NichoShop.Domain.Repositories;

namespace NichoShop.Infrastructure.Repositories;
public class UserRepository(NichoShopDbContext context) : BaseRepository<User, Guid>(context), IUserRepository 
{
    public async Task<User?> FindUserByPhoneNumberOrEmail(string phoneNumber, string email)
    {
        return await _context.User.Where(x => x.PhoneNumber.Value == phoneNumber || x.Email == email).FirstOrDefaultAsync();
    }
}
