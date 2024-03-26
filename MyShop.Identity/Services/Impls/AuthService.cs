using Microsoft.AspNetCore.Identity;
using MyShop.Domain;
using MyShop.Domain.AggregateModels.UserAggregate.Models;
using MyShop.Domain.AggregateModels.UserAggregate.Repository;
using MyShop.Identity.Dtos;
using MyShop.Identity.Services.Interfaces;

namespace MyShop.Identity.Services.Impls;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<MyShopUser> _userManager;
    private readonly GoogleHandler _googleHandler;
    private readonly JwtHandler _jwtHandler;
    public AuthService(
        IUserRepository userRepository,
        IUnitOfWork unitOfWork,
        UserManager<MyShopUser> userManager,
        GoogleHandler googleHandler,
        JwtHandler jwtHandler)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _userManager = userManager;
        _googleHandler = googleHandler;
        _jwtHandler = jwtHandler;
    }

    public async Task<UserLoginDto> ExternalLoginAsync(ExternalLoginDto externalLoginDto)
    {
        var payload = await _googleHandler.VerifyGoogleTokenAsync(externalLoginDto.IdToken);

        if (payload == null)
           throw new Exception("Invalid External Authentication.");

        var info = new UserLoginInfo(externalLoginDto.Provider, payload.Subject, externalLoginDto.Provider);
        var user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);

        if (user == null)
        {
            user = await _userManager.FindByEmailAsync(payload.Email);
            if (user == null)
            {
                user = new MyShopUser
                {
                    Email = payload.Email,
                    UserName = payload.Email,
                    EmailConfirmed = true
                };
                // Create info login by Google to table User
                await _userRepository.AddAsync(new User(payload.Email, null, payload.Name, payload.Email, null, payload.Picture, false, null));
                await _unitOfWork.CommitAsync();

                await _userManager.CreateAsync(user);
                await _userManager.AddLoginAsync(user, info);
            }
            else
            {
                await _userManager.AddLoginAsync(user, info);
            }
        }
        if (user == null)
            throw new Exception("Invalid External Authentication.");

        var token = _jwtHandler.GenerateToken(user);

        return new UserLoginDto
        {
            UserId = user.Id,
            UserName = user.UserName,
            Email = user.Email,
            Token = token
        };
    }

    public Task<UserLoginDto> SignInAsync(LoginDto loginDto)
    {
        throw new NotImplementedException();
    }

    public Task SignUpAsync()
    {
        throw new NotImplementedException();
    }

    public Task SignOutAsync()
    {
        throw new NotImplementedException();
    }
}   