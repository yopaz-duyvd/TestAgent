using System.Collections.Generic;

namespace Hackathon.Models.Dtos;

public class UserScanHistoryResponse
{
    public List<DeviceScanHistoryItemResponse> History { get; set; } = new();
    public string? LatestDeviceInfo { get; set; }
    public List<ScannedApplicationResponse> LatestApplications { get; set; } = new();
    public string? LatestStatus { get; set; }
}
