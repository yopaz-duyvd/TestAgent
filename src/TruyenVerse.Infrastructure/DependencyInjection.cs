using Microsoft.EntityFrameworkCore;
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
            var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            services.AddDbContext<TruyenVerseDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IUserRepository, EfUserRepository>();
            services.AddScoped<IStoryRepository, EfStoryRepository>();

            var secret = configuration["Jwt:Key"] ?? throw new InvalidOperationException("JWT key not configured");
            services.AddSingleton<IJwtTokenService>(new JwtTokenService(secret));
            return services;
        }
    }
}
