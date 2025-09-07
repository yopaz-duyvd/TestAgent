using Hackathon.Extensions;
using Hackathon.Models;
using Hackathon.Models.Dtos;
using Hackathon.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    private const int SevenDaysInSeconds = 60 * 60 * 24 * 7;
    private readonly IIsoDocumentService _service;
    private readonly IFileService _fileService;

    public IsoDocumentsController(IIsoDocumentService service, IFileService fileService)
    {
        _service = service;
        _fileService = fileService;
    }

    /// <summary>
    /// Retrieves all ISO documents.
    /// </summary>
    [HttpGet]
    [SwaggerOperation(Summary = "Retrieves all ISO documents.", Description = "Gets every ISO document in the system.")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<IsoDocument>))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> GetAll()
    {
        var docs = await _service.GetAllAsync();
        return Ok(docs);
    }

    /// <summary>
    /// Retrieves an ISO document by identifier.
    /// </summary>
    [HttpGet("{id:long}")]
    [SwaggerOperation(Summary = "Retrieves an ISO document by ID.", Description = "Gets a single ISO document matching the provided identifier.")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IsoDocument))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Get(long id)
    {
        var doc = await _service.GetByIdAsync(id);
        if (doc == null)
        {
            return NotFound();
        }
        return Ok(doc);
    }

    /// <summary>
    /// Retrieves ISO documents by year.
    /// </summary>
    [HttpGet("year/{year:int}")]
    [SwaggerOperation(Summary = "Retrieves ISO documents by year.", Description = "Gets all ISO documents uploaded for a specific year.")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<IsoDocument>))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> GetByYear(int year)
    {
        var documents = await _service.GetByYearAsync(year);
        return Ok(documents);
    }

    /// <summary>
    /// Retrieves files of an ISO document.
    /// </summary>
    [HttpGet("{id:long}/files")]
    [SwaggerOperation(Summary = "Retrieves files for an ISO document.", Description = "Gets all files associated with the specified ISO document.")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<IsoFile>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> GetFiles(long id)
    {
        var files = await _service.GetFilesAsync(id);
        if (files == null)
        {
            return NotFound();
        }
        return Ok(files);
    }

    /// <summary>
    /// Creates a new ISO document.
    /// </summary>
    [HttpPost]
    [SwaggerOperation(Summary = "Creates a new ISO document.", Description = "Adds a new ISO document without files.")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(IsoDocument))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Create(IsoDocumentRequest request)
    {
        var userId = User.GetUserId();
        if (userId == null)
        {
            return Unauthorized();
        }

        var document = await _service.CreateAsync(request, userId.Value);
        return CreatedAtAction(nameof(Get), new { id = document.Id }, document);
    }

    /// <summary>
    /// Updates an existing ISO document.
    /// </summary>
    [HttpPut("{id:long}")]
    [SwaggerOperation(Summary = "Updates an existing ISO document.", Description = "Replaces ISO document information with new values.")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Update(long id, IsoDocumentRequest request)
    {
        var success = await _service.UpdateAsync(id, request);
        if (!success)
        {
            return NotFound();
        }
        return NoContent();
    }

    /// <summary>
    /// Deletes an ISO document.
    /// </summary>
    [HttpDelete("{id:long}")]
    [SwaggerOperation(Summary = "Deletes an ISO document.", Description = "Removes an ISO document from the system.")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Delete(long id)
    {
        var success = await _service.DeleteAsync(id);
        if (!success)
        {
            return NotFound();
        }
        return NoContent();
    }

    /// <summary>
    /// Enables an ISO document as active.
    /// </summary>
    [HttpPost("{id:long}/enable")]
    [SwaggerOperation(Summary = "Enables an ISO document.", Description = "Marks the specified ISO document as active and disables others.")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Enable(long id)
    {
        var success = await _service.EnableAsync(id);
        if (!success)
        {
            return NotFound();
        }
        return NoContent();
    }

    /// <summary>
    /// Resets the scan time of an ISO document.
    /// </summary>
    [HttpPost("{id:long}/reset-scan")]
    [SwaggerOperation(Summary = "Resets scan time of an ISO document.", Description = "Sets the scanned timestamp of the specified ISO document to null.")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> ResetScan(long id)
    {
        var success = await _service.ResetScanAsync(id);
        if (!success)
        {
            return NotFound();
        }
        return NoContent();
    }

    /// <summary>
    /// Uploads files to an existing ISO document.
    /// </summary>
    [HttpPost("{id:long}/upload")]
    [RequestSizeLimit(1L * 1024 * 1024 * 1024)]
    [SwaggerOperation(Summary = "Uploads files to an ISO document.", Description = "Stores files for an existing ISO document and returns the document.")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IsoDocument))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Upload(long id, [FromForm] UploadIsoDocumentRequest request)
    {
        var userId = User.GetUserId();
        if (userId == null)
        {
            return Unauthorized();
        }

        try
        {
            var document = await _service.UploadAsync(id, request, userId.Value);
            return Ok(document);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

