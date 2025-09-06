namespace Hackathon.Services;

public interface IAuthService
{
    Task<string> LoginWithGoogleAsync(string email, string clientId);
}

