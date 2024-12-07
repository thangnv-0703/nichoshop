﻿using NichoShop.Application.CommonService.Interface;
using NichoShop.Application.Helpers;
using NichoShop.Application.Interfaces;
using NichoShop.Application.Models.Dtos.Request.User;
using NichoShop.Application.Models.Dtos.Response.User;
using NichoShop.Domain.AggergateModels.UserAggregate;
using NichoShop.Domain.Repositories;

namespace NichoShop.Application.Services;

public class UserService(IUserRepository userRepository, IJwtProvider jwtProvider, IUserContext userContext) : IUserService
{

    private readonly IUserRepository _userRepository = userRepository;
    private readonly IJwtProvider _jwtProvider = jwtProvider;
    private readonly IUserContext _userContext = userContext;
    public async Task<Guid> CreateUserAsync(CreateUserRequestDto requestDto)
    {
        var user = await _userRepository.FindUserByPhoneNumber(requestDto.PhoneNumber);

        if (user is not null)
        {
            throw new Exception("Pphone number already exists");
        }

        var passwordHashed = PasswordHelper.Hash(requestDto.Password);
        var newUser = new User(
            requestDto.PhoneNumber,
            passwordHashed,
            requestDto.UserName,
            null,
            null,
            null);

        _userRepository.Add(newUser);
        await _userRepository.SaveChangesAsync();

        return newUser.Id;
    }


    public async Task<LoginResponseDto> LoginAsync(LoginRequestDto requestDto)
    {
        var user = await _userRepository.FindUserByPhoneNumber(requestDto.PhoneNumber) ?? throw new Exception("Pphone number already exists");

        var isVerified = PasswordHelper.Verify(requestDto.Password, user.PasswordHashed);

        if (!isVerified)
        {
            throw new Exception("Password is incorrect");
        }

        return new LoginResponseDto { Token = _jwtProvider.GenerateToken(user) };
    }

    public async Task<bool> UpdateUserInfoAsync(UpdateUserRequestDto param)
    {
        var user = await _userRepository.GetByIdAsync(_userContext.UserId, includeDetail: true) ?? throw new Exception("User is undefined");

        user.UpdateUserInfo(param.FullName, param.Email, param.PhoneNumber, param.Gender);
        await _userRepository.SaveChangesAsync();
        return true;
    }

    public async Task<User> GetUserInfoAsync()
    {
        var user = await _userRepository.GetByIdAsync(_userContext.UserId, includeDetail: true) ?? throw new Exception("User is undefined");
        return user;
    }
}
