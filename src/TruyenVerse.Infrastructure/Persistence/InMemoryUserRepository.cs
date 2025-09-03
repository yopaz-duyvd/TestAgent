using System.Collections.Concurrent;
using TruyenVerse.Application.Interfaces.Repositories;
using TruyenVerse.Domain.Entities;
using TruyenVerse.Domain.Enums;

namespace TruyenVerse.Infrastructure.Persistence
{
    public class InMemoryUserRepository : IUserRepository
    {
        private readonly ConcurrentDictionary<Guid, User> _storage = new();

        public InMemoryUserRepository()
        {
            var admin = new User
            {
                Email = "admin@gmail.com",
                Password = "123456",
                FullName = "Default Admin",
                Role = UserRole.SuperAdmin
            };

            _storage[admin.Id] = admin;
        }

        public Task AddAsync(User user, bool autoSave = true)
        {
            _storage[user.Id] = user;
            return Task.CompletedTask;
        }

        public Task<IEnumerable<User>> GetAllAsync() =>
            Task.FromResult<IEnumerable<User>>(_storage.Values);

        public Task<User?> GetByIdAsync(Guid id) =>
            Task.FromResult(_storage.TryGetValue(id, out var user) ? user : null);

        public Task<User?> GetByEmailAsync(string email) =>
            Task.FromResult(_storage.Values.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase)));

        public Task UpdateAsync(User user, bool autoSave = true)
        {
            _storage[user.Id] = user;
            return Task.CompletedTask;
        }
    }
}
