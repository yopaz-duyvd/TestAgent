namespace Hackathon.Services;

using Hackathon.Models;
using Hackathon.Models.Dtos;

public interface IDeviceScanService
{
    Task<DeviceScan> ScanAsync(DeviceScanRequest request, long userId);
}

