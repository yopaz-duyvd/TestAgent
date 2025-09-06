namespace Hackathon.Controllers;

using Hackathon.Models.Dtos;
using Hackathon.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login(GoogleLoginRequest request)
    {
        try
        {
            var token = await authService.LoginWithGoogleAsync(request.Email, request.ClientId);
            return Ok(new { token });
        }
        catch
        {
            return Unauthorized();
        }
    }
}
