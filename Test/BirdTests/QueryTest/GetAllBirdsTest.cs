using Application.Queries.Birds.GetAllBirds;
using Application.Queries.Dogs.GetDogById;
using Domain.Models.AnimalModel;
using FakeItEasy;
using Infrastructure.Database;
using Infrastructure.Repositories.Birds;
using Infrastructure.Repositories.Dogs;

namespace Test.BirdTests.QueryTest
{
    [TestFixture]
    public class GetAllBirdsTest
    {
        [Test]
        public async Task Handle_Get_All_Birds_ReturnListAvBirds()
        {
            List<Bird> birds = new List<Bird>
            {
                new Bird { Name = "Vrabac", Color = "Brown", CanFly = true },
                new Bird { Name = "Penguin", Color = "Black and White", CanFly = false }
            };

            var birdRepository = A.Fake<IBirdRepository>();

            var handler = new GetAllBirdsQueryHandler(birdRepository);

            A.CallTo(() => birdRepository.GetAllBirds()).Returns(birds);

            var command = new GetAllBirdsQuery();

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result, Is.InstanceOf<List<Bird>>()); // result is a list of Bird objects
            Assert.That(result.Count, Is.EqualTo(birds.Count)); 
            CollectionAssert.AreEqual(birds, result);//compare both lists directly for equality
        }
    }
}


