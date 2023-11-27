using Application.Queries.Birds.GetAllBirds;
using Infrastructure.Database;

namespace Test.BirdTests.QueryTest
{
    [TestFixture]
    public class GetAllBirdsTest
    {
        private GetAllBirdsQueryHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _handler = new GetAllBirdsQueryHandler(_mockDatabase);
        }
        [Test]
        public async Task Handle_GetAllBirdsFromDB_ReturnsResultIsEqualToBirdsDB()
        {
            // Arrange
            var allBirdsFromMockDB = _mockDatabase.Birds;
            var query = new GetAllBirdsQuery();

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.EqualTo(allBirdsFromMockDB));
        }
        [Test]
        public async Task Handle_EmptyDB_ReturnsNull()
        {
            // Arrange
            _mockDatabase.Birds = null;

            var query = new GetAllBirdsQuery();

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsNull(result);
        }
    }
}


