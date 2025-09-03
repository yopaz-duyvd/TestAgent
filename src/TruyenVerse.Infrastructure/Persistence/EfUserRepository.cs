using Microsoft.EntityFrameworkCore;
using TruyenVerse.Application.Interfaces.Repositories;
using TruyenVerse.Domain.Entities;

namespace TruyenVerse.Infrastructure.Persistence
{
    public class EfUserRepository : IUserRepository
    {
        private readonly TruyenVerseDbContext _context;

        public EfUserRepository(TruyenVerseDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user, bool autoSave = true)
        {
            _context.Users.Add(user);
            if (autoSave)
            {
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task UpdateAsync(User user, bool autoSave = true)
        {
            _context.Users.Update(user);
            if (autoSave)
            {
                await _context.SaveChangesAsync();
            }
        }
    }
}
