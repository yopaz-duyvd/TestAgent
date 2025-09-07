namespace Hackathon.Services;

using Hackathon.Models;
using Hackathon.Models.Dtos;
using System.Collections.Generic;

public interface IDeviceScanService
{
    Task<DeviceScan> ScanAsync(DeviceScanRequest request, long userId);
    Task<IEnumerable<DeviceScanResponse>> GetHistoryAsync(long userId);
}

