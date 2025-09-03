using Microsoft.EntityFrameworkCore;
using TruyenVerse.Application.Interfaces.Repositories;
using TruyenVerse.Domain.Entities;

namespace TruyenVerse.Infrastructure.Persistence;

public class EfStoryRepository : EfRepository<Story>, IStoryRepository
{
    public EfStoryRepository(TruyenVerseDbContext context) : base(context)
    {
    }

    public override async Task<IEnumerable<Story>> GetAllAsync() =>
        await Entities
            .Include(s => s.User)
            .Include(s => s.Chapters)
            .ToListAsync();

    public override async Task<Story?> GetByIdAsync(Guid id) =>
        await Entities
            .Include(s => s.User)
            .Include(s => s.Chapters)
            .FirstOrDefaultAsync(s => s.Id == id);
}

