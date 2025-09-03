using Microsoft.EntityFrameworkCore;
using TruyenVerse.Domain.Entities;

namespace TruyenVerse.Infrastructure.Persistence
{
    public class TruyenVerseDbContext : DbContext
    {
        public TruyenVerseDbContext(DbContextOptions<TruyenVerseDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Story> Stories => Set<Story>();
        public DbSet<Chapter> Chapters => Set<Chapter>();
        public DbSet<StoryFollow> StoryFollows => Set<StoryFollow>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
