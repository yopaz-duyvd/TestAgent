using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.Models;

[Table("device_scans")]
public class DeviceScan
{
    [Column("id")]
    public long Id { get; set; }
    [Column("user_id")]
    public long UserId { get; set; }
    [Column("scanned_at")]
    public DateTime ScannedAt { get; set; } = DateTime.UtcNow;
    [Column("device_info")]
    public string? DeviceInfo { get; set; }

    public User? User { get; set; }
    public ICollection<ScannedApplication> ScannedApplications { get; set; } = new List<ScannedApplication>();
    public ICollection<Violation> Violations { get; set; } = new List<Violation>();
}
