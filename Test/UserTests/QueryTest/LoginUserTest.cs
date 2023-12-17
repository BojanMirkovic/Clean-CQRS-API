//using Infrastructure.Database;
//using Infrastructure.Authentication;
//using Application.Dtos;
//using Moq;
//using Application.Queries.Users.LoginUser;
//using Microsoft.Extensions.Configuration;
//using Nest;
//using Domain.Models.User;
//using System.Linq;

//namespace Test.UserTests.QueryTest
//{
//    namespace Test.UserTests.QueryTest
//    {
//        [TestFixture]
//        public class LoginUserTest
//        {
//            private MockDatabase _mockDatabase;
//            private LoginUserQueryHandler _handler;
//            private JWTtokenGenerator _jwtGenerator;

//            [SetUp]
//            public void SetUp()
//            {
//                // Initialize the mock database and other dependencies
//                _mockDatabase = new MockDatabase();
//                //mock IConfiguration
//                var mockConfiguration = new Mock<IConfiguration>();
//                mockConfiguration.Setup(x => x.GetSection("AppSetings").GetSection("Token").Value)
//                .Returns("mojTajniKljucZaJWTjeVelikoSranjeIliJaNeZnamDaKoristimJWT111111111111111111");

//                // Create a mock JWTtokenGenerator
//                _jwtGenerator = new JWTtokenGenerator(mockConfiguration.Object);

//                // Initialize the handler with the mock JWTtokenGenerator
//                _handler = new LoginUserQueryHandler(_mockDatabase, _jwtGenerator);

//            }
//            [Test]
//            public async Task Handle_WhenUserExists_ReturnsUserWithToken()
//            {
//                // Arrange
//                UserDto user = new()
//                {
//                    UserName = "Bojan",
//                    Password = "Bojan123",
//                };

//                var query = new LoginUserQuery(user);

//                // Act
//                var result = await _handler.Handle(query, CancellationToken.None);

//                // Assert
//                Assert.NotNull(result);

//            }
//            [Test]
//            public async Task Handle_WhenUserDoesNotExist_ThrowUnauthorizedAccessException()
//            {

//                UserDto userNotExist = new()
//                {
//                    UserName = "DontExist",
//                    Password = BCrypt.Net.BCrypt.HashPassword("Bojan123")
//                };

//                var query = new LoginUserQuery(userNotExist);

//                // Act and Assert
//                Assert.ThrowsAsync<UnauthorizedAccessException>(async () => await _handler.Handle(query, CancellationToken.None));
//            }
//        }
//    }
//}


