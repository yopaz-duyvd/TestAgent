using Hackathon.Models.Dtos;
using Hackathon.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "AdminOrAnalyst")]
public class ApprovedApplicationsController(IApprovedApplicationService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var apps = await service.GetAllAsync();
        return Ok(apps);
    }

    [HttpGet("iso-document/{isoDocumentId:long}")]
    public async Task<IActionResult> GetByIsoDocument(long isoDocumentId)
    {
        var apps = await service.GetByIsoDocumentIdAsync(isoDocumentId);
        return Ok(apps);
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> Get(long id)
    {
        var app = await service.GetByIdAsync(id);
        if (app == null)
        {
            return NotFound();
        }
        return Ok(app);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ApprovedApplicationRequest request)
    {
        var app = await service.CreateAsync(request);
        return CreatedAtAction(nameof(Get), new { id = app.Id }, app);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update(long id, ApprovedApplicationRequest request)
    {
        var success = await service.UpdateAsync(id, request);
        if (!success)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id:long}")]
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

