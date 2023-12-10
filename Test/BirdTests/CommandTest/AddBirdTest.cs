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
            BirdDto newBird = new()
            {
                Name = "testBird",
                CanFly = true
            };

            var query = new AddBirdCommand(newBird);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(newBird.Name, Is.EqualTo(result.Name));
            Assert.That(newBird.CanFly, Is.EqualTo(result.CanFly));
        }
    }
}

