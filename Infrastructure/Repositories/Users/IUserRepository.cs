using Domain.Models.User;

namespace Infrastructure.Repositories.Users
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetAllUsers();
        Task<UserModel> RegisterUser(UserModel userToRegister);
    }
}
