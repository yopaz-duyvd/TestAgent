using TruyenVerse.Application.Interfaces.Repositories;
using TruyenVerse.Application.Interfaces.Services;
using TruyenVerse.Domain.Entities;
using TruyenVerse.Domain.Enums;

namespace TruyenVerse.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<User?> LoginAsync(string email, string password)
        {
            var user = await _repository.GetByEmailAsync(email);
            return user is not null && user.Password == password ? user : null;
        }

        public async Task<User> RegisterAsync(string email, string password, string fullName)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email is required", nameof(email));
            }

            if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
            {
                throw new ArgumentException("Password must be at least 6 characters", nameof(password));
            }

            if (string.IsNullOrWhiteSpace(fullName))
            {
                throw new ArgumentException("Name is required", nameof(fullName));
            }

            var existing = await _repository.GetByEmailAsync(email);
            if (existing is not null)
            {
                throw new InvalidOperationException("Email already registered");
            }

            var user = new User
            {
                Email = email,
                Password = password,
                FullName = fullName
            };

            await _repository.AddAsync(user);
            return user;
        }

        public async Task ForgotPasswordAsync(string email)
        {
            var user = await _repository.GetByEmailAsync(email);
            if (user is null)
            {
                return;
            }

            user.Password = "123456";
            await _repository.UpdateAsync(user);
        }

        public async Task ChangePasswordAsync(Guid userId, string newPassword)
        {
            if (string.IsNullOrWhiteSpace(newPassword) || newPassword.Length < 6)
            {
                throw new ArgumentException("Password must be at least 6 characters", nameof(newPassword));
            }

            var user = await _repository.GetByIdAsync(userId);
            if (user is null)
            {
                return;
            }

            user.Password = newPassword;
            await _repository.UpdateAsync(user);
        }

        public async Task UpdateProfileAsync(Guid userId, string fullName, Gender gender, string address, string introduction)
        {
            var user = await _repository.GetByIdAsync(userId);
            if (user is null)
            {
                return;
            }

            user.FullName = fullName;
            user.Gender = gender;
            user.Address = address;
            user.Introduction = introduction;
            await _repository.UpdateAsync(user);
        }
    }
}
