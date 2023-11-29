using Application.Commands.Cats.UpdateCat;
using Application.Dtos;
using Infrastructure.Database;

namespace Test.CatTests.CommandTest
{
    [TestFixture]
    internal class UpdateCatByIdTest
    {
        private UpdateCatInfoByIdCommandHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _handler = new UpdateCatInfoByIdCommandHandler(_mockDatabase);
        }
        [Test]
        public async Task Handle_UpdateCatInfoById_ResultDB_ElementHasNewNameNewBehavior()
        {
            // Arrange
            var catId = new Guid("12345678-1234-5678-1234-567812345680");

            CatDto updatedCat = new CatDto();
            updatedCat.Name = "MikaMacor";
            updatedCat.LikesToPlay = true;
            var query = new UpdateCatInfoByIdCommand(updatedCat, catId);
            // Check if the database has been updated
            var catInDatabase = _mockDatabase.Cats.FirstOrDefault(cat => cat.Id == catId);
            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Id, Is.EqualTo(catId));
            Assert.NotNull(catInDatabase); // Ensure the cat with the given ID exists in the database
            Assert.That(result.LikesToPlay, Is.True); // check if behavior is updated
            Assert.That(catInDatabase.Name, Is.EqualTo(updatedCat.Name)); // Check if the name has been updated in the database
            Assert.That(catInDatabase.LikesToPlay, Is.EqualTo(updatedCat.LikesToPlay)); // Check if the behavior has been updated in the database
        }
    }

}

