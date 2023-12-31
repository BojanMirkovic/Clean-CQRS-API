using Application.Commands.Cats.AddCat;
using Application.Commands.Cats.DeleteCat;
using Application.Commands.Dogs.DeleteDog;
using Domain.Models.AnimalModel;
using FakeItEasy;
using Infrastructure.Repositories.Cats;
using Microsoft.Extensions.Logging.Abstractions;

namespace Test.CatTests.CommandTest
{
    [TestFixture]
    public class DeleteCatByIdTest
    {
        [Test]
        public async Task Handle_DeleteCat_Corect_Id()
        {
            //Arrange
            Guid id = new Guid("158a07b7-27fe-4322-8a5e-4c0a38fc3bb0");
            var cat = new Cat
            {
                AnimalId = id,
                Name = "Tom",
                Breed = "Domestic Cat",
                Weight = 4,
                LikesToPlay = true
            };
            var catRepository = A.Fake<ICatRepository>();

            var logger = new NullLogger<DeleteCatByIdCommandHandler>();
            var handler = new DeleteCatByIdCommandHandler(catRepository, logger);

            A.CallTo(() => catRepository.DeleteCat(cat.AnimalId)).Returns(cat);

            var command = new DeleteCatByIdCommand(cat.AnimalId);

            //Act
            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.AnimalId, Is.EqualTo(id)); // Check if the returned cat's ID matches the deleted cat's ID
            Assert.That(result.Name.Equals("Tom"));
            Assert.That(result, Is.TypeOf<Cat>());
            Assert.That(result.AnimalId.Equals(cat.AnimalId));
            A.CallTo(() => catRepository.DeleteCat(cat.AnimalId)).MustHaveHappened(); // Verify that DeleteDog method was called with the correct ID
        }
    }
}



