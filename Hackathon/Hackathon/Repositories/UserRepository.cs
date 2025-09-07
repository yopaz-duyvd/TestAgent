namespace Hackathon.Repositories;

using Hackathon.Models;
using Hackathon.UnitOfWork;
using Microsoft.EntityFrameworkCore;

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
}

