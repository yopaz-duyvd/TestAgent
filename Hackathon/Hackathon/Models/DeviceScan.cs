namespace Hackathon.Models;

public class DeviceScan
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public DateTime ScannedAt { get; set; } = DateTime.UtcNow;
    public string? DeviceInfo { get; set; }

    public User? User { get; set; }
    public ICollection<ScannedApplication> ScannedApplications { get; set; } = new List<ScannedApplication>();
    public ICollection<Violation> Violations { get; set; } = new List<Violation>();
}
