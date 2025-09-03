using TruyenVerse.Domain.Entities;

namespace TruyenVerse.Application.Interfaces.Repositories
{
    public interface IStoryRepository
    {
        Task<Story?> GetByIdAsync(Guid id);
        Task<IEnumerable<Story>> GetAllAsync();
        Task AddAsync(Story story, bool autoSave = true);
        Task UpdateAsync(Story story, bool autoSave = true);
        Task DeleteAsync(Guid id, bool autoSave = true);
    }
}
