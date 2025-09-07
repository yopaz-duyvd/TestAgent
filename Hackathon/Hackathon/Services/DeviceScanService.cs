namespace Hackathon.Services;

using Hackathon.Models;
using Hackathon.Models.Dtos;
using System.Linq;
using System.Text.Json;
using Hackathon.UnitOfWork;

public class DeviceScanService(IUnitOfWork unitOfWork) : IDeviceScanService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<DeviceScan> ScanAsync(DeviceScanRequest request, long userId)
    {
        var applications = request.ScannedApplications
            .Where(a => !string.Equals(a.Provider, "Apple Inc.", StringComparison.OrdinalIgnoreCase))
            .Select(a => new ScannedApplication
            {
                AppName = a.Name,
                Vendor = a.Provider
            }).ToList();

        var scan = new DeviceScan
        {
            UserId = userId,
            SystemInfo = JsonSerializer.Serialize(request.SystemInfo),
            ScannedApplications = applications
        };

        await _unitOfWork.DeviceScans.AddAsync(scan);
        await _unitOfWork.SaveChangesAsync();
        return scan;
    }
}

