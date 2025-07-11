﻿using Application.Interfaces.Repositories.Authentication;
using Domain.Models.User;
using Infrastructure.Database;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Repositories.Authorization
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IConfiguration _configuration;
        private readonly MockDatabase _mockDatabase;

        public AuthRepository(IConfiguration configuration, MockDatabase mockDatabase)
        {
            _configuration = configuration;
            _mockDatabase = mockDatabase;
        }

        public UserModel AuthenticateUser(string username, string password)
        {
            var user = _mockDatabase.Users.FirstOrDefault(u => u.UserName == username && u.UserPassword == password);

            if (user == null)
            {
                throw new Exception("User not found");
            }
            return user;
        }

        public string GenerateJwtToken(UserModel user)
        {
            var key = Encoding.ASCII.GetBytes(s: _configuration["JwtSettings:SecretKey"]!); //Implement null handling

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, "Admin")
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
