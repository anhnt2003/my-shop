using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyShop.Identity.Dtos;
using MyShop.Identity.Services.Interfaces;

namespace MyShop.Api.Controllers
{
    [AllowAnonymous]
    public class AccountController : BaseController
    {
        private readonly IAuthService _authService;
        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginReq req)
        {
            try
            {
                var result = await _authService.LoginAsync(new LoginDto
                {
                    FullName = req.FullName,
                    UserName = req.UserName,
                    Password = req.Password,
                    PhoneNumber = req.PhoneNumber,
                    IsRemembered = req.IsRemembered,
                    VerifyPassword = req.VerifyPassword
                });
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);  
            }
        }

        [HttpPost("login-google")]
        public async Task<IActionResult> LoginGoogleAsync(ExternalLoginDto req)
        {
            try
            {
                var result = await _authService.ExternalLoginAsync(req);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
