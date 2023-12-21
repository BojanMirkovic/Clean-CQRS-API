//using Application.Commands.Birds.DeleteBird;
//using Infrastructure.Database;

//namespace Test.BirdTests.CommandTest
//{
//    [TestFixture]
//    public class DeleteBirdByIdTest
//    {
//        private DeleteBirdByIdCommandHandler _handler;
//        private MockDatabase _mockDatabase;

//        [SetUp]
//        public void SetUp()
//        {
//            // Initialize the handler and mock database before each test
//            _mockDatabase = new MockDatabase();
//            _handler = new DeleteBirdByIdCommandHandler(_mockDatabase);
//        }
//        [Test]
//        public async Task Handle_DeleteBirdFromDB_CorrectId_ResultIsNotNull()
//        {
//            // Arrange
//            var birdId = new Guid("12345678-1234-5678-1234-567812345682");

//            var query = new DeleteBirdByIdCommand(birdId);
//            // Act
//            var result = await _handler.Handle(query, CancellationToken.None);

//            // Assert
//            Assert.That(result, Is.Not.Null);
//        }
//        [Test]
//        public async Task Handle_DeleteBirdById_IncorrectId_ResultIsNull()
//        {
//            //Arange
//            var birdId = new Guid();

//            var query = new DeleteBirdByIdCommand(birdId);
//            //Act
//            var result = await _handler.Handle(query, CancellationToken.None);
//            //Assert
//            Assert.That(result, Is.Null);
//        }
//    }
//}

