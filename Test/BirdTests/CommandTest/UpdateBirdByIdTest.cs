using Application.Commands.Birds.UpdateBird;
using Application.Dtos;
using Infrastructure.Database;

namespace Test.BirdTests.CommandTest
{
    [TestFixture]
    public class UpdateBirdByIdTest
    {
        private UpdateBirdInfoByIdCommandHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _handler = new UpdateBirdInfoByIdCommandHandler(_mockDatabase);
        }
        [Test]
        public async Task Handle_UpdateBirdInfoById_ResultDB_ElementHasNewNameNewBehavior()
        {
            // Arrange
            var birdId = new Guid("12345678-1234-5678-1234-567812345682");

            BirdDto updatedBird = new BirdDto();
            updatedBird.Name = "SokoSivi";
            updatedBird.CanFly = true;
            var query = new UpdateBirdInfoByIdCommand(updatedBird, birdId);
            // Check if the database has been updated
            var birdInDatabase = _mockDatabase.Birds.FirstOrDefault(bird => bird.Id == birdId);
            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Id, Is.EqualTo(birdId));
            Assert.NotNull(birdInDatabase); // Ensure the bird with the given ID exists in the database
            Assert.That(result.CanFly, Is.True); // check if behavior is updated
            Assert.That(birdInDatabase.Name, Is.EqualTo(updatedBird.Name)); // Check if the name has been updated in the database
            Assert.That(birdInDatabase.CanFly, Is.EqualTo(updatedBird.CanFly)); // Check if the behavior has been updated in the database
        }
    }
}

