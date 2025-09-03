using TruyenVerse.Domain.Entities;

namespace TruyenVerse.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(Guid id);
        Task<User?> GetByEmailAsync(string email);
        Task<IEnumerable<User>> GetAllAsync();
        Task AddAsync(User user, bool autoSave = true);
        Task UpdateAsync(User user, bool autoSave = true);
    }
}
