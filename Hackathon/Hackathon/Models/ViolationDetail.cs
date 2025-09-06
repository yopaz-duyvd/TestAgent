namespace Hackathon.Models;

public class ViolationDetail
{
    public long Id { get; set; }
    public long ViolationId { get; set; }
    public long ScannedAppId { get; set; }

    public Violation? Violation { get; set; }
    public ScannedApplication? ScannedApplication { get; set; }
}
