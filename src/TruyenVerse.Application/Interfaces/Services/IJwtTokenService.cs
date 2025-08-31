using TruyenVerse.Domain.Entities;

namespace TruyenVerse.Application.Interfaces.Services
{
    public interface IJwtTokenService
    {
        string GenerateToken(User user);
    }
}
