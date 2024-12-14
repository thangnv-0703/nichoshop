using NichoShop.Application.Models.Dtos.Request.UserAddress;

namespace NichoShop.Application.Interfaces
{
    public interface IUserAddressService
    {
        Task<List<UserAddressDto>> GetUserAddressAsync();
        Task<Guid> CreateUserAddressAsync(UserAddressRequestDto param);
        Task<bool> UpdateUserAddressAsync(UserAddressRequestDto param, Guid userAddressId);
        Task<bool> SetDefaultUserAddressAsync(Guid userAddressId);
        Task<bool> DeleteUserAddressAsync(Guid userAddressId);
    }
}
