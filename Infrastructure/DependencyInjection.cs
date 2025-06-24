using Application.Interfaces.Repositories.Authentication;
using Application.Interfaces.Repositories.Items;
using Application.Interfaces.Repositories.Users;
using Infrastructure.Database;
using Infrastructure.Database.DatabaseHelpers;
using Infrastructure.Database.MySQLDatabase;
using Infrastructure.Repositories.Authorization;
using Infrastructure.Repositories.Items;
using Infrastructure.Repositories.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddSingleton<MockDatabase>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();

            services.AddDbContext<RealDatabase>(options =>
            {
                options.UseNpgsql(connectionString).AddInterceptors(new CommandLoggingInterceptor());
            });

            return services;
        }
    }
}
