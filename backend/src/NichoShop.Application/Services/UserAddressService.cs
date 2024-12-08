using NichoShop.Application.CommonService.Interface;
using NichoShop.Application.Interfaces;
using NichoShop.Application.Models.Dtos.Request.UserAddress;
using NichoShop.Domain.AggergateModels.UserAggregate;
using NichoShop.Domain.Repositories;

namespace NichoShop.Application.Services;

public class UserAddressService(IUserRepository userRepository, IUserContext userContext) : IUserAddressService
{
    private readonly IUserContext _userContext = userContext;
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<List<UserAddress>> GetUserAddressAsync()
    {
        var user = await _userRepository.GetByIdAsync(_userContext.UserId);

        if (user is null)
        {
            throw new Exception("User is undefined");
        }

        return user.GetUserAddresses();
    }

    public async Task<Guid> CreateUserAddressAsync(CreateUserAddressRequestDto param)
    {
        var user = await _userRepository.GetByIdAsync(_userContext.UserId, includeDetail: true) ?? throw new Exception("User is undefined");
        var userAddressProp = new UserAddressProps()
        {
            FullName = param.FullName,
            Street = param.Street,
            Ward = param.Ward,
            District = param.District,
            Province = param.Province,
            Country = param.Country,
            ZipCode = param.ZipCode,
            PhoneNumber = param.PhoneNumber,
        };
        var address = user.AddAddress(userAddressProp);
        await _userRepository.SaveChangesAsync();
        return address.Id;
    }

    public async Task<bool> UpdateUserAddressAsync(UpdateUserAddressResquestDto param, Guid userAddressId)
    {
        var user = await _userRepository.GetByIdAsync(_userContext.UserId, includeDetail: true) ?? throw new Exception("User is undefined");
        var userAddress = user.GetUserAddressById(userAddressId);

        if (userAddress is not null)
        {
            var userAddressProp = new UserAddressProps()
            {
                FullName = param.FullName,
                Street = param.Street,
                Ward = param.Ward,
                District = param.District,
                Province = param.Province,
                Country = param.Country,
                ZipCode = param.ZipCode,
                PhoneNumber = param.PhoneNumber,
            };
            user.UpdateAddress(userAddressId, userAddressProp);
            await _userRepository.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<bool> SetDefaultUserAddressAsync(Guid userAddressId)
    {
        var user = await _userRepository.GetByIdAsync(_userContext.UserId);

        if (user is null)
        {
            throw new Exception("User is undefined");
        }

        var userAddress = user.GetUserAddressById(userAddressId);

        if (userAddress is not null && IsValidUser(userAddress.Id))
        {
            user.SetDefaultAddress(userAddressId);
            return true;
        }
        return false;
    }

    public async Task<bool> DeleteUserAddressAsync(Guid userAddressId)
    {
        var user = await _userRepository.GetByIdAsync(_userContext.UserId);

        if (user is null)
        {
            throw new Exception("User is undefined");
        }

        var userAddress = user.GetUserAddressById(userAddressId);

        if (userAddress is not null && IsValidUser(userAddress.Id))
        {
            user.RemoveAddress(userAddressId);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Hàm kiểm tra xem userId có khớp với userId của userAddress có khớp không?
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    private bool IsValidUser(Guid userID_userAddress)
    {
        if (_userContext.UserId == userID_userAddress)
            return true;
        return false;
    }
}
