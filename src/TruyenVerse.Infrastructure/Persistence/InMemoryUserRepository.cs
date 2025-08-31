using System.Collections.Concurrent;
using TruyenVerse.Application.Interfaces.Repositories;
using TruyenVerse.Domain.Entities;

namespace TruyenVerse.Infrastructure.Persistence
{
    public class InMemoryUserRepository : IUserRepository
    {
        private readonly ConcurrentDictionary<Guid, User> _storage = new();

        public Task AddAsync(User user)
        {
            _storage[user.Id] = user;
            return Task.CompletedTask;
        }

        public Task<IEnumerable<User>> GetAllAsync() =>
            Task.FromResult<IEnumerable<User>>(_storage.Values);

        public Task<User?> GetByIdAsync(Guid id) =>
            Task.FromResult(_storage.TryGetValue(id, out var user) ? user : null);
    }
}
