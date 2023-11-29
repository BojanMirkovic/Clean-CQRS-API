using Application.Commands.Birds.DeleteBird;
using Domain.Models.Animal;
using Infrastructure.Database;

namespace Test.BirdTests.CommandTest
{
    [TestFixture]
    public class DeleteBirdByIdTest
    {
        private DeleteBirdByIdCommandHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _handler = new DeleteBirdByIdCommandHandler(_mockDatabase);
        }
        [Test]
        public async Task Handle_DeleteBirdFromDB_ResultDB_HasOneElementLess()
        {
            // Arrange
            List<Bird> allBirdsFromMockDB = _mockDatabase.Birds;
            int newListCount = allBirdsFromMockDB.Count - 1;

            var birdId = new Guid("12345678-1234-5678-1234-567812345682");

            var query = new DeleteBirdByIdCommand(birdId);
            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            Bird birdToDelete = allBirdsFromMockDB.FirstOrDefault(bird => bird.Id == birdId)!;
            // with help of Contains() method check if element exist in the list
            bool DeletedBirdIsPresent = allBirdsFromMockDB.Contains(birdToDelete);

            // Assert
            Assert.That(allBirdsFromMockDB.Count, Is.EqualTo(newListCount));
            Assert.That(DeletedBirdIsPresent, Is.False);
        }
    }
}

