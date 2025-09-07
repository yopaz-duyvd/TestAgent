namespace Hackathon.Services;

using Hackathon.Models.Dtos;
using Hackathon.UnitOfWork;
using System.Linq;
using System.Collections.Generic;

public class ManagerUserService(IUnitOfWork unitOfWork) : IManagerUserService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<IEnumerable<UserScanSummaryResponse>> GetUsersWithLastScanAsync()
    {
        return await _unitOfWork.Users.GetUsersWithLastScanAsync();
    }

    public async Task<UserScanHistoryResponse> GetUserScanHistoryAsync(long userId)
    {
        var scans = await _unitOfWork.DeviceScans.GetByUserIdAsync(userId);
        var ordered = scans.OrderByDescending(s => s.ScannedAt).ToList();

        var history = ordered.Select(s => new DeviceScanHistoryItemResponse
        {
            Id = s.Id,
            ScannedAt = s.ScannedAt,
            ApplicationCount = s.ScannedApplications.Count
        }).ToList();

        var latest = ordered.FirstOrDefault();

        return new UserScanHistoryResponse
        {
            History = history,
            LatestDeviceInfo = latest?.DeviceInfo,
            LatestApplications = latest?.ScannedApplications.Select(a => new ScannedApplicationResponse
            {
                Id = a.Id,
                AppName = a.AppName,
                AppVersion = a.AppVersion,
                Vendor = a.Vendor,
                IsApproved = a.IsApproved,
                CheckedAt = a.CheckedAt
            }).ToList() ?? new List<ScannedApplicationResponse>(),
            LatestStatus = latest?.Violations.FirstOrDefault()?.Status
        };
    }
}
