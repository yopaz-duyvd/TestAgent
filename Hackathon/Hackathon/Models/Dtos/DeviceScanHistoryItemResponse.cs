using System;

namespace Hackathon.Models.Dtos;

public class DeviceScanHistoryItemResponse
{
    public long Id { get; set; }
    public DateTime ScannedAt { get; set; }
    public int ApplicationCount { get; set; }
    public int ApprovedApplicationCount { get; set; }
}
