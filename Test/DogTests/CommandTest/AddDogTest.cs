using Infrastructure.Database;
using Application.Commands.Dogs.AddDog;
using Application.Dtos;

namespace Test.DogTests.CommandTest
{
    [TestFixture]
    public class AddDogTest
    {
        private AddDogCommandHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _handler = new AddDogCommandHandler(_mockDatabase);
        }
        [Test]
        public async Task Handle_AddNewDogToDB_ResultDB_HasNewElement()
        {
            // Arrange
            DogDto newDog = new()
            {
                Name = "testDog"
            };

            var query = new AddDogCommand(newDog);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(newDog.Name, Is.EqualTo(result.Name));
            Assert.IsNotNull(result);
        }
    }
}
