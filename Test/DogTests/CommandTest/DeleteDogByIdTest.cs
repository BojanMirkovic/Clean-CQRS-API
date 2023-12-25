using Application.Commands.Dogs.DeleteDog;
using Domain.Models.AnimalModel;
using FakeItEasy;
using Infrastructure.Repositories.Dogs;

namespace Test.DogTests.CommandTest
{
    [TestFixture]
    public class DeleteDogByIdTest
    {

        [Test]
        public async Task Handle_DeleteDog_Corect_Id()
        {
            //Arrange
            var dog = new Dog
            {
                AnimalId = Guid.NewGuid(),
                Name = "Astor",
                Breed = "CaneCorso",
                Weight = 38
            };

            var dogRepository = A.Fake<IDogRepository>();

            var handler = new DeleteDogByIdCommandHandler(dogRepository);

            A.CallTo(() => dogRepository.DeleteDog(dog.AnimalId)).Returns(dog);

            var command = new DeleteDogByIdCommand(dog.AnimalId);

            //Act
            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.Name.Equals("Astor"));
            Assert.That(result, Is.TypeOf<Dog>());
            Assert.That(result.AnimalId.Equals(dog.AnimalId));
            A.CallTo(() => dogRepository.DeleteDog(dog.AnimalId)).MustHaveHappened(); // Verify that DeleteDog method was called with the correct ID
        }

    }
}
