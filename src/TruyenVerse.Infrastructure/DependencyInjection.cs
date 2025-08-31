using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TruyenVerse.Application.Interfaces.Repositories;
using TruyenVerse.Application.Interfaces.Services;
using TruyenVerse.Infrastructure.Persistence;
using TruyenVerse.Infrastructure.Services;

namespace TruyenVerse.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IUserRepository, InMemoryUserRepository>();
            services.AddSingleton<IStoryRepository, InMemoryStoryRepository>();
            var secret = configuration["Jwt:Key"] ?? "supersecret";
            services.AddSingleton<IJwtTokenService>(new JwtTokenService(secret));
            return services;
        }
    }
}
