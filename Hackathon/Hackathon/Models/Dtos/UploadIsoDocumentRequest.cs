namespace Hackathon.Models.Dtos;

using Microsoft.AspNetCore.Http;

public class UploadIsoDocumentRequest
{
    public IFormFileCollection Files { get; set; } = default!;
}

