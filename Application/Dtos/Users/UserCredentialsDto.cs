using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.Users
{
    public class UserCredentialsDto
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}
