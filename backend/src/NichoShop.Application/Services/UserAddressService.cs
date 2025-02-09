﻿using AutoMapper;
using NichoShop.Application.Interfaces;
using NichoShop.Application.Models.Dtos.Request.UserAddress;
using NichoShop.Common.Interface;
using NichoShop.Domain.AggergateModels.UserAggregate;
using NichoShop.Domain.Exceptions;
using NichoShop.Domain.Repositories;

namespace NichoShop.Application.Services;

public class UserAddressService : IUserAddressService
{
    private readonly IUserContext _userContext;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserAddressService(IUserRepository userRepository, IUserContext userContext, IMapper mapper)
    {
        _userRepository = userRepository;
        _userContext = userContext;
        _mapper = mapper;
    }

    public async Task<List<UserAddressDto>> GetUserAddressAsync()
    {
        var user = await _userRepository.GetByIdAsync(_userContext.UserId, includeDetail: true) ?? throw new NotFoundException("i18nUser.messages.notFoundUser");
        var userAddresses = user.Addresses.ToList();
        var res = _mapper.Map<List<UserAddressDto>>(userAddresses);
        return res;
    }

    public async Task<Guid> CreateUserAddressAsync(UserAddressRequestDto param)
    {
        var user = await _userRepository.GetByIdAsync(_userContext.UserId, includeDetail: true) ?? throw new NotFoundException("i18nUser.messages.notFoundUser");
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
        var user = await _userRepository.GetByIdAsync(_userContext.UserId, includeDetail: true) ?? throw new NotFoundException("i18nUser.messages.notFoundUser");
        var userAddress = user.Addresses.FirstOrDefault(x => x.Id == userAddressId);

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
        var user = await _userRepository.GetByIdAsync(_userContext.UserId, includeDetail: true) ?? throw new NotFoundException("i18nUser.messages.notFoundUser");
        var userAddress = user.Addresses.FirstOrDefault(x => x.Id == userAddressId);

        if (userAddress is not null)
        {
            user.SetDefaultAddress(userAddressId);
            await _userRepository.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<bool> DeleteUserAddressAsync(Guid userAddressId)
    {
        var user = await _userRepository.GetByIdAsync(_userContext.UserId, includeDetail: true) ?? throw new NotFoundException("i18nUser.messages.notFoundUser");
        var userAddress = user.Addresses.FirstOrDefault(x => x.Id == userAddressId);

        if (userAddress is not null)
        {
            user.RemoveAddress(userAddressId);
            await _userRepository.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<UserAddress> GetByIdAsync(Guid userAddressId)
    {
        var user = await _userRepository.GetByIdAsync(_userContext.UserId, includeDetail: true) ?? throw new NotFoundException("i18nUser.messages.notFoundUser");
        return user.Addresses.FirstOrDefault(x => x.Id == userAddressId) ?? throw new NotFoundException("i18nUserAddress.messages.notFoundAddress");
    }
}
