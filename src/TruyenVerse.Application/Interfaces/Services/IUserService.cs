using TruyenVerse.Domain.Entities;

namespace TruyenVerse.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<User?> GetUserAsync(Guid id);
        Task<IEnumerable<User>> GetUsersAsync();
        Task CreateUserAsync(User user);
    }
}
