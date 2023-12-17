using Application.Commands.Users.RegisterNewUser;
using Application.Dtos;
using Infrastructure.Database;

namespace Test.UserTests.CommandTest
{
    [TestFixture]
    public class RegisterUserTest
    {
        private MockDatabase _mockDatabase;
        private RegisterUserCommandHandler _handler;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _handler = new RegisterUserCommandHandler(_mockDatabase);
        }
        [Test]
        public async Task Handle_RegisterUser_Success()
        {
            //Arange
            UserDto userToRegister = new()
            {
                UserName = "NewUserToCreate",
                Password = "Bojan123",
            };

            var query = new RegisterUserCommand(userToRegister);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Username, Is.EqualTo(userToRegister.UserName));
            Assert.IsTrue(BCrypt.Net.BCrypt.Verify(userToRegister.Password, result.Password));//Check if the hashed password in User object matches the original hash
        }
        [Test]
        public async Task Handle_RegisterUser_MissingUsername_ThrowsException()
        {
            // Arrange - missing username
            UserDto userToRegister = new()
            {
                UserName = "",
                Password = BCrypt.Net.BCrypt.HashPassword("Bojan123")
            };

            var query = new RegisterUserCommand(userToRegister);

            // Act & Assert: Ensure an exception is thrown when handling the command
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await _handler.Handle(query, CancellationToken.None);
            });
        }
        [Test]
        public async Task Handle_RegisterUser_MissingPassword_ThrowsException()
        {
            // Arrange: Creating a UserDto with missing password
            UserDto userToRegister = new()
            {
                UserName = "NewUserToCreate",
                Password = null!,
            };

            var query = new RegisterUserCommand(userToRegister);

            // Act & Assert: Ensure an exception is thrown when handling the command
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await _handler.Handle(query, CancellationToken.None);
            });
        }
        [Test]
        public async Task Handle_RegisterUser_AddsUserToDatabase()
        {
            // Arrange: Create a UserDto for registration
            UserDto userToRegister = new()
            {
                UserName = "TestUser",
                Password = BCrypt.Net.BCrypt.HashPassword("TestPassword")
            };

            var query = new RegisterUserCommand(userToRegister);

            // Act: Register the user
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert: Check if the user is added to the database
            Assert.IsTrue(_mockDatabase.Users.Any(u => u.Id == result.Id));
        }



    }
}

