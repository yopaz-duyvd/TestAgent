using Hackathon.Models.Dtos;
using Hackathon.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Hackathon.Controllers;

/// <summary>
/// Manages operations related to approved applications.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "AdminOrAnalyst")]
public class ApprovedApplicationsController(IApprovedApplicationService service) : ControllerBase
{
    /// <summary>
    /// Retrieves all approved applications.
    /// </summary>
    /// <returns>All approved applications.</returns>
    [HttpGet]
    [SwaggerOperation(Summary = "Retrieves all approved applications.", Description = "Gets the list of every approved application in the system.")]
    public async Task<IActionResult> GetAll()
    {
        var apps = await service.GetAllAsync();
        return Ok(apps);
    }

    /// <summary>
    /// Retrieves approved applications by ISO document identifier.
    /// </summary>
    /// <param name="isoDocumentId">The ISO document identifier.</param>
    /// <returns>Approved applications associated with the ISO document.</returns>
    [HttpGet("iso-document/{isoDocumentId:long}")]
    [SwaggerOperation(Summary = "Retrieves approved applications by ISO document.", Description = "Returns approved applications linked to a specified ISO document identifier.")]
    public async Task<IActionResult> GetByIsoDocument(long isoDocumentId)
    {
        var apps = await service.GetByIsoDocumentIdAsync(isoDocumentId);
        return Ok(apps);
    }

    /// <summary>
    /// Retrieves an approved application by its identifier.
    /// </summary>
    /// <param name="id">The approved application identifier.</param>
    /// <returns>The approved application if found.</returns>
    [HttpGet("{id:long}")]
    [SwaggerOperation(Summary = "Retrieves an approved application by ID.", Description = "Gets a single approved application matching the provided identifier.")]
    public async Task<IActionResult> Get(long id)
    {
        var app = await service.GetByIdAsync(id);
        if (app == null)
        {
            return NotFound();
        }
        return Ok(app);
    }

    /// <summary>
    /// Creates a new approved application.
    /// </summary>
    /// <param name="request">The approved application details.</param>
    /// <returns>The created approved application.</returns>
    [HttpPost]
    [SwaggerOperation(Summary = "Creates a new approved application.", Description = "Adds a new approved application using the provided request data.")]
    public async Task<IActionResult> Create(ApprovedApplicationRequest request)
    {
        var app = await service.CreateAsync(request);
        return CreatedAtAction(nameof(Get), new { id = app.Id }, app);
    }

    /// <summary>
    /// Updates an existing approved application.
    /// </summary>
    /// <param name="id">The identifier of the approved application.</param>
    /// <param name="request">The updated application details.</param>
    /// <returns>No content if update succeeds.</returns>
    [HttpPut("{id:long}")]
    [SwaggerOperation(Summary = "Updates an existing approved application.", Description = "Replaces an approved application's information with new values.")]
    public async Task<IActionResult> Update(long id, ApprovedApplicationRequest request)
    {
        var success = await service.UpdateAsync(id, request);
        if (!success)
        {
            return NotFound();
        }
        return NoContent();
    }

    /// <summary>
    /// Deletes an approved application.
    /// </summary>
    /// <param name="id">The approved application identifier.</param>
    /// <returns>No content if deletion succeeds.</returns>
    [HttpDelete("{id:long}")]
    [SwaggerOperation(Summary = "Deletes an approved application.", Description = "Removes an approved application from the system.")]
    public async Task<IActionResult> Delete(long id)
    {
        var success = await service.DeleteAsync(id);
        if (!success)
        {
            return NotFound();
        }
        return NoContent();
    }
}

