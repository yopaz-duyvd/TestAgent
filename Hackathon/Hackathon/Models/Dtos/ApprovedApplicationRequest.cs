namespace Hackathon.Models.Dtos;

public class ApprovedApplicationRequest
{
    public long? IsoFileId { get; set; }
    public required string AppName { get; set; }
    public string? AppVersion { get; set; }
    public string? Vendor { get; set; }
    public string? Category { get; set; }
}

