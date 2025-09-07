using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.Models;

[Table("violations")]
public class Violation
{
    public long Id { get; set; }
    public long ScanId { get; set; }
    public long UserId { get; set; }
    public int TotalViolations { get; set; }
    public string Status { get; set; } = "pending";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DeviceScan? Scan { get; set; }
    public User? User { get; set; }
    public ICollection<ViolationDetail> Details { get; set; } = new List<ViolationDetail>();
    public ICollection<EmailNotification> EmailNotifications { get; set; } = new List<EmailNotification>();
}
