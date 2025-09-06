using Hackathon.Extensions;
using Hackathon.Models.Dtos;
using Hackathon.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using Swashbuckle.AspNetCore.Annotations;

namespace Hackathon.Controllers;

/// <summary>
/// Manages operations for ISO documents.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "AdminOrAnalyst")]
public class IsoDocumentsController : ControllerBase
{
    private readonly IIsoDocumentService _service;

    public IsoDocumentsController(IIsoDocumentService service)
    {
        _service = service;
    }

    /// <summary>
    /// Retrieves ISO documents by year.
    /// </summary>
    /// <param name="year">The year of the ISO documents.</param>
    /// <returns>ISO documents for the specified year.</returns>
    [HttpGet("year/{year:int}")]
    [SwaggerOperation(Summary = "Retrieves ISO documents by year.", Description = "Gets all ISO documents uploaded for a specific year.")]
    public async Task<IActionResult> GetByYear(int year)
    {
        var documents = await _service.GetByYearAsync(year);
        return Ok(documents);
    }

    /// <summary>
    /// Uploads a new ISO document.
    /// </summary>
    /// <param name="request">The ISO document upload request.</param>
    /// <returns>The identifier and version of the uploaded document.</returns>
    [HttpPost]
    [RequestSizeLimit(1L * 1024 * 1024 * 1024)]
    [SwaggerOperation(Summary = "Uploads a new ISO document.", Description = "Stores a new ISO document and returns its identifier and version.")]
    public async Task<IActionResult> Upload([FromForm] UploadIsoDocumentRequest request)
    {
        var userId = User.GetUserId();
        if (userId == null)
        {
            return Unauthorized();
        }

        try
        {
            var document = await _service.UploadAsync(request, userId.Value);
            return Ok(new { document.Id, document.Version });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

