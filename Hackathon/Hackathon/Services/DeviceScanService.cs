namespace Hackathon.Services;

using Hackathon.Models;
using Hackathon.Models.Dtos;
using Hackathon.UnitOfWork;
using System.Linq;
using System.Text.Json;
using System.Collections.Generic;

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
            DeviceInfo = JsonSerializer.Serialize(request.SystemInfo),
            ScannedApplications = applications
        };
        // Retrieve whitelist of approved applications
        var whitelist = await _unitOfWork.ApprovedApplications.GetWhitelistAsync();
        var whitelistNames = whitelist
            .Select(a => a.AppName)
            .ToHashSet(StringComparer.OrdinalIgnoreCase);

        // Collect scanned applications that are not in the whitelist
        var violations = new List<ScannedApplication>();
        foreach (var app in applications)
        {
            if (!whitelistNames.Contains(app.AppName))
            {
                violations.Add(app);
            }
        }

        if (violations.Count > 0)
        {
            var violation = new Violation
            {
                UserId = userId,
                TotalViolations = violations.Count,
                Details = violations.Select(app => new ViolationDetail
                {
                    ScannedApplication = app
                }).ToList()
            };

            scan.Violations.Add(violation);
        }

        await _unitOfWork.DeviceScans.AddAsync(scan);
        await _unitOfWork.SaveChangesAsync();
        return scan;
    }

    public async Task<IEnumerable<DeviceScanResponse>> GetHistoryAsync(long userId)
    {
        var scans = await _unitOfWork.DeviceScans.GetByUserIdAsync(userId);

        return scans.Select(scan => new DeviceScanResponse
        {
            Id = scan.Id,
            ScannedAt = scan.ScannedAt,
            DeviceInfo = scan.DeviceInfo,
            ScannedApplications = scan.ScannedApplications.Select(app => new ScannedApplicationResponse
            {
                Id = app.Id,
                AppName = app.AppName,
                AppVersion = app.AppVersion,
                Vendor = app.Vendor,
                IsApproved = app.IsApproved,
                CheckedAt = app.CheckedAt
            }).ToList(),
            Violations = scan.Violations.Select(v => new ViolationResponse
            {
                Id = v.Id,
                TotalViolations = v.TotalViolations,
                Status = v.Status,
                CreatedAt = v.CreatedAt,
                Details = v.Details.Select(d => new ViolationDetailResponse
                {
                    Id = d.Id,
                    ScannedApplicationId = d.ScannedApplicationId
                }).ToList()
            }).ToList()
        }).ToList();
    }
}

