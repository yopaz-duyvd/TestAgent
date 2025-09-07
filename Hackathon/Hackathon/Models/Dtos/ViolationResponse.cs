using System;
using System.Collections.Generic;

namespace Hackathon.Models.Dtos;

public class ViolationResponse
{
    public long Id { get; set; }
    public int TotalViolations { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public List<ViolationDetailResponse> Details { get; set; } = new();
}
