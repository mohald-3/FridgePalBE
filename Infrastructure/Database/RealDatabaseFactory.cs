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
            // Load configuration from appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<RealDatabase>();

            optionsBuilder.UseNpgsql("Host=aws-0-eu-north-1.pooler.supabase.com;Port=5432;Database=postgres;Username=postgres.ympfphskbjblatliknnf;Password=uBPoZ51UQEvvBBsg;SslMode=Require;Trust Server Certificate=true");

            return new RealDatabase(optionsBuilder.Options);
        }
    }
}
