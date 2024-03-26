using MyShop.Identity.Dtos;

namespace MyShop.Identity.Services.Interfaces;

public interface IAuthService
{
    Task<UserLoginDto> LoginAsync(LoginDto loginDto);
    
    Task<UserLoginDto> ExternalLoginAsync(ExternalLoginDto externalLoginDto);
}