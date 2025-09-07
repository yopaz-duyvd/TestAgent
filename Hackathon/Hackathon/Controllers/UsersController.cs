namespace Hackathon.Controllers;

using Hackathon.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "AdminOrAnalyst")]
public class UsersController(IUserService userService) : ControllerBase
{
    [HttpGet("latest-scan")]
    public async Task<IActionResult> GetUsersWithLatestScan()
    {
        var users = await userService.GetUsersWithLastScanAsync();
        return Ok(users);
    }
}
