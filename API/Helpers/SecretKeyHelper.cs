using Infrastructure.Configuration;
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

        public static CloudinarySettings GetCloudinarySettings(IConfiguration configuration)
        {
            var section = configuration.GetSection("Cloudinary");

            var cloudName = section["CloudName"];
            var apiKey = section["ApiKey"];
            var apiSecret = section["ApiSecret"];

            if (string.IsNullOrWhiteSpace(cloudName) || string.IsNullOrWhiteSpace(apiKey) || string.IsNullOrWhiteSpace(apiSecret))
            {
                throw new InvalidOperationException("Cloudinary settings are missing or invalid in configuration.");
            }

            return new CloudinarySettings
            {
                CloudName = cloudName,
                ApiKey = apiKey,
                ApiSecret = apiSecret
            };
        }

        public static string GetOpenAIApiKey(IConfiguration configuration)
        {
            var apiKey = configuration["OpenAI:ApiKey"];

            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new InvalidOperationException("OpenAI:ApiKey is missing or invalid in appsettings.json or environment.");
            }

            return apiKey;
        }
    }
}
