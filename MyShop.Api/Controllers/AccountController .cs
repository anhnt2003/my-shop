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

        [HttpPost("login-google")]
        public async Task<IActionResult> ExternalLoginAsync(ExternalLoginDto req)
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

        [HttpPost("sign-in")]
        public async Task<IActionResult> SignInAsync(LoginReq req)
        {
            try
            {
                var result = await _authService.SignInAsync(new LoginDto
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

        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUpAsync()
        {
            throw new NotImplementedException();
        }

        [HttpPost("sign-out")]
        public async Task<IActionResult> SignOutAsync()
        {
            throw new NotImplementedException();
        }
    }
}
