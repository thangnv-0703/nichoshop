using NichoShop.Application.Models.Dtos.Request.UserAddress;
using NichoShop.Application.Models.ViewModels;
using NichoShop.Domain.AggergateModels.UserAggregate;

namespace NichoShop.Application.Interfaces
{
    public interface IUserAddressService
    {
        Task<IReadOnlyCollection<UserAddress>> GetUserAddressAsync();
        Task<Guid> CreateUserAddressAsync(CreateUserAddressRequestDto param);
        Task<bool> UpdateUserAddressAsync(UpdateUserAddressResquestDto param, Guid userAddressId);
        Task<bool> SetDefaultUserAddressAsync(Guid userAddressId);
        Task<bool> DeleteUserAddressAsync(Guid userAddressId);
    }
}
