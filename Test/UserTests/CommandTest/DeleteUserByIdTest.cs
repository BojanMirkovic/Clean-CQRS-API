using Application.Commands.Birds.DeleteBird;
using Application.Commands.Cats.DeleteCat;
using Application.Commands.Users.DeleteUser;
using Azure.Identity;
using Domain.Models.AnimalModel;
using Domain.Models.UserModel;
using FakeItEasy;
using Infrastructure.Database;
using Infrastructure.Repositories.Birds;
using Infrastructure.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.UserTests.CommandTest
{
    public class DeleteUserByIdTest
    {

        [Test]
        public async Task Handle_DeleteUser_Corect_Id()
        {
            //Arrange
            var user = new User
            {
                UserId = Guid.NewGuid(),
                Username = "Test",
                Password = "Test12345"
            };

            var userRepository = A.Fake<IUserRepository>();

            var handler = new DeleteUserByIdCommandHandler(userRepository);

            A.CallTo(() => userRepository.DeleteUser(user.UserId)).Returns(user);

            var command = new DeleteUserByIdCommand(user.UserId);

            //Act
            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.Username.Equals("Test"));
            Assert.That(result, Is.TypeOf<User>());
            Assert.That(result.UserId.Equals(user.UserId));
            A.CallTo(() => userRepository.DeleteUser(user.UserId)).MustHaveHappened(); // Verify that DeleteUser method was called with the correct ID
        }

    }
}
