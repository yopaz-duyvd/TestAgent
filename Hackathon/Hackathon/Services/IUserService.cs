namespace Hackathon.Services;

using Hackathon.Models.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IUserService
{
    Task<IEnumerable<UserScanSummaryResponse>> GetUsersWithLastScanAsync();
}
