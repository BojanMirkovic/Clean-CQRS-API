using Application.Dtos;
using Application.Queries.Users.LoginUser;
using FakeItEasy;
using Infrastructure.Repositories.Users;

namespace Test.UserTests.QueryTest
{
    namespace Test.UserTests.QueryTest
    {
        [TestFixture]
        public class LoginUserTest
        {
            [Test]
            public async Task Handle_ValidUser_ReturnsToken()
            {
                // Arrange
                var fakeUserRepository = A.Fake<IUserRepository>();
                var loginQuery = new LoginUserQuery(new UserDto { UserName = "username", Password = "password" });
                var expectedToken = "fakeToken";

                // Mock the behavior of the repository method to return a token
                A.CallTo(() => fakeUserRepository.GetsTokenToLogin(A<string>._, A<string>._))
                    .WithAnyArguments()
                    .Returns(expectedToken);

                var handler = new LoginUserQueryHandler(fakeUserRepository);

                // Act
                var result = await handler.Handle(loginQuery, CancellationToken.None);

                // Assert
                Assert.That(result, Is.EqualTo(expectedToken));
            }

            [Test]
            public async Task Handle_InvalidUser_ReturnsNull()
            {
                // Arrange
                var fakeUserRepository = A.Fake<IUserRepository>();
                var loginQuery = new LoginUserQuery(new UserDto { UserName = "invalid_username", Password = "invalid_password" });

                // Mock the behavior of the repository method to return null for invalid user
                A.CallTo(() => fakeUserRepository.GetsTokenToLogin(A<string>._, A<string>._))
                    .WithAnyArguments()
                    .Returns(await Task.FromResult<string>(result: null!)); // Return null for an invalid user

                var handler = new LoginUserQueryHandler(fakeUserRepository); // Replace with your actual class name

                // Act
                var result = await handler.Handle(loginQuery, CancellationToken.None);

                // Assert
                Assert.IsNull(result);
            }
        }
    }
}


