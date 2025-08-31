using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TruyenVerse.Application.Interfaces.Services;
using TruyenVerse.Domain.Entities;

namespace TruyenVerse.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class StoriesController : ControllerBase
    {
        private readonly IStoryService _storyService;

        public StoriesController(IStoryService storyService)
        {
            _storyService = storyService;
        }

        [HttpPost]
        public async Task<ActionResult<Story>> CreateStory(CreateStoryRequest request)
        {
            var story = await _storyService.CreateStoryAsync(request.UserId, request.Title, request.Description);
            return Ok(story);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStory(Guid id, UpdateStoryRequest request)
        {
            await _storyService.UpdateStoryAsync(id, request.Title, request.Description);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStory(Guid id)
        {
            await _storyService.DeleteStoryAsync(id);
            return NoContent();
        }

        [HttpPost("{storyId}/chapters")]
        public async Task<ActionResult<Chapter>> AddChapter(Guid storyId, AddChapterRequest request)
        {
            var chapter = await _storyService.AddChapterAsync(storyId, request.Title, request.Content);
            return Ok(chapter);
        }

        [HttpPut("{storyId}/chapters/{chapterId}")]
        public async Task<IActionResult> UpdateChapter(Guid storyId, Guid chapterId, UpdateChapterRequest request)
        {
            await _storyService.UpdateChapterAsync(storyId, chapterId, request.Title, request.Content);
            return NoContent();
        }

        [HttpDelete("{storyId}/chapters/{chapterId}")]
        public async Task<IActionResult> DeleteChapter(Guid storyId, Guid chapterId)
        {
            await _storyService.DeleteChapterAsync(storyId, chapterId);
            return NoContent();
        }
    }

    public record CreateStoryRequest(Guid UserId, string Title, string Description);
    public record UpdateStoryRequest(string Title, string Description);
    public record AddChapterRequest(string Title, string Content);
    public record UpdateChapterRequest(string Title, string Content);
}
