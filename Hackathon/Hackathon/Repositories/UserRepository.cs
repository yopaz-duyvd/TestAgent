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
                    .FirstOrDefault(),
                TotalApplicationCount = context.DeviceScans
                    .Where(ds => ds.UserId == u.Id)
                    .OrderByDescending(ds => ds.ScannedAt)
                    .Select(ds => ds.ScannedApplications.Count())
                    .FirstOrDefault()
            })
            .ToListAsync();
    }

    public async Task<int> CountAsync() => await context.Users.CountAsync();

    public async Task<int> CountUsersWithLatestScanViolationAsync()
    {
        return await context.Users
            .Where(u => context.DeviceScans
                .Where(ds => ds.UserId == u.Id)
                .OrderByDescending(ds => ds.ScannedAt)
                .Take(1)
                .Any(ds => ds.Violations.Any()))
            .CountAsync();
    }
}

