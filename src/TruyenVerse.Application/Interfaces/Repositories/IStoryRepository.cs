using TruyenVerse.Domain.Entities;

namespace TruyenVerse.Application.Interfaces.Repositories
{
    public interface IStoryRepository
    {
        Task<Story?> GetByIdAsync(Guid id);
        Task<IEnumerable<Story>> GetAllAsync();
        Task AddAsync(Story story);
        Task UpdateAsync(Story story);
        Task DeleteAsync(Guid id);
    }
}
