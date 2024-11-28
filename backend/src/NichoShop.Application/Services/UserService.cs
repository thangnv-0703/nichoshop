using FluentValidation;
using NichoShop.Application.Interfaces;
using NichoShop.Application.Models.Dtos.Request.User;
using NichoShop.Application.Models.Dtos.Response.User;
using NichoShop.Domain.AggergateModels.UserAggregate;
using NichoShop.Domain.Repositories;

namespace NichoShop.Application.Services;

public class UserService : IUserService
{
    private readonly IValidator<CreateUserRequestDto> _createUserValidator;
    private readonly IUserRepository _userRepository;

    public UserService(IValidator<CreateUserRequestDto> createUserValidator, IUserRepository userRepository)
    {
        _createUserValidator = createUserValidator;
        _userRepository = userRepository;
    }

    public async Task<Guid> CreateUserAsync(CreateUserRequestDto requestDto)
    {
        _createUserValidator.ValidateAndThrow(requestDto);

        var userWithPhoneAndEmail = await _userRepository.FindUserByPhoneNumberOrEmail(requestDto.PhoneNumber, requestDto.Email);

        if (userWithPhoneAndEmail is not null)
        {
            throw new Exception("User with this phone number or email already exists");
        }
        var user = new User(requestDto.FullName, requestDto.Email, requestDto.PhoneNumber, requestDto.Password, requestDto.UserName);
        _userRepository.Add(user);
        await _userRepository.SaveChangesAsync();
        return user.Id;
    }

    public Task<LoginResponseDto> LoginAsync(LoginRequestDto requestDto)
    {
        throw new NotImplementedException();
    }
}
