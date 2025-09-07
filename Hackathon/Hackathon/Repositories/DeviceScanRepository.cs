namespace Hackathon.Repositories;

using Hackathon.Models;
using Hackathon.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

public class DeviceScanRepository(AppDbContext context) : IDeviceScanRepository
{
    public async Task AddAsync(DeviceScan scan) =>
        await context.DeviceScans.AddAsync(scan);

    public async Task<IEnumerable<DeviceScan>> GetByUserIdAsync(long userId) =>
        await context.DeviceScans
            .Where(d => d.UserId == userId)
            .Include(d => d.ScannedApplications)
            .Include(d => d.Violations)
                .ThenInclude(v => v.Details)
            .ToListAsync();
}

