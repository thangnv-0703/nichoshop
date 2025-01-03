﻿using AutoMapper;
using NichoShop.Application.Helpers;
using NichoShop.Application.Interfaces;
using NichoShop.Application.Models.Dtos.Request.User;
using NichoShop.Application.Models.Dtos.Response.User;
using NichoShop.Common.Interface;
using NichoShop.Common.Models;
using NichoShop.Domain.AggergateModels.UserAggregate;
using NichoShop.Domain.Repositories;

namespace NichoShop.Application.Services;

public class UserService(IUserRepository userRepository, IJwtService jwtService, IUserContext userContext, IMapper mapper) : IUserService
{
    private readonly IMapper _mapper = mapper;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IJwtService _jwtService = jwtService;
    private readonly IUserContext _userContext = userContext;
    public async Task<Guid> CreateUserAsync(CreateUserRequestDto requestDto)
    {
        var user = await _userRepository.FindUserByPhoneNumber(requestDto.PhoneNumber);

        if (user is not null)
        {
            throw new Exception("Phone number already exists");
        }

        var passwordHashed = PasswordHelper.Hash(requestDto.Password); 
        var newUser = new User(
            requestDto.PhoneNumber,
            passwordHashed,
            requestDto.UserName,
            null,
            null,
            null, null);

        _userRepository.Add(newUser);
        await _userRepository.SaveChangesAsync();

        return newUser.Id;
    }


    public async Task<LoginResponseDto> LoginAsync(LoginRequestDto requestDto)
    {
        var user = await _userRepository.FindUserByPhoneNumber(requestDto.PhoneNumber) ?? throw new Exception("Phone number not found");

        var isVerified = PasswordHelper.Verify(requestDto.Password, user.PasswordHashed);

        if (!isVerified)
        {
            throw new Exception("Password is incorrect");
        }

        var identity = new Identity 
        {
            UserId = user.Id,
            PhoneNumber = user.PhoneNumber.Value,
            Email = user.Email ?? ""
        };
        return new LoginResponseDto { Token = _jwtService.GenerateToken(identity) };
    }

    public async Task<bool> UpdateUserInfoAsync(UpdateUserRequestDto param)
    {
        var user = await _userRepository.GetByIdAsync(_userContext.UserId, includeDetail: true) ?? throw new Exception("User is undefined");

        user.UpdateUserInfo(param.UserName, param.FullName, param.Email, param.PhoneNumber, param.Gender, param.DateOfBirth);
        await _userRepository.SaveChangesAsync();
        return true;
    }

    public async Task<UserInfoDto> GetUserInfoAsync()
    {
        var user = await _userRepository.GetByIdAsync(_userContext.UserId, includeDetail: true) ?? throw new Exception("User is undefined");
        var res = _mapper.Map<UserInfoDto>(user);
        return res;
    }
}
