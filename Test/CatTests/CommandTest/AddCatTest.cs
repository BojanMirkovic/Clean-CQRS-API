using Application.Commands.Cats.AddCat;
using Application.Dtos;
using Domain.Models.Animal;
using Infrastructure.Database;

namespace Test.CatTests.CommandTest
{
    public class AddCatTest
    {
        private AddCatCommandHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _handler = new AddCatCommandHandler(_mockDatabase);
        }
        [Test]
        public async Task Handle_AddNewCatToDB_ResultDB_HasNewElement()
        {
            // Arrange
            List<Cat> allCatsFromMockDB = _mockDatabase.Cats;
            int newListCount = allCatsFromMockDB.Count + 1;
            CatDto newCat = new()
            {
                Name = "testCat",
                LikesToPlay = true
            };

            var query = new AddCatCommand(newCat);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Check if the cat with the specified name exists in the mock database
            bool catExistsInDatabase = allCatsFromMockDB.Any(cat => cat.Name == "testCat");

            // Assert
            Assert.That(allCatsFromMockDB.Count, Is.EqualTo(newListCount));
            Assert.That(catExistsInDatabase, Is.True);
        }
    }
}

