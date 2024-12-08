using NichoShop.Application.Models.Dtos.Request.UserAddress;
using NichoShop.Application.Models.ViewModels;
using NichoShop.Domain.AggergateModels.UserAggregate;

namespace NichoShop.Application.Interfaces
{
    public interface IUserAddressService
    {
        Task<List<UserAddress>> GetUserAddressAsync();
        Task<bool> CreateUserAddressAsync(CreateUserAddressRequestDto param);
        Task<bool> UpdateUserAddressAsync(UpdateUserAddressResquestDto param);
        Task<bool> SetDefaultUserAddressAsync(Guid userAddressId);
        Task<bool> DeleteUserAddressAsync(Guid userAddressId);
    }
}
