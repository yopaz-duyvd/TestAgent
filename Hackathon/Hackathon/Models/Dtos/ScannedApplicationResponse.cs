using System;

namespace Hackathon.Models.Dtos;

public class ScannedApplicationResponse
{
    public long Id { get; set; }
    public string AppName { get; set; } = string.Empty;
    public string? AppVersion { get; set; }
    public string? Vendor { get; set; }
    public bool? IsApproved { get; set; }
    public DateTime CheckedAt { get; set; }
}
