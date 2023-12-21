using Application.Commands.Users.UpdateUser;
using Application.Dtos;
using Domain.Models.AnimalModel;
using Domain.Models.UserModel;
using FakeItEasy;
using Infrastructure.Repositories.Users;

namespace Test.UserTests.CommandTest
{
    public class UpdateUserByIdTest
    {
        [Test]
        public async Task Handle_Update_Correct_User_By_Id()
        {
            //Arrange
            var guid = new Guid("ce9b91e4-08d1-4628-82c1-8ef6ec623230");

            var user = new User
            {
                UserId = new Guid("ce9b91e4-08d1-4628-82c1-8ef6ec623230"),
                Username = "TestUser",
                Password = BCrypt.Net.BCrypt.HashPassword("TestUser123"),
                Role = "user"
            };

            var userForUpdatingDto = new UpdatingUserDto { UserName = "NewName" , Password = BCrypt.Net.BCrypt.HashPassword("NoviPassword"), Role ="admin"};

            var userRepository = A.Fake<IUserRepository>();

            var handler = new UpdateUserInfoByIdCommandHandler(userRepository);

            var expectedUser = new User
            {
                UserId = new Guid("ce9b91e4-08d1-4628-82c1-8ef6ec623230"),
                Username = userForUpdatingDto.UserName,
                Password = BCrypt.Net.BCrypt.HashPassword(userForUpdatingDto.Password),
                Role = userForUpdatingDto.Role
            };

            A.CallTo(() => userRepository.UpdateUser(A<User>.That.Matches(u => u.UserId == guid))).Returns(expectedUser);

            var command = new UpdateUserInfoByIdCommand(userForUpdatingDto, guid);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            //Assert.That(result.UserId, Is.EqualTo(expectedUser.UserId));
            //Assert.That(result.Username, Is.EqualTo(expectedUser.Username));
            //Assert.That(result.Role, Is.EqualTo(expectedUser.Role));
           
            Assert.That(result.Username.Equals("NewName"));
            Assert.That(result.Password.Equals("NoviPasword"));
            Assert.That(result.Role.Equals("admin"));
            Assert.That(result, Is.TypeOf<Dog>());

            // Verify password hashing
            Assert.IsTrue(BCrypt.Net.BCrypt.Verify(userForUpdatingDto.Password, result.Password));

            Assert.That(result, Is.TypeOf<User>());
        }

    }
}

