namespace Hackathon.Controllers;

using Hackathon.Models.Dtos;
using Hackathon.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

/// <summary>
/// Handles authentication operations.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService) : ControllerBase
{
    /// <summary>
    /// Authenticates a user using email and password.
    /// </summary>
    /// <param name="request">The login details.</param>
    /// <returns>A JWT token if authentication succeeds.</returns>
    [HttpPost("login")]
    [SwaggerOperation(Summary = "Authenticates a user using email and password.", Description = "Validates credentials and returns a JWT token.")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        try
        {
            var token = await authService.LoginAsync(request.Email, request.Password);
            return Ok(new { token });
        }
        catch
        {
            return Unauthorized();
        }
    }
}
