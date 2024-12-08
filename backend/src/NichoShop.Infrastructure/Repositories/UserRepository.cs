﻿using Microsoft.EntityFrameworkCore;
using NichoShop.Domain.AggergateModels.UserAggregate;
using NichoShop.Domain.Repositories;

namespace NichoShop.Infrastructure.Repositories;
public class UserRepository(NichoShopDbContext context) : BaseRepository<User, Guid>(context), IUserRepository
{
    public async Task<User?> FindUserByPhoneNumber(string phoneNumber)
    {
        return await _context.User.Where(x => x.PhoneNumber.Value == phoneNumber).FirstOrDefaultAsync();
    }

    protected override IQueryable<User> ApplyIncludeDetail(IQueryable<User> query)
    {
        return query.Include(x => x.Addresses);
    }
}
