using Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Commands.Dogs.AddDog;
using Application.Queries.Dogs.GetAllDogs;
using Domain.Models.Animal;
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
            List<Dog> allDogsFromMockDB = _mockDatabase.Dogs;
            int newListCount = allDogsFromMockDB.Count + 1;
            DogDto newDog = new() 
            {
                Name="testDog"
            };

            var query = new AddDogCommand(newDog);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);
            // Check if the dog with the specified name exists in the mock database
            bool dogExistsInDatabase = allDogsFromMockDB.Any(dog => dog.Name == "testDog");


            // Assert
            Assert.That(allDogsFromMockDB.Count, Is.EqualTo(newListCount));
            Assert.That(dogExistsInDatabase, Is.True);
        }
    }
}
