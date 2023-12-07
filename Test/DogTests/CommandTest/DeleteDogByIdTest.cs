using Application.Commands.Dogs.DeleteDog;
using Domain.Models.Animal;
using Infrastructure.Database;

namespace Test.DogTests.CommandTest
{
    [TestFixture]
    public class DeleteDogByIdTest
    {
        private DeleteDogByIdCommandHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _handler = new DeleteDogByIdCommandHandler(_mockDatabase);
        }
        [Test]
        public async Task Handle_DeleteDogById_CorrectId_ResultIsNotNull()
        {
            // Arrange
            var dogId = new Guid("12345678-1234-5678-1234-567812345678");
            var query = new DeleteDogByIdCommand(dogId);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
        }
        [Test]
        public async Task Handle_DeleteDogById_IncorrectId_ResultIsNull() 
        {
            //Arange
            var dogId = new Guid();

            var query = new DeleteDogByIdCommand(dogId);
            //Act
            var result = await _handler.Handle(query, CancellationToken.None);
            //Assert
            Assert.That(result, Is.Null);
        }
    }
}
