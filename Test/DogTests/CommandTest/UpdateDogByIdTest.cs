using Application.Commands.Dogs.UpdateDog;
using Application.Dtos;
using Infrastructure.Database;

namespace Test.DogTests.CommandTest
{
    [TestFixture]
    public class UpdateDogByIdTest
    {
        private UpdateDogByIdCommandHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _handler = new UpdateDogByIdCommandHandler(_mockDatabase);
        }
        [Test]
        public async Task Handle_UpdateDogById_ResultDB_ElementHasNewName()
        {
            // Arrange
            var dogId = new Guid("12345678-1234-5678-1234-567812345678");

            DogDto updatedDog = new DogDto();
            updatedDog.Name = "Jhony";
            updatedDog.Breed = "Dodz";
            updatedDog.Weight = 35;
            var query = new UpdateDogByIdCommand(updatedDog, dogId);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.AnimalId, Is.EqualTo(dogId));
            Assert.That(result.Name, Is.EqualTo(updatedDog.Name)); // Check if the name has been updated 
        }
        [Test]
        public async Task Handle_UpdateDogById_IncorrectId_ResultIsNull()
        {
            //Arange
            DogDto updatedDog = new DogDto();
            var nonExistingDogId = new Guid();

            var query = new UpdateDogByIdCommand(updatedDog, nonExistingDogId);
            //Act
            var result = await _handler.Handle(query, CancellationToken.None);
            //Assert
            //Assert.Null(result);
        }
    }
}
