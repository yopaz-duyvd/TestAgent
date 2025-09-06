namespace Hackathon.Repositories;

using Hackathon.Models;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string email);
    Task AddAsync(User user);
}

