//using Application.Commands.Cats.DeleteCat;
//using Application.Commands.Users.DeleteUser;
//using Infrastructure.Database;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Test.UserTests.CommandTest
//{
//    public class DeleteUserByIdTest
//    {
//        private DeleteUserByIdCommandHandler _handler;
//        private MockDatabase _mockDatabase;

//        [SetUp]
//        public void SetUp()
//        {
//            // Initialize the handler and mock database before each test
//            _mockDatabase = new MockDatabase();
//            _handler = new DeleteUserByIdCommandHandler(_mockDatabase);
//        }
//        [Test]
//        public async Task Handle_DeleteUserFromDB_CorrectId_ResultIsNotNull()
//        {
//            // Arrange
//            var userId = new Guid("047425eb-15a5-4310-9d25-e281ab036869");
//            var query = new DeleteUserByIdCommand(userId);

//            // Act
//            var result = await _handler.Handle(query, CancellationToken.None);

//            // Assert
//            Assert.That(result, Is.Not.Null);
//        }
//        [Test]
//        public async Task Handle_DeleteUserById_IncorrectId_ResultIsNull()
//        {
//            //Arange
//            var catId = new Guid();

//            var query = new DeleteUserByIdCommand(catId);
//            //Act
//            var result = await _handler.Handle(query, CancellationToken.None);
//            //Assert
//            Assert.That(result, Is.Null);
//        }
//    }
//}
