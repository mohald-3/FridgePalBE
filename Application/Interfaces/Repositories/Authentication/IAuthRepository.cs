using Domain.Models.User;

namespace Application.Interfaces.Repositories.Authentication
{
    public interface IAuthRepository
    {
        UserModel AuthenticateUser(string username, string password);
        string GenerateJwtToken(UserModel user);
    }
}
