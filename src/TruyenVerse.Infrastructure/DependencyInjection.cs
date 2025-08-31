using Microsoft.Extensions.DependencyInjection;
using TruyenVerse.Application.Interfaces.Repositories;
using TruyenVerse.Infrastructure.Persistence;

namespace TruyenVerse.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IUserRepository, InMemoryUserRepository>();
            return services;
        }
    }
}
