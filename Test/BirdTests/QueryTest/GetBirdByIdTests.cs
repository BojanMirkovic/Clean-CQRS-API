using Application.Queries.Birds.GetBirdById;
using Domain.Models.AnimalModel;
using FakeItEasy;
using Infrastructure.Repositories.Birds;

namespace Test.BirdTests.QueryTest
{
    [TestFixture]
    public class GetBirdByIdTests
    {

        [Test]
        public async Task Handle_ValidId_ReturnCorrectBird()
        {
            var guid = Guid.NewGuid();

            var bird = new Bird { Name = "Vrabac", Color = "Sivi" };

            var birdRepository = A.Fake<IBirdRepository>();

            var handler = new GetBirdByIdQueryHandler(birdRepository);

            A.CallTo(() => birdRepository.GetBirdById(guid)).Returns(bird);

            var command = new GetBirdByIdQuery(guid);

            //Act
            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result, Is.TypeOf<Bird>());
            Assert.That(result.Name.Equals("Vrabac"));

        }
    }
}

