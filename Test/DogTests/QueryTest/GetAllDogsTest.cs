//using Application.Queries.Dogs.GetAllDogs;
//using Infrastructure.Database;

//namespace Test.DogTests.QueryTest
//{
//    [TestFixture]
//    public class GetAllDogsTest
//    {
//        private GetAllDogsQueryHandler _handler;
//        private MockDatabase _mockDatabase;

//        [SetUp]
//        public void SetUp()
//        {
//            // Initialize the handler and mock database before each test
//            _mockDatabase = new MockDatabase();
//            _handler = new GetAllDogsQueryHandler(_mockDatabase);
//        }
//        [Test]
//        public async Task Handle_GetAllDogsFromDB_ReturnsResultIsEqualToDB()
//        {
//            // Arrange
//            var allDogsFromMockDB = _mockDatabase.Dogs;
//            var query = new GetAllDogsQuery();

//            // Act
//            var result = await _handler.Handle(query, CancellationToken.None);

//            // Assert
//            Assert.That(result, Is.EqualTo(allDogsFromMockDB));
//        }

//        [Test]
//        public async Task Handle_EmptyDB_ReturnsNull()
//        {
//            // Arrange
//            _mockDatabase.Dogs = null!;


//            var query = new GetAllDogsQuery();

//            // Act
//            var result = await _handler.Handle(query, CancellationToken.None);

//            // Assert
//            Assert.IsNull(result);
//        }
//    }
//}
