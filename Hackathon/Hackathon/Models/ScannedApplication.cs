using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.Models;

[Table("scanned_applications")]
public class ScannedApplication
{
    public long Id { get; set; }
    public long ScanId { get; set; }
    public required string AppName { get; set; }
    public string? AppVersion { get; set; }
    public string? Vendor { get; set; }
    public bool? IsApproved { get; set; }
    public DateTime CheckedAt { get; set; } = DateTime.UtcNow;

    public DeviceScan? Scan { get; set; }
    public ICollection<ViolationDetail> ViolationDetails { get; set; } = new List<ViolationDetail>();
}
