using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.Models;

[Table("scanned_applications")]
public class ScannedApplication
{
    [Column("id")]
    public long Id { get; set; }
    [Column("scan_id")]
    public long ScanId { get; set; }
    [Column("app_name")]
    public required string AppName { get; set; }
    [Column("app_version")]
    public string? AppVersion { get; set; }
    [Column("vendor")]
    public string? Vendor { get; set; }
    [Column("is_approved")]
    public bool? IsApproved { get; set; }
    [Column("checked_at")]
    public DateTime CheckedAt { get; set; } = DateTime.UtcNow;

    public DeviceScan? Scan { get; set; }
    public ICollection<ViolationDetail> ViolationDetails { get; set; } = new List<ViolationDetail>();
}
