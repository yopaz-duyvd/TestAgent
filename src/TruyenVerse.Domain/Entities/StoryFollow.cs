using System;

namespace TruyenVerse.Domain.Entities
{
    public class StoryFollow : BaseEntity
    {
        public Guid UserId { get; set; }
        public User? User { get; set; }
        public Guid StoryId { get; set; }
        public Story? Story { get; set; }
    }
}
