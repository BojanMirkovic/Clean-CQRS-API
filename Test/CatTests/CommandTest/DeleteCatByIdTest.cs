using Application.Commands.Cats.DeleteCat;
using Domain.Models.Animal;
using Infrastructure.Database;

namespace Test.CatTests.CommandTest
{
    [TestFixture]
    public class DeleteCatByIdTest
    {
        private DeleteCatByIdCommandHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _handler = new DeleteCatByIdCommandHandler(_mockDatabase);
        }
        [Test]
        public async Task Handle_DeleteCatFromDB_ResultDB_HasOneElementLess()
        {
            // Arrange
            List<Cat> allCatsFromMockDB = _mockDatabase.Cats;
            int newListCount = allCatsFromMockDB.Count - 1;

            var catId = new Guid("12345678-1234-5678-1234-567812345680");

            var query = new DeleteCatByIdCommand(catId);
            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            Cat catToDelete = allCatsFromMockDB.FirstOrDefault(cat => cat.Id == catId)!;
            // with help of Contains() method check if element exist in the list
            bool DeletedCatIsPresent = allCatsFromMockDB.Contains(catToDelete);

            // Assert
            Assert.That(allCatsFromMockDB.Count, Is.EqualTo(newListCount));
            Assert.That(DeletedCatIsPresent, Is.False);
        }
    }

}

