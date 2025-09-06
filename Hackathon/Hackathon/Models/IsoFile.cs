namespace Hackathon.Models;

public class IsoFile
{
    public long Id { get; set; }
    public long IsoDocumentId { get; set; }
    public required string FilePath { get; set; }
    public string? FileType { get; set; }
    public DateTime UploadedAt { get; set; } = DateTime.UtcNow;

    public IsoDocument? IsoDocument { get; set; }
}
