using Domain.Models;
using Domain.Models.User;

namespace Infrastructure.Database
{
    public class MockDatabase
    {

        public List<UserModel> Users
        {
            get { return allUsers; }
            set { allUsers = value; }
        }

        private static List<UserModel> allUsers = new()
        {
            new UserModel { Id = Guid.NewGuid(), UserName = "JohnCorleone", UserPassword = "killYou" },
            new UserModel { Id = Guid.NewGuid(), UserName = "JaneCorleone", UserPassword = "killYou2" },
            new UserModel { Id = new Guid("550e8400-e29b-41d4-a716-446655440000"), UserName = "TestUser", UserPassword = "TestPassword"}
        };
    }
}
