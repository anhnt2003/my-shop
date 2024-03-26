using MyShop.Identity.Dtos;

namespace MyShop.Identity.Services.Interfaces;

public interface IAuthService
{
    Task<UserLoginDto> SignInAsync(LoginDto loginDto);

    Task SignUpAsync();

    Task SignOutAsync();
    
    Task<UserLoginDto> ExternalLoginAsync(ExternalLoginDto externalLoginDto);
}