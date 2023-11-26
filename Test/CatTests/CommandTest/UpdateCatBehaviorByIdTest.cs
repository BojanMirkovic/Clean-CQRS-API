using Application.Dtos;
using Infrastructure.Database;
using Application.Commands.Cats.UpdateCat.UpdateBehavior;


namespace Test.CatTests.CommandTest
{

    [TestFixture]
    internal class UpdateCatBehaviorByIdTest
    {
        private UpdateCatBehaviorByIdCommandHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _handler = new UpdateCatBehaviorByIdCommandHandler(_mockDatabase);
        }
        [Test]
        public async Task Handle_UpdateCatBehaviorById_ResultDB_BehaviorIsChanged()
        {
            // Arrange
            var catId = new Guid("12345678-1234-5678-1234-567812345680");

            CatDto updatedCat = new CatDto();
            updatedCat.LikesToPlay = true;
            var query = new UpdateCatBehaviorByIdCommand(updatedCat, catId);
            // Check if the database has been updated
            var catInDatabase = _mockDatabase.Cats.FirstOrDefault(cat => cat.Id == catId);
            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Id, Is.EqualTo(catId)); // make sure that we have updated corect cat
            Assert.That(result.LikesToPlay, Is.True); // check if behavior is updated
            Assert.NotNull(catInDatabase); // Ensure that cat with the given ID exists in the database
            Assert.That(catInDatabase.LikesToPlay, Is.EqualTo(updatedCat.LikesToPlay)); // Check if the behavior has been updated in the database
        }
    }
}

