namespace Hackathon.Repositories;

using Hackathon.Models;
using System.Collections.Generic;

public interface IDeviceScanRepository
{
    Task AddAsync(DeviceScan scan);
    Task<IEnumerable<DeviceScan>> GetByUserIdAsync(long userId);
}

