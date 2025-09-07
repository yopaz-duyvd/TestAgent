namespace Hackathon.Extensions;

using Hackathon.Models;
using Hackathon.UnitOfWork;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

public static class SeedExtensions
{
    public static async Task SeedUsersAsync(this IHost app)
    {
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;
        var env = services.GetRequiredService<IWebHostEnvironment>();
        var unitOfWork = services.GetRequiredService<IUnitOfWork>();

        var filePath = Path.Combine(env.ContentRootPath, "SeedData", "users.json");
        if (!File.Exists(filePath)) return;

        var json = await File.ReadAllTextAsync(filePath);
        var seedUsers = JsonSerializer.Deserialize<List<UserSeed>>(json) ?? new();

        foreach (var seed in seedUsers.Where(u => u.IsSeed))
        {
            var user = await unitOfWork.Users.GetByEmailAsync(seed.Email);
            if (user is null)
            {
                user = new User
                {
                    Email = seed.Email,
                    Password = seed.Password,
                    Role = seed.Role
                };
                await unitOfWork.Users.AddAsync(user);
            }
            else
            {
                user.Password = seed.Password;
                user.Role = seed.Role;
                unitOfWork.Users.Update(user);
            }
        }

        await unitOfWork.SaveChangesAsync();
    }

    private class UserSeed
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; } = "123456";

        [JsonPropertyName("isSeed")]
        public bool IsSeed { get; set; }

        [JsonPropertyName("role")]
        public string Role { get; set; } = "user";
    }
}
