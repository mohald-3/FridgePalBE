using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace Infrastructure.Database.DatabaseHelpers
{
    public class DatabaseConfiguration : IDatabaseConfiguration
    {
        public void Configure(DbContextOptionsBuilder optionsBuilder, string connectionString)
        {
            optionsBuilder.UseNpgsql(connectionString)
                          .AddInterceptors(new CommandLoggingInterceptor());
            // Additional configuration logic here
        }
    }
}
