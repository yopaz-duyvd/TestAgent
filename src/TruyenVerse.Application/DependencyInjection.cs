using Microsoft.Extensions.DependencyInjection;
using TruyenVerse.Application.Interfaces.Services;
using TruyenVerse.Application.Services;

namespace TruyenVerse.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IStoryService, StoryService>();
            return services;
        }
    }
}
