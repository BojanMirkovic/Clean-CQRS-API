using Application.Commands.Users.UpdateUser;
using Application.Dtos;
using Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.UserTests.CommandTest
{
    public class UpdateUserByIdTest
    {
        private UpdateUserInfoByIdCommandHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _handler = new UpdateUserInfoByIdCommandHandler(_mockDatabase);
        }
        [Test]
        public async Task Handle_UpdateUserInfoById_ResultDB_ElementHasNewName_Password_Role()
        {
            // Arrange
            var userId = new Guid("047425eb-15a5-4310-9d25-e281ab036868");

            UserUpdateDto updatedUser = new UserUpdateDto();
            updatedUser.UserName = "MikaTheUser";
            updatedUser.Password = BCrypt.Net.BCrypt.HashPassword("Bojan123");
            updatedUser.Role = "admin";

            var query = new UpdateUserInfoByIdCommand(updatedUser, userId);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.UserId, Is.EqualTo(userId));
            Assert.That(result.Username, Is.EqualTo(updatedUser.UserName)); // Check if the name has been updated 
            Assert.That(result.Role, Is.EqualTo(updatedUser.Role)); // Check if role has been updated 
        }
        [Test]
        public async Task Handle_UpdateUserById_IncorrectId_ResultIsNull()
        {
            //Arange
            UserUpdateDto updatedUser = new UserUpdateDto();
            var nonExistingUserId = new Guid();

            var query = new UpdateUserInfoByIdCommand(updatedUser, nonExistingUserId);
            //Act
            var result = await _handler.Handle(query, CancellationToken.None);
            //Assert
            Assert.Null(result);
        }
    }
}

