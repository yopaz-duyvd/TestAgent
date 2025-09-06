namespace Hackathon.Models.Dtos;

public class ScannedApplicationRequest
{
    public required string AppName { get; set; }
    public string? AppVersion { get; set; }
    public string? Vendor { get; set; }
}

