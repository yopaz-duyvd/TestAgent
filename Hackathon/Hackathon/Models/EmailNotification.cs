using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.Models;

[Table("email_notifications")]
public class EmailNotification
{
    [Column("id")]
    public long Id { get; set; }
    [Column("user_id")]
    public long UserId { get; set; }
    [Column("violation_id")]
    public long? ViolationId { get; set; }
    [Column("email_subject")]
    public string? EmailSubject { get; set; }
    [Column("email_body")]
    public string? EmailBody { get; set; }
    [Column("sent_at")]
    public DateTime SentAt { get; set; } = DateTime.UtcNow;

    public User? User { get; set; }
    public Violation? Violation { get; set; }
}
