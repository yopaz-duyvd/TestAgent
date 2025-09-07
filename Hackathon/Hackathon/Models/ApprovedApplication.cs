using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.Models;

[Table("approved_applications")]
public class ApprovedApplication
{
    public long Id { get; set; }
    public long? IsoFileId { get; set; }
    public required string AppName { get; set; }
    public string? AppVersion { get; set; }
    public string? Vendor { get; set; }
    public string? Category { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public IsoFile? IsoFile { get; set; }
}
