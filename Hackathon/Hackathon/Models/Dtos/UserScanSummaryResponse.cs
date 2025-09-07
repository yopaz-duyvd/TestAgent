namespace Hackathon.Models.Dtos;

public class UserScanSummaryResponse
{
    public long Id { get; set; }
    public string Email { get; set; } = null!;
    public string? FullName { get; set; }
    public DateTime? LastScannedAt { get; set; }
    public int ApprovedApplicationCount { get; set; }
}
