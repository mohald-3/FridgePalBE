using Application.Interfaces.Repositories.Users;
using Domain.Models.User;
using Infrastructure.Database.MySQLDatabase;

namespace Infrastructure.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly RealDatabase _realDatabase;

        public UserRepository(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;
        }

        public async Task<UserModel> RegisterUser(UserModel userToRegister)
        {
            try
            {
                _realDatabase.Users.Add(userToRegister);
                _realDatabase.SaveChanges();
                return await Task.FromResult(userToRegister);
            }
            catch (ArgumentException e)
            {
                //// Log the error and return an error response
                //_logger.LogError(e, "Error registering user");
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            try
            {
                List<UserModel> allUsersFromDatabase = _realDatabase.Users.ToList();
                return await Task.FromResult(allUsersFromDatabase);
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException(e.Message);
            }
        }
    }
}
