namespace Hackathon.Services;

public interface IAuthService
{
    Task RegisterAsync(string username, string password);
    Task<string?> LoginAsync(string username, string password);
}

