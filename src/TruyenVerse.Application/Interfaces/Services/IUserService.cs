using TruyenVerse.Domain.Entities;
using TruyenVerse.Domain.Enums;

namespace TruyenVerse.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<User?> LoginAsync(string email, string password);
        Task<User> RegisterAsync(string email, string password, string fullName);
        Task ForgotPasswordAsync(string email);
        Task ChangePasswordAsync(Guid userId, string newPassword);
        Task UpdateProfileAsync(Guid userId, string fullName, Gender gender, string address, string introduction);
    }
}
