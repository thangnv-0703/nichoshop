using FluentValidation;
using NichoShop.Application.Interfaces;
using NichoShop.Application.Models.Dtos.Request.User;
using NichoShop.Application.Models.Dtos.Response.User;

namespace NichoShop.Application.Services;

public class UserService : IUserService
{
    private readonly IValidator<CreateUserRequestDto> _createUserValidator;

    public UserService(IValidator<CreateUserRequestDto> createUserValidator)
    {
        _createUserValidator = createUserValidator;
    }

    public Task<Guid> CreateUserAsync(CreateUserRequestDto requestDto)
    {
        _createUserValidator.ValidateAndThrow(requestDto);
        throw new NotImplementedException();
    }

    public Task<LoginResponseDto> LoginAsync(LoginRequestDto requestDto)
    {
        throw new NotImplementedException();
    }
}
