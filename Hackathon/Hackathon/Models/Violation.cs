using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.Models;

[Table("violations")]
public class Violation
{
    [Column("id")]
    public long Id { get; set; }
    [Column("scan_id")]
    public long ScanId { get; set; }
    [Column("user_id")]
    public long UserId { get; set; }
    [Column("total_violations")]
    public int TotalViolations { get; set; }
    [Column("status")]
    public string Status { get; set; } = "pending";
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DeviceScan? Scan { get; set; }
    public User? User { get; set; }
    public ICollection<ViolationDetail> Details { get; set; } = new List<ViolationDetail>();
    public ICollection<EmailNotification> EmailNotifications { get; set; } = new List<EmailNotification>();
}
