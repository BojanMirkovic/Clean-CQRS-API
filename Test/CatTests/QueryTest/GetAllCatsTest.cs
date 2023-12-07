using Application.Queries.Cats.GetAllCats;
using Infrastructure.Database;

namespace Test.CatTests.QueryTest
{
    [TestFixture]
    public class GetAllCatsTest
    {
        private GetAllCatsQueryHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _handler = new GetAllCatsQueryHandler(_mockDatabase);
        }
        [Test]
        public async Task Handle_GetAllCatsFromDB_ReturnsResultIsEqualToCatsDB()
        {
            // Arrange
            var allCatsFromMockDB = _mockDatabase.Cats;
            var query = new GetAllCatsQuery();

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.EqualTo(allCatsFromMockDB));
        }
        [Test]
        public async Task Handle_EmptyDB_ReturnsNull()
        {
            // Arrange
            _mockDatabase.Cats = null!;

            var query = new GetAllCatsQuery();

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsNull(result);
        }
    }
}

