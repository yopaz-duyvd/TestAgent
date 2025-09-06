namespace Hackathon.Models.Dtos;

using Microsoft.AspNetCore.Http;

public class UploadIsoDocumentRequest
{
    public int Year { get; set; }
    public string? Notes { get; set; }
    public IFormFileCollection Files { get; set; } = default!;
}

