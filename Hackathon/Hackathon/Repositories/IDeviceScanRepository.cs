namespace Hackathon.Repositories;

using Hackathon.Models;

public interface IDeviceScanRepository
{
    Task AddAsync(DeviceScan scan);
}

