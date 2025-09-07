namespace Hackathon.Repositories;

using Hackathon.Models;
using Hackathon.Models.Dtos;
using Hackathon.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System.Linq;

public class UserRepository(AppDbContext context) : IUserRepository
{
    public async Task<User?> GetByEmailAsync(string email)
    {
        return await context.Users
            .Where(u => u.Email == email)
            .OrderByDescending(u => u.CreatedAt)
            .FirstOrDefaultAsync();
    }

    public async Task AddAsync(User user) => await context.Users.AddAsync(user);

    public void Update(User user) => context.Users.Update(user);

    public async Task<IEnumerable<UserScanSummaryResponse>> GetUsersWithLastScanAsync()
    {
        return await context.Users
            .Select(u => new UserScanSummaryResponse
            {
                Id = u.Id,
                Email = u.Email,
                FullName = u.FullName,
                LastScannedAt = context.DeviceScans
                    .Where(ds => ds.UserId == u.Id)
                    .OrderByDescending(ds => ds.ScannedAt)
                    .Select(ds => (DateTime?)ds.ScannedAt)
                    .FirstOrDefault(),
                ApprovedApplicationCount = context.DeviceScans
                    .Where(ds => ds.UserId == u.Id)
                    .OrderByDescending(ds => ds.ScannedAt)
                    .Select(ds => ds.ScannedApplications.Count(sa => sa.IsApproved == true))
                    .FirstOrDefault()
            })
            .ToListAsync();
    }
}

