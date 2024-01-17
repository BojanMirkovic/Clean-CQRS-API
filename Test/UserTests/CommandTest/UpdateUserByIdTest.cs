using Application.Commands.Dogs.UpdateDog;
using Application.Commands.Users.UpdateUser;
using Application.Dtos;
using Domain.Models.AnimalModel;
using Domain.Models.UserModel;
using FakeItEasy;
using Infrastructure.Repositories.Dogs;
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
                Username = "Ari",
                Password = "EnglishPointer",
                Role = "user"
            };

            var userDto = new UpdatingUserDto { UserName = "Max", Password = "Dzukela", Role = "admin" };

            var userRepository = A.Fake<IUserRepository>();

            var handler = new UpdateUserInfoByIdCommandHandler(userRepository);

            A.CallTo(() => userRepository.GetUserById(user.UserId)).Returns(user);

            A.CallTo(() => userRepository.UpdateUser(user)).Returns(user);

            var command = new UpdateUserInfoByIdCommand(userDto, guid);

            //Act

            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.UserId, Is.EqualTo(guid));
            Assert.That(result.Username.Equals("Max"));
            Assert.That(result.Role.Equals("admin"));

            Assert.That(result, Is.TypeOf<User>());
        }

    }
}

