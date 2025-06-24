using System.Text;

namespace API.Helpers
{
    public class SecretKeyHelper
    {
        public static byte[] GetSecretKey(IConfiguration configuration)
        {
            var secretKey = configuration["JwtSettings:SecretKey"];

            if (string.IsNullOrEmpty(secretKey))
            {
                throw new InvalidOperationException("JwtSettings:SecretKey is missing or invalid in appsettings.json.");
            }

            return Encoding.ASCII.GetBytes(secretKey);
        }

        public static string GetSecretConnectionString(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("ConnectionString:SecretConnectionString is missing or invalid in appsettings.json.");
            }

            return connectionString;
        }
    }
}
