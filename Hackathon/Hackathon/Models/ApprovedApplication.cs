namespace Hackathon.Models;

public class ApprovedApplication
{
    public long Id { get; set; }
    public long IsoDocumentId { get; set; }
    public required string AppName { get; set; }
    public string? AppVersion { get; set; }
    public string? Vendor { get; set; }
    public string? Category { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public IsoDocument? IsoDocument { get; set; }
}
