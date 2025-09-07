namespace Hackathon.Controllers;

using Hackathon.Models.Dtos;
using Hackathon.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

/// <summary>
/// Provides endpoints for managing users.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "AdminOrAnalyst")]
public class ManagerUserController(IManagerUserService managerUserService) : ControllerBase
{
    /// <summary>
    /// Retrieves users with their latest scan.
    /// </summary>
    /// <returns>List of users and the timestamp of their last scan.</returns>
    [HttpGet("list-user")]
    [SwaggerOperation(Summary = "Retrieves users with their latest scan.", Description = "Gets a list of users along with the timestamp of their most recent scan.")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserScanSummaryResponse>))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> GetUsersWithLatestScan()
    {
        var users = await managerUserService.GetUsersWithLastScanAsync();
        return Ok(users);
    }

    /// <summary>
    /// Retrieves scan history for a specific user.
    /// </summary>
    /// <param name="userId">Identifier of the user.</param>
    /// <returns>Scan history and latest scan details.</returns>
    [HttpGet("{userId:long}/scan-history")]
    [SwaggerOperation(Summary = "Retrieves scan history for a user.", Description = "Gets device scan history and latest scan details for the specified user.")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserScanHistoryResponse))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> GetUserScanHistory(long userId)
    {
        var history = await managerUserService.GetUserScanHistoryAsync(userId);
        return Ok(history);
    }
}
