using Application.Commands.Cats.DeleteCat;
using Domain.Models.AnimalModel;
using FakeItEasy;
using Infrastructure.Repositories.Cats;

namespace Test.CatTests.CommandTest
{
    [TestFixture]
    public class DeleteCatByIdTest
    {
        [Test]
        public async Task Handle_DeleteCat_Corect_Id()
        {
            //Arrange
            var cat = new Cat
            {
                AnimalId = Guid.NewGuid(),
                Name = "Tom",
                Breed = "Domestic Cat",
                Weight = 4,
                LikesToPlay = true
            };

            var catRepository = A.Fake<ICatRepository>();

            var handler = new DeleteCatByIdCommandHandler(catRepository);

            A.CallTo(() => catRepository.DeleteCat(cat.AnimalId)).Returns(cat);


            var command = new DeleteCatByIdCommand(cat.AnimalId);

            //Act
            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.Name.Equals("Tom"));
            Assert.That(result, Is.TypeOf<Cat>());
            Assert.That(result.AnimalId.Equals(cat.AnimalId));
            A.CallTo(() => catRepository.DeleteCat(cat.AnimalId)).MustHaveHappened(); // Verify that DeleteCat method was called with the correct ID
        }
    }
}



