namespace Hackathon.Repositories;

using Hackathon.Models;
using Hackathon.Models.Dtos;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string email);
    Task AddAsync(User user);
    void Update(User user);
    Task<IEnumerable<UserScanSummaryResponse>> GetUsersWithLastScanAsync();
}

