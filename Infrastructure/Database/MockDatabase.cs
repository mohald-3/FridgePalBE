using Domain.Models;
using Domain.Models.User;

namespace Infrastructure.Database
{
    public class MockDatabase
    {
        public List<Dog> Dogs
        {
            get { return allDogs; }
            set { allDogs = value; }
        }

        public List<UserModel> Users
        {
            get { return allUsers; }
            set { allUsers = value; }
        }

        private static List<Dog> allDogs = new()
        {
            new Dog { Id = Guid.NewGuid(), Name = "Björn"},
            new Dog { Id = Guid.NewGuid(), Name = "Patrik"},
            new Dog { Id = Guid.NewGuid(), Name = "Alfred"},
            new Dog { Id = new Guid("12345678-1234-5678-1234-567812345678"), Name = "TestDogForUnitTests"}
        };

        private static List<UserModel> allUsers = new()
        {
            new UserModel { Id = Guid.NewGuid(), UserName = "JohnCorleone", UserPassword = "killYou" },
            new UserModel { Id = Guid.NewGuid(), UserName = "JaneCorleone", UserPassword = "killYou2" },
            new UserModel { Id = new Guid("550e8400-e29b-41d4-a716-446655440000"), UserName = "TestUser", UserPassword = "TestPassword"}
        };
    }
}
