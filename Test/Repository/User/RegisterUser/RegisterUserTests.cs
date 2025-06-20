using Domain.Models.User;
using Infrastructure.Database.MySQLDatabase;
using Infrastructure.Repositories.Users;
using Moq;

namespace Test.Repository.User.RegisterUser
{
    [TestFixture]
    public class RegisterUserTests
    {
        private UserRepository _userRepository;
        private Mock<RealDatabase> _mockRealDatabase = new Mock<RealDatabase>();

        [SetUp]
        public void SetUp()
        {
            _mockRealDatabase.Setup(db => db.Users.Add(It.IsAny<UserModel>()));
            _mockRealDatabase.Setup(db => db.SaveChanges());
            _userRepository = new UserRepository(_mockRealDatabase.Object);
        }
        [Test]
        public async Task RegisterUser_Success()
        {
            // Arrange
            var userToRegister = new UserModel() { Id = Guid.NewGuid(), UserName = "Necika2221!", UserPassword = "pASSWROD12343" };

            // Act
            var registeredUser = await _userRepository.RegisterUser(userToRegister);

            // Assert
            Assert.That(registeredUser, Is.Not.Null);
            Assert.That(registeredUser.Id, Is.EqualTo(userToRegister.Id));
            Assert.That(registeredUser.UserName, Is.EqualTo(userToRegister.UserName));
            Assert.That(registeredUser.UserPassword, Is.EqualTo(userToRegister.UserPassword));
            _mockRealDatabase.Verify(db => db.Users.Add(It.IsAny<UserModel>()), Times.Once);
            _mockRealDatabase.Verify(db => db.SaveChanges(), Times.Once);
        }
    }
}
