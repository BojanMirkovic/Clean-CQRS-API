using Application.Commands.Cats.AddCat;
using Application.Dtos;
using Infrastructure.Database;

namespace Test.CatTests.CommandTest
{
    [TestFixture]
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
            CatDto newCat = new()
            {
                Name = "testCat",
                LikesToPlay = true
            };

            var query = new AddCatCommand(newCat);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(newCat.Name, Is.EqualTo(result.Name));
            Assert.That(newCat.LikesToPlay, Is.EqualTo(result.LikesToPlay));

        }
    }
}

