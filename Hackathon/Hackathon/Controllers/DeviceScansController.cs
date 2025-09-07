using Hackathon.Extensions;
using Hackathon.Models.Dtos;
using Hackathon.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Hackathon.Controllers;

/// <summary>
/// Handles device scan submissions.
/// </summary>
[ApiController]
[Route("api/paring")]
[Authorize]
public class DeviceScansController(IDeviceScanService service) : ControllerBase
{
    /// <summary>
    /// Submits a device scan.
    /// </summary>
    /// <param name="request">The device scan data.</param>
    /// <returns>The identifier of the created scan.</returns>
    [HttpPost]
    [SwaggerOperation(Summary = "Submits a device scan.", Description = "Registers a new device scan for the authenticated user.")]
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

    /// <summary>
    /// Retrieves scan history for the authenticated user.
    /// </summary>
    /// <returns>List of device scans.</returns>
    [HttpGet]
    [SwaggerOperation(Summary = "Gets scan history.", Description = "Returns device scans for the authenticated user.")]
    public async Task<IActionResult> GetHistory()
    {
        var userId = User.GetUserId();
        if (userId == null)
        {
            return Unauthorized();
        }

        var scans = await service.GetHistoryAsync(userId.Value);
        return Ok(scans);
    }
}

