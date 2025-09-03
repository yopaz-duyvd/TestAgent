using System.Collections.Concurrent;
using TruyenVerse.Application.Interfaces.Repositories;
using TruyenVerse.Domain.Entities;

namespace TruyenVerse.Infrastructure.Persistence
{
    public class InMemoryStoryRepository : IStoryRepository
    {
        private readonly ConcurrentDictionary<Guid, Story> _storage = new();


        public Task<IEnumerable<Story>> GetAllAsync() =>
            Task.FromResult<IEnumerable<Story>>(_storage.Values);

        public Task<Story?> GetByIdAsync(Guid id) =>
            Task.FromResult(_storage.TryGetValue(id, out var story) ? story : null);

        public Task AddAsync(Story story, bool autoSave = true)
        {
            _storage[story.Id] = story;
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Guid id, bool autoSave = true)
        {
            _storage.TryRemove(id, out _);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Story story, bool autoSave = true)
        {
            _storage[story.Id] = story;
            return Task.CompletedTask;
        }
    }
}
