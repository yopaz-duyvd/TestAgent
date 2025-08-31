using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TruyenVerse.Application.Interfaces.Services;
using TruyenVerse.Domain.Entities;
using TruyenVerse.Domain.Enums;

namespace TruyenVerse.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtTokenService _tokenService;

        public UsersController(IUserService userService, IJwtTokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> Login(LoginRequest request)
        {
            var user = await _userService.LoginAsync(request.Email, request.Password);
            if (user is null)
            {
                return Unauthorized();
            }

            var token = _tokenService.GenerateToken(user);
            return Ok(token);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult<User>> Register(RegisterRequest request)
        {
            var user = await _userService.RegisterAsync(request.Email, request.Password, request.FullName);
            return Ok(user);
        }

        [HttpPost("forgot-password")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordRequest request)
        {
            await _userService.ForgotPasswordAsync(request.Email);
            return NoContent();
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordRequest request)
        {
            await _userService.ChangePasswordAsync(request.UserId, request.NewPassword);
            return NoContent();
        }

        [HttpPut("update-profile")]
        public async Task<IActionResult> UpdateProfile(UpdateProfileRequest request)
        {
            await _userService.UpdateProfileAsync(request.UserId, request.FullName, request.Gender, request.Address, request.Introduction);
            return NoContent();
        }
    }

    public record LoginRequest(string Email, string Password);
    public record RegisterRequest(string Email, string Password, string FullName);
    public record ForgotPasswordRequest(string Email);
    public record ChangePasswordRequest(Guid UserId, string NewPassword);
    public record UpdateProfileRequest(Guid UserId, string FullName, Gender Gender, string Address, string Introduction);
}
