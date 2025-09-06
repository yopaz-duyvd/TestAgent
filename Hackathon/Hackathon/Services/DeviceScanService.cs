namespace Hackathon.Services;

using Hackathon.Models;
using Hackathon.Models.Dtos;
using System.Linq;
using Hackathon.UnitOfWork;

public class DeviceScanService(IUnitOfWork unitOfWork) : IDeviceScanService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<DeviceScan> ScanAsync(DeviceScanRequest request, long userId)
    {
        var scan = new DeviceScan
        {
            UserId = userId,
            DeviceInfo = request.DeviceInfo,
            ScannedApplications = request.ScannedApplications
                .Select(a => new ScannedApplication
                {
                    AppName = a.AppName,
                    AppVersion = a.AppVersion,
                    Vendor = a.Vendor
                }).ToList()
        };

        await _unitOfWork.DeviceScans.AddAsync(scan);
        await _unitOfWork.SaveChangesAsync();
        return scan;
    }
}

