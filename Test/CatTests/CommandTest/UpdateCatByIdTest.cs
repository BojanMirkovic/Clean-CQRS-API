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
            updatedCat.Breed = "Domestic Cat";
            updatedCat.Weight = 2;
            var query = new UpdateCatInfoByIdCommand(updatedCat, catId);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.AnimalId, Is.EqualTo(catId));
            Assert.That(result.LikesToPlay, Is.True); // check if behavior is updated
            Assert.That(result.Name, Is.EqualTo(updatedCat.Name)); // Check if the name has been updated 
            Assert.That(result.LikesToPlay, Is.EqualTo(updatedCat.LikesToPlay)); // Check if the behavior has been updated 
        }
        [Test]
        public async Task Handle_UpdateCatById_IncorrectId_ResultIsNull()
        {
            //Arange
            CatDto updatedCat = new CatDto();
            var nonExistingCatId = new Guid();

            var query = new UpdateCatInfoByIdCommand(updatedCat, nonExistingCatId);
            //Act
            var result = await _handler.Handle(query, CancellationToken.None);
            //Assert
            Assert.Null(result);
        }
    }

}

