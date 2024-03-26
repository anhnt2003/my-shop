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
    private readonly GoogleHandler _googleHandler;
    private readonly JwtHandler _jwtHandler;
    public AuthService(
        IUserRepository userRepository,
        IUnitOfWork unitOfWork,
        GoogleHandler googleHandler,
        JwtHandler jwtHandler)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _googleHandler = googleHandler;
        _jwtHandler = jwtHandler;
    }
    public Task<UserLoginDto> LoginAsync(LoginDto loginDto)
    {
        throw new NotImplementedException();
    }

    public async Task<UserLoginDto> ExternalLoginAsync(ExternalLoginDto externalLoginDto)
    {
        var payload = await _googleHandler.VerifyGoogleTokenAsync(externalLoginDto.IdToken);
        if (payload == null)
        {
            throw new Exception("Invalid External Authentication");
        }

        var user = await _userRepository.GetByEmailAsync(payload.Email);
        if(user == null)
        {
            user = new User(
                payload.Email,
                null,
                payload.Name,
                payload.Email,
                null,
                payload.Picture,
                false,
                null);
            await _userRepository.AddAsync(user);
            await _unitOfWork.CommitAsync();
        }
        var token = _jwtHandler.GenerateToken(user);

        return new UserLoginDto
        {
            UserId = user.Id,
            Email = user.Email,
            FullName = user.FullName,
            UserName = user.UserName,
            Token = token,
        };
    }
}   