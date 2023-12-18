using Application.Commands.Cats.DeleteCat;
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
        public async Task Handle_DeleteCatFromDB_CorrectId_ResultIsNotNull()
        {
            // Arrange
            var catId = new Guid("12345678-1234-5678-1234-567812345680");
            var query = new DeleteCatByIdCommand(catId);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
        }
        [Test]
        public async Task Handle_DeleteCatById_IncorrectId_ResultIsNull()
        {
            //Arange
            var catId = new Guid();

            var query = new DeleteCatByIdCommand(catId);
            //Act
            var result = await _handler.Handle(query, CancellationToken.None);
            //Assert
            Assert.That(result, Is.Null);
        }
    }
}



