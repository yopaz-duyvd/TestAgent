namespace Hackathon.Services;

using Hackathon.Models.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IManagerUserService
{
    Task<IEnumerable<UserScanSummaryResponse>> GetUsersWithLastScanAsync();
}
