using Infrastructure.Database;
using Infrastructure.Database.DatabaseHelpers;
using Infrastructure.Database.MySQLDatabase;
using Infrastructure.Repositories.Authorization;
using Infrastructure.Repositories.Dogs;
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
            services.AddScoped<AuthRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IDogRepository, DogRepository>();


            services.AddDbContext<RealDatabase>(options =>
            {
                options.UseSqlServer(connectionString).AddInterceptors(new CommandLoggingInterceptor());
            });

            return services;
        }
    }
}
