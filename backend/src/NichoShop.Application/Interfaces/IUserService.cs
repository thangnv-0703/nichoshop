using NichoShop.Application.Models.Dtos.Request.User;
using NichoShop.Application.Models.Dtos.Response.User;

namespace NichoShop.Application.Interfaces;

public interface IUserService
{
    Task<Guid> CreateUserAsync(CreateUserRequestDto requestDto);
    Task<LoginResponseDto> LoginAsync(LoginRequestDto requestDto);
    Task<bool> UpdateUserInfoAsync(UpdateUserRequestDto param);
    Task<UserInfoDto> GetUserInfoAsync();

}
