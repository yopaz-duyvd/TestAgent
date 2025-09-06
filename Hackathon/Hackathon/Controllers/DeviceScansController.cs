using Hackathon.Extensions;
using Hackathon.Models.Dtos;
using Hackathon.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class DeviceScansController(IDeviceScanService service) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Scan(DeviceScanRequest request)
    {
        var userId = User.GetUserId();
        if (userId == null)
        {
            return Unauthorized();
        }

        var scan = await service.ScanAsync(request, userId.Value);
        return Ok(new { scan.Id });
    }
}

