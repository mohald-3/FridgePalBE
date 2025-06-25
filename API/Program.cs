using API.Authentication;
using API.Helpers;
using API.Swagger;
using Application;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

DotNetEnv.Env.Load(); // Load .env file

builder.Configuration.AddEnvironmentVariables();

var secretKey = SecretKeyHelper.GetSecretKey(builder.Configuration);

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
        builder.WithOrigins(
            "http://localhost:8081",
            "http://192.168.0.13:8081",
            "http://192.168.0.13:5000",
            "https://localhost:5001"
            ) // Replace with your FE URL
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, Configuration>();

var ConnectionString = SecretKeyHelper.GetSecretConnectionString(builder.Configuration);

builder.Services.AddApplication().AddInfrastructure(ConnectionString);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowFrontend");

app.UseAuthorization();

app.MapControllers();

app.Run();
