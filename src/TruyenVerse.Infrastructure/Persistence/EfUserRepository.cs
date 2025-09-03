using Microsoft.EntityFrameworkCore;
using TruyenVerse.Application.Interfaces.Repositories;
using TruyenVerse.Domain.Entities;

namespace TruyenVerse.Infrastructure.Persistence;

public class EfUserRepository : EfRepository<User>, IUserRepository
{
    public EfUserRepository(TruyenVerseDbContext context) : base(context)
    {
    }

    public Task<User?> GetByEmailAsync(string email) =>
        Entities.FirstOrDefaultAsync(u => u.Email == email);
}

