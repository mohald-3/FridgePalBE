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

app.UseAuthorization();

app.MapControllers();

app.Run();
