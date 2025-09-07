using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.Models;

[Table("users")]
public class User
{
    [Column("id")]
    public long Id { get; set; }
    [Column("email")]
    public required string Email { get; set; }
    [Column("password")]
    public required string Password { get; set; }
    [Column("full_name")]
    public string? FullName { get; set; }
    [Column("role")]
    public string Role { get; set; } = "user";
    [Column("sso_provider")]
    public string? SsoProvider { get; set; }
    [Column("sso_id")]
    public string? SsoId { get; set; }
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<DeviceScan> DeviceScans { get; set; } = new List<DeviceScan>();
    public ICollection<Violation> Violations { get; set; } = new List<Violation>();
    public ICollection<EmailNotification> EmailNotifications { get; set; } = new List<EmailNotification>();
}


