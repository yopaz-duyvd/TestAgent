using TruyenVerse.Domain.Enums;

namespace TruyenVerse.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public Gender Gender { get; set; } = Gender.Unknown;
        public string Address { get; set; } = string.Empty;
        public string Introduction { get; set; } = string.Empty;
        public UserRole? Role { get; set; }
        public List<Story>? Stories { get; set; }
    }
}
