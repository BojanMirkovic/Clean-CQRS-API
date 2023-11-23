using Application.Commands.Dogs.UpdateDog;
using Application.Dtos;
using Application.Queries.Dogs.GetDogById;
using Domain.Models.Animal;
using Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DogTests.CommandTest
{
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
            var query = new UpdateDogByIdCommand(updatedDog, dogId);
            // Check if the database has been updated
            var dogInDatabase = _mockDatabase.Dogs.FirstOrDefault(dog => dog.Id == dogId);
            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Id, Is.EqualTo(dogId));
            Assert.NotNull(dogInDatabase); // Ensure the dog with the given ID exists in the database
            Assert.That(dogInDatabase.Name, Is.EqualTo(updatedDog.Name)); // Check if the name has been updated in the database
        }
    }
}
