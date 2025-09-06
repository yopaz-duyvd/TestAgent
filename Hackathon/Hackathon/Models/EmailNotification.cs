namespace Hackathon.Models;

public class EmailNotification
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long? ViolationId { get; set; }
    public string? EmailSubject { get; set; }
    public string? EmailBody { get; set; }
    public DateTime SentAt { get; set; } = DateTime.UtcNow;

    public User? User { get; set; }
    public Violation? Violation { get; set; }
}
