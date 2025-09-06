namespace Hackathon.Controllers;

using Hackathon.Models.Dtos;
using Hackathon.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        await authService.RegisterAsync(request.Username, request.Password);
        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var token = await authService.LoginAsync(request.Username, request.Password);
        if (token is null)
        {
            return Unauthorized();
        }

        return Ok(new { token });
    }
}

