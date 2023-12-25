using Application.Queries.Dogs.GetAllDogs;
using Domain.Models.AnimalModel;
using FakeItEasy;
using Infrastructure.Repositories.Dogs;

namespace Test.DogTests.QueryTest
{
    [TestFixture]
    public class GetAllDogsTest
    {
        [Test]
        public async Task Handle_Get_All_Dogs_ReturnListAvDogs()
        {
            List<Dog> dogs = new List<Dog>
            {
                new Dog { Name = "Ari", Breed = "English Pointer" , Weight = 27 },
                new Dog { Name = "Kity", Breed = "English Pointer" , Weight = 22 }
            };

            var dogRepository = A.Fake<IDogRepository>();

            var handler = new GetAllDogsQueryHandler(dogRepository);

            A.CallTo(() => dogRepository.GetAllDogs()).Returns(dogs);

            var command = new GetAllDogsQuery();

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result, Is.InstanceOf<List<Dog>>()); // result is a list of Dog objects
            Assert.That(result.Count, Is.EqualTo(dogs.Count));
            CollectionAssert.AreEqual(dogs, result);//compare both lists directly for equality
        }
    }
}
