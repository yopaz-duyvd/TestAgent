namespace Hackathon.Repositories;

using Hackathon.Models;

public interface IUserRepository
{
    Task<User?> GetByUsernameAsync(string username);
    Task AddAsync(User user);
}

