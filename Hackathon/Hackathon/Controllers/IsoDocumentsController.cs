using Hackathon.Extensions;
using Hackathon.Models.Dtos;
using Hackathon.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Hackathon.Controllers;

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

    [HttpGet("year/{year:int}")]
    public async Task<IActionResult> GetByYear(int year)
    {
        var documents = await _service.GetByYearAsync(year);
        return Ok(documents);
    }

    [HttpPost]
    [RequestSizeLimit(1L * 1024 * 1024 * 1024)]
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

