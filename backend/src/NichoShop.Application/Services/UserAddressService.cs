using AutoMapper;
using NichoShop.Application.Interfaces;
using NichoShop.Application.Models.Dtos.Request.UserAddress;
using NichoShop.Common.Interface;
using NichoShop.Domain.AggergateModels.UserAggregate;
using NichoShop.Domain.Repositories;

namespace NichoShop.Application.Services;

public class UserAddressService(IUserRepository userRepository, IUserContext userContext, IMapper mapper) : IUserAddressService
{
    private readonly IUserContext _userContext = userContext;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<List<UserAddressDto>> GetUserAddressAsync()
    {
        var user = await _userRepository.GetByIdAsync(_userContext.UserId, includeDetail: true) ?? throw new Exception("User is undefined"); ;
        var userAddresses = user.Addresses.ToList();
        var res = _mapper.Map<List<UserAddressDto>>(userAddresses);
        return res;
    }

    public async Task<Guid> CreateUserAddressAsync(UserAddressRequestDto param)
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

    public async Task<bool> UpdateUserAddressAsync(UserAddressRequestDto param, Guid userAddressId)
    {
        var user = await _userRepository.GetByIdAsync(_userContext.UserId, includeDetail: true) ?? throw new Exception("User is undefined");
        var userAddresses = user.Addresses.ToList();

        if (userAddresses.Any() && userAddresses.Find(x => x.Id == userAddressId) is not null)
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
        var user = await _userRepository.GetByIdAsync(_userContext.UserId, includeDetail: true) ?? throw new Exception("User is undefined");
        var userAddresses = user.Addresses.ToList();

        if (userAddresses.Any() && userAddresses.Find(x => x.Id == userAddressId) is not null)
        {
            user.SetDefaultAddress(userAddressId);
            await _userRepository.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<bool> DeleteUserAddressAsync(Guid userAddressId)
    {
        var user = await _userRepository.GetByIdAsync(_userContext.UserId, includeDetail: true) ?? throw new Exception("User is undefined");
        var userAddresses = user.Addresses.ToList();

        if (userAddresses.Any() && userAddresses.Find(x => x.Id == userAddressId) is not null)
        {
            user.RemoveAddress(userAddressId);
            await _userRepository.SaveChangesAsync();
            return true;
        }
        return false;
    }
}
