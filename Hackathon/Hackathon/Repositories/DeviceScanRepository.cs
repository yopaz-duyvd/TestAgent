namespace Hackathon.Repositories;

using Hackathon.Models;
using Hackathon.UnitOfWork;

public class DeviceScanRepository(AppDbContext context) : IDeviceScanRepository
{
    public async Task AddAsync(DeviceScan scan) =>
        await context.DeviceScans.AddAsync(scan);
}

