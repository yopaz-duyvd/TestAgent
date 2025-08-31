using System.Collections.Generic;

namespace TruyenVerse.Domain.Entities
{
    public class Story : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<Chapter> Chapters { get; set; } = new();
    }
}
