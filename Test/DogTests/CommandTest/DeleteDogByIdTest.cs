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
        public async Task Handle_DeleteDogFromDB_ResultDB_HasOneElementLess()
        {
            // Arrange
            List<Dog> allDogsFromMockDB = _mockDatabase.Dogs;
            int newListCount = allDogsFromMockDB.Count - 1;

            var dogId = new Guid("12345678-1234-5678-1234-567812345678");

            var query = new DeleteDogByIdCommand(dogId);
            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            Dog dogToDelete = allDogsFromMockDB.FirstOrDefault(dog => dog.Id == dogId)!;
            // with Contains() method help check if element exist in the list
            bool DeletedDogIsPresent = allDogsFromMockDB.Contains(dogToDelete);

            // Assert
            Assert.That(allDogsFromMockDB.Count, Is.EqualTo(newListCount));
            Assert.That(DeletedDogIsPresent, Is.False);
        }
    }
}
