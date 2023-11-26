using Application.Commands.Cats.UpdateCat.UpdateName;
using Application.Dtos;
using Infrastructure.Database;

namespace Test.CatTests.CommandTest
{
    [TestFixture]
    internal class UpdateCatNameByIdTest
    {
        private UpdateCatNameByIdCommandHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _handler = new UpdateCatNameByIdCommandHandler(_mockDatabase);
        }
        [Test]
        public async Task Handle_UpdateCatNameById_ResultDB_ElementHasNewName()
        {
            // Arrange
            var catId = new Guid("12345678-1234-5678-1234-567812345680");

            CatDto updatedCat = new CatDto();
            updatedCat.Name = "MikaMacor";
            var query = new UpdateCatNameByIdCommand(updatedCat, catId);
            // Check if the database has been updated
            var catInDatabase = _mockDatabase.Cats.FirstOrDefault(cat => cat.Id == catId);
            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Id, Is.EqualTo(catId));
            Assert.NotNull(catInDatabase); // Ensure the dog with the given ID exists in the database
            Assert.That(catInDatabase.Name, Is.EqualTo(updatedCat.Name)); // Check if the name has been updated in the database
        }
    }
}

