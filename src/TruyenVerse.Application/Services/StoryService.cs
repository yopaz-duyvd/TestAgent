using TruyenVerse.Application.Interfaces.Repositories;
using TruyenVerse.Application.Interfaces.Services;
using TruyenVerse.Domain.Entities;

namespace TruyenVerse.Application.Services;

public class StoryService(IStoryRepository repository) : IStoryService
{
    private readonly IStoryRepository _repository = repository;

    public async Task<Story> CreateStoryAsync(Guid userId, string title, string description)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Title is required", nameof(title));
        }

        var story = new Story
        {
            UserId = userId,
            Title = title,
            Description = description
        };

        await _repository.AddAsync(story);
        return story;
    }

    public async Task UpdateStoryAsync(Guid storyId, string title, string description)
    {
        var story = await _repository.GetByIdAsync(storyId);
        if (story is null)
        {
            return;
        }

        story.Title = title;
        story.Description = description;
        await _repository.UpdateAsync(story);
    }

    public Task DeleteStoryAsync(Guid storyId) => _repository.DeleteAsync(storyId);

    public async Task<Chapter> AddChapterAsync(Guid storyId, string title, string content)
    {
        var story = await GetStoryAsync(storyId) ?? throw new InvalidOperationException("Story not found");

        var chapter = new Chapter
        {
            StoryId = storyId,
            Title = title,
            Content = content
        };

        story.Chapters.Add(chapter);
        await _repository.UpdateAsync(story);
        return chapter;
    }

    public async Task UpdateChapterAsync(Guid storyId, Guid chapterId, string title, string content)
    {
        var (story, chapter) = await GetStoryWithChapterAsync(storyId, chapterId);
        if (story is null || chapter is null)
        {
            return;
        }

        chapter.Title = title;
        chapter.Content = content;
        await _repository.UpdateAsync(story);
    }

    public async Task DeleteChapterAsync(Guid storyId, Guid chapterId)
    {
        var (story, chapter) = await GetStoryWithChapterAsync(storyId, chapterId);
        if (story is null || chapter is null)
        {
            return;
        }

        story.Chapters.Remove(chapter);
        await _repository.UpdateAsync(story);
    }

    private Task<Story?> GetStoryAsync(Guid storyId) => _repository.GetByIdAsync(storyId);

    private async Task<(Story? story, Chapter? chapter)> GetStoryWithChapterAsync(Guid storyId, Guid chapterId)
    {
        var story = await GetStoryAsync(storyId);
        return (story, story?.Chapters.FirstOrDefault(c => c.Id == chapterId));
    }
}
