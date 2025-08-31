using TruyenVerse.Application.Interfaces.Repositories;
using TruyenVerse.Application.Interfaces.Services;
using TruyenVerse.Domain.Entities;

namespace TruyenVerse.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public Task<User?> GetUserAsync(Guid id) => _repository.GetByIdAsync(id);

        public Task<IEnumerable<User>> GetUsersAsync() => _repository.GetAllAsync();

        public Task CreateUserAsync(User user) => _repository.AddAsync(user);
    }
}
