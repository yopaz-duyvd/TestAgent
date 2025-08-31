namespace TruyenVerse.Domain.Entities
{
    public class Chapter : BaseEntity
    {
        public Guid StoryId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
    }
}
