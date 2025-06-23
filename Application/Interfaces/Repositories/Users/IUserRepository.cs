using Domain.Models.User;

namespace Application.Interfaces.Repositories.Users
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetAllUsers();
        Task<UserModel> RegisterUser(UserModel userToRegister);
    }
}
