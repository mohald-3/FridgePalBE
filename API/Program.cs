using API.Authentication;
using API.Helpers;
using API.Swagger;
using Application;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections;
using System.Security.Cryptography.X509Certificates;

var builder = WebApplication.CreateBuilder(args);

DotNetEnv.Env.Load(); // Load .env file

// Manually sync environment variables loaded by DotNetEnv (.env file)
// into builder.Configuration, so they are accessible via IConfiguration["Key"]
foreach (DictionaryEntry entry in Environment.GetEnvironmentVariables())
{
    var key = entry.Key?.ToString();
    var value = entry.Value?.ToString();
    if (!string.IsNullOrWhiteSpace(key) && !string.IsNullOrWhiteSpace(value))
    {
        builder.Configuration[key] = value;
    }
}

builder.Configuration.AddEnvironmentVariables();

// Setting up .env variables
var secretKey = SecretKeyHelper.GetSecretKey(builder.Configuration);
var cloudinarySettings = SecretKeyHelper.GetCloudinarySettings(builder.Configuration);
var ConnectionString = SecretKeyHelper.GetSecretConnectionString(builder.Configuration);
var openAIApiKey = SecretKeyHelper.GetOpenAIApiKey(builder.Configuration);

var allowedOrigins = builder.Configuration["CORS_ALLOWED_ORIGINS"]
                     ?.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                     ?? Array.Empty<string>();

builder.Services.AddMyCustomAuthentication(secretKey);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy =>
    {
        policy.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
        policy.RequireAuthenticatedUser();
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", builder =>
    {
        builder.WithOrigins(allowedOrigins) // Replace with your FE URL
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, Configuration>();


builder.Services.AddApplication().AddInfrastructure(ConnectionString, builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseCors("AllowFrontend");

app.UseAuthorization();

app.MapControllers();


var logger = app.Services.GetRequiredService<ILoggerFactory>().CreateLogger("Startup");
logger.LogInformation("Cloudinary:CloudName = {CloudName}", cloudinarySettings.CloudName);
logger.LogInformation("JWT Secret = {Secret}", secretKey[..5] + "*****");
logger.LogInformation("DB Connection = {Connection}", ConnectionString[..20] + "...");

app.Run();
