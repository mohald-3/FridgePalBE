using Infrastructure.Database.MySQLDatabase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Database
{
    public class RealDatabaseFactory : IDesignTimeDbContextFactory<RealDatabase>
    {
        public RealDatabase CreateDbContext(string[] args)
        {
            // Load .env from API folder if needed
            var envPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "API", ".env");
            DotNetEnv.Env.Load(envPath);

            // Now build configuration from environment variables
            var configuration = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection")
                                   ?? configuration["ConnectionStrings__DefaultConnection"]; // fallback

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new InvalidOperationException("Connection string not found in environment variables.");

            var optionsBuilder = new DbContextOptionsBuilder<RealDatabase>();
            optionsBuilder.UseNpgsql(connectionString);

            return new RealDatabase(optionsBuilder.Options);
        }
    }
}
