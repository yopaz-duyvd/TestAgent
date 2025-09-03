using Microsoft.EntityFrameworkCore;
using TruyenVerse.Application.Interfaces.Repositories;
using TruyenVerse.Domain.Entities;

namespace TruyenVerse.Infrastructure.Persistence
{
    public class EfStoryRepository : IStoryRepository
    {
        private readonly TruyenVerseDbContext _context;

        public EfStoryRepository(TruyenVerseDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Story story, bool autoSave = true)
        {
            _context.Stories.Add(story);
            if (autoSave)
            {
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(Guid id, bool autoSave = true)
        {
            var story = await _context.Stories.FindAsync(id);
            if (story != null)
            {
                _context.Stories.Remove(story);
                if (autoSave)
                {
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task<IEnumerable<Story>> GetAllAsync()
        {
            return await _context.Stories
                .Include(s => s.User)
                .Include(s => s.Chapters)
                .ToListAsync();
        }

        public async Task<Story?> GetByIdAsync(Guid id)
        {
            return await _context.Stories
                .Include(s => s.User)
                .Include(s => s.Chapters)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task UpdateAsync(Story story, bool autoSave = true)
        {
            _context.Stories.Update(story);
            if (autoSave)
            {
                await _context.SaveChangesAsync();
            }
        }
    }
}
