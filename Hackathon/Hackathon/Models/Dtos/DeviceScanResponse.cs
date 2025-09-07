using System;
using System.Collections.Generic;

namespace Hackathon.Models.Dtos;

public class DeviceScanResponse
{
    public long Id { get; set; }
    public DateTime ScannedAt { get; set; }
    public string? DeviceInfo { get; set; }
    public List<ScannedApplicationResponse> ScannedApplications { get; set; } = new();
    public List<ViolationResponse> Violations { get; set; } = new();
}
