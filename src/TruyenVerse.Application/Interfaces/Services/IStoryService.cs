using TruyenVerse.Domain.Entities;

namespace TruyenVerse.Application.Interfaces.Services
{
    public interface IStoryService
    {
        Task<Story> CreateStoryAsync(Guid userId, string title, string description);
        Task UpdateStoryAsync(Guid storyId, string title, string description);
        Task DeleteStoryAsync(Guid storyId);
        Task<Chapter> AddChapterAsync(Guid storyId, string title, string content);
        Task UpdateChapterAsync(Guid storyId, Guid chapterId, string title, string content);
        Task DeleteChapterAsync(Guid storyId, Guid chapterId);
    }
}
