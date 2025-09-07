namespace Hackathon.Models.Dtos;

using System.Collections.Generic;

public class DeviceScanRequest
{
    public required SystemInfo SystemInfo { get; set; }
    public IList<ScannedApplicationRequest> ScannedApplications { get; set; } = new List<ScannedApplicationRequest>();
}

