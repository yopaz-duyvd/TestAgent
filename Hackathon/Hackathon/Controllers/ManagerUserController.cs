namespace Hackathon.Controllers;

using Hackathon.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "AdminOrAnalyst")]
public class ManagerUserController(IManagerUserService managerUserService) : ControllerBase
{
    [HttpGet("latest-scan")]
    public async Task<IActionResult> GetUsersWithLatestScan()
    {
        var users = await managerUserService.GetUsersWithLastScanAsync();
        return Ok(users);
    }
}
