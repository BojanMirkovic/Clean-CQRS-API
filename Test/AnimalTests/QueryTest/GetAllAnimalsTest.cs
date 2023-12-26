
using Application.Queries.Animals.GetAllAnimals;
using Application.Queries.Birds.GetAllBirds;
using Domain.Models.AnimalModel;
using FakeItEasy;
using Infrastructure.Repositories.Animals;


namespace Test.AnimalTests.QueryTest
{
    [TestFixture]
    public class GetAllAnimalsTest
    {
        [Test]
        public async Task Handle_Get_All_Animals_ReturnListAvAnimals()
        {
            List<Animal> animals = new List<Animal>
            {
                new Bird{Name = "Vrabac", Color = "Brown", CanFly = true },
                new Bird{Name = "Penguin", Color = "Black and White", CanFly = false },
                new Dog {Name = "Ari", Breed = "English Pointer" , Weight = 27 },
                new Dog {Name = "Kity", Breed = "English Pointer" , Weight = 22 },
                new Cat {Name = "Tom", Breed = "Domestic Cat", Weight = 3, LikesToPlay = false},
                new Cat {Name = "Felix", Breed = "Domestic Cat", Weight = 4, LikesToPlay = true}
            };

            var animalRepository = A.Fake<IAnimalRepository>();

            var handler = new GetAllAnimalsQueryHandler(animalRepository);

            A.CallTo(() => animalRepository.GetAllAnimals()).Returns(animals);

            var command = new GetAllAnimalsQuery();

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result, Is.InstanceOf<List<Animal>>()); // result is a list of Animal objects
            Assert.That(result.Count, Is.EqualTo(animals.Count));
            CollectionAssert.AreEqual(animals, result);//compare both lists directly for equality
        }
    }
}
