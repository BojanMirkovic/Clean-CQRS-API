using Application.Queries.Dogs.GetDogById;
using Domain.Models.AnimalModel;
using FakeItEasy;
using Infrastructure.Repositories.Dogs;

namespace Test.DogTests.QueryTest
{
    [TestFixture]
    public class GetDogByIdTests
    {
        [Test]
        public async Task Handle_ValidId_ReturnCorrectDog()
        {
            var guid = Guid.NewGuid();

            var cat = new Dog { Name = "Rex", Breed = "Dzukela" };

            var dogRepository = A.Fake<IDogRepository>();

            var handler = new GetDogByIdQueryHandler(dogRepository);

            A.CallTo(() => dogRepository.GetDogById(guid)).Returns(cat);

            var command = new GetDogByIdQuery(guid);

            //Act

            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result, Is.TypeOf<Dog>());
            Assert.That(result.Name.Equals("Rex"));

        }

    }
}

