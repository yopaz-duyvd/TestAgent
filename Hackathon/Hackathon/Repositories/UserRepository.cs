namespace Hackathon.Repositories;

using Hackathon.Models;
using Hackathon.UnitOfWork;
using Microsoft.EntityFrameworkCore;

public class UserRepository(AppDbContext context) : IUserRepository
{
    public async Task<User?> GetByEmailAsync(string email) =>
        await context.Users.SingleOrDefaultAsync(u => u.Email == email);

    public async Task AddAsync(User user) => await context.Users.AddAsync(user);
}

