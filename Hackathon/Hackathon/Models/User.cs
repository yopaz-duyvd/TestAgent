namespace Hackathon.Models;

public class User
{
    public long Id { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public string? FullName { get; set; }
    public string Role { get; set; } = "user";
    public string? SsoProvider { get; set; }
    public string? SsoId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<DeviceScan> DeviceScans { get; set; } = new List<DeviceScan>();
    public ICollection<Violation> Violations { get; set; } = new List<Violation>();
    public ICollection<EmailNotification> EmailNotifications { get; set; } = new List<EmailNotification>();
}


