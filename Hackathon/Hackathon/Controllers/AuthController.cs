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
    /// Authenticates a user using Google login.
    /// </summary>
    /// <param name="request">The Google login details.</param>
    /// <returns>A JWT token if authentication succeeds.</returns>
    [HttpPost("login")]
    [SwaggerOperation(Summary = "Authenticates a user using Google login.", Description = "Validates Google credentials and returns a JWT token.")]
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
