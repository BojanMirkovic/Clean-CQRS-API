//using Application.Commands.Birds.UpdateBird;
//using Application.Dtos;
//using Infrastructure.Database;

//namespace Test.BirdTests.CommandTest
//{
//    [TestFixture]
//    public class UpdateBirdByIdTest
//    {
//        private UpdateBirdInfoByIdCommandHandler _handler;
//        private MockDatabase _mockDatabase;

//        [SetUp]
//        public void SetUp()
//        {
//            // Initialize the handler and mock database before each test
//            _mockDatabase = new MockDatabase();
//            _handler = new UpdateBirdInfoByIdCommandHandler(_mockDatabase);
//        }
//        [Test]
//        public async Task Handle_UpdateBirdInfoById_ResultDB_ElementHasNewNameNewBehavior()
//        {
//            // Arrange
//            var birdId = new Guid("12345680-1224-5878-1234-667812345690");

//            BirdDto updatedBird = new BirdDto();
//            updatedBird.Name = "SokoSivi";
//            updatedBird.Color = "Grey";
//            updatedBird.CanFly = true;
//            var query = new UpdateBirdInfoByIdCommand(updatedBird, birdId);

//            // Act
//            var result = await _handler.Handle(query, CancellationToken.None);

//            // Assert
//            Assert.NotNull(result);
//            Assert.That(result.AnimalId, Is.EqualTo(birdId));
//            Assert.That(result.Name, Is.EqualTo(updatedBird.Name)); // Check if the name has been updated 
//            Assert.That(result.CanFly, Is.EqualTo(updatedBird.CanFly)); // Check if the behavior has been updated 
//        }
//        [Test]
//        public async Task Handle_UpdateBirdById_IncorrectId_ResultIsNull()
//        {
//            //Arange
//            BirdDto updatedBird = new BirdDto();
//            updatedBird.Name = "SokoSivi";
//            updatedBird.Color = "Grey";
//            updatedBird.CanFly = true;
//            var nonExistingBirdId = new Guid();

//            var query = new UpdateBirdInfoByIdCommand(updatedBird, nonExistingBirdId);
//            //Act
//            var result = await _handler.Handle(query, CancellationToken.None);
//            //Assert
//            Assert.Null(result);

//        }
//    }
//}

