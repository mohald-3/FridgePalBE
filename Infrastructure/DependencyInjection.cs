using Application.Interfaces.Repositories.Authentication;
using Application.Interfaces.Repositories.Items;
using Application.Interfaces.Repositories.Users;
using Application.Interfaces.Services.Images;
using Application.Interfaces.Services.OpenAI;
using Infrastructure.Configuration;
using Infrastructure.Database;
using Infrastructure.Database.DatabaseHelpers;
using Infrastructure.Database.MySQLDatabase;
using Infrastructure.Repositories.Authorization;
using Infrastructure.Repositories.Items;
using Infrastructure.Repositories.Users;
using Infrastructure.Services.OpenAI;
using Infrastructure.Services.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString, IConfiguration configuration)
        {
            // user services
            services.AddSingleton<MockDatabase>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();

            services.AddDbContext<RealDatabase>(options =>
            {
                options.UseNpgsql(connectionString).AddInterceptors(new CommandLoggingInterceptor());
            });

            // Register OpenAI service
            services.AddScoped<IOpenAIService, OpenAIService>();

            // Register HttpClient
            services.AddHttpClient();

            // Make sure IConfiguration is registered (usually done in Program.cs, but for safety):
            services.AddSingleton(configuration);

            // Bind Cloudinary settings from appsettings
            services.Configure<CloudinarySettings>(configuration.GetSection("Cloudinary"));

            // Register Cloudinary service
            services.AddScoped<IImageStorageService, CloudinaryImageStorageService>();

            return services;
        }
    }
}
