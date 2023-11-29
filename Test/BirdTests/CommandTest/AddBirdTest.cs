using Application.Commands.Birds.AddBird;
using Application.Dtos;
using Domain.Models.Animal;
using Infrastructure.Database;

namespace Test.BirdTests.CommandTest
{
    [TestFixture]
    public class AddBirdTest
    {
        private AddBirdCommandHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _handler = new AddBirdCommandHandler(_mockDatabase);
        }
        [Test]
        public async Task Handle_AddNewBirdToDB_ResultDB_HasNewElement()
        {
            // Arrange
            List<Bird> allBirdsFromMockDB = _mockDatabase.Birds;
            int newListCount = allBirdsFromMockDB.Count + 1;
            BirdDto newBird = new()
            {
                Name = "testBird",
                CanFly = true
            };

            var query = new AddBirdCommand(newBird);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Check if the bird with the specified name exists in the mock database
            bool birdExistsInDatabase = allBirdsFromMockDB.Any(bird => bird.Name == "testBird");

            // Assert
            Assert.That(allBirdsFromMockDB.Count, Is.EqualTo(newListCount));
            Assert.That(birdExistsInDatabase, Is.True);
        }
    }
}

